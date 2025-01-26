using NUnit.Framework;
using Moq;
using InventoryManager.InputValidation;
using InventoryManager.UserInterface;
using System.Text;

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

        [TestCaseSource]
        [Test]
        public void GetUserOptions_ShallReturnInput_IfInputIsBetween0And6(IEnumerable<StringReader> stringsToRead)
        {        
            StringReader sb = new ("3") ;
            Console.SetIn(sb);
            int result = inputManager.GetUserOptions();
            Assert.LessOrEqual(result, inputUserOption);           
        }

        private static IEnumerable<object> inputStrings()
        {
            return new[]
            {
             new object[] { new StringReader("3") },
             new object[] { new StringReader("2") },
             new object[] { new StringReader("0") },
             new object[] { new StringReader("1") }

            };
        }
    }
}
