using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Repositories
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocument(string id);
        Task SaveDocument(Document document, bool force);
    }
}