using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Infra.File.LocalDiskFile
{
    public class LocalDiskImage(string directory) : ILocalDiskImage
    {
        public string DirectoryRoot { get; private set; } = directory;

        public async Task Save(string directory, byte[] file) => await System.IO.File.WriteAllBytesAsync($"{DirectoryRoot}/{directory}", file);

        public async Task<byte[]> Read(string directory) => await System.IO.File.ReadAllBytesAsync($"{DirectoryRoot}/{directory}");

        public async Task<bool> Exists(string directory) => await Task.Run(() => System.IO.File.Exists($"{DirectoryRoot}/{directory}"));

        public async Task Delete(string directory) => await Task.Run(() => System.IO.File.Delete($"{DirectoryRoot}/{directory}"));

        public async Task CreateDirectory(string directory) => await Task.Run(() => System.IO.Directory.CreateDirectory($"{DirectoryRoot}/{directory}"));
    }
}