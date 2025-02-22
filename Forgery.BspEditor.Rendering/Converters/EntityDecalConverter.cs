using System.ComponentModel.Composition;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Primitives.MapObjectData;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.BspEditor.Rendering.ChangeHandlers;
using Forgery.BspEditor.Rendering.Resources;
using Forgery.DataStructures.Geometric;
using Forgery.Rendering.Engine;
using Forgery.Rendering.Resources;

namespace Forgery.BspEditor.Rendering.Converters
{
    [Export(typeof(IMapObjectSceneConverter))]
    public class EntityDecalConverter : IMapObjectSceneConverter
    {
        public MapObjectSceneConverterPriority Priority => MapObjectSceneConverterPriority.DefaultLow;

        public bool ShouldStopProcessing(MapDocument document, IMapObject obj)
        {
            return true;
        }

        public bool Supports(IMapObject obj)
        {
            return obj is Entity && obj.Data.OfType<EntityDecal>().Any();
        }

        public async Task Convert(BufferBuilder builder, MapDocument document, IMapObject obj, ResourceCollector resourceCollector)
        {
            var faces = obj.Data.Get<EntityDecal>().SelectMany(x => x.Geometry).ToList();
            await DefaultSolidConverter.ConvertFaces(builder, document, obj, faces, resourceCollector);

            var origin = obj.Data.GetOne<Origin>()?.Location ?? obj.BoundingBox.Center;
            await DefaultEntityConverter.ConvertBox(builder, obj, new Box(origin - Vector3.One * 4, origin + Vector3.One * 4));
        }
    }
}