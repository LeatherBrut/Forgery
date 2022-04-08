using System.ComponentModel.Composition;
using System.Numerics;
using System.Threading.Tasks;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Editing.Properties;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations.Mutation;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Tools", "", "Snap", "B")]
    [CommandID("BspEditor:Tools:SnapToGrid")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SnapSelection))]
    public class SnapToGrid : BaseCommand
    {
        public override string Name { get; set; } = "Snap to grid";
        public override string Details { get; set; } = "Snap selection to grid";

        protected override bool IsInContext(IContext context, MapDocument document)
        {
            return base.IsInContext(context, document) && !document.Selection.IsEmpty;
        }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var selBox = document.Selection.GetSelectionBoundingBox();
            var grid = document.Map.Data.GetOne<GridData>();
            if (grid == null) return;

            var start = selBox.Start;
            var snapped = grid.Grid.Snap(start);
            var trans = snapped - start;
            if (trans == Vector3.Zero) return;

            var tform = Matrix4x4.CreateTranslation(trans);

            var transaction = new Transaction();
            var transformOperation = new BspEditor.Modification.Operations.Mutation.Transform(tform, document.Selection.GetSelectedParents());
            transaction.Add(transformOperation);

            // Check for texture transform
            var tl = document.Map.Data.GetOne<TransformationFlags>() ?? new TransformationFlags();
            if (tl.TextureLock) transaction.Add(new TransformTexturesUniform(tform, document.Selection));

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}
