using System.Threading.Tasks;
using Forgery.BspEditor.Documents;

namespace Forgery.BspEditor.Providers.Processors
{
    public interface IBspSourceProcessor
    {
        string OrderHint { get; }
        Task AfterLoad(MapDocument document);
        Task BeforeSave(MapDocument document);
    }
}
