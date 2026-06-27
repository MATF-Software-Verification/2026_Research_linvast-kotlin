# LINVAST - Kotlin Language Support Extension

Extension of the [LINVAST](https://github.com/LINVAST/LINVAST) language-invariant AST framework with support for the **Kotlin** programming language.

## Authors

| Name | Role |
|------|------|
| **Anđela Jovanović** | Kotlin extension - seminar paper 2026 |
| Ivan Ristović | Original LINVAST framework author |

---

## Prerequisites

| Tool / Library | Version | Purpose |
|----------------|---------|---------|
| [.NET SDK](https://dotnet.microsoft.com/download) | 5.0 or later | Build and run the project |
| [ANTLR4 Runtime for C#](https://www.nuget.org/packages/Antlr4.Runtime.Standard) | 4.9.0 | Lexing and parsing source files |
| [Serilog](https://www.nuget.org/packages/Serilog) | 4.0.0 | Structured logging |
| [Java JRE](https://adoptium.net/) | 11+ | Required only to regenerate ANTLR grammars |

All NuGet dependencies are restored automatically by `dotnet restore`.

### Installing the ANTLR4 tool (only needed to regenerate grammars)

**macOS (Homebrew):**
```bash
brew install antlr
```

**Manual (any OS):**
```bash
# Download the JAR
curl -O https://www.antlr.org/download/antlr-4.9-complete.jar

# Add a permanent alias to your shell profile (~/.zshrc or ~/.bashrc)
alias antlr4='java -jar /path/to/antlr-4.9-complete.jar'
```

Once installed, regenerate the Kotlin lexer/parser from the grammar files:

```bash
cd LINVAST.Imperative/Builders/Kotlin/ANTLR
antlr4 -Dlanguage=CSharp -visitor KotlinLexer.g4
antlr4 -Dlanguage=CSharp -visitor KotlinParser.g4
```

---

## Building the Project

Clone the repository and build with the .NET CLI:

```bash
git clone https://github.com/MATF-Software-Verification/2026_Research_linvast-kotlin.git
cd 2026_Research_linvast-kotlin
dotnet build
```

A successful build produces:
- `LINVAST/bin/Debug/netstandard2.1/LINVAST.dll`
- `LINVAST.Imperative/bin/Debug/netstandard2.1/LINVAST.Imperative.dll`

---

## Sample Files

The `samples/` directory contains example Kotlin files. Use the `LINVAST.Runner` console project to parse them and print the resulting AST.

| Directory | File | Description |
|-----------|------|-------------|
| `samples/valid/` | `Functions.kt` | Function declarations with parameters, return types, and bodies |
| `samples/valid/` | `Expressions.kt` | Arithmetic, logical, comparison, and unary expressions |
| `samples/valid/` | `ControlFlow.kt` | `if`/`else`, `while`, and assignment operators |
| `samples/valid/` | `ForLoop.kt` | `for`/`in` loops, including destructuring |
| `samples/valid/` | `Classes.kt` | Class and interface declarations, primary constructors, base types |
| `samples/unsupported/` | `Lambdas.kt` | Throws `NotImplementedException` - lambdas are not supported |
| `samples/unsupported/` | `ExpressionBody.kt` | Throws `NotImplementedException` - expression body functions are not supported |

Run a sample (from the repository root):

```
dotnet run --project LINVAST.Runner samples/valid/Functions.kt
dotnet run --project LINVAST.Runner samples/unsupported/ForLoop.kt
```

You can also point it at any `.kt` file:

```
dotnet run --project LINVAST.Runner path/to/your/file.kt
```

---

## Tests

Tests live in `LINVAST.Tests/Imperative/Builders/Kotlin/` and use NUnit 3.

| File | What it covers |
|------|---------------|
| `TypeTests.cs` | Kotlin type visitors: user types, nullable types, function types |
| `DeclarationTests.cs` | Variable and property declarations (`val`, `var`) |
| `ExpressionTests.cs` | Arithmetic, logic, comparison, unary expressions, literals, identifiers |
| `StatementTests.cs` | `if`, `while`, `for`, `return`, assignment expressions |
| `FunctionTests.cs` | Function declarations, parameter lists, function bodies |
| `ClassTests.cs` | Class and interface declarations, primary constructors, base types |
| `SourceTests.cs` | Top-level Kotlin file parsing |

Run all tests:

```bash
dotnet test
```

Run only Kotlin tests:

```bash
dotnet test --filter "FullyQualifiedName~Builders.Kotlin"
```

Run a specific test class:

```bash
dotnet test --filter "FullyQualifiedName~Builders.Kotlin.TypeTests"
```

Expected output:

```
Passed! - Failed: 0, Passed: 97, Skipped: 0, Total: 97
```

---

## Known Limitations

The following Kotlin constructs are not yet supported and will throw `NotImplementedException`:

| Construct | Example |
|-----------|---------|
| `do-while` loops | `do { } while (cond)` |
| `break` / `continue` | Inside loops |
| Expression body functions | `fun double(x: Int) = x * 2` |
| Lambda expressions | `{ x -> x + 1 }` |
| `is` / `in` operators | `x is Int`, `x in list` |
| Elvis operator | `x ?: default` |
| Type casts | `x as Int` |
| String interpolation | `"Hello $name"` |


