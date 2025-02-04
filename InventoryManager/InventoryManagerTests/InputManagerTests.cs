using NUnit.Framework;
using InventoryManager.InputValidation;
using InventoryManager.UserInterface;

namespace InventoryManagerTests
{
    [TestFixture]
    public class InputManagerTests
    {
        InputManager inputManager;
        public InputManagerTests()
        {      
            var dataValidation = new DataValidation();
            inputManager = new InputManager(dataValidation);
        }

        [TestCaseSource(nameof(inputUserOptionsTestCases))]
        [Test]
        public void GetUserOptions_ShallReturnInput_IfInputIsBetween0And6(StringReader inputUserOptions)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputUserOptions);
            int result = inputManager.GetUserOptions();
            var consoleOuput = stringWriter.ToString();
            Assert.Multiple(() =>
            {
                Assert.True((result >= 0) && (result <= 6));
                Assert.AreEqual(consoleOuput, "\nHello!\nWhat do you want to do?\n[0] View the Product List\n[1] Add new Product\n[2] Delete the Product\n[3] Modify the Product List\n[4] Search the Product List\n[5] QuickSort the Product List\n[6] Exit the Product List\nType your Choice: ");
            });
        }

        private static IEnumerable<object> inputUserOptionsTestCases()
        {
            return new[]
            {
             new object[] { new StringReader("3") },
             new object[] { new StringReader("2") },
             new object[] { new StringReader("0") },
             new object[] { new StringReader("1") },
             new object[] { new StringReader("6") },
             new object[] { new StringReader("5") },
            };
        }

        [TestCaseSource (nameof(inputEditFieldTestCases))]
        [Test]
        public void GetEditField_ShallReturnInput_IfInputIsBetween0And3(StringReader inputEditField)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputEditField);
            int result = inputManager.GetEditField();
            var consoleOuput = stringWriter.ToString();
            Assert.Multiple(() =>
            {
                Assert.True((result>=0) && (result<=3));    
                Assert.AreEqual(consoleOuput, "Choose the Information that must be edited : \n[0] Name of the Product \n[1] ID of the Product \n[2] Price of the Product \n[3] Quantity of the product \nType your Choice: ");
            });
        }

        private static IEnumerable<object> inputEditFieldTestCases()
        {
            return new[]
            {
             new object[] { new StringReader("3") },
             new object[] { new StringReader("2") },
             new object[] { new StringReader("0") },
             new object[] { new StringReader("1") }

            };
        }

        [TestCaseSource(nameof(inputActionFieldTestCases))]
        [Test]
        public void GetActionField_ShallReturnInput_IfInputIsBetween0And1(StringReader inputActionField)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputActionField);
            int result = inputManager.GetActionField();
            var consoleOuput = stringWriter.ToString();
            Assert.Multiple(() =>
            {
                Assert.True((result >= 0) && (result <= 1));
                Assert.AreEqual(consoleOuput, "[0] Name\n[1] Id\nPerform the action by Name or ID : ");
            });
        }

        private static IEnumerable<object> inputActionFieldTestCases()
        {
            return new[]
            {
             new object[] { new StringReader("0") },
             new object[] { new StringReader("1") }
            };
        }

        private static IEnumerable<object> inputChoiceWithinBoundsTestCases()
        {
            return new[]
            {
             new object[] { 7, new List<StringReader> { new StringReader("15"), new StringReader("-7"), new StringReader("5") } },
             new object[] { 10, new List<StringReader> { new StringReader("9") } },
             new object[] { 3, new List<StringReader> { new StringReader("0") } },
             new object[] { 120, new List<StringReader> { new StringReader("500"), new StringReader("150"), new StringReader("50") } },
            };
        }

    }
}
