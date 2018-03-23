using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_06.Tests
{
    [TestClass]
    class ProductBuilderTest
    {
        private ProductBuilder productBuilder;
        ProductBuilderTest()
        {
            productBuilder = new ProductBuilder();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetType_IllegalArguments_ThrowArgumentException()
        {
            
        }
    }
}
