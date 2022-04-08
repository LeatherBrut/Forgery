using Forgery.BspEditor.Documents;
using Forgery.Rendering.Overlay;

namespace Forgery.BspEditor.Rendering.Overlay
{
    public interface IMapDocumentOverlayRenderable : IOverlayRenderable
    {
        void SetActiveDocument(MapDocument doc);
    }
}