using System.ComponentModel.Composition;
using System.Linq;
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
    [CommandID("BspEditor:Grid:IncreaseSpacing")]
    [DefaultHotkey("]")]
    [MenuItem("Map", "", "Grid", "H")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_LargerGrid))]
    [AutoTranslate]
    public class IncreaseGrid : ICommand
    {
        public string Name { get; set; } = "Bigger Grid";
        public string Details { get; set; } = "Increase the grid size";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var gd = doc.Map.Data.Get<GridData>().FirstOrDefault();
                var grid = gd?.Grid;
                if (grid != null)
                {
                    var operation = new TrivialOperation(x => grid.Spacing++, x => x.Update(gd));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}