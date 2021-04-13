using Refit;

namespace Bill.Management.Rest.Service.Client.Connection
{
    public static class ClientFactory
    {
        public static IBillManagementClient Create(string path)
        {
            return RestService.For<IBillManagementClient>(path);
        }
    }
}