using System.Runtime.Serialization;
using Forgery.BspEditor.Primitives;
using Forgery.BspEditor.Primitives.MapObjectData;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Transport;

namespace Forgery.BspEditor.Tools.Vertex.Selection
{
    public class VertexHidden : IMapObjectData, IRenderVisibility
    {
        public bool IsRenderHidden => true;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Not serialisable
        }

        public SerialisedObject ToSerialisedObject()
        {
            // Not serialisable
            return null;
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public IMapElement Clone()
        {
            return new VertexHidden();
        }

    }
}
