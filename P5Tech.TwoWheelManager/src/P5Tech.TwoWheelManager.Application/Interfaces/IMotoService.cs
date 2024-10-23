using P5Tech.TwoWheelManager.Application.Requests;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.Interfaces
{
    public interface IMotoService
    {
        Task<string> Save(MotoRequest request);
    }
}