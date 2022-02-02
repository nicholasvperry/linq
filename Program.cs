using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{

    // Build a collection of customers who are millionaires
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}

public class BankMillionairs
{
    public string Name {get; set;}
    public int Millionairs {get; set;}
}

public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}

public class ReportItem
{
    public string CustomerName { get; set; }
    public string BankName { get; set; }
}



    


    class Program
    {

        
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
            where fruit.StartsWith("L")
            select fruit;
        
            foreach (string fruit in LFruits){
                Console.WriteLine(fruit);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);

            // IEnumerable<int> fourSixMultiples =
            // from num in numbers
            // where num % 4 == 0 || num % 6 == 0
            // orderby num ascending
            // select num;
            
            foreach (int num in fourSixMultiples) {
                Console.WriteLine(num);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            List<string> descend = names.OrderByDescending(x => x).ToList();

            foreach (string name in descend) {
            Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> sortNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            // IEnumerable<int> ascending = sortNumbers.OrderBy(n => n);

            IEnumerable<int> ascending = from sn in sortNumbers
            orderby sn ascending
            select sn;


            foreach (int num in ascending) {
                Console.WriteLine(num);
            }

           
            // Output how many numbers are in this list
            List<int> numbersCount = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var count = numbersCount.Count();

            Console.WriteLine(count);


            // What is our most expensive product? - - - - -
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            //First sort them descending order
            IEnumerable<double> descendingPrices = from p in prices
            orderby p descending
            select p;

            foreach (double p in descendingPrices) {
                Console.WriteLine(p);
            }

            //Then find the first item in the list
            double highest = descendingPrices.First();

            Console.WriteLine($"The highest priced item is {highest}");


            //Make a list until a condition is met
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            /*
                Store each number in the following List until a perfect square
                is detected.

                Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx


            */
            IEnumerable<int> stopAtSquare = wheresSquaredo.TakeWhile(n => (Math.Sqrt(n) % 1) != 0 );

            foreach (int n in stopAtSquare) {
                
                Console.WriteLine(n);
            };


            //Given the same customer set, display how many millionaires per bank.
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };   
            
            
            // var millionairs = customers.Where(c => c.Balance >= 1000000);
            
            //Could also take off .ToList() and change List to IEnumerable 
            // List<BankMillionairs> millionairReport = (from customer in millionairs
            //     group customer by customer.Bank into bankGroup
            //     select new BankMillionairs {
            //         Name = bankGroup.Key,
            //         Millionairs = bankGroup.Count()
            //     }
            // ).ToList();

            
            // foreach (BankMillionairs item in millionairReport) {
            // Console.WriteLine($"{item.Name} {item.Millionairs}");
            // }
            
            
            /*
            TASK:
            As in the previous exercise, you're going to output the millionaires,
            but you will also display the full name of the bank. You also need
            to sort the millionaires' names, ascending by their LAST name.

            Example output:
                Tina Fey at Citibank
                Joe Landy at Wells Fargo
                Sarah Ng at First Tennessee
                Les Paul at Wells Fargo
                Peg Vale at Bank of America
            */
            
            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

            // Create some customers and store in a List
        List<Customer> ncustomers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

        /*
            You will need to use the `Where()`
            and `Select()` methods to generate
            instances of the following class.

            public class ReportItem
            {
                public string CustomerName { get; set; }
                public string BankName { get; set; }
            }
        */
        List<ReportItem> millionaireReport = (from customer in ncustomers
            where customer.Balance >= 1000000
            join bank in banks on customer.Bank equals bank.Symbol
            orderby customer.Name.Split(" ")[1] ascending
            select new ReportItem {
                CustomerName = customer.Name,
                BankName = bank.Name
            }
            
        ).ToList();

        foreach (var item in millionaireReport)
        {
            Console.WriteLine($"{item.CustomerName} at {item.BankName}");
        }

        }


    }   
}
