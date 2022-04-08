using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Rendering.Resources;
using Forgery.Rendering.Resources;

namespace Forgery.BspEditor.Rendering.Dynamic
{
    public interface IMapObjectDynamicRenderable
    {
        void Render(MapDocument document, BufferBuilder builder, ResourceCollector resourceCollector);
    }
}