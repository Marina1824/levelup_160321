namespace Bill.Management.Core.Abstractions.Services.JsonPersistence
{
    public interface IJsonPersistenceService
    {
        string Serialize<TItem>(TItem item);

        TItem Deserialize<TItem>(string jsonBody);
    }
}