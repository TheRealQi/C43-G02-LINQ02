using System.Diagnostics.Tracing;

namespace Assignment02Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = ListGenerator.ProductsList;
            List<Customer> customers = ListGenerator.CustomersList;
            string[] dictionary = System.IO.File.ReadAllLines("./dictionary_english.txt");

            #region LINQ - Aggregate Operators

            // // 1. Get the total units in stock for each product category.
            // var totalUnitsInStock = products.GroupBy(p => p.Category).Select(g =>
            //     new { Category = g.Key, TotalUnitsInStock = g.Sum(p => p.UnitsInStock) });
            // foreach (var category in totalUnitsInStock)
            // {
            //     Console.WriteLine($"Category: {category.Category}, Total units in stock: {category.TotalUnitsInStock}");
            // }
            //
            // // 2. Get the cheapest price among each category's products
            // var cheapestPricePerCategory = products.GroupBy(p => p.Category)
            //     .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
            // foreach (var category in cheapestPricePerCategory)
            // {
            //     Console.WriteLine($"Category: {category.Category}, Cheapest Price: {category.CheapestPrice}");
            // }
            //
            // // 3. Get the products with the cheapest price in each category (Use Let)
            // var cheapestProductsPerCategory = from p in products
            //     group p by p.Category
            //     into g
            //     let minPrice = g.Min(p => p.UnitPrice)
            //     select new { Category = g.Key, CheapestProducts = g.Where(p => p.UnitPrice == minPrice).ToList() };
            // foreach (var category in cheapestProductsPerCategory)
            // {
            //     Console.WriteLine($"Category: {category.Category}");
            //     foreach (var product in category.CheapestProducts)
            //     {
            //         Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
            //     }
            // }
            //
            // // 4. Get the most expensive price among each category's products.
            // var mostExpensivePricePerCategory = products.GroupBy(p => p.Category)
            //     .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });
            // foreach (var category in mostExpensivePricePerCategory)
            // {
            //     Console.WriteLine($"Category: {category.Category}, Most Expensive Price: {category.MostExpensivePrice}");
            // }
            //
            // // 5. Get the products with the most expensive price in each category.
            // var mostExpensiveProductsPerCategory = from p in products
            //     group p by p.Category
            //     into g
            //     let maxPrice = g.Max(p => p.UnitPrice)
            //     select new { Category = g.Key, MostExpensiveProducts = g.Where(p => p.UnitPrice == maxPrice).ToList() };
            // foreach (var category in mostExpensiveProductsPerCategory)
            // {
            //     Console.WriteLine($"Category: {category.Category}");
            //     foreach (var product in category.MostExpensiveProducts)
            //     {
            //         Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
            //     }
            // }
            //
            // // 6. Get the average price of each category's products.
            // var averagePricePerCategory = products.GroupBy(p => p.Category)
            //     .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });
            // foreach (var category in averagePricePerCategory)
            // {
            //     Console.WriteLine($"Category: {category.Category}, Average Price: {category.AveragePrice}");
            // }

            #endregion

            #region LINQ - Set Operators

            // // 1. Find the unique Category names from Product List
            // var uniqueCategoryNames = products.Select(p => p.Category).Distinct();
            // foreach (var category in uniqueCategoryNames)
            // {
            //     Console.WriteLine(category);
            // }
            //
            // // 2. Produce a Sequence containing the unique first letter from both product and customer names.
            // var uniqueFirstLetters = products.Select(p => p.ProductName[0])
            //     .Union(customers.Select(c => c.CustomerName[0])).Distinct();
            // foreach (var letter in uniqueFirstLetters)
            // {
            //     Console.Write($" {letter} ");
            // }
            //
            // Console.WriteLine();
            //
            // // 3. Create one sequence that contains the common first letter from both product and customer names.
            // var commonFirstLetters = products.Select(p => p.ProductName[0])
            //     .Intersect(customers.Select(c => c.CustomerName[0]));
            // foreach (var letter in commonFirstLetters)
            // {
            //     Console.Write($" {letter} ");
            // }
            //
            // Console.WriteLine();
            //
            // // 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            // var notCommonFirstLetters =
            //     products.Select(p => p.ProductName[0]).Except(customers.Select(c => c.CustomerName[0]));
            // foreach (var letter in notCommonFirstLetters)
            // {
            //     Console.Write($" {letter} ");
            // }
            //
            // Console.WriteLine();
            //
            // // 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            // var lastThreeLetters = products
            //     .Select(p =>
            //         p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName)
            //     .Concat(customers.Select(c =>
            //         c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName));
            // foreach (var i in lastThreeLetters)
            // {
            //     Console.Write($" {i} ");
            // }

            #endregion

            #region LINQ - Partitioning Operators

            // // 1. Get the first 3 orders from customers in Washington
            // var firstThreeOrdersInWashington = customers.Where(c => c.City == "Washington")
            //     .SelectMany(c => c.Orders).Take(3);
            // foreach (var order in firstThreeOrdersInWashington)
            // {
            //     Console.WriteLine(order.OrderID);
            // }
            //
            // // 2. Get all but the first 2 orders from customers in Washington.
            // var allButFirstTwoOrdersInWashington = customers.Where(c => c.City == "Washington")
            //     .SelectMany(c => c.Orders).Skip(2);
            // foreach (var order in allButFirstTwoOrdersInWashington)
            // {
            //     Console.WriteLine(order.OrderID);
            // }
            //
            // int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            // // 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            // var elementsUntilNumberLessThanPosition = numbers.TakeWhile((n, i) => n >= i);
            // Console.WriteLine("Elements starting from the beginning of the array until a number is hit that is less than its position in the array:");
            // foreach (var number in elementsUntilNumberLessThanPosition)
            // {
            //     Console.WriteLine(number);
            // }
            //
            // // 4. Get the elements of the array starting from the first element divisible by 3.
            // var elementsStartingFromFirstDivisibleByThree = numbers.SkipWhile(n => n % 3 != 0);
            // Console.WriteLine("Elements starting from the first element divisible by 3:");
            // foreach (var number in elementsUntilNumberLessThanPosition)
            // {
            //     Console.WriteLine(number);
            // }
            //
            // // 5. Get the elements of the array starting from the first element less than its position.
            // var elementsStartingFromFirstLessThanPosition = numbers.SkipWhile((n, i) => n >= i);
            // Console.WriteLine("Elements starting from the first element less than its position:");
            // foreach (var number in elementsStartingFromFirstLessThanPosition)
            // {
            //     Console.WriteLine(number);
            // }

            #endregion

            #region LINQ - Quantifiers
            
            // // 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            // var containsEi = dictionary.Any(w => w.Contains("ei"));
            // Console.WriteLine(containsEi);
            //
            // // 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
            // var categoriesWithOutOfStockProducts = products.GroupBy(p => p.Category)
            //     .Where(g => g.Any(p => p.UnitsInStock == 0));
            // foreach (var category in categoriesWithOutOfStockProducts)
            // {
            //     Console.WriteLine($"Category: {category.Key}");
            //     foreach (var product in category)
            //     {
            //         Console.WriteLine($"{product.ProductName} - {product.UnitsInStock}");
            //     }
            // }
            //
            // // 3. Return a grouped a list of products only for categories that have all of their products in stock.
            // var categoriesWithAllProductsInStock = products.GroupBy(p => p.Category)
            //     .Where(g => g.All(p => p.UnitsInStock > 0));
            // foreach (var category in categoriesWithAllProductsInStock)
            // {
            //     Console.WriteLine($"Category: {category.Key}");
            //     foreach (var product in category)
            //     {
            //         Console.WriteLine($"{product.ProductName} - {product.UnitsInStock}");
            //     }
            // }

            #endregion

            #region LINQ - Grouping Operators
            
            // // 1. Use group by to partition a list of numbers by their remainder when divided by 5
            // List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            // var numbersGroupedByRemainder = numbers.GroupBy(n => n % 5);
            // foreach (var group in numbersGroupedByRemainder)
            // {
            //     Console.WriteLine($"Numberswith a remainder of {group.Key} when divided by 5:");
            //     foreach (var number in group)
            //     {
            //         Console.WriteLine(number);
            //     }
            // }
            //
            // // 2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input
            // var wordsGroupedByFirstLetter = dictionary.GroupBy(w => w[0]);
            // foreach (var group in wordsGroupedByFirstLetter)
            // {
            //     foreach (var word in group)
            //     {
            //         Console.WriteLine(word);
            //     }
            // }
            //
            //
            // // 3. Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            // string[] Arr = {"from", "salt", "earn", " last", "near", "form"};
            // var wordsGroupedBySameCharacters = Arr.GroupBy(w => new string(w.OrderBy(c => c).ToArray()));
            // Console.WriteLine("Words grouped by same characters:");
            // foreach (var group in wordsGroupedBySameCharacters)
            // {
            //     foreach (var word in group)
            //     {
            //         Console.WriteLine(word);
            //     }
            //     Console.WriteLine("....");
            // }

            
            #endregion
        }
    }
}