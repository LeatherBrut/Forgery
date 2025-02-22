using System.Drawing;
using System.Numerics;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Rendering.Viewport;
using Forgery.Rendering.Cameras;

namespace Forgery.BspEditor.Tools.Widgets
{
    public abstract class Widget : BaseTool
    {
        protected MapViewport ActiveViewport { get; private set; }

        public delegate void TransformEventHandler(Widget sender, Matrix4x4? transformation);
        public event TransformEventHandler Transforming;
        public event TransformEventHandler Transformed;

        public abstract bool IsUniformTransformation { get; }
        public abstract bool IsScaleTransformation { get; }

        protected void OnTransforming(Matrix4x4? transformation)
        {
            Transforming?.Invoke(this, transformation);
        }

        protected void OnTransformed(Matrix4x4? transformation)
        {
            Transformed?.Invoke(this, transformation);
        }

        public override Image GetIcon() { return null; }
        public override string GetName() { return "Widget"; }

        protected override void MouseEnter(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e)
        {
            ActiveViewport = viewport;
            base.MouseEnter(document, viewport, camera, e);
        }

        protected override void MouseEnter(MapDocument document, MapViewport viewport, PerspectiveCamera camera, ViewportEvent e)
        {
            ActiveViewport = viewport;
            base.MouseEnter(document, viewport, camera, e);
        }

        protected override void MouseLeave(MapDocument document, MapViewport viewport, OrthographicCamera camera, ViewportEvent e)
        {
            ActiveViewport = null;
            base.MouseLeave(document, viewport, camera, e);
        }

        protected override void MouseLeave(MapDocument document, MapViewport viewport, PerspectiveCamera camera, ViewportEvent e)
        {
            ActiveViewport = null;
            base.MouseLeave(document, viewport, camera, e);
        }

        public abstract void SelectionChanged();
    }
}