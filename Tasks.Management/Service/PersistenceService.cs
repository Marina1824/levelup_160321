using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Tasks.Management.Data;

namespace Tasks.Management.Service
{
    public sealed class PersistenceService
    {
        private const string DbName = "tasks.dat.json";

        public PersistenceService()
        {
            string currentDirectory = Environment.CurrentDirectory;
            FullPath = Path.Combine(currentDirectory, DbName);
        }

        public List<UserTask> Load()
        {
            if (IsFileExist)
            {
                string body = File.ReadAllText(FullPath);

                return JsonConvert.DeserializeObject<List<UserTask>>(body);
            }

            return new List<UserTask>();
        }

        public bool Save(List<UserTask> tasks)
        {
            string body = JsonConvert.SerializeObject(tasks);

            File.WriteAllText(FullPath, body);

            return true;
        }

        private string FullPath { get; }

        private bool IsFileExist => File.Exists(FullPath);
    }
}