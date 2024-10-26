using P5Tech.TwoWheelManager.Domain.Bases;
using System.Threading;

namespace P5Tech.TwoWheelManager.Domain.Queue
{
    public interface INotificacaoKafkaConsumer : IBaseConsumer
    {
        BaseResult<T> Consume<T>(CancellationToken cancellationToken = default);
    }
}