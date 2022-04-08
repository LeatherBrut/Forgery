using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Components;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Properties;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Controls.Layout
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Window:CreateWindow")]
    [MenuItem("Window", "", "Layout", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_NewWindow))]
    [AllowToolbar(false)]
    public class CreateLayoutWindow : BaseCommand
    {
        private readonly Lazy<MapDocumentControlHost> _host;

        [ImportingConstructor]
        public CreateLayoutWindow(
            [Import] Lazy<MapDocumentControlHost> host
        )
        {
            _host = host;
        }

        public override string Name { get; set; } = "New layout window";
        public override string Details { get; set; } = "Create a new layout window";
        
        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            _host.Value.CreateNewWindow();
            return Task.CompletedTask;
        }
    }
}