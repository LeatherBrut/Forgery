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
    [CommandID("BspEditor:Grid:DecreaseSpacing")]
    [DefaultHotkey("[")]
    [MenuItem("Map", "", "Grid", "G")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SmallerGrid))]
    [AutoTranslate]
    public class DecreaseGrid : ICommand
    {
        public string Name { get; set; } = "Smaller Grid";
        public string Details { get; set; } = "Decrease the grid size";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var activeGrid = doc.Map.Data.GetOne<GridData>();
                var grid = activeGrid?.Grid;
                if (grid != null)
                {
                    var operation = new TrivialOperation(x => grid.Spacing--, x => x.Update(activeGrid));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}