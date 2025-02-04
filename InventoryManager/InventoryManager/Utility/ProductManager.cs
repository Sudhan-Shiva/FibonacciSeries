using InventoryManager.UserInterface;
using InventoryManager.Model;

namespace InventoryManager.Utility
{
    /// <summary>
    /// Handles the operations of the product list
    /// </summary>
    public class ProductManager
    {
        /// <summary>
        /// Represents the Product List
        /// </summary>
        private List<Product> _productList = new List<Product>();
        InputManager inputManager;
        OutputManager outputManager;

        /// <summary>
        /// Represents the ProductManager class with the essential object references
        /// </summary>
        /// <param name="mainDataValidation">Required Data validation object reference</param>
        /// <param name="mainInputManager">Required Input manager object reference</param>
        public ProductManager(InputManager mainInputManager, OutputManager mainOutputManager)
        {
            inputManager = mainInputManager ;
            outputManager = mainOutputManager ;
        }
        /// <summary>
        /// To check if the product list is empty
        /// </summary>
        /// <returns>True if the product list is empty, else false</returns>
        private bool IsListEmpty()
        {
            return (_productList.Count == 0);
        }

        /// <summary>
        /// Returns the index of the product from the product list
        /// </summary>
        /// <param name="inputProductName">The product name whose information must be stored</param>
        /// <returns>The index of the matched product</returns>
        private int ReturnIndexWithName(string inputProductName)
        {
            return _productList.FindIndex(x => x.ProductName == inputProductName);
        }

        /// <summary>
        /// Returns the index of the product from the product list
        /// </summary>
        /// <param name="inputProductId">The product ID whose information must be stored</param>
        /// <returns>The index of the matched product</returns>
        private int ReturnIndexWithId(int inputProductId)
        {
            return _productList.FindIndex(x => x.ProductId == inputProductId);       
        }
        /// <summary>
        /// To check whether the input string is contained in any of the product name
        /// </summary>
        /// <param name="inputForSearchProductName">The input string which is to be checked</param>
        /// <returns>True if any product name contains the input string, else false</returns>
        private bool IsContainingProductName(string inputForSearchProductName)
        {
            bool isSearchPresent = false;
            foreach (Product searchproduct in _productList)
            {
                if (searchproduct.ProductName.Contains(inputForSearchProductName))
                {
                    outputManager.SpecificProductInformation(_productList, ReturnValidIndex(searchproduct.ProductName));
                    isSearchPresent = true;
                }
            }
            return isSearchPresent;
        }

        private int ReturnValidIndex(string viewProduct)
        {
            int printIndex = ReturnIndexWithName(viewProduct);
            while (printIndex == -1)
            {
                viewProduct = inputManager.ReplaceInvalidInput();
                printIndex = ReturnIndexWithName(viewProduct);
            }
            return printIndex;
        }

        private string GetDistinctProductName(string inputProductName)
        {
            while (ReturnIndexWithName(inputProductName) != -1)
            {
                inputProductName = inputManager.GetUniqueProductName();
            }
            return inputProductName;
        }

        private int GetDistinctProductId(int inputProductId)
        {
            while (ReturnIndexWithId(inputProductId) != -1)
            {
                inputProductId = inputManager.GetUniqueProductId();
            }
            return inputProductId;
        }

        /// <summary>
        /// To add new products in the list
        /// </summary>
        public void AddProduct()
        {
            Product product = new Product();
            product.ProductName = GetDistinctProductName(inputManager.GetProductName());
            product.ProductId = GetDistinctProductId(inputManager.GetProductId());
            product.ProductPrice = inputManager.GetProductPrice();
            product.ProductQuantity = inputManager.GetProductQuantity();
            _productList.Add(product);
            OutputManager.PrintSuccessfulAddition();
            outputManager.SpecificProductInformation(_productList, ReturnValidIndex(product.ProductName));
        }

        /// <summary>
        /// To delete products in the list
        /// </summary>
        public void DeleteProduct()
        {
            if (!IsListEmpty())
            {
                string deleteChoice = inputManager.GetProductName();
                int deleteIndex = ReturnIndexWithName(deleteChoice);
                if (deleteIndex == -1)
                {
                    OutputManager.PrintNoMatches();
                }
                else
                {
                    OutputManager.PrintSuccessfulDeletion();
                    _productList.RemoveAt(deleteIndex);
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To modify product information in the list
        /// </summary>
        public void ModifyProduct()
        {
            if (!IsListEmpty())
            {
                string editChoice = inputManager.GetProductName();
                int editIndex = ReturnIndexWithName(editChoice);
                string newProductName = editChoice;
                if (editIndex == -1)
                { 
                    OutputManager.PrintNoMatches(); 
                }
                else
                {
                    UserEditChoice userEditChoice = (UserEditChoice)inputManager.GetEditField();
                    switch (userEditChoice)
                    {
                        case UserEditChoice.EditProductName:
                            newProductName = GetDistinctProductName(inputManager.GetProductName());
                            _productList[editIndex].ProductName = newProductName;
                            break;
                        case UserEditChoice.EditProductId:
                            _productList[editIndex].ProductId = GetDistinctProductId(inputManager.GetProductId());
                            break;
                        case UserEditChoice.EditProductPrice:
                            _productList[editIndex].ProductPrice = inputManager.GetProductPrice();
                            break;
                        case UserEditChoice.EditProductQuantity:
                            _productList[editIndex].ProductQuantity = inputManager.GetProductQuantity();
                            break;
                        default:
                            break;
                    }
                    outputManager.SpecificProductInformation(_productList, editIndex);
                    OutputManager.PrintSuccessfulModification();
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To sort the products in the list
        /// </summary>
        public void SortProduct()
        {
            if (!IsListEmpty())
            {
                int sortOrder = inputManager.GetActionField();
                NameOrIdChoice sortChoice = (NameOrIdChoice) sortOrder;

                if (sortChoice == NameOrIdChoice.ByName)
                {
                    OutputManager.PrintSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductName).ToList();
                    outputManager.ProductList(_productList);
                }
                else if (sortChoice == NameOrIdChoice.ById)
                {
                    OutputManager.PrintSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductId).ToList();
                    outputManager.ProductList(_productList);
                }
                else
                {
                    inputManager.ReplaceInvalidInput();
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To view the product names in the list
        /// </summary>
        public void ViewProduct()
        {
            if (!IsListEmpty())
            {
                outputManager.ProductList(_productList);
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To search for a particular product in the list
        /// </summary>
        public void SearchProduct()
        {
            if (!IsListEmpty())
            {
                int searchByChoice = inputManager.GetActionField();
                bool isSearchPresent = false;
                NameOrIdChoice searchChoice = (NameOrIdChoice) searchByChoice;
                switch(searchChoice)
                    {
                        case NameOrIdChoice.ByName:
                            string productNameHint = inputManager.GetProductName();
                            isSearchPresent = IsContainingProductName(productNameHint);
                        break;
                        case NameOrIdChoice.ById:
                            int productIdHint = inputManager.GetProductId();
                            int searchIndex = ReturnIndexWithId(productIdHint);
                            if (searchIndex == -1)
                            { break; }
                            else
                            {
                                outputManager.SpecificProductInformation(_productList, searchIndex);
                                isSearchPresent = true;
                            }                       
                        break;
                    default:
                        OutputManager.PrintInvalidInput();
                        break;
                    }
                if (!isSearchPresent)
                {
                   OutputManager.PrintNoMatches();
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }
    }
}
