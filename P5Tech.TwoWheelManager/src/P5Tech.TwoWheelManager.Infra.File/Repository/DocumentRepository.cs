using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Infra.File.LocalDiskFile;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Infra.File.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ILocalDiskImage _localDiskImage;
        private readonly string _directory = "ImageCnh";

        public DocumentRepository(ILocalDiskImage dbFile)
        {
            _localDiskImage = dbFile;
        }

        private string BuildPath(string docName) => $"/{_directory}/{docName}.png";

        public async Task SaveDocument(Document document, bool force)
        {
            if (force)
            {
                if (await _localDiskImage.Exists(BuildPath(document.Id)))
                    await _localDiskImage.Delete(BuildPath(document.Id));

                await _localDiskImage.Save(BuildPath(document.Id), document.Content);
                return;
            }

            if (await _localDiskImage.Exists(BuildPath(document.Id)))
                throw new System.InvalidOperationException("File already exists");

            await _localDiskImage.Save(BuildPath(document.Id), document.Content);
        }


        public async Task<Document> GetDocument(string id)
        {
            if (!await _localDiskImage.Exists(BuildPath(id)))
                throw new System.InvalidOperationException("File not found");

            var doc = new Document
            {
                Id = id
            };
            doc.SetContent(await _localDiskImage.Read(BuildPath(id)));
            return doc;
        }
    }
}
