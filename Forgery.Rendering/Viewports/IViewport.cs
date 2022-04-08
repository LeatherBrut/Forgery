using System;
using System.Windows.Forms;
using Forgery.Rendering.Cameras;
using Forgery.Rendering.Overlay;

namespace Forgery.Rendering.Viewports
{
    public interface IViewport : IRenderTarget
    {
        int ID { get; }

        int Width { get; }
        int Height { get; }
        Control Control { get; }
        bool IsFocused { get; }

        ICamera Camera { get; set; }
        ViewportOverlay Overlay { get; }

        void Update(long frame);
        event EventHandler<long> OnUpdate;
    }
}