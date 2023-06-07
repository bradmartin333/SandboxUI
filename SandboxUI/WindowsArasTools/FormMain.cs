using Innovator.Client;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsArasTools.Tools;

namespace WindowsArasTools
{
    public partial class FormMain : Form
    {
        public readonly static string DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "WindowsArasTools");
        public static IRemoteConnection Connection;

        public FormMain()
        {
            Directory.CreateDirectory(DownloadPath);
            InitializeComponent();

            Show();
            RtbCADPDFs.Text = "Connecting to Aras...\n";
            Application.DoEvents();

            // Connect to Parata's Aras database with credentials
            try
            {
                Connection = Factory.GetConnection("http://ps-aras/InnovatorServer/Server/", "BMartin");
                string database = Connection.GetDatabases().First();
                Connection.Login(new ExplicitCredentials(database, "bmartin", "innovator"));
                RtbCADPDFs.Text += "Connected to Aras!\n\n";
                RtbCADPDFs.Text += "Replace this text with a list of Aras part numbers (One per line) that have an associated CAD PDF that you would like to download.\n";
                BtnCADPDFs.Enabled = true;
                InitializeTools();
            }
            catch (Exception)
            {
                RtbCADPDFs.Text += "Failed to connect to Aras. Check your internet connection and try again.";
                BtnCADPDFs.Enabled = false;
                TabControl.Enabled = false;
            }
        }

        private void InitializeTools()
        {
            _ = new ToolCADPDFs(RtbCADPDFs, BtnCADPDFs);
        }
    }
}
