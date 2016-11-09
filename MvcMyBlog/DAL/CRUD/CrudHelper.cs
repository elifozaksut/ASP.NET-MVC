using DAL.Utility;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.CRUD
{
    public class CrudHelper
    {
        private Helper _helper = null;

        public CrudHelper()
        {
            _helper = new Helper();
        }

        // Category CRUD
        #region Category CRUD
        public List<Category> CategorySelect()
        {
            using (var connection = _helper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("Select * From Category", connection);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();

                }
                SqlDataReader dr = cmd.ExecuteReader();
                List<Category> catList = new List<Category>();
                while (dr.Read())
                {
                    catList.Add(new Category() { ID = (int)dr["ID"], Name = dr["Name"].ToString() });
                }
                return catList;
            }
        }

        public bool CategoryInsert(Category model)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Category (Name,[Order]) values(@Name, @Order)", connection);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Order", model.Order);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public Category CategorySelected(int Id)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * From Category Where ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", Id);
                var reader = cmd.ExecuteReader();
                Category cat = new Category();
                while (reader.Read())
                {
                    int catID = reader.GetOrdinal("ID");
                    int catName = reader.GetOrdinal("Name");
                    int catOrder = reader.GetOrdinal("Order");

                    cat.ID = reader.GetInt32(catID);
                    cat.Name = reader.GetString(catName);
                    cat.Order = reader.GetInt32(catOrder);
                }
                return cat;

            }
        }

        public bool CategoryUpdate(Category model)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Category SET Name=@Name, [Order]= @Order WHERE ID = @ID ", connection);
                cmd.Parameters.AddWithValue("@ID", model.ID);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Order", model.Order);

                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public bool CategoryDelete(int Id)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Category Where Id=@Id", connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        #endregion


        //Author CRUD
        #region Author CRUD
        public List<Author> AuthorSelect()
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Author", connection);
                List<Author> authorList = new List<Author>();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    authorList.Add(new Author()
                    {
                        ID = (int)dr["ID"],
                        Name = dr["Name"].ToString(),
                        Surname = dr["Surname"].ToString()
                    });
                }
                return authorList;
            }
        }

        public Author AuthorSelected(int Id)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * From Author Where ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                Author model = new Author();
                while (dr.Read())
                {
                    model.ID = (int)dr["ID"];
                    model.Name = dr["Name"].ToString();
                    model.Surname = dr["Surname"].ToString();

                }
                return model;
            }
      
        }

        public bool AuthorInsert(Author model)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Author (Name, Surname) VALUES(@Name, @Surname)", connection);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Surname", model.Surname);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public bool AuthorUpdate(Author model)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Author SET Name = @Name, Surname = @Surname WHERE ID = @ID ", connection);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Surname", model.Surname);
                cmd.Parameters.AddWithValue("@ID", model.ID);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }

        public bool AuthorDelete(Author model)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Author WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", model.ID);
                return cmd.ExecuteNonQuery() > 0 ? true : false; 
            }
        }
        #endregion

        //Article CRUD
        #region Article CRUD

        public List<Article> ArticleSelect()
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * From Article", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                List<Article> articleList = new List<Article>();
                while (dr.Read())
                {
                    articleList.Add(new Article()
                    {
                        ID = (int)dr["ID"],
                        Title = dr["Title"].ToString(),
                        Content = dr["Content"].ToString(),
                        CategoryId = (int)dr["CategoryId"],
                        AuthorId = (int)dr["AuthorId"],
                        PublishDate = (DateTime)dr["PublishDate"],
                        Photo = dr["Photo"].ToString()                  
                    });

                }
                return articleList;
            }

           
        }
        public bool ArticleInsert(Article model)
        {
            using (var connection = _helper.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Article (CategoryId, AuthorId, Title , [Content] ) VALUES(@CategoryId, @AuthorId, @Title , @Content) ", connection);
                cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                cmd.Parameters.AddWithValue("@AuthorId", model.AuthorId);
                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Content", model.Content);
                           
                return cmd.ExecuteNonQuery() > 0 ? true : false;               
            }
            

        }

        #endregion

    }
}