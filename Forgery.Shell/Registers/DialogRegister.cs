using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Forgery.Common.Logging;
using Forgery.Common.Shell.Components;
using Forgery.Common.Shell.Context;
using Forgery.Common.Shell.Hooks;

namespace Forgery.Shell.Registers
{
    /// <summary>
    /// The dialog register controls dialogs
    /// </summary>
    [Export(typeof(IStartupHook))]
    public class DialogRegister : IStartupHook
    {
        [Import] private Forms.Shell _shell;
        [ImportMany] private IEnumerable<Lazy<IDialog>> _dialogs;

        public async Task OnStartup()
        {
            // Register the exported dialogs
            foreach (var export in _dialogs)
            {
                Log.Debug(nameof(DialogRegister), "Loaded: " + export.Value.GetType().FullName);
                _components.Add(export.Value);
            }

            // Subscribe to context changes
            Oy.Subscribe<IContext>("Context:Changed", ContextChanged);
        }

        private readonly List<IDialog> _components;

        public DialogRegister()
        {
            _components = new List<IDialog>();
        }

        private Task ContextChanged(IContext context)
        {
            _shell.InvokeLater(() =>
            {
                foreach (var c in _components)
                {
                    var vis = c.IsInContext(context);
                    if (vis != c.Visible) c.SetVisible(context, vis);
                }
            });
            return Task.CompletedTask;
        }
    }
}
