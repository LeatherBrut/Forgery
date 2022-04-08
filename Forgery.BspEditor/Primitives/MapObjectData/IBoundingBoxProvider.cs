using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.DataStructures.Geometric;

namespace Forgery.BspEditor.Primitives.MapObjectData
{
    public interface IBoundingBoxProvider : IMapObjectData
    {
        Box GetBoundingBox(IMapObject obj);
    }
}
