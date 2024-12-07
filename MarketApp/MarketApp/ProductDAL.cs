using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MarketApp
{
    class ProductDAL
    {
        DataSet ds;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cb;

        public ProductDAL()
        {
            con = new SqlConnection();
            con.ConnectionString = "user id=sa;password=admin1235;server=DESKTOP-E8DR0EG;database=9to11";
            da = new SqlDataAdapter("select * from Product", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            
        }
        public DataSet LoadDataSet()
        {
            da.Fill(ds, "Product");
            return ds;
        }
        public void GetAllProducts()
        {
            
            DataTable dt = ds.Tables["Product"];
            if (dt.Rows.Count > 0)
            {
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        Console.Write(dt.Rows[r][c] + "  ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Empty Product Table");
            }
        }
        public void AddProduct(Product n)
        {
            try
            {
                DataRow newPro = ds.Tables["Product"].NewRow();
                newPro[0] = n.Id;
                newPro[1] = n.Name;
                newPro[2] = n.Qty;
                newPro[3] = n.Price;
                newPro[4] = n.Status;
                ds.Tables["Product"].Rows.Add(newPro);
                da.Update(ds, "Product");
                ds.AcceptChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public Product FindProductById(int ProId)
        {
            Product p = null;
            DataRow findRow = null;
            findRow = ds.Tables["Product"].Rows.Find(ProId);
            if(findRow !=null)
            {
                p = new Product();
                p.Id = int.Parse(findRow[0].ToString());
                p.Name = findRow[1].ToString();
                p.Qty = findRow[2].ToString();
                p.Price = int.Parse(findRow[3].ToString());
                string s = findRow[4].ToString();
                if(s.Equals("True"))
                {
                    p.Status = 1;
                }
                else
                {
                    p.Status = 0;
                }
                //p.Status = int.Parse(s);
                return p; // p with data
            }
            else
            {
                //null 
                return p;
            }
        }

        public void UpdateProduct(Product np)
        {
            try
            {
                DataRow dr = ds.Tables["Product"].Rows.Find(np.Id);
                dr[1] = np.Name;
                dr[2] = np.Qty;
                dr[3] = np.Price;
                dr[4] = np.Status;
                da.Update(ds, "Product");
                ds.AcceptChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteProduct(Product np)
        {
            try
            {
                DataRow dr = ds.Tables["Product"].Rows.Find(np.Id);
                int rowno = ds.Tables["Product"].Rows.IndexOf(dr);
                ds.Tables["Product"].Rows[rowno].Delete();
                da.Update(ds, "Product");
                ds.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
