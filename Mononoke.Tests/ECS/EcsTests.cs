using Mononoke.ECS;
using NUnit.Framework;

namespace Mononoke.Tests.ECS
{
    [TestFixture]
    public class EcsTests
    {
        struct TestFiltersStruct
        {
            public EcsTypes.A a;
            public EcsTypes.I1 i;
        }

        [Test]
        public void TestFilters()
        {
            
            
            var filter = new EcsFilter<TestFiltersStruct>();
            
            
            Assert.IsTrue(filter.Accept(typeof(EcsTypes.A), typeof(EcsTypes.I1)));
            Assert.IsTrue(filter.Accept(typeof(EcsTypes.A), typeof(EcsTypes.I1), typeof(EcsTypes.C)));
            Assert.IsTrue(filter.Accept(typeof(EcsTypes.A1), typeof(EcsTypes.B)));
            Assert.IsTrue(filter.Accept(typeof(EcsTypes.A1), typeof(EcsTypes.B), typeof(EcsTypes.C)));
            
            Assert.IsFalse(filter.Accept(typeof(EcsTypes.A)));
            Assert.IsFalse(filter.Accept(typeof(EcsTypes.B)));
            Assert.IsFalse(filter.Accept(typeof(EcsTypes.C)));
            Assert.IsFalse(filter.Accept(typeof(EcsTypes.A), typeof(EcsTypes.C)));
            Assert.IsFalse(filter.Accept(typeof(EcsTypes.C), typeof(EcsTypes.B)));
        }
        
        
        
        struct TestFiltersStruct2
        {
            public EcsTypes.I1 i;
        }

        [Test]
        public void TestFilters2()
        {
            var filter = new EcsFilter<TestFiltersStruct2>();
            
            Assert.IsTrue(filter.Accept(typeof(EcsTypes.I1)));
            Assert.IsTrue(filter.Accept(typeof(EcsTypes.B)));
            Assert.IsTrue(filter.Accept(typeof(EcsTypes.B1)));
        }
        
    }
}