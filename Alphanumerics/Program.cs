// 1. Data Setup
string customerName = "Ms. Barros";
int currentShares = 2975000;

ProductDetail[] productDetails = [
    new("Magic Yield", 0.1275m, 55000000.0m),
    new("Glorious Future", 0.13125m, 63000000.0m)
];

// 2. Execution (No 'out' parameters needed here)
string openingMessage = GetCustomerMessage(customerName);
string sharesMessage = GetSharesMessage(currentShares, productDetails[0].Return);
string offerMessage = GetOfferMessage(productDetails[1]);
string comparison = GetComparisonTable(productDetails);

// 3. Output
Console.WriteLine(openingMessage);
Console.WriteLine(sharesMessage);
Console.WriteLine(offerMessage);
Console.WriteLine(comparison);

// --- METHODS ---

static string GetCustomerMessage(string name)
{
    string promptOpener = "As a customer of our Magic Yield offering we are excited to tell you about a\nnew financial product that would dramatically increase your return.\r\n";
    return $"Dear {name},\n{promptOpener}";
}

static string GetSharesMessage(int shares, decimal rate) =>
    $"Currently you own: {shares:N0} shares at a return of {rate:P}\n";

static string GetOfferMessage(ProductDetail product) =>
    $"Our new product, {product.Product}, offers a return of {product.Return:P}.\n" +
    $"Given your current volume, your potential would be {product.Profit:C}\n";

static string GetComparisonTable(ProductDetail[] products)
{
    var sb = new System.Text.StringBuilder("Here's a quick comparison:\n\n");
    foreach (var p in products)
    {
        sb.AppendLine($"{p.Product.PadRight(20)}{p.Return:P}\t{p.Profit:C2}");
    }
    return sb.ToString();
}

public record ProductDetail(string Product, decimal Return, decimal Profit);