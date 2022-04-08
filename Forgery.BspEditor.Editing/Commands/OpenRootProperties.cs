using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Editing.Properties;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "A")]
    [CommandID("BspEditor:Map:RootProperties")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_MapProperties))]
    public class OpenRootProperties : BaseCommand
    {
        public override string Name { get; set; } = "Map properties";
        public override string Details { get; set; } = "Open the map properties window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:ObjectProperties:OpenWithSelection", new List<IMapObject> {document.Map.Root});
        }
    }
}