using LINVAST.Imperative.Builders.Kotlin;
using LINVAST.Imperative.Nodes;
using LINVAST.Nodes;
using LINVAST.Tests.Imperative.Builders.Common;
using NUnit.Framework;

namespace LINVAST.Tests.Imperative.Builders.Kotlin
{
    internal sealed class SourceTests : SourceComponentTestsBase
    {
        protected override ASTNode GenerateAST(string src)
            => new KotlinASTBuilder().BuildFromSource(src);

        [Test]
        public void EmptyFileProducesSourceNodeTest()
        {
            this.AssertTranslationUnit("", empty: true);
        }
    }
}
