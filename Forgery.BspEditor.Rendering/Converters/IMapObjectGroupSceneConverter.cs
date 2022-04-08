using System.Collections.Generic;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.BspEditor.Rendering.Resources;
using Forgery.Rendering.Resources;

namespace Forgery.BspEditor.Rendering.Converters
{
    /// <summary>
    /// Converts a group of <see cref="IMapObject"/>s for rendering.
    /// </summary>
    public interface IMapObjectGroupSceneConverter
    {
        /// <summary>
        /// The priority of this converter.
        /// </summary>
        MapObjectSceneConverterPriority Priority { get; }

        /// <summary>
        /// Convert a list of MapObjects and add the data in the buffer.
        /// </summary>
        /// <param name="builder">The buffer builder</param>
        /// <param name="document">The current document</param>
        /// <param name="objects">The group of objects to convert</param>
        /// <param name="resourceCollector">A resource collecter to precache resources</param>
        Task Convert(BufferBuilder builder, MapDocument document, IEnumerable<IMapObject> objects, ResourceCollector resourceCollector);
    }
}