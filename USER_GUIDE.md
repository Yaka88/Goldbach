# User Guide for Goldbach Conjecture Explorer

## Getting Started

### Prerequisites
- Windows operating system
- .NET 8.0 runtime or later
- Visual Studio 2022 or later (for compilation)

### Building the Application
1. Open the project in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

## Step-by-Step Usage Guide

### 1. Basic Prime Generation

**Objective**: Generate and visualize prime numbers up to a limit.

**Steps**:
1. Enter a number in the "Even:" field (e.g., `1000`)
2. Click the **"Prime Collection"** button
3. Observe the results:
   - Left panel: Shows all numbers with primes in red, composite in black
   - Count field: Shows total number of primes found
   - Time field: Shows computation time in milliseconds

**What you'll see**:
- Numbers displayed in grid format
- Prime numbers highlighted in red
- Composite numbers in black
- Timing information for performance analysis

### 2. Goldbach Conjecture Verification

**Objective**: Test the Goldbach conjecture for all even numbers in a range.

**Steps**:
1. Enter an upper limit (e.g., `100`)
2. Click **"Prime Collection"** first to generate the prime numbers
3. Click **"Even Collection"** to analyze all even numbers
4. Review the results in the right panel

**What you'll see**:
- A grid showing prime pair counts for each even number
- Pattern analysis of how many ways each even number can be expressed as sum of two primes
- Exception analysis results

### 3. Specific Prime Pair Analysis

**Objective**: Find all ways to express a specific even number as sum of two primes.

**Steps**:
1. Enter a specific even number (e.g., `24`)
2. Click **"Prime Collection"** to generate primes up to that number
3. Click **"Prime Pair"** to find all valid combinations
4. Examine the detailed results

**What you'll see**:
- All valid prime pairs that sum to your target number
- Example for 24: `24 = 5+19 = 7+17 = 11+13`
- Factorization information
- Count of total prime pairs found

### 4. Advanced Features

#### Number Base Conversion
- Check the **"Senary"** checkbox to switch to base-6 (senary) display
- This can reveal mathematical patterns not visible in decimal
- All input and output will use base-6 notation

#### Conjecture Testing
- Click **"Decide"** to test conjecture compliance
- This performs advanced mathematical analysis
- Results show whether any exceptions are found in the range

## Understanding the Output

### Prime Collection Display
- **Red numbers**: Prime numbers
- **Black numbers**: Composite numbers
- **Grid layout**: Organized by number base (6 or 10)
- **Timing**: Shows algorithm efficiency

### Prime Pair Analysis
Format: `pp(n)=count, factorization; n=p1+p2+p3+...`
- `pp(n)`: Prime pair count for number n
- `count`: Number of ways to express n as sum of two primes
- `factorization`: Prime factorization of n/2
- `p1+p2`: Individual prime pairs that sum to n

### Statistical Information
- **Count**: Total primes found in range
- **Time(ms)**: Computation time in milliseconds
- **Result**: Analysis results (exception counts, verification status)

## Practical Examples

### Example 1: Verify Goldbach for Small Numbers
```
Input: 20
Steps: Prime Collection → Even Collection
Result: See that all even numbers 4,6,8,10,12,14,16,18,20 
        can be expressed as sum of two primes
```

### Example 2: Find Prime Pairs for 30
```
Input: 30
Steps: Prime Collection → Prime Pair
Result: 30 = 7+23 = 11+19 = 13+17
        (3 different ways to express 30 as sum of two primes)
```

### Example 3: Performance Testing
```
Input: 10000
Steps: Prime Collection
Result: Observe computation time and prime count
        Compare efficiency of the Sieve of Eratosthenes
```

## Tips for Effective Use

1. **Start Small**: Begin with numbers under 1000 to understand the patterns
2. **Use Timing**: Compare performance with different input sizes
3. **Pattern Recognition**: Switch between decimal and senary to spot patterns
4. **Sequential Analysis**: Use Even Collection to see trends across ranges
5. **Verification**: Use Decide button to verify mathematical properties

## Common Use Cases

### Educational
- **Math Students**: Understand prime number patterns and distribution
- **Computer Science**: Study algorithm efficiency and optimization
- **Number Theory**: Explore unsolved mathematical problems

### Research
- **Pattern Analysis**: Look for trends in prime pair distributions
- **Conjecture Testing**: Empirically verify mathematical hypotheses
- **Algorithm Study**: Compare different approaches to prime generation

### Entertainment
- **Mathematical Exploration**: Discover interesting number properties
- **Challenge Solving**: Test specific numbers or ranges
- **Pattern Hunting**: Look for mathematical curiosities

## Troubleshooting

### Performance Issues
- **Large Numbers**: Computation time increases quadratically
- **Memory Usage**: BitArray is used for efficiency, but very large ranges may still consume significant memory
- **Display Limits**: Output is limited to first 255 results for performance

### Input Validation
- **Even Numbers**: Prime pair analysis requires even input numbers
- **Range Limits**: Very large numbers may cause memory or performance issues
- **Senary Input**: When using senary mode, ensure input uses only digits 0-5

## Mathematical Background

This application implements several important algorithms:

1. **Sieve of Eratosthenes**: Efficient prime number generation
2. **Goldbach Verification**: Tests one of mathematics' most famous conjectures
3. **Prime Pair Enumeration**: Systematic analysis of additive prime combinations
4. **Number Base Conversion**: Supports mathematical analysis in different bases

The Goldbach Conjecture remains unproven but has been verified computationally for extremely large numbers. This application allows you to explore this fascinating area of number theory interactively.