using System.Collections.Generic;
using System.Numerics;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Rendering.Cameras;
using Forgery.Rendering.Overlay;
using Forgery.Rendering.Viewports;

namespace Forgery.BspEditor.Rendering.Overlay
{
    public interface IMapObject2DOverlay
    {
        void Render(IViewport viewport, ICollection<IMapObject> objects, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
    }
}