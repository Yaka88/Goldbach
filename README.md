# Goldbach Conjecture Explorer

## Overview

This is a Windows Forms application written in C# that explores and visualizes the **Goldbach Conjecture**, one of the most famous unsolved problems in number theory.

## What is the Goldbach Conjecture?

The Goldbach Conjecture states that:
> **Every even integer greater than 2 can be expressed as the sum of two prime numbers.**

For example:
- 4 = 2 + 2
- 6 = 3 + 3  
- 8 = 3 + 5
- 10 = 3 + 7 = 5 + 5
- 12 = 5 + 7

## Project Functionality

This application provides several tools to explore and test the Goldbach Conjecture:

### Core Features

#### 1. **Prime Number Generation**
- Uses the Sieve of Eratosthenes algorithm to efficiently generate prime numbers up to a specified limit
- Displays prime numbers in both decimal and senary (base-6) number systems
- Shows computation time and count of primes found
- Visualizes primes with color coding (red for primes, black for composite numbers)

#### 2. **Prime Pair Analysis**
- For any given even number, finds all possible ways to express it as the sum of two primes
- Displays the prime pairs that sum to the target even number
- Shows the count of valid prime pairs for each even number
- Includes factorization information for the target number

#### 3. **Even Number Collection Analysis**
- Systematically analyzes all even numbers up to a specified limit
- Counts how many prime pairs exist for each even number
- Identifies patterns and exceptions in prime pair distributions
- Displays results in a tabular format

#### 4. **Conjecture Verification**
- Tests whether the Goldbach Conjecture holds for all even numbers in a given range
- Identifies any counterexamples (though none have been found mathematically)
- Provides statistical analysis of prime pair distributions

#### 5. **Number Base Conversion**
- Supports both decimal (base-10) and senary (base-6) number systems
- Useful for mathematical analysis and pattern recognition
- Toggle between number systems using the "Senary" checkbox

### User Interface Components

- **Even Number Input**: Enter the upper limit for analysis
- **Prime Collection Button**: Generate and display all primes up to the limit
- **Even Collection Button**: Analyze prime pairs for all even numbers
- **Prime Pair Button**: Find specific prime pairs for the entered even number
- **Decide Button**: Verify conjecture compliance for the range
- **Senary Checkbox**: Toggle between decimal and base-6 display
- **Results Display**: Two rich text boxes showing primes and prime pair analysis
- **Statistics**: Count of primes found, computation time, and analysis results

## Mathematical Algorithms

### Prime Generation (Sieve of Eratosthenes)
```csharp
// Efficiently marks composite numbers and identifies primes
for(int i = 3; i < intEven; i=i+2)
{
    if (intPrimeCol[i] == false)  // false means Prime
    {
        if (i <= intSqrtEven)
        {
            // Mark multiples as composite
            for (long j = i * i; j < intEven; j = j + (i << 1))
                intPrimeCol[(int)j] = true;
        }
    }
}
```

### Prime Pair Finding
```csharp
// Find all prime pairs that sum to the target even number
for (int i = 5; i <= (intEven >> 1); i += 2)
{
    if (intPrimeCol[i] == false && intPrimeCol[intEven - i] == false)
    {
        // Found a valid prime pair: i + (intEven - i) = intEven
        intPrimePairCount++;
    }
}
```

## System Requirements

- **Operating System**: Windows (requires Windows Forms)
- **Framework**: .NET 8.0 or later
- **Architecture**: Any CPU (AnyCPU)

## Usage Examples

1. **Basic Prime Generation**:
   - Enter `1000` in the Even field
   - Click "Prime Collection" to generate all primes up to 1000
   - View the colored output showing primes in red

2. **Goldbach Verification**:
   - Enter `100` in the Even field
   - Click "Prime Collection" first to generate primes
   - Click "Even Collection" to see prime pair counts for all even numbers up to 100

3. **Specific Prime Pair Analysis**:
   - Enter `24` in the Even field
   - Click "Prime Collection" to generate primes up to 24
   - Click "Prime Pair" to see all ways to express 24 as sum of two primes

## Educational Value

This application serves as an excellent tool for:
- **Mathematics Education**: Visualizing prime numbers and their properties
- **Number Theory Research**: Exploring patterns in prime distributions
- **Algorithm Demonstration**: Showing efficient prime generation techniques
- **Conjecture Testing**: Empirically verifying mathematical conjectures
- **Computer Science Learning**: Understanding computational number theory

## Technical Implementation

- **Language**: C# with Windows Forms
- **Data Structures**: BitArray for efficient memory usage in prime marking
- **Algorithms**: Optimized Sieve of Eratosthenes with wheel factorization concepts
- **UI Framework**: Windows Forms with rich text formatting for mathematical display
- **Number Systems**: Support for decimal and senary (base-6) representations

## License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE.txt](LICENSE.txt) file for details.

## Mathematical Background

The Goldbach Conjecture, proposed by Christian Goldbach in 1742, remains one of the oldest unsolved problems in number theory. While it has been verified computationally for very large numbers (up to 4 × 10^18 as of recent studies), a formal mathematical proof remains elusive. This application allows users to explore this fascinating conjecture interactively and understand the patterns that emerge in prime number distributions.