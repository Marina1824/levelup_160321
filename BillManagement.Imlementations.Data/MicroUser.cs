using BillManagement.Core.Abstractions.Data;

namespace BillManagement.Imlementations.Data
{
    public class MicroUser : BaseEntity<int>
    {
        public string Text { get; set; }
    }
}