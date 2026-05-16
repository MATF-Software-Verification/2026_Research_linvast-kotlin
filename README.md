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

## Tests

Tests live in `LINVAST.Tests/Imperative/Builders/Kotlin/` and use NUnit 3.

| File | What it covers |
|------|---------------|
| `TypeTests.cs` | `VisitUserType`, `VisitSimpleUserType`, `VisitNullableType`, `VisitTypeReference`, `VisitFunctionType` |
| `SourceTests.cs` | `VisitKotlinFile` - only empty file parsing for now |

Run all Kotlin tests:

```bash
dotnet test --filter "FullyQualifiedName~Builders.Kotlin"
```

Run a specific test class:

```bash
dotnet test --filter "FullyQualifiedName~Builders.Kotlin.TypeTests"
```


