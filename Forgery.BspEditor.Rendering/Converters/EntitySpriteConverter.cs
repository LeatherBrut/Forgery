using System.ComponentModel.Composition;
using System.Numerics;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.BspEditor.Rendering.ChangeHandlers;
using Forgery.BspEditor.Rendering.Resources;
using Forgery.DataStructures.Geometric;
using Forgery.Rendering.Cameras;
using Forgery.Rendering.Engine;
using Forgery.Rendering.Pipelines;
using Forgery.Rendering.Primitives;
using Forgery.Rendering.Resources;

namespace Forgery.BspEditor.Rendering.Converters
{
    [Export(typeof(IMapObjectSceneConverter))]
    public class EntitySpriteConverter : IMapObjectSceneConverter
    {
        [Import] private EngineInterface _engine;

        public MapObjectSceneConverterPriority Priority => MapObjectSceneConverterPriority.DefaultLow;

        public bool ShouldStopProcessing(MapDocument document, IMapObject obj)
        {
            return false;
        }

        public bool Supports(IMapObject obj)
        {
            return obj is Entity e && GetSpriteData(e) != null;
        }

        private EntitySprite GetSpriteData(Entity e)
        {
            var es = e.Data.GetOne<EntitySprite>();
            return es != null && es.ContentsReplaced ? es : null;
        }

        public async Task Convert(BufferBuilder builder, MapDocument document, IMapObject obj, ResourceCollector resourceCollector)
        {
            var entity = (Entity) obj;
            var tc = await document.Environment.GetTextureCollection();

            var sd = GetSpriteData(entity);
            if (sd == null || !sd.ContentsReplaced) return;

            var name = sd.Name;
            var scale = sd.Scale;

            var width = entity.BoundingBox.Width;
            var height = entity.BoundingBox.Height;

            var t = await tc.GetTextureItem(name);

            var texture = $"{document.Environment.ID}::{name}";
            if (t != null) resourceCollector.RequireTexture(t.Name);

            var tint = sd.Color.ToVector4();

            var flags = VertexFlags.None;
            if (entity.IsSelected) flags |= VertexFlags.SelectiveTransformed;

            builder.Append(
                new [] { new VertexStandard { Position = entity.Origin, Normal = new Vector3(width, height, 0), Colour = Vector4.One, Tint = tint, Flags = flags } },
                new [] { 0u },
                new [] { new BufferGroup(PipelineType.BillboardAlpha, CameraType.Perspective, entity.BoundingBox.Center, texture, 0, 1) }
            );

        }
    }
}