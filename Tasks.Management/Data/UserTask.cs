using System;

namespace Tasks.Management.Data
{
    [Serializable]
    public sealed class UserTask
    {
        public DateTime Create { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskPriority Priority { get; set; }
    }
}