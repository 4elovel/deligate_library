using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace deligate_library
{
    delegate void dell();
    internal class Program
    {
        class Book : ICloneable {
            public Book(string name,string author_s,int price) { this.name = name; this.author_s = author_s; this.price = price; }
            string name;
            string author_s;
            public int price;
            public void print()
            {
                Console.WriteLine($"NAME - {name}, AUTHOR - {author_s}, PRICE - {price}\n");
            }

            public object Clone()
            {
                return MemberwiseClone();
            }
        }
        class Order : ICloneable
            {
            public Order()
            {
                while (leaver)
                {
                    //Thread.Sleep(1000);
                    Console.Clear();
                    dell dl = null;
                    int choice;
                    Console.WriteLine("Write your option:");
                    Console.WriteLine("1 - add new book");
                    Console.WriteLine("2 - total order price");
                    Console.WriteLine("3 - print your basket");
                    Console.WriteLine("4 - end order");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            dl = this.order;
                            break;
                        case 2:
                            dl = this.print_total_price;
                            break;
                        case 3:
                            dl = this.print_basket;
                            break;
                        case 4:
                            dl = this.end;
                            break;
                        default:
                            Console.WriteLine("Wrong format");
                            break;
                            
                    }
                    dl.Invoke();
                    Console.WriteLine("\n\n press any button to continue");
                    Console.ReadKey();
                }
            }

            public void order()
            {
                print_menu();
                int choice = Convert.ToInt32(Console.ReadLine());
                Book book = all_books[choice];
                ls.Add(book);
                total_price += all_books[choice].price;
                Console.WriteLine("SUCESSFULL");
            }

            public void print_basket()
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    Console.Write($"{i+1} - ");
                    ls[i].print();
                }
            }

            bool leaver = true;
            public void print_menu()
            {
                Console.WriteLine("Here is the list of all books:\n");
                for (int i = 0; i < all_books.Count; i++)
                {
                    Console.Write(i);
                    Console.Write(" - ");
                    all_books[i].print();
                }
            }


            List <Book> all_books = new List<Book>() { 
            new Book("Tom Sawyer","Mark Twen",249),
            new Book("Robinson Crusoe","Daniel Defoe",349),
            new Book("Gulliver’s Travels","Jonathan Swift",299),
            new Book("Frankenstein","Mary Shelley",499),
            new Book("Sybil","Benjamin Disraeli",349),
            new Book("The Sign of Four","Arthur Conan Doyle",549),
            new Book("Clarissa","Samuel Richardson",399)
            };
            List<Book> ls = new List<Book>();


            public void end()
            {
                Console.WriteLine("Thank you for using our program!!");
                leaver = false;
            }

            public void print_total_price()
            {
                Console.WriteLine($"Total price - {total_price} grn");
            }

            public object Clone()
            {
                return MemberwiseClone();
            }
            int total_price = 0;
        }

        static void Main(string[] args)
        {
            Order order = new Order();
            Console.ReadKey();
        }
    }
}
