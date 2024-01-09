using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2CSharp
{
    enum UserType { Admin = 1, Customer = 2, End = 3 };
    internal class Program
    {
        static void Main(string[] args)
        {
            bool condition = true;
            bool condition1;


            Product product = new Product();
            while (condition)
            {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Admin\n2.Customer\n3.End");
            Console.WriteLine("Enter User Type");

            int userType = Byte.Parse(Console.ReadLine());

                switch (userType)
                {
                    case (byte)UserType.Admin:
                        product.GetProductDetails();
                        condition1 = true;
                        while (condition1)
                        {
                            Console.WriteLine("Do you want to add more items(y/n) ?");
                            char ch = char.Parse(Console.ReadLine());
                            switch (ch)
                            {
                                case 'y':
                                    product.GetProductDetails();
                                    break;
                                case 'n':
                                    condition1 = false;
                                    break;
                            }
                        }
                        product.DisplayDetails();
                            break;
                        
                    case (byte)UserType.Customer:
                        Console.WriteLine("Enter Product Name to Purchase");
                        string purchase=Console.ReadLine();
                        product.Purchase(purchase);
                        break;
                    case (byte)UserType.End:condition=false;
                        break;
                }//switch
            }//while
        }//main
    }//class
}//namespace