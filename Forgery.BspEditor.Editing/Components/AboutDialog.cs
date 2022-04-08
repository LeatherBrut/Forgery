using System.Diagnostics;
using System.Windows.Forms;
using Forgery.BspEditor.Documents;

namespace Forgery.BspEditor.Editing.Components
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            VersionLabel.Text = FileVersionInfo.GetVersionInfo(typeof (MapDocument).Assembly.Location).FileVersion;

            LTLink.Click += (s, e) => OpenSite("http://logic-and-trick.com");
            GithubLink.Click += (s, e) => OpenSite("https://github.com/LogicAndTrick/Forgery");
            GPLLink.Click += (s, e) => OpenSite("https://opensource.org/licenses/BSD-3-Clause");
            AJLink.Click += (s, e) => OpenSite("http://scrub-studios.com");
            TWHLLink.Click += (s, e) => OpenSite("https://twhl.info");
        }

        private void OpenSite(string url)
        {
            Process.Start(url);
        }
    }
}
