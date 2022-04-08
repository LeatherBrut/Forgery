using System.Numerics;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Rendering.Viewport;
using Forgery.BspEditor.Tools.Draggable;
using Forgery.Rendering.Cameras;

namespace Forgery.BspEditor.Tools.Selection.TransformationHandles
{
    public interface ITransformationHandle : IDraggable
    {
        string Name { get; }
        Matrix4x4? GetTransformationMatrix(MapViewport viewport, OrthographicCamera camera, BoxState state, MapDocument doc);
        TextureTransformationType GetTextureTransformationType(MapDocument doc);
    }
}
