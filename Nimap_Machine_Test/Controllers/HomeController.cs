using Nimap_Machine_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Nimap_Machine_Test.Controllers
{
    public class HomeController : Controller
    {
        DataAccess_model da = new DataAccess_model();

        //product
        public ActionResult Index(int? page)
        {
            var datalist = da.Product__model().ToPagedList(page ?? 1, 10); ;
            return View(datalist);
        }
        //catogry
        public ActionResult Category(int? page)
        {
            var datalist = da.Category_model().ToPagedList(page ?? 1, 10); ;

            return View(datalist);
        }

        //insertcatogry
        public ActionResult Create()
        {
            return View();
        }

        //insertcatogry
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            DataAccess_model da = new DataAccess_model();
            Category_model model = new Category_model();
            model.CategoryId = fc["CategoryId"];
            model.CategoryName = fc["CategoryName"];
           
            bool response = da.ADDCatogryrecord(model);

            if (response == true)
            {
              
                return RedirectToAction("Category");
            }
            else
            {
                
                return RedirectToAction("Category");
            }



            
        }

        //insertproduct
        public ActionResult insertproduct()
        {
            //DataAccess_model da = new DataAccess_model();

            //var catogrylist = da.catogorylist().ToList();
            //ViewBag.list = new SelectList(catogrylist, "CategoryId", "CategoryName");

            var list = new List<string>() { "Car", "Bike" };
            ViewBag.list = list;
            return View();
        }

        //insertproduct
        [HttpPost]
        public ActionResult insertproduct(FormCollection fc)
        {
           

            DataAccess_model da = new DataAccess_model();
            var list = new List<string>() { "Car", "BIke" };
            ViewBag.list = list;


            Product__model model = new Product__model();
            model.ProductId = fc["ProductId"];
            model.ProductName = fc["ProductName"];
            
            model.CategoryId = fc["dropdown1"];

            bool response = da.ADDProductrecord(model);

            if (response == true)
            {
                
                return RedirectToAction("Index");
            }
            else
            {
             
                return RedirectToAction("Index");
            }



            
        }

        //productedit
        [HttpPost, ActionName("Edit_product")]
        public ActionResult ProductEditconform(int ProductId, FormCollection fc)
        {

            DataAccess_model da = new DataAccess_model();
            Product__model model = new Product__model();
            var list = new List<string>() { "Car", "BIke" };
            ViewBag.list = list;


            model.ProductId = fc["ProductId"];
            model.ProductName = fc["ProductName"];
            model.CategoryId = fc["DropDownList1"];
           




            bool response = da.UpdateProductdata(ProductId, model);

            if (response == true)
            {
            
                return RedirectToAction("Index");
            }
            else
            {
                
                return RedirectToAction("Index");
            }
        
           
        }

        //Productedit
        public ActionResult ProductEdit(int id)
        {
            var list = new List<string>() { "Car", "BIke" };
            ViewBag.list = list;
            var datalist = da.Product__model_Databind(id).FirstOrDefault();
            try
            {
                if (datalist == null)
                {
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
               

            }

            return View(datalist);



        }


        //catogryedit
        [HttpPost, ActionName("Edit_catogry")]
        public ActionResult CatogryEditconform(int CategoryId, FormCollection fc)
        {

            DataAccess_model da = new DataAccess_model();
            Category_model model = new Category_model();



            model.CategoryId = fc["CategoryId"];
            model.CategoryName = fc["CategoryName"];





            bool response = da.UpdateCatogrydata(CategoryId, model);

            if (response == true)
            {
                

                return RedirectToAction("Category");
            }
            else
            {
              
                return RedirectToAction("Category");
            }
         
        }

        //catogryedit
        public ActionResult CatogryEdit(int id)
        {
            var datalist = da.Category_model_Databind(id).FirstOrDefault();
            try
            {
                if (datalist == null)
                {
                    return RedirectToAction("Category");

                }
            }
            catch (Exception ex)
            {
              

            }

            return View(datalist);



        }

        //catdelet
        public ActionResult CatDelete(int id)
        {
            var datalist = da.Category_model_Databind(id).FirstOrDefault();
            try
            {
                if (datalist == null)
                {
                    
                    return RedirectToAction("Category");
                }
            }
            catch (Exception ex)
            {
                

            }

            return View(datalist);



        }
        [HttpPost, ActionName("CatDelete")]


        //catdeletconform
        public ActionResult CatDeleteconform(int Id)
        {
            string result = da.Catdelete(Id);

            try
            {
                if (result.Contains("delete"))
                {
                   
                    return RedirectToAction("Category");
                }

            }
            catch (Exception ex)
            {
               


            }
            return View();
        }





        //catdelet
        public ActionResult ProductDelete(int id)
        {
            var datalist = da.Product__model_Databind(id).FirstOrDefault();
            try
            {
                if (datalist == null)
                {
                   
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
               

            }

            return View(datalist);



        }
        [HttpPost, ActionName("ProductDelete")]


        //deletpost
        public ActionResult ProductDeleteconform(int Id)
        {
            string result = da.Productdelete(Id);

            try
            {
                if (result.Contains("delete"))
                {
                    
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                


            }
            return View();
        }

        //productlist
        public ActionResult Product_list( string searchBy, string search , int? page)
        {
            if(searchBy == "Name")
            {
                var datalist = da.Product_List().Where(X => X.ProductName.StartsWith(search) ).ToList().ToPagedList(page ?? 1,10);
                return View(datalist);
            }
            else if(searchBy == "Id")
            {
                var datalist = da.Product_List().Where(X => X.ProductId == search).ToList().ToPagedList(page ?? 1,10); 
                return View(datalist);
            }
            else
            {
                var datalist = da.Product_List().ToList().ToPagedList(page ?? 1, 10);
                return View(datalist);
            }

          
            
        }






       



    }
}