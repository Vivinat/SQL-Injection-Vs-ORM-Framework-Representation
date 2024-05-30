using InjectionClinic.Contexts;
using InjectionClinic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes; 
using System.Data;

namespace InjectionClinic.Services
{
    public class ConnectionService
    {
        private readonly UserDBContext _context;
        private readonly string connectionString = "Host=localhost;Port=5432;Database=users;Username=vinicius;Password=admin;"; 

        public ConnectionService(UserDBContext context)
        {
            _context = context;
        }


        public async Task<userinfo> StartSafeQuery(string username, string password)
        {
            userinfo user = (await _context.userinfo
                .Where(u => u.user_name == username && u.user_password == password)
                .FirstOrDefaultAsync())!;

            return user;
        }
        
        public DataTable StartUnsafeQuery(string username, string password)
        {
            string query = $"SELECT * FROM userinfo WHERE user_name = '{username}' AND user_password = '{password}'";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

    }
}
