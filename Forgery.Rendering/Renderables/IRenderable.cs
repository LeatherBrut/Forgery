using System;
using System.Collections.Generic;
using System.Numerics;
using Forgery.Rendering.Engine;
using Forgery.Rendering.Pipelines;
using Forgery.Rendering.Viewports;
using Veldrid;

namespace Forgery.Rendering.Renderables
{
    public interface IRenderable : IDisposable
    {
        IEnumerable<ILocation> GetLocationObjects(IPipeline pipeline, IViewport viewport);
        bool ShouldRender(IPipeline pipeline, IViewport viewport);
        void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl);
        void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl, ILocation locationObject);
    }

    public interface ILocation
    {
        Vector3 Location { get; }
    }
}
