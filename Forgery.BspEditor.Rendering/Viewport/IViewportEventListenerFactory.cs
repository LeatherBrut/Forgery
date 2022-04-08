using System.Collections.Generic;

namespace Forgery.BspEditor.Rendering.Viewport
{
    public interface IViewportEventListenerFactory
    {
        IEnumerable<IViewportEventListener> Create(MapViewport viewport);
    }
}