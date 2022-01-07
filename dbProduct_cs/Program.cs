using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace Exer10_1
{
    public class Product
    {
        public int IDproduct;
        public string productName;
        public decimal price;

        public void PrintInfoProduct()
        {
            Console.Write(IDproduct + " " + productName + " " + price);
            Console.WriteLine();
        }
    }

    public class Seller
    {
        public int IDSeller;
        public string SellerName;
        public int TimeWork;

        public void PrintInfoSeller()
        {
            Console.Write(IDSeller + " " + SellerName + " " + TimeWork);
            Console.WriteLine();
        }
    }



    class Program
    {

        static int GetNewProductId(List<Product> products)
        {
            int NewIDProduct = products.Max(X => X.IDproduct);
            return NewIDProduct + 1;
        }

        static public int GetNewSellerId(List<Seller> sellers)
        {
            int NewIDSeller = sellers.Max(x => x.IDSeller);
            return NewIDSeller + 1;
        }

        static void Main(string[] args)
        {
            List<Product> products = DatabaseConnector.GetProducts();
            List<Seller> sellers = DatabaseConnector.GetSaller();
            
                char variant = ' ';
            do
            {
                do
                {
                    //Console.Clear();
                    Console.WriteLine("\nShow Table\nTable 1(Product) - 1 \nTable 2(Seller) - 2 \nEverything Table - * \nExit - e");
                    Console.Write(">> ");
                    variant = Char.Parse(Console.ReadLine());
                } while (variant != '1' && variant != '2' && variant != '*' && variant != 'e');

               // Console.Clear();

                switch (variant)
                {
                    case '1'://Таблица продуктов
                        {
                            Console.WriteLine("\tInformation about products");
                            foreach (Product item in products)
                                item.PrintInfoProduct();

                            //=====//
                            char productQuary;
                            do
                            {
                                Console.WriteLine("INSERT - 1\nDELETE FROM TABLE - 2\nUPDATE - 3\nCheck Table - *\nBack - \\");
                                Console.Write(">> ");
                                productQuary = char.Parse(Console.ReadLine());//запрос
                            } while (productQuary != '1' && productQuary != '2' && productQuary != '3' && productQuary != '*' && productQuary != '\\');

                            switch (productQuary)
                            {
                                case '1'://INSERT
                                    {
                                        Console.WriteLine("Input name product: ");
                                        string nameProduct = Console.ReadLine();
                                        Console.WriteLine("Input price product: ");
                                        decimal priceProduct = Convert.ToDecimal(Console.ReadLine());

                                        Product newProduct = new Product();
                                        newProduct.IDproduct = GetNewProductId(products);
                                        newProduct.productName = nameProduct;
                                        newProduct.price = priceProduct;

                                        //Подключаем его к таблице
                                        DatabaseConnector.AddProduct(newProduct);
                                        products.Add(newProduct);
                                        //Если добавилось, сообщение о успехн
                                    }
                                    break;

                                case '2'://DELETE
                                    {
                                        Console.WriteLine("Input IDProduct: ");
                                        int IDdelete = Convert.ToInt32(Console.ReadLine());
                                        var deleteProduct = products.Where(x => x.IDproduct == IDdelete).First();
                                        DatabaseConnector.DeleteProduct(deleteProduct);
                                        products.Remove(deleteProduct);
                                    }
                                    break;

                                    
                                case '3'://UPDATE
                                    {
                                        char quaryUPDATE;
                                        do
                                        {
                                            /*
                                            Console.WriteLine("Input IDProduct for update: ");
                                            int indexUpdateProduct = Convert.ToInt32(Console.ReadLine());
                                            Product updateProduct = products[indexUpdateProduct - 1];    
                                            */
                                            Console.WriteLine("Input IDProduct: ");
                                            int IDupdate = Convert.ToInt32(Console.ReadLine());
                                            var updateProduct = products.Where(x => x.IDproduct == IDupdate).First();
                                            do
                                            {
                                                Console.WriteLine("UPDATE:\n1.ProductName\n2.ProductPrice\n#.ProductName&ProductPrice\n\\.Back");
                                                Console.Write(">> ");
                                                quaryUPDATE = char.Parse(Console.ReadLine());
                                            } while (quaryUPDATE != '1' && quaryUPDATE != '2' && quaryUPDATE != '#' && quaryUPDATE != '\\');

                                            switch (quaryUPDATE)
                                            {
                                                //pN-ProductName
                                                //pP-ProductPrice
                                                case '1':
                                                    {
                                                        Console.WriteLine("Input new ProductName: ");
                                                        string pN = Console.ReadLine();
                                                        updateProduct.productName = pN;
                                                        DatabaseConnector.UpdateProduct(updateProduct);
                                                    }
                                                    break;
                                                case '2':
                                                    {
                                                        Console.WriteLine("Input new ProductNPrice: ");
                                                        decimal pP = Convert.ToDecimal(Console.ReadLine());
                                                        updateProduct.price = pP;
                                                        DatabaseConnector.UpdateProduct(updateProduct);
                                                    }
                                                    break;
                                                case '#':
                                                    {
                                                        Console.WriteLine("Input new ProductName: ");
                                                        string pN = Console.ReadLine();
                                                        updateProduct.productName = pN;

                                                        Console.WriteLine("Input new ProductNPrice: ");
                                                        decimal pP = Convert.ToDecimal(Console.ReadLine());
                                                        updateProduct.price = pP;
                                                        DatabaseConnector.UpdateProduct(updateProduct);
                                                    }
                                                    break;
                                                case '\\':
                                                    {

                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }//Swich(quaryUPDATE)
                                            Console.WriteLine("UPDATE one more Y/N: ");
                                            Console.Write(">> ");
                                            quaryUPDATE = Char.Parse(Console.ReadLine());
                                        } while (quaryUPDATE =='Y' && quaryUPDATE == 'y' && quaryUPDATE != 'N' && quaryUPDATE != 'n');
                                    }//Case UPDATE
                                       break;
                         
                                case '*'://CHECKTABLE
                                    {
                                            Console.WriteLine("\tInformation about products");
                                            foreach (Product item in products)
                                                item.PrintInfoProduct();
                                    }
                                    break;
                                case '\\'://BACK
                                    {

                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;

                    case '2'://Прадовец 
                        {
                            Console.WriteLine("\tInformation about sellers");
                            foreach (Seller seller in sellers)
                                seller.PrintInfoSeller();
                            //=====//
                            char sellerQuary;
                            do
                            {
                                Console.WriteLine("INSERT - 1\nDELETE FROM TABLE - 2\nUPDATE - 3\nCheck Table - *\nBack - \\");
                                Console.Write(">> ");
                                sellerQuary = char.Parse(Console.ReadLine());//запрос
                            } while (sellerQuary != '1' && sellerQuary != '2' && sellerQuary != '3' && sellerQuary != '*' && sellerQuary != '\\');

                            switch (sellerQuary)
                            {
                                case '1'://INSERT
                                    {
                                        Console.WriteLine("Input name seller: ");
                                        string nameSeller = Console.ReadLine();
                                        Console.WriteLine("Input time work: ");
                                        int timeSeller = Convert.ToInt32(Console.ReadLine());

                                        Seller newSeller = new Seller();
                                        newSeller.IDSeller = GetNewSellerId(sellers);
                                        newSeller.SellerName = nameSeller;
                                        newSeller.TimeWork = timeSeller;

                                        //Подключаем его к таблице
                                        DatabaseConnector.AddSeller(newSeller);
                                        sellers.Add(newSeller);
                                        //Если добавилось, сообщение о успехн
                                    }
                                    break;

                                case '2'://DELETE
                                    {
                                        Console.WriteLine("Input IDSeller: ");
                                        int IDdelete = Convert.ToInt32(Console.ReadLine());
                                        var deleteSeller = sellers.Where(x => x.IDSeller == IDdelete).First();
                                        DatabaseConnector.DeleteSeller(deleteSeller);
                                        sellers.Remove(deleteSeller);
                                    }
                                    break;


                                case '3'://UPDATE
                                    {
                                        char quaryUPDATE;
                                        do
                                        {
                                            /*
                                            Console.WriteLine("Input IDProduct for update: ");
                                            int indexUpdateProduct = Convert.ToInt32(Console.ReadLine());
                                            Product updateProduct = products[indexUpdateProduct - 1];    
                                            */
                                            Console.WriteLine("Input IDSeller: ");
                                            int IDupdate = Convert.ToInt32(Console.ReadLine());
                                            var updateSeller = sellers.Where(x => x.IDSeller == IDupdate).First();
                                            do
                                            {
                                                Console.WriteLine("UPDATE:\n1.SellerName\n2.TimeWork\n#.Everythink\n\\.Back");
                                                Console.Write(">> ");
                                                quaryUPDATE = char.Parse(Console.ReadLine());
                                            } while (quaryUPDATE != '1' && quaryUPDATE != '2' && quaryUPDATE != '#' && quaryUPDATE != '\\');

                                            switch (quaryUPDATE)
                                            {
                                                //sN-sellerName
                                                //tw-TimeWork
                                                
                                                case '1':
                                                    {
                                                        Console.WriteLine("Input new SellerName: ");
                                                        string sN = Console.ReadLine();
                                                        updateSeller.SellerName = sN;
                                                        DatabaseConnector.UpdateSeller(updateSeller); //добавить метод изменения параметров для продовца
                                                    }
                                                    break;
                                                case '2':
                                                    {
                                                        Console.WriteLine("Input new TimeWork: ");
                                                        int tw = Convert.ToInt32(Console.ReadLine());
                                                        updateSeller.TimeWork = tw;
                                                        DatabaseConnector.UpdateSeller(updateSeller);
                                                    }
                                                    break;
                                                case '#':
                                                    {
                                                        Console.WriteLine("Input new SellerName: ");
                                                        string sN = Console.ReadLine();
                                                        updateSeller.SellerName = sN;
                                                        DatabaseConnector.UpdateSeller(updateSeller);

                                                        Console.WriteLine("Input new TimeWork: ");
                                                        int tw = Convert.ToInt32(Console.ReadLine());
                                                        updateSeller.TimeWork = tw;
                                                        DatabaseConnector.UpdateSeller(updateSeller);
                                                    }
                                                    break;
                                                case '\\':
                                                    {

                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }//Swich(quaryUPDATE)
                                            Console.WriteLine("UPDATE one more Y/N: ");
                                            Console.Write(">> ");
                                            quaryUPDATE = Char.Parse(Console.ReadLine());
                                        } while (quaryUPDATE == 'Y' && quaryUPDATE == 'y' && quaryUPDATE != 'N' && quaryUPDATE != 'n');
                                    }//Case UPDATE
                                    break;

                                case '*'://CHECKTABLE
                                    {
                                        Console.WriteLine("\tInformation about products");
                                        foreach (Seller item in sellers)
                                            item.PrintInfoSeller();
                                    }
                                    break;
                                case '\\'://BACK
                                    {

                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;

                    case '*'://поазать все таблицы
                        {
                            Console.WriteLine("\tInformation about products");
                            foreach (Product item in products)
                                item.PrintInfoProduct();
                            Console.WriteLine();
                            Console.WriteLine("\tInformation about sellers");
                            foreach (Seller seller in sellers)
                                seller.PrintInfoSeller();
                        }
                        break;
                    default:
                        break;
                }
            } while (variant != 'e' && variant != 'E');


            Console.WriteLine("Exit");
        }
    }
}
