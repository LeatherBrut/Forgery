using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Help", "", "Links", "D")]
    [CommandID("BspEditor:Links:ForgeryWebsite")]
    public class OpenForgeryWebsite : ICommand
    {
        public string Name { get; set; } = "Forgery Website";
        public string Details { get; set; } = "Go to the Forgery website";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            System.Diagnostics.Process.Start("http://Forgery-editor.com/");
        }
    }
}