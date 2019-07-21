using System;
using library.service;
using Unity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using library.data;

namespace library.clientapp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Library System");
            while (true)
            {
                var selectedOption = SelectMenuOption();

                if (selectedOption == 6)
                {
                    Console.WriteLine("Exiting program");
                    break;
                }

                switch (selectedOption)
                {
                    case 1:
                        CreateBook();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected");
                        break;
                }
            }
        }

        private static int SelectMenuOption()
        {
            Console.WriteLine("Please select an option to proceed");
            Console.WriteLine("1. Add new book");
            Console.WriteLine("2. List all books");
            Console.WriteLine("3. Create Member");
            Console.WriteLine("4. Borrow Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Exit");
            var option = int.Parse(Console.ReadLine());
            return option;
        }

        private static void CreateBook()
        {
            Console.Write("Name : ");
            var name = Console.ReadLine();
            Console.Write("Author : ");
            var author = Console.ReadLine();
            Console.Write("Price : ");
            var price = Console.ReadLine();
            Console.Write("Total Copies : ");
            var totalCopies = Console.ReadLine();
            BookService bookService = new BookService(new BookRepositoryMySql());
            bookService.CreateBook(name, author, int.Parse(price), int.Parse(totalCopies));
        }
    }
}
