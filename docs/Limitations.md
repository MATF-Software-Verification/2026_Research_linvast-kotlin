# Known Limitations

Kotlin constructs that are recognized during parsing but not mapped to LINVAST nodes.

| Construct | Reason |
|---|---|
| Import alias (`import Foo as Bar`) | Alias is silently dropped; `ImportNode` contains only the path |
| Wildcard import (`import kotlin.math.*`) | Parsed without error, wildcard is ignored |
| Type inference (`var y = 0`) | `TypeName` is set to the keyword (`"var"`) instead of the inferred type |
| Destructuring declaration (`val (a, b) = pair`) | Not supported |
| Expression body function (`= expr`) | Throws `NotImplementedException`; only block body is implemented |
| Default parameter values | Parsed but value is silently dropped |
| Extension functions (`fun String.shout()`) | Receiver type is ignored |
| Generic functions (`fun <T> id(x: T)`) | Type parameters are ignored |
| Function modifiers (`private`, `suspend`, ...) | Not mapped to LINVAST modifiers |
| `do-while` loop | No corresponding LINVAST node; throws `NotImplementedException` |
| `break`, `continue`, `throw` | Throw `NotImplementedException` |
| Labeled return (`return@label`) | Label is ignored; treated as plain `return` |
| Elvis operator (`x ?: y`) | Throws `NotImplementedException` |
| Infix calls (`1 to 2`, `1 until 10`) | Throw `NotImplementedException` |
| Range (`1..10`) | Throws `NotImplementedException` |
| Type cast (`x as Int`, `x as? Int`) | Throws `NotImplementedException` |
| Prefix `++`/`--` | `UnaryOpNode.FromSymbol` throws for these symbols |
| Method calls and field access | Postfix operations throw `NotImplementedException` |
| Lambda expressions | Throw `NotImplementedException` in `VisitAtomicExpression` |
| Class parameter default values (`class Foo(val x: Int = 0)`) | Value is silently dropped |
| Explicit delegation (`by`) | `class Foo : Bar by impl` throws `NotImplementedException` |
| Secondary constructors | `constructor(...)` inside class body throws `NotImplementedException` |
| `init` blocks | Throw `NotImplementedException` |
| Companion objects | Throw `NotImplementedException` |
| Type parameter constraints (`where`) | `where T : Comparable<T>` throws `NotImplementedException` |
| Enum class body | Not supported |
| Function types (`(Int) -> String`) | Throws `NotImplementedException` in `VisitFunctionType` |
| `dynamic` type | Throws `NotImplementedException` in `VisitTypeReference` |
