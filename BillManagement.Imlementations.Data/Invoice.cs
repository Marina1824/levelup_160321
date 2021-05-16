using System.ComponentModel.DataAnnotations.Schema;
using BillManagement.Core.Abstractions.Data;

namespace BillManagement.Imlementations.Data
{
    [Table("Bill", Schema = "Test")]
    public sealed class Invoice : BaseEntity<int>
    {
        public string ShopName { get; set; }

        public double Sum { get; set; }
        
        public string Comment { get; set; }
    }
}
