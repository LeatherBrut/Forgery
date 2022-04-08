using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Transport;

namespace Forgery.BspEditor.Primitives
{
    public interface IMapElementFormatter
    {
        bool IsSupported(IMapElement obj);
        SerialisedObject Serialise(IMapElement elem);

        bool IsSupported(SerialisedObject elem);
        IMapElement Deserialise(SerialisedObject obj);
    }
}
