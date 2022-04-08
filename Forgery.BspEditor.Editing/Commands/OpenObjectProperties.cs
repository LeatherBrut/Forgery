using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Editing.Properties;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Edit", "", "Properties", "B")]
    [CommandID("BspEditor:Map:Properties")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ObjectProperties))]
    [DefaultHotkey("Alt+Enter")]
    public class OpenObjectProperties : BaseCommand
    {
        public override string Name { get; set; } = "Object properties";
        public override string Details { get; set; } = "Open the object properties window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:ObjectProperties"));
        }
    }
}