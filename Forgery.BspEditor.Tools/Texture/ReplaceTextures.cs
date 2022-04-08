using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.BspEditor.Documents;
using Forgery.BspEditor.Tools.Properties;
using Forgery.Common.Shell.Commands;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Menu;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Tools.Texture
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:ReplaceTextures")]
    [MenuItem("Tools", "", "Texture", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ReplaceTextures))]
    public class ReplaceTextures : ICommand
    {
        [Import] private ITranslationStringProvider _translation;

        public string Name { get; set; } = "Replace textures...";
        public string Details { get; set; } = "Replace textures";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var md = context.Get<MapDocument>("ActiveDocument");
            if (md == null) return;

            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:TextureReplace"));
        }
    }
}
