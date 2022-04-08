using System.Collections.Generic;
using System.ComponentModel.Composition;
using Forgery.Common.Shell.Menu;

namespace Forgery.BspEditor.Commands
{
    [Export(typeof(IMenuMetadataProvider))]
    public class MenuDataProvider : IMenuMetadataProvider
    {
        public IEnumerable<MenuSection> GetMenuSections()
        {
            yield break;
        }

        public IEnumerable<MenuGroup> GetMenuGroups()
        {
            yield return new MenuGroup("Edit", "", "History", "B");
            yield return new MenuGroup("Edit", "", "Clipboard", "D");
            yield return new MenuGroup("Edit", "", "Selection", "T");

            yield return new MenuGroup("Tools", "", "Group", "D");
        }
    }
}