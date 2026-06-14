# Kotlin → LINVAST Node Mapping

Mapping of implemented Kotlin grammar rules to LINVAST nodes.

| Kotlin construct | Grammar rule | LINVAST node |
|---|---|---|
| Import directive | `importHeader` | `ImportNode` |
| `val`/`var` declaration | `propertyDeclaration` | `DeclStatNode` (`DeclSpecsNode` + `DeclListNode`) |
| Function declaration | `functionDeclaration` | `FuncNode` |
| Parameter list | `functionValueParameters` | `FuncParamsNode` |
| Single parameter | `parameter` | `FuncParamNode` |
| `if`/`else` | `ifExpression` | `IfStatNode` |
| `while` loop | `whileExpression` | `WhileStatNode` |
| `for` loop | `forExpression` | `ForeachStatNode` |
| `return` statement | `jumpExpression` | `JumpStatNode` |
| Assignment | `expression` (with assignment operator) | `AssignExprNode` |
| Arithmetic expression | `additiveExpression`, `multiplicativeExpression` | `ArithmExprNode` |
| Logical expression | `disjunction`, `conjunction` | `LogicExprNode` |
| Relational expression | `comparison`, `equalityComparison` | `RelExprNode` |
| Unary expression | `prefixUnaryExpression` | `UnaryExprNode` |
| Literal | `literalConstant` | `LitExprNode` / `NullLitExprNode` |
| Identifier | `simpleIdentifier` | `IdNode` |
| Statement block | `block` | `BlockStatNode` |
| Class declaration | `classDeclaration` | `ClassNode` (wraps `TypeDeclNode`) |
| Interface declaration | `classDeclaration` (with `INTERFACE`) | `InterfaceNode` (wraps `TypeDeclNode`) |
| Primary constructor | `primaryConstructor`, `classParameters` | `FuncDeclNode` inside `DeclStatNode` |
| Class parameter | `classParameter` | `FuncParamNode` |
| Base types | `delegationSpecifiers` | `TypeNameListNode` |
| Class body | `classBody` | `BlockStatNode` |
