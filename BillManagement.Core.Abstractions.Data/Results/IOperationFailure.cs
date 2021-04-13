namespace BillManagement.Core.Abstractions.Data.Results
{
    public interface IOperationFailure
    {
        string PropertyName { get; }

        string Description { get; }
    }
}