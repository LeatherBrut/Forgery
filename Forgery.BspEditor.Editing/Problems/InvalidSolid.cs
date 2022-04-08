using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Modification;
using Forgery.BspEditor.Modification.Operations.Tree;
using Forgery.BspEditor.Primitives;
using Forgery.BspEditor.Primitives.MapObjects;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Editing.Problems
{
    [Export(typeof(IProblemCheck))]
    [AutoTranslate]
    public class InvalidSolid : IProblemCheck
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Uri Url => null;
        public bool CanFix => true;

        public Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter)
        {
            var solids = document.Map.Root.FindAll()
                .Where(x => filter(x))
                .OfType<Solid>()
                .Where(x => !x.IsValid())
                .Select(x => new Problem().Add(x))
                .ToList();

            return Task.FromResult(solids);
        }

        public Task Fix(MapDocument document, Problem problem)
        {
            var delete = new Transaction();
            foreach (var g in problem.Objects.GroupBy(x => x.Hierarchy.Parent.ID))
            {
                delete.Add(new Detatch(g.Key, g));
            }
            return MapDocumentOperation.Perform(document, delete);
        }
    }
}