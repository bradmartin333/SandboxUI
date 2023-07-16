using Innovator.Client;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsArasTools.Tools;

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
            Lookup partLookup = new Lookup() { Dock = DockStyle.Fill };
            partLookup.Initialize(Lookup.LookupTypes.Part);
            Lookup documentLookup = new Lookup() { Dock = DockStyle.Fill };
            documentLookup.Initialize(Lookup.LookupTypes.Document);
            TabControl.TabPages[2].Controls.Add(partLookup);
            TabControl.TabPages[3].Controls.Add(documentLookup);
        }

        private void BtnFun_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 10);
            switch (randomNumber)
            {
                case 0:
                    MessageBox.Show("You are a winner!", 
                        "There are 10 different fun actions!!!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);
                    break;
                case 1:
                    Point location = BtnFun.Location;
                    location.X -= 10;
                    location.Y -= 10;
                    if (location.X < 0) location.X = 0;
                    if (location.Y < 0) location.Y = 0;
                    BtnFun.Location = location;
                    break;
                case 2:
                    BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    break;
                case 3:
                    BtnFun.Text = "Are we having fun yet?";
                    break;
                case 4:
                    BtnFun.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    BtnFun.ForeColor = Color.FromArgb(255 - BtnFun.BackColor.R, 255 - BtnFun.BackColor.G, 255 - BtnFun.BackColor.B);
                    break;
                case 5:
                    for (int i = 0; i < 3; i++)
                        Process.Start("notepad.exe");
                    break;
                case 6:
                    Size size = BtnFun.Size;
                    size.Width += 10;
                    size.Height += 10;
                    if (size.Width > 0.5 * Width) size.Width = (int)(0.5 * Width);
                    if (size.Height > 0.5 * Height) size.Height = (int)(0.5 * Height);
                    BtnFun.Size = size;
                    break;
                case 7:
                    BtnFun.Text = "Fun!";
                    BtnFun.BackColor = Color.FromArgb(255, 0, 0);
                    BtnFun.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
                case 8:
                    TabControl.TabPages.Remove(TabFunButton);
                    MessageBox.Show("Fun is over!");
                    break;
                case 9:
                    if (CbxDanger.Checked)
                        Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                    else
                        MessageBox.Show("YOU ARE NOT IN DANGER!",
                            "Everything is okay!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    break;
                default:
                    break;
            }
        }
    }
}
