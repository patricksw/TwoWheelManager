using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Infra.File.LocalDiskFile
{
    public interface ILocalDiskImage
    {
        string DirectoryRoot { get; }

        Task CreateDirectory(string directory);
        Task Delete(string directory);
        Task<bool> Exists(string directory);
        Task<byte[]> Read(string directory);
        Task Save(string directory, byte[] file);
    }
}