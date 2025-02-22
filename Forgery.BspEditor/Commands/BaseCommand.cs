using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;

namespace Forgery.BspEditor.Commands
{
    /// <summary>
    /// A class that <see cref="MapDocument"/> commands can derive from.
    /// Does appropriate context checks and provides the document to the Invoke method.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        public abstract string Name { get; set; }
        public abstract string Details { get; set; }

        public virtual bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument doc)
                   && IsInContext(context, doc);
        }

        protected virtual bool IsInContext(IContext context, MapDocument document)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                await Invoke(doc, parameters);
            }
        }

        protected abstract Task Invoke(MapDocument document, CommandParameters parameters);
    }
}