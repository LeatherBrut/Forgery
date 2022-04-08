using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.BspEditor.Documents;
using Forgery.Common.Shell.Components;
using Forgery.Common.Shell.Context;

namespace Forgery.BspEditor.Tools
{
    [Export(typeof(IStatusItem))]
    [OrderHint("H")]
    public class ToolStatusItem : IStatusItem
    {
        public event EventHandler<string> TextChanged;

        public string ID => "Forgery.BspEditor.Tools.ToolStatusItem";
        public int Width => 130;
        public bool HasBorder => true;
        public string Text { get; set; }

        public ToolStatusItem()
        {
            Oy.Subscribe<string>("MapDocument:ToolStatus:UpdateText", UpdateText);
        }

        private async Task UpdateText(string text)
        {
            Text = text;
            TextChanged?.Invoke(this, Text);
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }
    }
}
