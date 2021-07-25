using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailExtractionService
{
    public class Application
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to The Email Extractor");
            Console.WriteLine();
            Console.WriteLine("Please type a sentence that includes one or more emails in it and I will extract the email(s) back to you");
            Console.WriteLine();
            var UserInput = Console.ReadLine();
            EmailExtractor(UserInput);
        }

        private static void EmailExtractor(string UserInput)
        {
            var pattern = @"[a-zA-Z0-9][a-zA-Z-.]+@[a-z]+\.[a-zA-z]+";
            var Regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection match = Regex.Matches(UserInput);
            if (match.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"I found {match.Count()} email(s) in your sentence:");
                Console.WriteLine();
                foreach (var item in match)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            else
            {
                
                Console.WriteLine();
                Console.WriteLine("OOPS! Your input does not contain any email, \nIf you Think something is wrong, Please try again");
                Console.WriteLine();
                subMenu:
                Console.WriteLine("Press");
                Console.WriteLine("1: Try again");
                Console.WriteLine("2: Exit Email Extractor");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        Application.Main();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Have a lovely day");
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        goto subMenu;                    
                }
            }
        }
    }
}
