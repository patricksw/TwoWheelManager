using P5Tech.TwoWheelManager.Domain.Bases;

namespace P5Tech.TwoWheelManager.Domain.Queue
{
    public interface INotificacaoKafkaProducer
    {
        BaseResult<bool> Produce(Notificacao notificacao);
    }
}