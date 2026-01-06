# Goldbach Conjecture Exploration

A collection of tools for exploring the Goldbach conjecture through numerical computation, desktop visualization, and spectral analysis.

## Project Overview

This repository contains two main components:
1.  **Goldbach (C# WinForms)**: A .NET 8 desktop application that provides interactive tools to find primes and count Goldbach pairs (the number of ways an even integer can be expressed as a sum of two primes).
2.  **Spectral Analysis (Python)**: A script that uses the Circle Method approach to analyze the distribution of primes and prime pairs through exponential sums, FFT, and numerical integration.

## Features

### C# Desktop Application
-   **Prime Sieve**: Efficiently finds primes up to a specified limit.
-   **Goldbach Pair Counting**: Calculates the number of prime pairs for even integers.
-   **Senary Support**: includes a unique feature to display and parse numbers in **Senary (Base 6)**. This is mathematically relevant as all primes greater than 3 can be expressed as 6n ± 1.
-   **Performance Metrics**: Real-time measurement of calculation time.

### Python Visualization (`plot_S_alpha.py`)
-   **Spectral Sums**: Computes the exponential sum S(α) for primes up to N.
-   **FFT Convolution**: Uses Fast Fourier Transform for fast counting of prime pairs.
-   **Analytical Plotting**: Visualizes the real parts of the sums and compares FFT results with numerical integration results.
-   **Major Arcs**: Supports marking major arcs at rational points (a / q).

## Requirements

### Windows Application
-   .NET 8.0 SDK or Runtime (Windows)

### Python Tools
-   Python 3.x
-   NumPy
-   Matplotlib
-   SciPy

## License

This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.
