using System;
using System.Windows.Forms;
using Forgery.Common.Translations;

namespace Forgery.BspEditor.Environment
{
    public interface IEnvironmentEditor : IManualTranslate
    {
        event EventHandler EnvironmentChanged;
        Control Control { get; }
        IEnvironment Environment { get; set; }
    }
}