using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace Supermarket_WebAPI.Service
{
    public interface IMessagePublisher
    {
        Task PublisherMessage<T>(T request);
        Message MessageBuilder<T>(T request);

    }
}
