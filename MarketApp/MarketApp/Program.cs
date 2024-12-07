using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MarketApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductDAL pdal = new ProductDAL();
            ProductBLL pbll = new ProductBLL();
            DataSet ds = pdal.LoadDataSet();
            int Id=0;
            Product x=null;
            int opt = 1;
            do
            {
                Console.WriteLine("1.Get All Products");
                Console.WriteLine("2.Find Product By Id");
                Console.WriteLine("3.Update Price");
                Console.WriteLine("4.Delete Product By Id");
                Console.WriteLine("5.Add Product");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter your option(1/2/3/4/5/6");
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        pdal.GetAllProducts();
                        break;
                    case 2:
                        Console.WriteLine("Enter Product Id To Find: ");
                        Id = int.Parse(Console.ReadLine());
                        x = pdal.FindProductById(Id);
                        if (x != null)
                        {
                            Console.WriteLine($"Id {x.Id} Name {x.Name} Qty {x.Qty} Price {x.Price} Status {x.Status}");
                        }
                        else
                        {
                            Console.WriteLine($"Id {Id} Not Found");
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("Enter Product Id To Find and Update: ");
                            Id = int.Parse(Console.ReadLine());
                            x = pdal.FindProductById(Id);
                            if (x != null)
                            {
                                Console.WriteLine($"Id {x.Id} Name {x.Name} Qty {x.Qty} Price {x.Price} Status {x.Status}");
                                //Read new values 
                                Console.WriteLine("Enter New Price");
                                x.Price = int.Parse(Console.ReadLine());
                                //here we can update all properties with new values except Id 
                                pdal.UpdateProduct(x);
                                Console.WriteLine("Upated ");
                                pdal.GetAllProducts();

                            }
                            else
                            {
                                Console.WriteLine($"Id {Id} Not Found");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Update Failed");
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Enter Product Id To Find and Delete: ");
                            Id = int.Parse(Console.ReadLine());
                            x = pdal.FindProductById(Id);
                            if (x != null)
                            {
                                Console.WriteLine($"Id {x.Id} Name {x.Name} Qty {x.Qty} Price {x.Price} Status {x.Status}");
                                pdal.DeleteProduct(x);
                                Console.WriteLine("Deleted");
                                pdal.GetAllProducts();

                            }
                            else
                            {
                                Console.WriteLine($"Id {Id} Not Found");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Deletion Failed");
                        }
                        break;
                    case 5:
                        try
                        {
                            Product p = pbll.GetProductData();
                            pdal.AddProduct(p);
                            pdal.GetAllProducts();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("AddProduct Failed");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Option Try Again");
                        break;
                }
            } while (opt >=1 && opt <= 5);
                        
            

          


            Console.ReadKey();

        }
        
    }
}
