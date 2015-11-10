using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pryEvolvedTrinityGuard.Classes;

namespace pryEvolvedTrinityGuard
{
    public partial class frmSandbox : Form
    {
        private  SandboxServer commandbox;
        public string console;
        public frmSandbox()
        {
            InitializeComponent();
            commandbox = new SandboxServer();
            commandbox.CommandOutput += new SandboxServer.OutputRead(commandbox_CommandOutput);
        }

        void commandbox_CommandOutput(string output)
        {
            this.Invoke(new processCommandOutputDelegate(processCommandOutput), output);
        }

        private delegate void processCommandOutputDelegate(string output);

        private void processCommandOutput(string output)
        {
            txtCommandResult.Text += "\n" + output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //commandbox.Execute(@"C:\Varios\Personal\WoWCore\ipconfig.bat", "");
        }

        private void frmSandbox_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            commandbox.PostCommand(txtEntrarComando.Text);
        }

        private void loadConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commandbox.Execute("cmd.exe", "");
            lblConsoleStatus.Text = "Console status: Loaded";
            mnuConsoleLoad.Enabled = false;
            mnuConsoleUnload.Enabled = true;
            btnConsoleStatus.Image = global::pryEvolvedTrinityGuard.Properties.Resources.up;
            commandbox.PostCommand(@"cd C:\Build\bin\Release");
            commandbox.PostCommand(console);
            
        }

        private void mnuConsoleUnload_Click(object sender, EventArgs e)
        {
            commandbox.Dispose();
            mnuConsoleLoad.Enabled = true;
            mnuConsoleUnload.Enabled = false;
            lblConsoleStatus.Text = "Console status: Disabled";
            btnConsoleStatus.Image = global::pryEvolvedTrinityGuard.Properties.Resources.down;
        }

        private void lblConsoleOutput_Click(object sender, EventArgs e)
        {

        }

        private void frmSandbox_FormClosing(object sender, FormClosingEventArgs e)
        {
            commandbox.Dispose();
            commandbox = null;
        }

        private void frmSandbox_Load(object sender, EventArgs e)
        {

        }

        public void SendCommand(string command)
        {
            commandbox.PostCommand(command);
        }

        private void statusToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
