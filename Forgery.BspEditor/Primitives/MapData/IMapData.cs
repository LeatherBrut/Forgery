using System.Runtime.Serialization;
using Forgery.BspEditor.Primitives.MapObjects;

namespace Forgery.BspEditor.Primitives.MapData
{
    /// <summary>
    /// Base interface for generic map metadata
    /// </summary>
    public interface IMapData : ISerializable, IMapElement
    {
        bool AffectsRendering { get; }
    }
}