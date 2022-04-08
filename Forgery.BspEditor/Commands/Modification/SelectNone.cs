using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations.Selection;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.BspEditor.Properties;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:SelectNone")]
    [DefaultHotkey("Shift+Q")]
    [MenuItem("Edit", "", "Selection", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SelectNone))]
    public class SelectNone : BaseCommand
    {
        public override string Name { get; set; } = "Select None";
        public override string Details { get; set; } = "Clear selection";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var op = new Deselect(document.Map.Root.FindAll());
            return MapDocumentOperation.Perform(document, op);
        }
    }
}