using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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
        double bill;
        List<Product> products =new List<Product>();
        List<Product> carts = new List<Product>();
        public Product()
        {
            pCode = 1;
        }
        public Product(int pCode, string pName, int qtyInStock, float discountAllowed , double amount, double bill)
        {
            this.pCode = pCode;
            this.pName = pName;
            this.qtyInStock = qtyInStock;
            this.discountAllowed = discountAllowed;
            this.amount = amount;
            this.bill = bill;
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
                    Console.WriteLine(products[i].amount);
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
                amount=amount,
            });

        }
        public void Purchase() {
            Console.WriteLine("Enter Product Name to Purchase");
            string purchase = Console.ReadLine();
            var list = products.Where(x => x.pName == purchase).ToList();
            if (list.Count == 1)
            {
                foreach (var product in list)
                {
                    Console.WriteLine("Product details-->");
                    Console.WriteLine(product.pCode);
                    Console.WriteLine(product.qtyInStock);
                    Console.WriteLine(product.discountAllowed);
                    Console.WriteLine(brand);
                    Console.WriteLine(product.amount);

                    string offer = DateTime.Now.ToString("MMMM dd");
                    if (offer.Equals("January 26"))
                    {
                        product.bill = product.amount - ((product.amount * 50) / 100);
                        Console.WriteLine("As today is 26th Jan, Company wants to give a discount of 50% on all the products");
                        Console.WriteLine("The bill is " + product.bill);
                    }//if
                    else
                    {
                        product.bill = product.amount - ((product.amount * product.discountAllowed) / 100);
                        Console.WriteLine("The bill is " + product.bill);
                    }//else
                    AddToCart(product.pCode, product.pName, product.qtyInStock, product.discountAllowed, product.amount, product.bill);
                }//foreach
            }//if
            else
            {
                Console.WriteLine("Product does not exist.");
            }//else
            
        }//purchase
        public void AddToCart(int pCode, string pName, int qtyInStock, float discountAllowed, double amount, double bill)
        {
            carts.Add(new Product
            {
                pCode = pCode,
                pName = pName,
                qtyInStock = qtyInStock,
                discountAllowed = discountAllowed,
                amount = amount,
                bill = bill
            });
        }
        public void DisplayCart()
        {
            for (var i = 0; i < carts.Count; i++)
            {
                Console.WriteLine(carts[i].pCode);
                Console.WriteLine(carts[i].pName);
                Console.WriteLine(carts[i].qtyInStock);
                Console.WriteLine(carts[i].discountAllowed);
                Console.WriteLine(brand);
                Console.WriteLine(carts[i].amount);
                Console.WriteLine(carts[i].bill);
            }

        }
        public void TotalAmount()
        {
            double sum=0.0;
            for (var i = 0; i < carts.Count; i++)
            {
                sum += carts[i].bill;
            }
            Console.WriteLine("Total amount to be paid is" + sum);
        }
            
        }//class
    }//namespace
