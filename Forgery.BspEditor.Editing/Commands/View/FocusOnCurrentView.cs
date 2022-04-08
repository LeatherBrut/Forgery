using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands.View
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:View:FocusCurrent")]
    [MenuItem("View", "", "SplitView", "B")]
    [DefaultHotkey("Shift+Z")]
    public class FocusOnCurrentView : BaseCommand
    {
        public override string Name { get; set; } = "Focus on current view";
        public override string Details { get; set; } = "Maximise the current view in the viewport grid";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:SplitView:FocusCurrent");
        }
    }
}