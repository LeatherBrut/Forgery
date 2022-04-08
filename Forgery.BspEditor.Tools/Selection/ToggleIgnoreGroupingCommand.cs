using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.BspEditor.Tools.Properties;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Tools.Selection
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Map:ToggleIgnoreGrouping")]
    [DefaultHotkey("Ctrl+W")]
    [MenuItem("Map", "", "Grouping", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_IgnoreGrouping))]
    [AutoTranslate]
    public class ToggleIgnoreGroupingCommand : BaseCommand
    {
        public override string Name { get; set; } = "Ignore grouping";
        public override string Details { get; set; } = "Toggle ignore grouping on and off";
        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var opt = document.Map.Data.GetOne<SelectionOptions>() ?? new SelectionOptions();
            opt.IgnoreGrouping = !opt.IgnoreGrouping;
            MapDocumentOperation.Perform(document, new TrivialOperation(x => x.Map.Data.Replace(opt), x => x.Update(opt)));
            return Task.CompletedTask;
        }
    }
}