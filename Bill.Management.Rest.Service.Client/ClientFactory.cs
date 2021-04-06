using Refit;

namespace Bill.Management.Rest.Service.Client
{
    public static class ClientFactory
    {
        public static IBillManagementClient Create(string path)
        {
            return RestService.For<IBillManagementClient>(path);
        }
    }
}