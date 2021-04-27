using System.ComponentModel.DataAnnotations.Schema;
using BillManagement.Core.Abstractions.Data;

namespace BillManagement.Imlementations.Data
{
    [Table("User", Schema = "Test")]
    public sealed class User : BaseEntity<int>
    {
        public string Text { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
