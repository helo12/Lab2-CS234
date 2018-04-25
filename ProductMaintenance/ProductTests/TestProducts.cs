using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProductMaint;


namespace ProductTests
{
    [TestFixture]
    public class TestProducts
    {
        [Test]
        public void testIEnum()
        {
            Product p1 = new Product();
            Product p2 = new Product();
            Product p3 = new Product();
            Product p4 = new Product();


            ProductList test = new ProductList();
            test.Add(p1);
            test.Add(p2);
            test.Add(p3);
            test.Add(p4);

            foreach (Product p in test)
            {
                p.Code = "Test";
            }
            Assert.AreEqual(test[0], p1);

        }
    }
}
