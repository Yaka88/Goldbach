# Code Documentation

## Project Structure

### Main Files

- **Program.cs**: Entry point of the application, initializes Windows Forms
- **frmMain.cs**: Main form containing all the logic for Goldbach conjecture exploration
- **frmMain.Designer.cs**: Auto-generated UI layout and control definitions
- **frmMain.resx**: Resource file for the form
- **Goldbach.csproj**: Project configuration file

## Key Classes and Methods

### frmMain Class

The main form class that implements the Goldbach conjecture explorer functionality.

#### Properties and Fields

- `BitArray intPrimeCol`: Stores prime/composite status for numbers (false = prime, true = composite)
- `int intNoBase`: Current number base (6 for senary, 10 for decimal)

#### Core Methods

#### `ToSenary(int intNumber)`
Converts an integer to senary (base-6) representation.
- **Purpose**: Allows mathematical analysis in base-6 for pattern recognition
- **Usage**: Toggled via the "Senary" checkbox

#### `ParseSenary(string strNumber)`
Parses a senary string back to decimal integer.
- **Purpose**: Handles input when senary mode is enabled

#### `btnPrime_Click(object sender, EventArgs e)`
**Sieve of Eratosthenes Implementation**
- Generates all prime numbers up to the specified limit
- Uses optimized algorithm that only processes odd numbers
- Employs BitArray for memory-efficient storage
- Colors output: Red for primes, Black for composite numbers
- Measures and displays computation time

**Algorithm Details:**
1. Initialize BitArray with all values as false (potential primes)
2. Skip even numbers except 2 (implicit prime)
3. For each unmarked odd number i:
   - Mark it as prime (increment counter)
   - If i ≤ √n, mark all odd multiples of i as composite
4. Display results with color coding

#### `btnEven_Click(object sender, EventArgs e)`
**Prime Pair Analysis for All Even Numbers**
- Systematically analyzes all even numbers up to the limit
- Counts prime pairs for each even number (Goldbach pairs)
- Displays results in tabular format
- Calls `DecideExcludePP()` for exception analysis

**Algorithm:**
1. For each prime p in range [5, n/2]:
   - For each number q in range [p, n-p]:
     - If both p and q are prime, increment counter for p+q
2. Display count matrix for all even numbers

#### `btnPrimePair_Click(object sender, EventArgs e)`
**Specific Prime Pair Finding**
- Finds all ways to express a specific even number as sum of two primes
- Shows detailed breakdown with factorization
- Displays each valid prime pair (p₁ + p₂ = target)

#### `DecideExcludePP(ref int[] intEvenCol)`
**Exception Analysis** (例外pp数)
- Analyzes patterns in prime pair distributions
- Identifies numbers with unusual prime pair counts
- Uses mathematical progression analysis

#### `DecideSucceedPP()`
**Conjecture Verification** (PP对小质数 + intBase 仍可构成PP对)
- Tests if adding a base value to small primes still yields prime pairs
- Verifies Goldbach conjecture compliance across the range
- Returns success/failure status

#### `IsSucceed(int intEven, int intBase)`
**Individual Number Verification**
- Checks if a specific even number satisfies Goldbach conjecture
- Tests if small prime + base offset maintains prime pair property

## Mathematical Concepts

### Goldbach Conjecture
Every even integer greater than 2 can be expressed as the sum of two primes.

### Sieve of Eratosthenes
Ancient algorithm for finding prime numbers:
1. List all numbers from 2 to n
2. Start with smallest unmarked number (prime)
3. Mark all multiples as composite
4. Repeat until √n reached

### Prime Pairs
Two primes p₁ and p₂ such that p₁ + p₂ = even number.

### Senary (Base-6) System
- Uses digits 0, 1, 2, 3, 4, 5
- Useful for mathematical pattern analysis
- Some number theory patterns are clearer in base-6

## UI Controls

### Input Controls
- **txtNumber**: Even number input (supports both decimal and senary)
- **checkBox1**: Toggle between decimal and senary display

### Action Buttons
- **btnPrime**: Generate prime collection using Sieve of Eratosthenes
- **btnEven**: Analyze prime pairs for all even numbers
- **btnPrimePair**: Find specific prime pairs for entered number
- **btnDecide**: Verify Goldbach conjecture compliance

### Display Controls
- **richTextPrime**: Shows generated primes with color coding
- **richTextPrimePair**: Shows prime pair analysis results
- **txtCount**: Displays count of primes found
- **txtTime**: Shows computation time in milliseconds
- **txtEvenCount**: Shows analysis results (pair counts or exceptions)

## Performance Optimizations

1. **BitArray Usage**: Memory-efficient storage (1 bit per number vs 32 bits for bool array)
2. **Odd-Only Processing**: Skips even numbers in sieve (except 2)
3. **Square Root Limit**: Only sieves up to √n
4. **Display Limiting**: Limits output to first 255 results for performance
5. **Step Optimization**: Uses 2*i steps to skip even multiples

## Educational Applications

1. **Number Theory Study**: Visualize prime distributions and patterns
2. **Algorithm Analysis**: Understand sieve algorithms and optimization
3. **Conjecture Testing**: Empirically verify mathematical conjectures
4. **Base Conversion**: Learn different number systems
5. **Computer Science**: Study efficient data structures and algorithms

## Chinese Text Translations

- 应用程序的主入口点 = "Main entry point of the application"
- 必需的设计器变量 = "Required designer variable"
- 清理所有正在使用的资源 = "Clean up any resources being used"
- Windows 窗体设计器生成的代码 = "Windows Form Designer generated code"
- 设计器支持所需的方法 = "Required method for Designer support"
- 例外pp数 = "Exception prime pair numbers"
- PP对小质数 + intBase 仍可构成PP对 = "PP pairs: small prime + intBase can still form PP pairs"