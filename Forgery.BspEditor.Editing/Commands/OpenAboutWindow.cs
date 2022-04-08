using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.BspEditor.Editing.Components;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Help", "", "About", "Z")]
    [CommandID("BspEditor:Help:About")]
    public class OpenAboutWindow : ICommand
    {
        public string Name { get; set; } = "About Forgery";
        public string Details { get; set; } = "View information about this application";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            using (var vg = new AboutDialog())
            {
                vg.ShowDialog();
            }
        }
    }
}