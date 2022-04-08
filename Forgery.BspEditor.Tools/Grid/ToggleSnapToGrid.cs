using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.BspEditor.Tools.Properties;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Tools.Grid
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Grid:ToggleSnapToGrid")]
    [DefaultHotkey("Shift+W")]
    [MenuItem("Map", "", "Grid", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SnapToGrid))]
    [AutoTranslate]
    public class ToggleSnapToGrid : ICommand
    {
        public string Name { get; set; } = "Snap to Grid";
        public string Details { get; set; } = "Toggle grid snapping";
        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var activeGrid = doc.Map.Data.GetOne<GridData>();
                if (activeGrid != null)
                {
                    var operation = new TrivialOperation(x => activeGrid.SnapToGrid = !activeGrid.SnapToGrid, x => x.Update(activeGrid));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}