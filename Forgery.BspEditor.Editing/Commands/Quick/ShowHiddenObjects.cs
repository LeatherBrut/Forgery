using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Editing.Properties;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations.Data;
using Forgery.BspEditor.Primitives.MapObjectData;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands.Quick
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("View", "", "Quick", "F")]
    [CommandID("BspEditor:View:ShowHidden")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowHidden))]
    [DefaultHotkey("U")]
    public class ShowHiddenObjects : BaseCommand
    {
        public override string Name { get; set; } = "Show hidden objects";
        public override string Details { get; set; } = "Show objects hidden with quick hide";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Map.Root.Find(x => x.Data.Get<QuickHidden>().Any()))
            {
                transaction.Add(new RemoveMapObjectData(mo.ID, mo.Data.GetOne<QuickHidden>()));
            }

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}