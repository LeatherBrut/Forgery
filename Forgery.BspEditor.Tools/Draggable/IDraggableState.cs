using System.Collections.Generic;

namespace Forgery.BspEditor.Tools.Draggable
{
    public interface IDraggableState : IDraggable
    {
        IEnumerable<IDraggable> GetDraggables();
    }
}