using System.IO;
using System.Windows.Forms;
using Forgery.BspEditor.Tools.Properties;

namespace Forgery.BspEditor.Tools
{
    public static class ToolCursors
    {
        public static Cursor RotateCursor { get; }

        static ToolCursors()
        {
            RotateCursor = new Cursor(new MemoryStream(Resources.Cursor_Rotate));
        }
    }
}
