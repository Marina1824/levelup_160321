namespace Bill.Management.Core.Abstractions.Results
{
    public sealed class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }
        public string Description { get; set; }
    }
}