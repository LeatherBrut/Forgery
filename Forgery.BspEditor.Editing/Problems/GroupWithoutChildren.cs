using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations.Tree;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Problems
{
    [Export(typeof(IProblemCheck))]
    [AutoTranslate]
    public class GroupWithoutChildren : IProblemCheck
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Uri Url => null;
        public bool CanFix => true;

        public Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter)
        {
            var empty = document.Map.Root.FindAll()
                .OfType<Group>()
                .Where(x => filter(x))
                .Where(x => !x.Hierarchy.HasChildren)
                .Select(x => new Problem().Add(x))
                .ToList();
            return Task.FromResult(empty);
        }

        public Task Fix(MapDocument document, Problem problem)
        {
            var edit = new Transaction();

            foreach (var obj in problem.Objects)
            {
                edit.Add(new Detatch(obj.Hierarchy.Parent.ID, obj));
            }

            return MapDocumentOperation.Perform(document, edit);
        }
    }
}