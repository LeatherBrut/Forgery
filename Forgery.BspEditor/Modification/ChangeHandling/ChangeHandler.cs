using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Shell.Hooks;

namespace Forgery.BspEditor.Modification.ChangeHandling
{
    [Export(typeof(IInitialiseHook))]
    public class ChangeHandler : IInitialiseHook
    {
        private readonly IMapDocumentChangeHandler[] _changeHandlers;

        [ImportingConstructor]
        public ChangeHandler(
            [ImportMany] IMapDocumentChangeHandler[] changeHandlers
        )
        {
            _changeHandlers = changeHandlers;
        }

        public Task OnInitialise()
        {
            Oy.Subscribe<Change>("MapDocument:Changed:Early", Changed);
            Oy.Subscribe<MapDocument>("Document:Opened", Opened);
            return Task.CompletedTask;
        }

        private Task Opened(MapDocument doc)
        {
            var ch = new Change(doc);
            ch.AddRange(doc.Map.Root.FindAll());
            foreach (var d in doc.Map.Data) ch.Update(d);
            return Changed(ch);
        }

        private async Task Changed(Change change)
        {
            foreach (var ch in _changeHandlers.OrderBy(x => x.OrderHint))
            {
                await ch.Changed(change);
            }
        }
    }
}