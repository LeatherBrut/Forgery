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
    [MenuItem("Map", "", "Properties", "E")]
    [CommandID("BspEditor:Map:LogicalTree")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowLogicalTree))]
    public class OpenMapTreeWindow : BaseCommand
    {
        public override string Name { get; set; } = "Show logical tree";
        public override string Details { get; set; } = "Show the logical tree of the current document.";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:MapTree"));
        }
    }
}