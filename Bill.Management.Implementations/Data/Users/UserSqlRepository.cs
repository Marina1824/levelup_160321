using System;
using System.Collections.Generic;
using System.Data;
using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Core.Abstractions.Logging;
using Npgsql;

namespace Bill.Management.Implementations.Data.Users
{
    internal sealed class UserSqlRepository : IUserRepository
    {
        private readonly ILoggerService _loggerService;
        private readonly NpgsqlConnection _connection;

        public UserSqlRepository(ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _connection = new NpgsqlConnection("Host=192.168.1.72;Database=LevelUp;Username=postgres;Password=qwe123;");
        }

        public IReadOnlyList<User> Read()
        {
            string query = "set search_path = \"Test\";" +
                           "SELECT * FROM \"Simple\";";

            using (NpgsqlCommand command = new NpgsqlCommand(query, Connection))
            {
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string text = reader.GetString(1);
                    }
                }
            }

            return ArraySegment<User>.Empty;
        }

        public void Create(User data)
        {
            string query = "set search_path = \"Test\";" +
                           "INSERT INTO \"Simple\" VALUES(@id, @firstName);";

            using (NpgsqlCommand command = new NpgsqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("id", data.Id);
                command.Parameters.AddWithValue("firstName", data.FirstName);

                int count = command.ExecuteNonQuery();
            }
        }

        public void Update(User data)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        private NpgsqlConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }
    }
}