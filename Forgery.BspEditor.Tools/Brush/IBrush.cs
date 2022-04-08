using System.Collections.Generic;
using Forgery.BspEditor.Primitives;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.BspEditor.Tools.Brush.Brushes.Controls;
using Forgery.DataStructures.Geometric;

namespace Forgery.BspEditor.Tools.Brush
{
    public interface IBrush
    {
        string Name { get; }
        bool CanRound { get; }
        IEnumerable<BrushControl> GetControls();
        IEnumerable<IMapObject> Create(UniqueNumberGenerator idGenerator, Box box, string texture, int roundDecimals);
    }
}
