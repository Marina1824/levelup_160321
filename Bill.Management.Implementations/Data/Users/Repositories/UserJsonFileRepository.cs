using System;
using System.Collections.Generic;
using System.IO;
using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Abstractions.Exceptions;
using Bill.Management.Core.Abstractions.Services.JsonPersistence;

namespace Bill.Management.Implementations.Data.Users.Repositories
{
    internal sealed class UserJsonFileRepository : IUserRepository
    {
        private const string UsersFileName = "users.json";

        private readonly IJsonPersistenceService _jsonPersistenceService;
        private readonly string _fullUserFilePath;

        public UserJsonFileRepository(IJsonPersistenceService jsonPersistenceService)
        {
            _jsonPersistenceService = jsonPersistenceService;
            string currentDirectory = Environment.CurrentDirectory;

            _fullUserFilePath = Path.Combine(currentDirectory, UsersFileName);
        }

        public IReadOnlyList<User> Read()
        {
            List<User> users = ReadFile();

            if (users is null)
            {
                return ArraySegment<User>.Empty;
            }

            return users;
        }

        public void Create(User data)
        {
            IList<User> users = ReadFile();

            if (users is null)
            {
                users = new List<User>(1);
            }

            data.Id = users.Count + 1;

            users.Add(data);

            SaveUsers(users);
        }

        public void Update(User data)
        {
            IList<User> users = ReadFile();

            if (users is null)
            {
                throw new UserRepositoryFailureException();
            }

            for (int index = 0; index < users.Count; index++)
            {
                User user = users[index];

                if (user.Id == data.Id)
                {
                    users[index] = data;

                    SaveUsers(users);

                    return;
                }
            }

            Create(data);
        }

        public void Delete(int id)
        {
            IList<User> users = ReadFile();

            if (users is null)
            {
                throw new UserRepositoryFailureException();
            }

            for (int index = 0; index < users.Count; index++)
            {
                User user = users[index];

                if (user.Id == id)
                {
                    user.IsDeleted = true;

                    SaveUsers(users);
                }
            }

            throw new DeleteUserRepositoryFailureException();
        }

        private void SaveUsers(IList<User> users)
        {
            string jsonBody = _jsonPersistenceService.Serialize<IList<User>>(users);

            File.WriteAllText(_fullUserFilePath, jsonBody);
        }

        private List<User> ReadFile()
        {
            if (File.Exists(_fullUserFilePath))
            {
                string body = File.ReadAllText(_fullUserFilePath);

                IList<User> users = _jsonPersistenceService.Deserialize<List<User>>(body);

                List<User> finalUsersList = new List<User>();

                foreach (User user in users)
                {
                    if (user.IsDeleted)
                    {
                        continue;
                    }

                    finalUsersList.Add(user);
                }

                return finalUsersList;
            }

            return null;
        }
    }
}