﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Mvc;

namespace FrozenCritters.Models
{
    public static class FrozenCrittersDb
    {
        public static bool AddProduct(Models.Products product)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand insertProd = new SqlCommand();
            insertProd.CommandText = "INSERT INTO Products (ProductsName, ProductsDescription, ProductsPrice, ProductsSalePrice, ProductsQuantity, ProductsFeature, ProductsFeatureSale, CategoriesId, ProductsPhoto, ProductsPhoto2, ProductsPhoto3, ProductsPhoto4, ProductsPhoto5) VALUES (@ProductsName, @ProductsDescription, @ProductsPrice, @ProductsSalePrice, @ProductsQuantity, @ProductsFeature, @ProductsFeatureSale, @CategoriesId, @ProductsPhoto, @ProductsPhoto2, @ProductsPhoto3, @ProductsPhoto4, @ProductsPhoto5)";
            insertProd.Connection = con;
            insertProd.Parameters.AddWithValue("@ProductsName", product.ProductsName);
            insertProd.Parameters.AddWithValue("@ProductsDescription", product.ProductsDescription);
            insertProd.Parameters.AddWithValue("@ProductsPrice", product.ProductsPrice);
            if (product.ProductsSalePrice == null)
            {
                insertProd.Parameters.AddWithValue("@ProductsSalePrice", DBNull.Value);
            }
            else
            {
                insertProd.Parameters.AddWithValue("@ProductsSalePrice", product.ProductsSalePrice);

            }
            insertProd.Parameters.AddWithValue("@ProductsQuantity", product.ProductsQuantity);
            insertProd.Parameters.AddWithValue("@ProductsFeature", product.ProductsFeature);
            insertProd.Parameters.AddWithValue("@ProductsFeatureSale", product.ProductsFeatureSale);
            if (product.CategoriesId < 1)
            {
                insertProd.Parameters.AddWithValue("@CategoriesId", DBNull.Value);
            }
            else
            {
                insertProd.Parameters.AddWithValue("@CategoriesId", product.CategoriesId);
            }
            if (product.ProductsPhoto == null)
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto", DBNull.Value);
            }
            else
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto", product.ProductsPhoto);
            }

            if (product.ProductsPhoto2 == null)
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto2", DBNull.Value);
            }
            else
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto2", product.ProductsPhoto2);
            }

            if (product.ProductsPhoto3 == null)
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto3", DBNull.Value);
            }
            else
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto3", product.ProductsPhoto3);
            }

            if (product.ProductsPhoto4 == null)
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto4", DBNull.Value);
            }
            else
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto4", product.ProductsPhoto4);

            }

            if (product.ProductsPhoto5 == null)
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto5", DBNull.Value);
            }
            else
            {
                insertProd.Parameters.AddWithValue("@ProductsPhoto5", product.ProductsPhoto5);
            }

            try
            {
                con.Open();
                int rows = insertProd.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static bool AddNews(ViewModels.AddNewsViewModel news)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand addNews = new SqlCommand();
            addNews.CommandText = "INSERT INTO News (NewsTitle, NewsDescription, NewsPostDate, NewsExpirationDate) VALUES (@NewsTitle, @NewsDescription, @NewsPostDate, @NewsExpirationDate)";
            addNews.Connection = con;
            addNews.Parameters.AddWithValue("@NewsTitle", news.NewsTitle);
            addNews.Parameters.AddWithValue("@NewsDescription", news.NewsDescription);
            addNews.Parameters.AddWithValue("@NewsPostDate", news.NewsPostDate);
            addNews.Parameters.AddWithValue("@NewsExpirationDate", news.NewsExpirationDate);

            try
            {
                con.Open();
                int rows = addNews.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static List<News> GetAllNews()
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getNews = new SqlCommand();
            getNews.CommandText = "SELECT NewsId, NewsTitle, NewsDescription, NewsPostDate, NewsExpirationDate FROM News";
            getNews.Connection = con;
            con.Open();
            SqlDataReader reader = getNews.ExecuteReader();
            var newsList = new List<News>();
            while (reader.Read())
            {
                News news = new News();
                news.NewsId = (int)reader["NewsId"];
                news.NewsTitle = reader["NewsTitle"].ToString();
                news.NewsDescription = reader["NewsDescription"].ToString();
                news.NewsPostDate = (DateTime)reader["NewsPostDate"];
                news.NewsExpirationDate = (DateTime)reader["NewsExpirationDate"];
                newsList.Add(news);
            }
            return newsList;
        }

        public static News GetNews(int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getNews = new SqlCommand();
            getNews.CommandText = "SELECT NewsId, NewsTitle, NewsDescription, NewsPostDate, NewsExpirationDate FROM News";
            getNews.Connection = con;
            con.Open();
            SqlDataReader reader = getNews.ExecuteReader();
            News news = new News();
            while (reader.Read())
            {
                news.NewsId = (int)reader["NewsId"];
                news.NewsTitle = reader["NewsTitle"].ToString();
                news.NewsDescription = reader["NewsDescription"].ToString();
                news.NewsPostDate = (DateTime)reader["NewsPostDate"];
                news.NewsExpirationDate = (DateTime)reader["NewsExpirationDate"];
            }
            return news;
        }

        public static bool EditNews(News news, int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand editNews = new SqlCommand();
            editNews.CommandText = "UPDATE News SET NewsTitle = @NewsTitle, NewsDescription = @NewsDescription, NewsPostDate = @NewsPostDate, NewsExpirationDate = @NewsExpirationDate WHERE NewsId = " + id;
            editNews.Connection = con;
            editNews.Parameters.AddWithValue("@Newstitle", news.NewsTitle);
            editNews.Parameters.AddWithValue("@NewsDescription", news.NewsDescription);
            editNews.Parameters.AddWithValue("@NewsPostDate", news.NewsPostDate);
            editNews.Parameters.AddWithValue("@NewsExpirationDate", news.NewsExpirationDate);

            try
            {
                con.Open();
                int rows = editNews.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static bool AddCategory(Models.Categories category)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand insertCategory = new SqlCommand();
            insertCategory.CommandText = "INSERT INTO Categories (CategoriesName) VALUES (@CategoriesName)";
            insertCategory.Connection = con;
            insertCategory.Parameters.AddWithValue("@CategoriesName", category.CategoriesName);

            try
            {
                con.Open();
                int rows = insertCategory.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static bool RemoveCategory(int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand removeCat = new SqlCommand();
            removeCat.CommandText = "DELETE FROM Categories WHERE CategoriesId = " + id;
            removeCat.Connection = con;

            try
            {
                con.Open();
                int rows = removeCat.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static List<Categories> GetCategories()
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getCat = new SqlCommand();
            getCat.CommandText = "SELECT CategoriesId, CategoriesName FROM Categories";
            getCat.Connection = con;
            con.Open();
            SqlDataReader reader = getCat.ExecuteReader();
            var cats = new List<Categories>();
            while (reader.Read())
            {
                Categories cat = new Categories();
                cat.CategoriesId = (int)reader["CategoriesId"];
                cat.CategoriesName = reader["CategoriesName"].ToString();
                cats.Add(cat);
            }
            return cats;
        }

        public static Categories GetCategory(int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getCat = new SqlCommand();
            getCat.CommandText = "SELECT Categoriesid, CategoriesName FROM Categories WHERE CategoriesId = " + id;
            getCat.Connection = con;
            con.Open();
            SqlDataReader reader = getCat.ExecuteReader();
            Categories cat = new Categories();
            while (reader.Read())
            {
                cat.CategoriesId = (int)reader["CategoriesId"];
                cat.CategoriesName = reader["CategoriesName"].ToString();
            }
            return cat;
        }

        public static List<Products> GetProducts()
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getProd = new SqlCommand();
            getProd.Connection = con;
            getProd.CommandText = "SELECT * FROM Products";
            con.Open();
            SqlDataReader reader = getProd.ExecuteReader();
            var prods = new List<Products>();
            while (reader.Read())
            {
                Products prod = new Products();
                prod.ProductsId = (int)reader["ProductsId"];
                prod.ProductsName = reader["ProductsName"].ToString();
                prod.ProductsDescription = reader["ProductsDescription"].ToString();
                prod.ProductsPrice = (double)reader["ProductsPrice"];
                prod.ProductsSalePrice = reader["ProductsSalePrice"] as double?;
                prod.ProductsQuantity = (int)reader["ProductsQuantity"];
                prod.ProductsFeature = (bool)reader["ProductsFeature"];
                prod.ProductsFeatureSale = (bool)reader["ProductsFeatureSale"];
                prod.ProductsPhoto = reader["ProductsPhoto"].ToString();
                prod.ProductsPhoto2 = reader["ProductsPhoto2"].ToString();
                prod.ProductsPhoto3 = reader["ProductsPhoto3"].ToString();
                prod.ProductsPhoto4 = reader["ProductsPhoto4"].ToString();
                prod.ProductsPhoto5 = reader["ProductsPhoto5"].ToString();
                prod.CategoriesId = (int)reader["CategoriesId"];
                prods.Add(prod);
            }
            return prods;
        }

        public static List<Products> GetProductsPage(int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getProds = new SqlCommand();
            getProds.CommandText = "SELECT ProductsId, ProductsName, ProductsDescription, ProductsPrice, ProductsSalePrice, ProductsQuantity, ProductsPhoto, ProductsPhoto2, ProductsPhoto3, ProductsPhoto3, ProductsPhoto4, ProductsPhoto5, CategoriesId FROM Products WHERE CategoriesId = " + id;
            getProds.Connection = con;
            con.Open();
            SqlDataReader reader = getProds.ExecuteReader();
            var prods = new List<Products>();
            while (reader.Read())
            {
                Products prod = new Products();
                prod.ProductsId = (int)reader["ProductsId"];
                prod.ProductsName = reader["ProductsName"].ToString();
                prod.ProductsDescription = reader["ProductsDescription"].ToString();
                prod.ProductsPrice = (double)reader["ProductsPrice"];
                prod.ProductsSalePrice = reader["ProductsSalePrice"] as double?;
                prod.ProductsQuantity = (int)reader["ProductsQuantity"];
                prod.ProductsPhoto = reader["ProductsPhoto"].ToString();
                prod.ProductsPhoto2 = reader["ProductsPhoto2"].ToString();
                prod.ProductsPhoto3 = reader["ProductsPhoto3"].ToString();
                prod.ProductsPhoto4 = reader["ProductsPhoto4"].ToString();
                prod.ProductsPhoto5 = reader["ProductsPhoto5"].ToString();
                prod.CategoriesId = (int)reader["CategoriesId"];
                prods.Add(prod);
            }
            return prods;
        }

        public static Products GetProd(int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getProd = new SqlCommand();
            getProd.Connection = con;
            getProd.CommandText = "SELECT * FROM Products WHERE ProductsId = " + id;
            con.Open();
            SqlDataReader reader = getProd.ExecuteReader();
            Products prod = new Products();
            while (reader.Read())
            {
                prod.ProductsId = (int)reader["ProductsId"];
                prod.ProductsName = reader["ProductsName"].ToString();
                prod.ProductsDescription = reader["ProductsDescription"].ToString();
                prod.ProductsPrice = (double)reader["ProductsPrice"];
                prod.ProductsSalePrice = reader["ProductsSalePrice"] as double?;
                prod.ProductsQuantity = (int)reader["ProductsQuantity"];
                prod.ProductsFeature = (bool)reader["ProductsFeature"];
                prod.ProductsFeatureSale = (bool)reader["ProductsFeatureSale"];
                prod.ProductsPhoto = reader["ProductsPhoto"].ToString();
                prod.ProductsPhoto2 = reader["ProductsPhoto2"].ToString();
                prod.ProductsPhoto3 = reader["ProductsPhoto3"].ToString();
                prod.ProductsPhoto4 = reader["ProductsPhoto4"].ToString();
                prod.ProductsPhoto5 = reader["ProductsPhoto5"].ToString();
                prod.CategoriesId = (int)reader["CategoriesId"];
            }
            return prod;
        }

        public static bool EditProduct(Models.Products product, int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand editProd = new SqlCommand();
            editProd.Connection = con;
            editProd.CommandText = "UPDATE Products SET ProductsName = @ProductsName, ProductsDescription = @ProductsDescription, ProductsPrice = @ProductsPrice, ProductsSalePrice = @ProductsSalePrice, ProductsQuantity = @ProductsQuantity, ProductsFeature = @ProductsFeature, ProductsFeatureSale = @ProductsFeatureSale, ProductsPhoto = @ProductsPhoto, ProductsPhoto2 = @ProductsPhoto2, ProductsPhoto3 = @ProductsPhoto3, ProductsPhoto4 = @ProductsPhoto4, ProductsPhoto5 = @ProductsPhoto5 WHERE ProductsId = " + id;
            editProd.Parameters.AddWithValue("@ProductsName", product.ProductsName);
            editProd.Parameters.AddWithValue("@ProductsDescription", product.ProductsDescription);
            editProd.Parameters.AddWithValue("@ProductsPrice", product.ProductsPrice);
            if (product.ProductsSalePrice == null)
            {
                editProd.Parameters.AddWithValue("@ProductsSalePrice", DBNull.Value);
            }
            else
            {
                editProd.Parameters.AddWithValue("@ProductsSalePrice", product.ProductsSalePrice);

            }
            editProd.Parameters.AddWithValue("@ProductsQuantity", product.ProductsQuantity);
            editProd.Parameters.AddWithValue("@ProductsFeature", product.ProductsFeature);
            editProd.Parameters.AddWithValue("@ProductsFeatureSale", product.ProductsFeatureSale);
            if (product.ProductsPhoto != null)
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto", product.ProductsPhoto);
            }
            else
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto", DBNull.Value);

            }

            if (product.ProductsPhoto2 != null)
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto2", product.ProductsPhoto2);
            }
            else
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto2", DBNull.Value);
            }

            if (product.ProductsPhoto3 != null)
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto3", product.ProductsPhoto3);
            }
            else
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto3", DBNull.Value);
            }

            if (product.ProductsPhoto4 != null)
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto4", product.ProductsPhoto4);
            }
            else
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto4", DBNull.Value);
            }

            if (product.ProductsPhoto5 != null)
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto5", product.ProductsPhoto5);
            }
            else
            {
                editProd.Parameters.AddWithValue("@ProductsPhoto5", DBNull.Value);
            }

            try
            {
                con.Open();
                int rows = editProd.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static bool AddPhotos(FrozenCritters.Models.Photos photo)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand addPhoto = new SqlCommand();
            addPhoto.CommandText = "INSERT INTO Photos (PhotosFile, PhotosName, PhotosDescription) VALUES(@PhotosFile, @PhotosName, @PhotosDescription)";
            addPhoto.Connection = con;
            addPhoto.Parameters.AddWithValue("@PhotosFile", photo.PhotosFile);
            addPhoto.Parameters.AddWithValue("@PhotosName", photo.PhotosName);
            addPhoto.Parameters.AddWithValue("@PhotosDescription", photo.PhotosDescription);

            try
            {
                con.Open();
                int rows = addPhoto.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static bool EditPhoto(FrozenCritters.Models.Photos photo, int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand editPhoto = new SqlCommand();
            editPhoto.CommandText = "UPDATE Photos SET PhotosFile = @PhotosFile,  PhotosName = @PhotosName, PhotosDescription = @PhotosDescription WHERE PhotosId = " + id;
            editPhoto.Connection = con;
            editPhoto.Parameters.AddWithValue("@PhotosFile", photo.PhotosFile);
            editPhoto.Parameters.AddWithValue("@PhotosName", photo.PhotosName);
            editPhoto.Parameters.AddWithValue("@PhotosDescription", photo.PhotosDescription);

            try
            {
                con.Open();
                int rows = editPhoto.ExecuteNonQuery();
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Dispose();
            }
        }

        public static Photos GetPhoto(int id)
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getPhoto = new SqlCommand();
            getPhoto.CommandText = "SELECT Photosid, PhotosFile, PhotosName, PhotosDescription FROM Photos WHERE PhotosId = " + id;
            getPhoto.Connection = con;
            con.Open();
            SqlDataReader reader = getPhoto.ExecuteReader();
            Photos photo = new Photos();
            while (reader.Read())
            {
                photo.PhotosId = (int)reader["PhotosId"];
                photo.PhotosFile = reader["PhotosFile"].ToString();
                photo.PhotosName = reader["PhotosName"].ToString();
                photo.PhotosDescription = reader["PhotosDescription"].ToString();
            }
            return photo;
        }

        public static List<Photos> GetAllPhotos()
        {
            string conString = WebConfigurationManager.ConnectionStrings["FrozenCrittersDb"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand getPhotos = new SqlCommand();
            getPhotos.CommandText = "SELECT PhotosId, PhotosFile, PhotosName, PhotosDescription FROM Photos";
            getPhotos.Connection = con;
            con.Open();
            SqlDataReader reader = getPhotos.ExecuteReader();
            var photos = new List<Photos>();
            while (reader.Read())
            {
                Photos photo = new Photos();
                photo.PhotosId = (int)reader["PhotosId"];
                photo.PhotosFile = reader["PhotosFile"].ToString();
                photo.PhotosName = reader["PhotosName"].ToString();
                photo.PhotosDescription = reader["PhotosDescription"].ToString();
                photos.Add(photo);
            }
            return photos;
        }
    }
}