using System.Numerics;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.BspEditor.Rendering.Viewport;
using Forgery.BspEditor.Tools.Draggable;
using Forgery.Rendering.Cameras;

namespace Forgery.BspEditor.Tools.Cordon
{
    public class CordonBoxDraggableState : BoxDraggableState
    {
        public CordonBoxDraggableState(BaseDraggableTool tool) : base(tool)
        {
        }

        public void Update()
        {
            var document = Tool.GetDocument();
            if (document == null)
            {
                State.Action = BoxAction.Idle;
            }
            else
            {
                var cordon = document.Map.Data.GetOne<CordonBounds>() ?? new CordonBounds {Enabled = false};
                State.Start = cordon.Box.Start;
                State.End = cordon.Box.End;
                State.Action = BoxAction.Drawn;
            }
        }

        public override void Click(MapDocument document, MapViewport viewport, OrthographicCamera camera,
            ViewportEvent e, Vector3 position)
        {
            //
        }

        public override bool CanDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera,
            ViewportEvent e, Vector3 position)
        {
            return false;
        }
    }
}
