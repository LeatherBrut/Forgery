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
    [MenuItem("Map", "", "Properties", "D")]
    [CommandID("BspEditor:Map:CheckForProblems")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_CheckForProblems))]
    [DefaultHotkey("Alt+P")]
    public class OpenCheckForProblemsDialog : BaseCommand
    {
        public override string Name { get; set; } = "Check for problems";
        public override string Details { get; set; } = "Open the check for problems window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:CheckForProblems"));
        }
    }
}