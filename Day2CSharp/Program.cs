using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2CSharp
{
    enum UserType { Admin=1,Customer=2};
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            Console.WriteLine("1.Admin\n2.Customer");
            Console.WriteLine("Enter User Type");

            int userType=Byte.Parse(Console.ReadLine());
            switch(userType) { 
                case (byte)UserType.Admin: product.GetProductDetails();
                    break;

                    case (byte)UserType.Customer: product.DisplayDetails();
                    break;
            }
        }
    }
}
