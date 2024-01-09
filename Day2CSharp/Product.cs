using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Day2CSharp
{
    internal class Product
    {
        int pCode;
        string pName;
        int qtyInStock;
        float discountAllowed;
        static string brand;
        double amount;
        List<Product> products =new List<Product>();
        public Product()
        {
            pCode = 1;
        }
        public Product(int pCode, string pName, int qtyInStock, float discountAllowed , double amount)
        {
            this.pCode = pCode;
            this.pName = pName;
            this.qtyInStock = qtyInStock;
            this.discountAllowed = discountAllowed;
            this.amount = amount;
        }

        static Product ()
        {
            brand = "Lewis";
        }

        public void GetProductDetails()
        {
            //int temp = 0;
            Console.WriteLine("Enter Product Code");
            int check = int.Parse(Console.ReadLine());
            var dup=products.Where(x=>x.pCode == check).ToList();
            if(dup.Count == 0)
            {
                pCode = check;
                Console.WriteLine("Enter Product Name");
                pName = Console.ReadLine();
                Console.WriteLine("Enter Quantity in Stock");
                qtyInStock = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Discount Allowed");
                discountAllowed = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter price of product");
                amount = double.Parse(Console.ReadLine());
                AddProduct(pCode, pName, qtyInStock, discountAllowed, amount);
                
            }
            else
            {
                Console.WriteLine("Duplicate Product Codes not allowed.");
            }
           
        }           
            
               public void DisplayDetails()
        {
                for(var i = 0;i<products.Count;i++)
                {
                    Console.WriteLine(products[i].pCode);
                    Console.WriteLine(products[i].pName);
                    Console.WriteLine(products[i].qtyInStock);
                    Console.WriteLine(products[i].discountAllowed);
                    Console.WriteLine(brand);
                    Console.WriteLine(amount);
                }
        }

        public void AddProduct(int pCode, string pName, int qtyInStock , float discountAllowed, double amount)
        {
            products.Add(new Product
            {
                pCode = pCode,
                pName = pName,
                qtyInStock = qtyInStock,
                discountAllowed = discountAllowed,
                amount=amount
            });

        }
        public void Purchase(string purchase) { 
            var list = products.Where(x => x.pName == purchase).ToList();
            if (list.Count > 0)
            {
                foreach (var product in list)
                {
                    Console.WriteLine("Product details-->");
                    Console.WriteLine(pCode);
                    Console.WriteLine(qtyInStock);
                    Console.WriteLine(discountAllowed);
                    Console.WriteLine(brand);
                    Console.WriteLine(amount);
                }//foreach
            }//if
            else
            {
                Console.WriteLine("Product does not exist.");
            }//else
            int month= DateTime.Now.Month;
            int day= DateTime.Now.Day;
            if (month == 01 && day == 26)
            {
                double totalAmount = amount - ((amount * 50) / 100);
                Console.WriteLine("As today is 26th Jan, Company wants to give a discount of 50% on all the products");
                Console.WriteLine("The bill is "+totalAmount);
            }//if
            else
            {
                double totalAmount = amount-((amount * discountAllowed) / 100);
                Console.WriteLine("The bill is " + totalAmount);
            }//else
        }//purchase

            
        }//class
    }//namespace
