namespace BillManagement.Core.Abstractions.Data.Results
{
    public sealed class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }
        public string Description { get; set; }
    }
}