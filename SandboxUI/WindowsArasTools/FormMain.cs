using Innovator.Client;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsArasTools
{
    public partial class FormMain : Form
    {
        public readonly static string DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "WindowsArasTools");
        public static IRemoteConnection Connection;
        public static bool ArasConnected => Connection != null && Connection.UserId != null;

        public FormMain()
        {
            Directory.CreateDirectory(DownloadPath);
            InitializeComponent();
        }
    }
}
