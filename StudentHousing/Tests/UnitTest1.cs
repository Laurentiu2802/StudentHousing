using Logic.Entities;
using Logic.Interfaces;
using Logic.Managers;
using Xunit.Sdk;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddCustomer()
        {
            bool success;
            ICustomer iCustomer = new MockRepository();
            CustomerManager customerManager = new CustomerManager(iCustomer);
            if (customerManager.AddCustomer(new Customer("testUserName", "testFirstName", "testLastName", "testAddress", "testCity", "testCountry", 6, "testEmail", "testPassword", false).CustomerToCustomerDTO()) == true)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void GetIDByCredentials()
        {
            bool success;
            ICustomer customer = new MockRepository();
            CustomerManager customerManager = new CustomerManager(customer);
            string email = "testEmail";
            string password = "testPassword";
            if (customerManager.GetIDByCredentials(email, password).PersonID > -1)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            Assert.IsTrue(success);
        }
    }
}