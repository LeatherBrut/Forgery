using System.ComponentModel.Composition;
using System.Drawing;
using System.Windows.Forms;
using Forgery.BspEditor.Documents;
using Forgery.DataStructures.GameData;

namespace Forgery.BspEditor.Editing.Components.Properties.SmartEdit
{
    [Export(typeof(IObjectPropertyEditor))]
    [Export("Default", typeof(IObjectPropertyEditor))]
    public class DumbEditControl : SmartEditControl
    {
        private readonly TextBox _keyBox;
        private readonly TextBox _textBox;

        public DumbEditControl()
        {
            _keyBox = new TextBox { Width = 200 };
            _textBox = new TextBox { Width = 200 };

            _keyBox.TextChanged += (sender, e) => OnNameChanged();
            _textBox.TextChanged += (sender, e) => OnValueChanged();

            Controls.Add(new Label { Text = "Key", AutoSize = false, Height = 18, Width = 50, TextAlign = ContentAlignment.BottomRight });
            Controls.Add(_keyBox);
            Controls.Add(new Label { Text = "Value", AutoSize = false, Height = 18, Width = 50, TextAlign = ContentAlignment.BottomRight });
            Controls.Add(_textBox);
        }

        public override string PriorityHint => "Y";

        public override bool SupportsType(VariableType type)
        {
            return true;
        }

        protected override string GetName()
        {
            return _keyBox.Text;
        }

        protected override string GetValue()
        {
            return _textBox.Text;
        }

        protected override void OnSetProperty(MapDocument document)
        {
            _keyBox.Text = PropertyName;
            _textBox.Text = PropertyValue;
        }
    }
}