﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Forgery.BspEditor.Tools.Vertex.Selection;

namespace Forgery.BspEditor.Tools.Vertex.Errors
{
    [Export(typeof(IVertexErrorCheck))]
    public class NonPlanarVertices : IVertexErrorCheck
    {
        private const string Key = "Forgery.BspEditor.Tools.Vertex.Errors.NonPlanarVertices";

        public IEnumerable<VertexError> GetErrors(VertexSolid solid)
        {
            foreach (var face in solid.Copy.Faces)
            {
                var nonPlanar = face.Vertices.Where(x => face.Plane.OnPlane(x.Position, 0.5f) != 0).ToList();
                if (nonPlanar.Any()) yield return new VertexError(Key, solid).Add(face).Add(nonPlanar);
            }
        }
    }
}