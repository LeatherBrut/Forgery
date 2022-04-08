using System.Collections.Generic;
using Forgery.BspEditor.Tools.Vertex.Selection;

namespace Forgery.BspEditor.Tools.Vertex.Errors
{
    public interface IVertexErrorCheck
    {
        IEnumerable<VertexError> GetErrors(VertexSolid solid);
    }
}
