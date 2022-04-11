using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Nimap_Machine_Test.Models
{
    public class DataAccess_model
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        //AddCatogryrecord
        public bool ADDCatogryrecord(Category_model cat)
        {
            SqlCommand com = new SqlCommand("Category_master_curd ", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", cat.CategoryId);
            com.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
            com.Parameters.AddWithValue("@Action", "INSERT");
           
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //AddProductrecord
        public bool ADDProductrecord(Product__model p)
        {
            SqlCommand com = new SqlCommand("Product_master_curd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productId", p.ProductId);
            com.Parameters.AddWithValue("@ProductName", p.ProductName);
           
            if (p.CategoryId == "Car")
            {
                com.Parameters.AddWithValue("@CategoryId", 1);
            }else if ( p.CategoryId == "Bike")
            {
                com.Parameters.AddWithValue("@CategoryId", 2);
            }

            com.Parameters.AddWithValue("@Action","INSERT");
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Categorydatabind
        public List<Category_model> Category_model()
        {
            

            List<Category_model> Category_model = new List<Category_model>();
            SqlCommand com = new SqlCommand("Category_master_curd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "SELECT");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dtuser = new DataTable();
            con.Open();
            da.Fill(dtuser);
            con.Close();

            foreach (DataRow dr in dtuser.Rows)
            {
                Category_model.Add(new Category_model
                {
                    CategoryId = dr["CategoryId"].ToString(),
                    CategoryName =dr["CategoryName"].ToString(),
                });



            }


            return Category_model.ToList();

        }


        //Productdatabind
        public List<Product__model> Product__model()
        {
          

            List<Product__model> Product__model = new List<Product__model>();
            SqlCommand com = new SqlCommand("Product_master_curd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "SELECT");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dtuser = new DataTable();
            con.Open();
            da.Fill(dtuser);
            con.Close();

            foreach (DataRow dr in dtuser.Rows)
            {
                Product__model.Add(new Product__model
                {
                    ProductId = dr["productId"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                    CategoryId = dr["CategoryId"].ToString(),
                });



            }


            return Product__model.ToList();

        }

        //productlist
        public List<Product_List> Product_List()
        {


            List<Product_List> Product_List = new List<Product_List>();
             SqlCommand com = new SqlCommand("SELECT Product_master.productId,Product_master.ProductName, Category_master.CategoryId,Category_master.CategoryName FROM Product_master INNER JOIN Category_master ON Product_master.CategoryId = Category_master.CategoryId; ", con);
          
            com.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dtuser = new DataTable();
            con.Open();
            da.Fill(dtuser);
            con.Close();

            foreach (DataRow dr in dtuser.Rows)
            {
                Product_List.Add(new Product_List
                {
                    ProductId = dr["ProductId"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                    CategoryId=dr["CategoryId"].ToString(),
                    CategoryName=dr["CategoryName"].ToString(),
                });



            }


            return Product_List.ToList();

        }

        //bindcatogrydata
        public List<Category_model> Category_model_Databind(int Id)
        {
            List<Category_model> getalldatalist1 = new List<Category_model>();

            SqlCommand com = new SqlCommand("Category_master_curd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", Id);
            com.Parameters.AddWithValue("@Action", "SELECT2");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dtuser = new DataTable();
            con.Open();
            da.Fill(dtuser);
            con.Close();

            foreach (DataRow dr in dtuser.Rows)
            {
                getalldatalist1.Add(new Category_model
                {
                    CategoryId = dr["CategoryId"].ToString(),
                    CategoryName = dr["CategoryName"].ToString(),
                 

                });
            }


            return getalldatalist1;

        }


        //binddeletepagedata
        public List<Product__model> Product__model_Databind(int id)
        {
            List<Product__model> getalldatalist1 = new List<Product__model>();

            SqlCommand com = new SqlCommand("select * from Product_master where ProductId=@ProductId", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@productId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dtuser = new DataTable();
            con.Open();
            da.Fill(dtuser);
            con.Close();

            foreach (DataRow dr in dtuser.Rows)
            {
                getalldatalist1.Add(new Product__model
                {
                    ProductId = dr["productId"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                   

                });
            
            }


            return getalldatalist1;

        }

        //Catdelete
        public string Catdelete(int Id)
        {
            string result = "";


            SqlCommand com = new SqlCommand("Category_master_curd ", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", Id);
            com.Parameters.AddWithValue("@Action", "DELETE");
            con.Open();
            int i = com.ExecuteNonQuery();
            if (i == 1)
            {
                result = "delete";
            }
            else
            {
                result = "Not delete";
            }


            return result;


        }

        //Productdelete
        public string Productdelete(int Id)
        {
            string result = "";


            SqlCommand com = new SqlCommand("Product_master_curd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productId", Id);
            com.Parameters.AddWithValue("@Action", "DELETE");
            con.Open();
            int i = com.ExecuteNonQuery();
            if (i == 1)
            {
                result = "delete";
            }
            else
            {
                result = "Not delete";
            }


            return result;


        }

        //UpdateCatogrydata
        public bool UpdateCatogrydata(int CategoryId, Category_model model)
        {

            SqlCommand com = new SqlCommand("Category_master_curd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", CategoryId);
            com.Parameters.AddWithValue("@CategoryName", model.CategoryName);
            com.Parameters.AddWithValue("@Action", "UPDATE");
           
            con.Open();
            int i = com.ExecuteNonQuery();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //UpdateProductdata
        public bool UpdateProductdata(int ProductId, Product__model model)
        {

            SqlCommand com = new SqlCommand("Product_master_curd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productId", ProductId);
            com.Parameters.AddWithValue("@ProductName", model.ProductName);
            if (model.CategoryId == "Car")
            {
                com.Parameters.AddWithValue("@CategoryId", 1);
            }
            else if (model.CategoryId == "BIke")
            {
                com.Parameters.AddWithValue("@CategoryId", 2);
            }
            
            com.Parameters.AddWithValue("@Action", "UPDATE");
          
        

            con.Open();
            int i = com.ExecuteNonQuery();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        //binddropdown
        //public List<Category_model> catogorylist()
        //{


        //    List<Category_model> catogorylist = new List<Category_model>();
        //    SqlCommand com = new SqlCommand(" SELECT * FROM Category_master; ", con);

        //    com.CommandType = CommandType.Text;

        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dtuser = new DataTable();
        //    con.Open();
        //    da.Fill(dtuser);
        //    con.Close();

        //    foreach (DataRow dr in dtuser.Rows)
        //    {
        //        catogorylist.Add(new Category_model
        //        {
                    
        //            CategoryId = dr["CategoryId"].ToString(),
        //            CategoryName = dr["CategoryName"].ToString(),
        //        });



        //    }


        //    return catogorylist.ToList();

        //}

    }
}