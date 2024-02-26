using CSharpTodolist.Models;
using CSharpTodolist.Utils;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace CSharpTodolist.Service
{
    public class CRUDService : DBhelper
    {
        public int Create(TodoList todo)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO todo_list (Title, Content, CreateDate, UpdateDate) VALUES (@title, @content, @createDate, @updateDate)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", todo.Title);
                    cmd.Parameters.AddWithValue("@content", todo.Content);
                    cmd.Parameters.AddWithValue("@createDate", todo.CreateDate);
                    cmd.Parameters.AddWithValue("@updateDate", todo.UpdateDate);
                    cmd.Parameters.AddWithValue("@id", todo.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable FindOne(int id) {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from todo_list where Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                
            }
            return dataTable;
        }

        public DataTable Read()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM todo_list";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public void Update(TodoList todo)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE todo_list SET Title = @title, Content = @content, CreateDate = @createDate, UpdateDate = @updateDate WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", todo.Title);
                    cmd.Parameters.AddWithValue("@content", todo.Content);
                    cmd.Parameters.AddWithValue("@createDate", todo.CreateDate);
                    cmd.Parameters.AddWithValue("@updateDate", todo.UpdateDate);
                    cmd.Parameters.AddWithValue("@id", todo.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM todo_list WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TodoList> ConvertDataTableToList(DataTable dataTable)
        {
            var todoList = new List<TodoList>();

            foreach (DataRow row in dataTable. Rows)
            {
                var item = new TodoList
                {
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    CreateDate = row["CreateDate"].ToString(),
                    UpdateDate = row["UpdateDate"].ToString(),
                    Id = Convert.ToInt32(row["Id"])
                };

                todoList.Add(item);
            }

            return todoList;
        }

    }
}
