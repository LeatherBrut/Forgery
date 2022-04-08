using System.Numerics;
using Forgery.Rendering.Interfaces;
using Veldrid;

namespace Forgery.Rendering.Engine
{
    public class RenderContext : IUpdateable
    {
        public ResourceLoader ResourceLoader { get; }
        public GraphicsDevice Device { get; }
        public Matrix4x4 SelectiveTransform { get; set; } = Matrix4x4.Identity;

        public RenderContext(GraphicsDevice device)
        {
            Device = device;
            ResourceLoader = new ResourceLoader(this);
        }

        public void Update(long frame)
        {

        }
    }
}
