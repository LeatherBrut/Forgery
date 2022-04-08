using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Editing.Properties;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "D")]
    [CommandID("BspEditor:Map:SelectionDetails")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowBrushID))]
    public class OpenSelectionDetails : BaseCommand
    {
        public override string Name { get; set; } = "Selection details";
        public override string Details { get; set; } = "Show details of the current selection";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:SelectionDetails"));
        }
    }
}