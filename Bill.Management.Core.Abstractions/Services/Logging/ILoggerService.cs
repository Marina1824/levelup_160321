namespace Bill.Management.Core.Abstractions.Services.Logging
{
    public interface ILoggerService
    {
        void Information(string info);
        
        void Debug(string debugInfo);

        void Error(string errorInfo);
    }
}