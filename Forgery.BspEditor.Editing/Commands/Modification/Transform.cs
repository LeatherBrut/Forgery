﻿using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forgery.BspEditor.Commands;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Editing.Components;
using Forgery.BspEditor.Editing.Properties;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations.Mutation;
using Forgery.BspEditor.Primitives.MapData;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Hotkeys;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Tools", "", "Transform", "D")]
    [CommandID("BspEditor:Tools:Transform")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Transform))]
    [DefaultHotkey("Ctrl+M")]
    public class Transform : BaseCommand
    {
        [Import] private Lazy<ITranslationStringProvider> _translator;

        public override string Name { get; set; } = "Transform";
        public override string Details { get; set; } = "Transform the current selection";

        public string ErrorCannotScaleByZeroTitle { get; set; } = "Cannot scale by zero";
        public string ErrorCannotScaleByZeroMessage { get; set; } = "Please enter a non-zero value for all axes when scaling.";

        protected override bool IsInContext(IContext context, MapDocument document)
        {
            return base.IsInContext(context, document) && !document.Selection.IsEmpty;
        }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var objects = document.Selection.GetSelectedParents().ToList();
            var box = document.Selection.GetSelectionBoundingBox();

            using (var dialog = new TransformDialog(box))
            {
                _translator.Value.Translate(dialog);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var transaction = new Transaction();

                        // Add the operation
                        var transform = dialog.GetTransformation(box);
                        var transformOperation = new BspEditor.Modification.Operations.Mutation.Transform(transform, objects);
                        transaction.Add(transformOperation);

                        // Check for texture transform
                        var tl = document.Map.Data.GetOne<TransformationFlags>() ?? new TransformationFlags();
                        if (dialog.Type == TransformDialog.TransformType.Rotate || dialog.Type == TransformDialog.TransformType.Translate)
                        {
                            if (tl.TextureLock) transaction.Add(new TransformTexturesUniform(transform, objects.SelectMany(x => x.FindAll())));
                        }
                        else if (dialog.Type == TransformDialog.TransformType.Scale)
                        {
                            if (tl.TextureScaleLock) transaction.Add(new TransformTexturesScale(transform, objects.SelectMany(x => x.FindAll())));
                        }

                        await MapDocumentOperation.Perform(document, transaction);
                    }
                    catch (TransformDialog.CannotScaleByZeroException)
                    {
                        MessageBox.Show(ErrorCannotScaleByZeroMessage, ErrorCannotScaleByZeroTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}