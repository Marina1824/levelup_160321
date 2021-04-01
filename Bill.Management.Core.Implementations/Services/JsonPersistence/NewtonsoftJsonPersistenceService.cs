using Bill.Management.Core.Abstractions.Services.JsonPersistence;
using Newtonsoft.Json;

namespace Bill.Management.Core.Implementations.Services.JsonPersistence
{
    internal sealed class NewtonsoftJsonPersistenceService : IJsonPersistenceService
    {
        public string Serialize<TItem>(TItem item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public TItem Deserialize<TItem>(string jsonBody)
        {
            return JsonConvert.DeserializeObject<TItem>(jsonBody);
        }

        /*
         * 1. Файловая система в файле. data.bin (неделя)
         * 2. Консольный файловый менеджер (неделя)
         * 3. 
         */
    }
}