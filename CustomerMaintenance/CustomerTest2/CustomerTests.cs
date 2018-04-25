using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomerMaintenance;

namespace CustomerTest2
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void testClone()
        {
            Object cloneCustomer;
            Customer testCustomer = new Customer("Tim", "Allen", "testEmail@google.com");
            cloneCustomer = testCustomer.Clone() as Customer;

            Assert.AreEqual(cloneCustomer.ToString(), testCustomer.ToString());
        }
        [Test]
        public static void TestForEach()
        {
            CustomerList cL = new CustomerList();
            Customer c1 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");
            Customer c2 = new Customer(
                "Mickey", "Mouse", "mmouse@disney.com");
            cL.Add(c1);
            cL.Add(c2);
            string[] test = new string[2];
            foreach (Customer c in cL)
            {
                Assert.AreSame(cL[1].ToString(),cL[0].ToString()); 
            }

        }
    }
}
