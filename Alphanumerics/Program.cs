string openingMessage = string.Empty;
string sharesMessage = string.Empty;
string offerMessage = string.Empty;
string comparisonMessage = string.Empty;

string customerName = "Ms. Barros";
int currentShares = 2975000;
string promptOpener = "As a customer of our Magic Yield offering we are excited to tell you about a\nnew financial product that would dramatically increase your return.\r\n";

string currentProduct = "Magic Yield";
decimal currentReturn = 0.1275m;
decimal currentProfit = 55000000.0m;

string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
decimal newProfit = 63000000.0m;


// Your logic here
// 2. Initializing with the Type name
ProductDetail[] productDetails = {
    new ProductDetail(currentProduct, currentReturn, currentProfit),
    new ProductDetail(newProduct, newReturn, newProfit)
};

DisplayCustomerMessage(customerName, promptOpener, out openingMessage);
DisplayCustomerShares(currentShares, currentReturn, out sharesMessage);
DisplayOffer(newProduct, newReturn, newProfit, out offerMessage);
CalculateComparison(productDetails, out comparisonMessage);

Console.WriteLine(openingMessage);
Console.WriteLine(sharesMessage);
Console.WriteLine(offerMessage);
Console.WriteLine(comparisonMessage);

static string CalculateComparison(ProductDetail[] products, out string comparisonMessage)
{
    comparisonMessage = $"Here's a quick comparison:\n\n{ListRates(products)}";
    return comparisonMessage;
}

static string DisplayCustomerMessage(string customerName, string promptOpener, out string openingMessage)
{
    openingMessage = $"Dear {customerName},\n{promptOpener}";
    return openingMessage;
}

static string DisplayCustomerShares(int currentShares, decimal currentReturn, out string sharesMessage)
{
    sharesMessage = $"Currently you own: {currentShares:N} shares at a return of {currentReturn:P}\n\n";
    return sharesMessage;
}

static string DisplayOffer(string newProduct, decimal newReturn, decimal newProfit, out string offerMessage)
{
    offerMessage = $"Our new product, {newProduct}, offers a return of {newReturn:P}.\nGiven your currrent volume, your potential would be ${newProfit:N}\n\n";
    return offerMessage;
}

static string ListRates(ProductDetail[] productDetails)
{
    string ratelist = string.Empty;
    for (int i = 0; i < productDetails.Length; i++)
    {
        ratelist += $"{productDetails[i].Product.PadRight(20)}{productDetails[i].Return:P}\t${productDetails[i].Profit:N2}\n";
    }
    return ratelist;
}

public record ProductDetail(string Product, decimal Return, decimal Profit);