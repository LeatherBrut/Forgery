using System.Runtime.Serialization;
using Forgery.BspEditor.Primitives.MapObjects;

namespace Forgery.BspEditor.Primitives.MapObjectData
{
    /// <summary>
    /// Base interface for generic map object metadata
    /// </summary>
    public interface IMapObjectData : ISerializable, IMapElement
    {

    }
}