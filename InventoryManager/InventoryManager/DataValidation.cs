//Method to Check whether the given string for the Phone number can be formatted to the Phone number format

public class DataValidation
{
    public int CheckProductId(string inputProductId,bool isProductId)
    {
        string printType = isProductId ? "ID" : "Quantity";
        bool isProductIdInt = int.TryParse(inputProductId, out int parsedId);
        while (!isProductIdInt)
        {
                    
            Console.WriteLine($"The Product {printType} is invalid !!\nType the Product {printType} Again : ");
            isProductIdInt = int.TryParse(Console.ReadLine(), out parsedId);
        }
        Console.WriteLine($"The Product {printType} has  been successfully added");
        return parsedId;
    }

    public decimal CheckProductPrice(string inputProductPrice)
    {
        bool isProductPriceDecimal = decimal.TryParse(inputProductPrice, out decimal parsedPrice);
        while (!isProductPriceDecimal)
        {

            Console.WriteLine("The Product Price is invalid !!\nType the Product Price Again : ");
            isProductPriceDecimal = decimal.TryParse(Console.ReadLine(), out parsedPrice);
        }
        Console.WriteLine("The Product Price has  been successfully added");
        return parsedPrice;
    }

}



