using System;

namespace P5Tech.TwoWheelManager.Domain.Queue
{
    public interface IBaseConsumer : IDisposable
    {
        void Commit();

        string GetSubscribe();
    }
}