using Forgery.BspEditor.Rendering.Resources;
using Forgery.Rendering.Resources;

namespace Forgery.BspEditor.Rendering.Dynamic
{
    public interface IDynamicRenderable
    {
        void Render(BufferBuilder builder, ResourceCollector resourceCollector);
    }
}