using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Documents;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;
using Forgery.Shell.Properties;
using Forgery.Shell.Registers;

namespace Forgery.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:Close")]
    [MenuItem("File", "", "File", "F")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Close))]
    public class CloseFile : ICommand
    {
        private readonly Lazy<DocumentRegister> _documentRegister;

        public string Name { get; set; } = "Close";
        public string Details { get; set; } = "Close";

        [ImportingConstructor]
        public CloseFile(
            [Import] Lazy<DocumentRegister> documentRegister
        )
        {
            _documentRegister = documentRegister;
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out IDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var doc = context.Get<IDocument>("ActiveDocument");
            if (doc != null)
            {
                await _documentRegister.Value.RequestCloseDocument(doc);
            }
        }
    }
}