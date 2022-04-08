using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;
using Forgery.Shell.Forms;

namespace Forgery.Shell.Commands
{
    /// <summary>
    /// Opens the translator form
    /// </summary>
    [Export(typeof(ICommand))]
    [CommandID("Tools:Translator")]
    [MenuItem("Tools", "", "Settings", "B")]
    [AutoTranslate]
    public class OpenTranslator : ICommand
    {
        private readonly Form _shell;

        public string Name { get; set; } = "Forgery translator...";
        public string Details { get; set; } = "Open the translator app";

        [ImportingConstructor]
        public OpenTranslator([Import("Shell")] Form shell)
        {
            _shell = shell;
        }

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public Task Invoke(IContext context, CommandParameters parameters)
        {
            _shell.InvokeLater(() =>
            {
                var tf = new TranslationForm();
                tf.Show(_shell);
            });
            return Task.CompletedTask;
        }
    }
}
