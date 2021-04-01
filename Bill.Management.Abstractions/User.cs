using System;
using Bill.Management.Core.Abstractions.Data;

namespace Bill.Management.Abstractions
{
    public sealed class User : BaseEntity<int>
    {
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }

        public string MiddleName { get; set; }
    }
}
