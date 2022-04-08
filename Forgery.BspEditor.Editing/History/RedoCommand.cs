using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Editing.Properties;
using Forgery.BspEditor.Modification;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.History
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:Redo")]
    [DefaultHotkey("Ctrl+Y")]
    [MenuItem("Edit", "", "History", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Redo))]
    public class RedoCommand : BaseCommand
    {
        public override string Name { get; set; } = "Redo";
        public override string Details { get; set; } = "Redo the last undone operation";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var stack = document.Map.Data.GetOne<HistoryStack>();
            if (stack == null) return;
            if (stack.CanRedo()) await MapDocumentOperation.Perform(document, stack.RedoOperation());
        }
    }
}