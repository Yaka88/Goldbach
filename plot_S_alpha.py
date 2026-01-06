#!/usr/bin/env python3
"""
二素数有序计数（三个图并列一行）：
  - 左：Re( [S(α)]^2 e^{-2π i α N_Max} ) (F(α) 实部)
  - 中：A_fft(N) 由 FFT 卷积直接计算（有序对计数）
  - 右：A_integral(N) 由数值积分 (quad) 得到的有序计数（四舍五入）

主弧以既约分数 a/q (q <= q0) 的竖线标注。
"""
import time
from math import gcd, ceil, log2
import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import quad
import concurrent.futures

# ========== 可调参数（统一变量 VAR） ==========
base = 3            #2 表示二元和，3 表示三元和（不包含素数2）
step = 2           # 步长
N_max = 400           # 最大 N
alpha_points = 1000  # alpha 采样点数（用于画 F(α)）
q0 = 6               # 主弧分母上界（标注 a/q, q<=q0）

# quad 配置
quad_limit = 2000
quad_epsabs = 1e-8
quad_epsrel = 1e-6

# ========== 基本设置 ==========
if (N_max+base) % 2 != 0:
    N_max -= 1

# ========== 素数筛 ==========
def sieve_primes(n):
    if n < 2:
        return np.array([], dtype=int)
    sieve = np.ones(n+1, dtype=bool)
    sieve[:2] = False
    for i in range(2, int(n**0.5) + 1):
        if sieve[i]:
            sieve[i*i:n+1:i] = False
    return np.nonzero(sieve)[0]

primes = sieve_primes(N_max)
#primes = primes[primes != 2]  # 排除素数2
# ==== 新增：构造 von Mangoldt 权重 λ(n)（n<=N_max） ====
lam = np.zeros(N_max + 1, dtype=float)
for p in primes:
    power = p
    while power <= N_max:
        lam[power] = np.log(p)
        power *= p
lam_idx = np.nonzero(lam)[0]
lam_vals = lam[lam_idx]
# ========== alpha网格与F(α) ==========
alphas = np.linspace(0, 1, alpha_points, endpoint=False)
F_real = np.empty_like(alphas, dtype=float)
F_lambda_real = np.empty_like(alphas, dtype=float)   # 新增数组
for i, alpha in enumerate(alphas):
    S = np.sum(np.exp(2j * np.pi * primes * alpha))
    F_real[i] = (S**base * np.exp(-2j * np.pi * alpha * N_max)).real
    # 用 von Mangoldt 权重计算 F_Λ(α)
    S_lambda = np.sum(lam_vals * np.exp(2j * np.pi * lam_idx * alpha))
    F_lambda_real[i] = (S_lambda**base * np.exp(-2j * np.pi * alpha * N_max)).real
# ========== 主弧中心 ==========
major_centers = []
for q in range(1, q0 + 1):
    for a in range(q):
        if gcd(a, q) == 1:
            major_centers.append((a, q, a / q))
major_centers = sorted(set(major_centers), key=lambda t: t[2])

# ========== 积分函数 ==========
def S_alpha(alpha):
    return np.sum(np.exp(2j * np.pi * primes * alpha))

def F_alpha_real(alpha, N):
    S = S_alpha(alpha)
    return (S**base * np.exp(-2j * np.pi * alpha * N)).real

# ========== 有序对计数：quad ==========
N_values = np.arange(3*base, N_max + 1, step)  # 从 3*base 开始，步长 step
A_integral = []
print(f"N_max={N_max}, computing integral for N in [{3*base}, {N_max}] ...")

def compute_integral(N):    
    try:
        res, err = quad(F_alpha_real, 0.0, 1.0, args=(N,), limit=quad_limit, epsabs=quad_epsabs, epsrel=quad_epsrel)
        A_int = int(np.rint(res)) if not np.isnan(res) else 0
        print(f"R{base}({N})\t:{A_int}")
        return A_int
    except Exception as e:
        print(f"quad failed for N={N}: {e}")
        return 0

start_time = time.time()
with concurrent.futures.ProcessPoolExecutor() as executor:
    A_integral = list(executor.map(compute_integral, N_values))


end_time = time.time()
print(f"done in {end_time - start_time:.2f}s")

# ========== FFT卷积（有序计数） ==========
max_sum = base * N_max
L = max_sum + 1
nfft = 1 << int(ceil(log2(L)))
f = np.zeros(nfft, dtype=float)
f[primes] = 1.0

Ff = np.fft.fft(f)
conv = np.fft.ifft(Ff ** base).real
A_fft = np.rint(conv[:L]).astype(np.int64)
A_fft_list = [int(A_fft[N]) if N < len(A_fft) else 0 for N in N_values]
# ========== 输出对比表格（逐 N 打印差异） ==========
#print("\nN\tFFT_ordered\tintegral_ordered\tdiff")
#for N, a_fft, a_int in zip(N_values, A_fft_list, A_integral):
#    print(f"{N}\t{a_fft}\t{a_int}\t{a_int - a_fft}")
# ========== 三图并列 ==========
plt.rcParams['font.sans-serif'] = ['Noto Sans CJK JP', 'Arial']
plt.rcParams['axes.unicode_minus'] = False
fig = plt.figure(figsize=(18, 10))
gs = fig.add_gridspec(2, 2, height_ratios=[1.1, 1])
ax0 = fig.add_subplot(gs[0, 0])    # 第一行左：F(α)
ax0_lambda = fig.add_subplot(gs[0, 1])    # 第一行右：F_Λ(α)
ax1 = fig.add_subplot(gs[1, 0])    # 第二行左
ax2 = fig.add_subplot(gs[1, 1])    # 第二行右

# 上左：F(α) 实部
ax0.plot(alphas, F_real, color='tab:blue', linewidth=1.5)
ax0.set_xlabel(r'$\alpha$')
ax0.set_ylabel('Re $F(\\alpha)$')
ax0.set_title(fr'Re $([S(\alpha)]^{base} e^{{-2\pi i \alpha N}})$ (primes), N={N_max}, Base={base}')
for a, q, c in major_centers:
    ax0.axvline(c, color='red', alpha=0.6, linewidth=0.8)
    ax0.text(c, np.max(F_real) * 0.9, f'{a}/{q}', ha='center', va='top', rotation=90, color='red', fontsize=8)
ax0.grid(alpha=0.3)

# 上右：F_Λ(α) 实部
ax0_lambda.plot(alphas, F_lambda_real, color='orange', linewidth=1.5)
ax0_lambda.set_xlabel(r'$\alpha$')
ax0_lambda.set_ylabel('Re $F_Λ(\\alpha)$')
ax0_lambda.set_title(fr'Re $([S_Λ(\alpha)]^{base} e^{{-2\pi i \alpha N}})$ (von Mangoldt), N={N_max}, Base={base}')
for a, q, c in major_centers:
    ax0_lambda.axvline(c, color='red', alpha=0.6, linewidth=0.8)
    ax0_lambda.text(c, np.max(F_lambda_real) * 0.9, f'{a}/{q}', ha='center', va='top', rotation=90, color='red', fontsize=8)
ax0_lambda.grid(alpha=0.3)
# 下左：FFT卷积计数
ax1.plot(N_values, A_fft_list, '^-', color='teal', label='FFT ordered A(N)')
ax1.set_xlabel(f'N Base={base}')
ax1.set_ylabel(r'$A(N)$ (ordered)')
ax1.set_title('A(N) by FFT convolution (ordered)')
ax1.grid(alpha=0.3)
ax1.legend()

# 下右：quad积分计数
ax2.plot(N_values, A_integral, 'o-', color='purple', label='integral (quad) ordered')
ax2.set_xlabel(f'N Base={base}')
ax2.set_ylabel(r'$A(N)$ (ordered)')
ax2.set_title('A(N) from integral (quad, rounded)')
ax2.grid(alpha=0.3)
ax2.legend()

plt.tight_layout()
plt.show()

