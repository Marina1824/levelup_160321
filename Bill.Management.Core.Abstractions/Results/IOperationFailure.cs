namespace Bill.Management.Core.Abstractions.Results
{
    public interface IOperationFailure
    {
        string PropertyName { get; }

        string Description { get; }
    }
}