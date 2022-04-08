using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Grid;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Tools.Grid
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Grid:CycleGrid")]
    [DefaultHotkey("Shift+R")]
    [AutoTranslate]
    public class SwitchGrid : ICommand
    {
        [ImportMany] private IGridFactory[] _grids;

        public string Name => "Switch grids";
        public string Details => "Cycle through grid types";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                if (!_grids.Any()) return;

                var current = doc.Map.Data.GetOne<GridData>()?.Grid;
                var idx = current == null ? -1 : Array.FindIndex(_grids, x => x.IsInstance(current));
                idx = (idx + 1) % _grids.Length;
                
                var grid = await _grids[idx].Create(doc.Environment);

                var gd = new GridData(grid);
                var operation = new TrivialOperation(x => doc.Map.Data.Replace(gd), x => x.Update(gd));

                await MapDocumentOperation.Perform(doc, operation);
            }
        }
    }
}