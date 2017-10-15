using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRangerAPI.Controllers;
using AgeRangerAPI.Models;
using System.Web.Http;

namespace ageRangerAPI.Tests.Controllers
{
    /// <summary>
    /// Summary description for PeopleViewTest
    /// </summary>
    [TestClass]
    public class PeopleViewTest
    {
        public PeopleViewTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestPostPerson()
        {
            PeopleController controller = new PeopleController();

            Person person = new Person();
            person.FirstName = "Test";
            person.LastName = "Test";
            person.Age = 1;

            IHttpActionResult result = controller.PostPerson(person);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetPeople()
        {
            PeopleController controller = new PeopleController();

            Assert.IsNotNull(controller.GetPerson(1));
        }
    }
}
