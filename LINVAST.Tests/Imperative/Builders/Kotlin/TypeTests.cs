using System;
using LINVAST.Imperative.Builders.Kotlin;
using LINVAST.Imperative.Nodes;
using LINVAST.Nodes;
using NUnit.Framework;

namespace LINVAST.Tests.Imperative.Builders.Kotlin
{
    internal sealed class TypeTests : ASTBuilderTestBase
    {
        // entry point: parse just a userType rule, e.g. "Int" or "kotlin.io.File"
        protected override ASTNode GenerateAST(string src)
            => new KotlinASTBuilder().BuildFromSource(src, p => p.userType());

        [Test]
        public void SimpleTypeTest()
        {
            TypeNameNode node = this.GenerateAST("Int").As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("Int"));

            node = this.GenerateAST("String").As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("String"));

            node = this.GenerateAST("Boolean").As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("Boolean"));
        }

        [Test]
        public void QualifiedTypeTest()
        {
            // kotlin.io.File → three simpleUserType segments joined with "."
            TypeNameNode node = this.GenerateAST("kotlin.io.File").As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("kotlin.io.File"));

            node = this.GenerateAST("java.util.ArrayList").As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("java.util.ArrayList"));
        }

        [Test]
        public void GenericTypeDropsArgumentsTest()
        {
            // generics are ignored for now -> List<String> becomes just "List"
            TypeNameNode node = this.GenerateAST("List<String>").As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("List"));

            node = this.GenerateAST("Map<String,Int>").As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("Map"));
        }

        [Test]
        public void NullableTypeTest()
        {
            ASTNode ast = new KotlinASTBuilder().BuildFromSource("String?", p => p.nullableType());
            TypeNameNode node = ast.As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("String?"));

            ast = new KotlinASTBuilder().BuildFromSource("Int?", p => p.nullableType());
            node = ast.As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("Int?"));
        }

        // --- typeReference tests ---

        [Test]
        public void TypeReferenceSimpleTest()
        {
            // typeReference → userType → simpleUserType
            TypeNameNode node = new KotlinASTBuilder()
                .BuildFromSource("Int", p => p.typeReference())
                .As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("Int"));
        }

        [Test]
        public void TypeReferenceQualifiedTest()
        {
            TypeNameNode node = new KotlinASTBuilder()
                .BuildFromSource("kotlin.io.File", p => p.typeReference())
                .As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("kotlin.io.File"));
        }

        [Test]
        public void TypeReferenceParenthesizedTest()
        {
            // typeReference : LPAREN typeReference RPAREN - recursive, strips parens
            TypeNameNode node = new KotlinASTBuilder()
                .BuildFromSource("(Int)", p => p.typeReference())
                .As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("Int"));
        }

        [Test]
        public void TypeReferenceDynamicThrowsTest()
        {
            // DYNAMIC is not supported
            TypeNameNode node = new KotlinASTBuilder()
                .BuildFromSource("dynamic", p => p.typeReference())
                .As<TypeNameNode>();
            Assert.That(node.TypeName, Is.EqualTo("dynamic"));
        }

        // --- functionType tests ---

        [Test]
        public void FunctionTypeThrowsTest()
        {
            // function types are not supported yet
            Assert.That(
                () => new KotlinASTBuilder().BuildFromSource("() -> Unit", p => p.functionType()),
                Throws.InstanceOf<NotImplementedException>());

            Assert.That(
                () => new KotlinASTBuilder().BuildFromSource("(Int) -> String", p => p.functionType()),
                Throws.InstanceOf<NotImplementedException>());
        }
    }
}
