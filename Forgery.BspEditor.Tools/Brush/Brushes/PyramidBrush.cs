using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Numerics;
using Forgery.BspEditor.Primitives;
using Forgery.BspEditor.Primitives.MapObjectData;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.BspEditor.Tools.Brush.Brushes.Controls;
using Forgery.Common;
using Forgery.Common.Shell.Components;
using Forgery.Common.Translations;
using Forgery.DataStructures.Geometric;
using Plane = Forgery.DataStructures.Geometric.Plane;

namespace Forgery.BspEditor.Tools.Brush.Brushes
{
    [Export(typeof(IBrush))]
    [OrderHint("C")]
    [AutoTranslate]
    public class PyramidBrush : IBrush
    {
        public string Name { get; set; } = "Pyramid";
        public bool CanRound => true;

        public IEnumerable<BrushControl> GetControls()
        {
            return new List<BrushControl>();
        }

        public IEnumerable<IMapObject> Create(UniqueNumberGenerator generator, Box box, string texture, int roundDecimals)
        {
            var solid = new Solid(generator.Next("MapObject"));
            solid.Data.Add(new ObjectColor(Colour.GetRandomBrushColour()));

            // The lower Z plane will be base
            var c1 = new Vector3(box.Start.X, box.Start.Y, box.Start.Z).Round(roundDecimals);
            var c2 = new Vector3(box.End.X, box.Start.Y, box.Start.Z).Round(roundDecimals);
            var c3 = new Vector3(box.End.X, box.End.Y, box.Start.Z).Round(roundDecimals);
            var c4 = new Vector3(box.Start.X, box.End.Y, box.Start.Z).Round(roundDecimals);
            var c5 = new Vector3(box.Center.X, box.Center.Y, box.End.Z).Round(roundDecimals);
            var faces = new[]
                            {
                                new[] { c1, c2, c3, c4 },
                                new[] { c2, c1, c5 },
                                new[] { c3, c2, c5 },
                                new[] { c4, c3, c5 },
                                new[] { c1, c4, c5 }
                            };
            foreach (var arr in faces)
            {
                var face = new Face(generator.Next("Face"))
                {
                    Plane = new Plane(arr[0], arr[1], arr[2]),
                    Texture = {Name = texture }
                };
                face.Vertices.AddRange(arr);
                solid.Data.Add(face);
            }
            solid.DescendantsChanged();
            yield return solid;
        }
    }
}