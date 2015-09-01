namespace Haep.Core.SOA
{
    public interface IServiceAgent
    {
        TResponse Request<TRequest, TResponse>(string name, TRequest request);
    }
}