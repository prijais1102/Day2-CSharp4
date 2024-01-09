namespace Day2CSharp
{
    internal class Product
    {
        readonly int pCode;
        string pName;
        int qtyInStock;
        float discountAllowed;
        static string brand;

        public Product()
        {
            pCode = 10105;
        }
        public Product(int pCode, string pName, int qtyInStock, float discountAllowed)
        {
            this.pCode = pCode;
            this.pName = pName;
            this.qtyInStock = qtyInStock;
            this.discountAllowed = discountAllowed;
        }

        static Product ()
        {
            brand = "Lewis";
        }

        public void GetProductDetails()
        {
            Console.WriteLine("Enter Product Name");
            pName = Console.ReadLine();
            Console.WriteLine("Enter Quantity in Stock");
            qtyInStock=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Discount Allowed");
            discountAllowed = float.Parse(Console.ReadLine());
        }

        public void DisplayDetails()
        {
            Console.WriteLine(pCode);
            Console.WriteLine(pName); 
            Console.WriteLine(qtyInStock);
            Console.WriteLine(discountAllowed);
            Console.WriteLine(brand);
        }
        //static void Main(string[] args)
        //{
            

        //    Console.WriteLine("Hello, World!");
        //}
    }
}
