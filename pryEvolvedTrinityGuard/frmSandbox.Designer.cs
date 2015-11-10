namespace pryEvolvedTrinityGuard
{
    partial class frmSandbox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSandbox));
            this.txtCommandResult = new System.Windows.Forms.RichTextBox();
            this.txtEntrarComando = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.lblConsoleOutput = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConsoleStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConsoleStatus = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelectedAccount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsoleLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsoleUnload = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommandResult
            // 
            this.txtCommandResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandResult.Location = new System.Drawing.Point(9, 54);
            this.txtCommandResult.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommandResult.Name = "txtCommandResult";
            this.txtCommandResult.Size = new System.Drawing.Size(654, 250);
            this.txtCommandResult.TabIndex = 1;
            this.txtCommandResult.Text = "";
            // 
            // txtEntrarComando
            // 
            this.txtEntrarComando.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntrarComando.Location = new System.Drawing.Point(358, 31);
            this.txtEntrarComando.Margin = new System.Windows.Forms.Padding(2);
            this.txtEntrarComando.Name = "txtEntrarComando";
            this.txtEntrarComando.Size = new System.Drawing.Size(244, 20);
            this.txtEntrarComando.TabIndex = 2;
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.Location = new System.Drawing.Point(605, 30);
            this.btnPost.Margin = new System.Windows.Forms.Padding(2);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(56, 19);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // lblConsoleOutput
            // 
            this.lblConsoleOutput.AutoSize = true;
            this.lblConsoleOutput.Location = new System.Drawing.Point(9, 30);
            this.lblConsoleOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConsoleOutput.Name = "lblConsoleOutput";
            this.lblConsoleOutput.Size = new System.Drawing.Size(81, 13);
            this.lblConsoleOutput.TabIndex = 4;
            this.lblConsoleOutput.Text = "Console output:";
            this.lblConsoleOutput.Click += new System.EventHandler(this.lblConsoleOutput_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConsoleStatus,
            this.btnConsoleStatus,
            this.toolStripStatusLabel1,
            this.lblSelectedAccount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 306);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(670, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConsoleStatus
            // 
            this.lblConsoleStatus.Name = "lblConsoleStatus";
            this.lblConsoleStatus.Size = new System.Drawing.Size(135, 21);
            this.lblConsoleStatus.Text = "Console status: Disabled";
            // 
            // btnConsoleStatus
            // 
            this.btnConsoleStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConsoleStatus.Image = global::pryEvolvedTrinityGuard.Properties.Resources.down;
            this.btnConsoleStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConsoleStatus.Name = "btnConsoleStatus";
            this.btnConsoleStatus.Size = new System.Drawing.Size(36, 24);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(459, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Selected account:";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSelectedAccount
            // 
            this.lblSelectedAccount.Name = "lblSelectedAccount";
            this.lblSelectedAccount.Size = new System.Drawing.Size(29, 21);
            this.lblSelectedAccount.Text = "N/A";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConsole,
            this.statusToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(670, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuConsole
            // 
            this.mnuConsole.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConsoleLoad,
            this.mnuConsoleUnload});
            this.mnuConsole.Name = "mnuConsole";
            this.mnuConsole.Size = new System.Drawing.Size(62, 20);
            this.mnuConsole.Text = "Console";
            this.mnuConsole.Click += new System.EventHandler(this.loadConsoleToolStripMenuItem_Click);
            // 
            // mnuConsoleLoad
            // 
            this.mnuConsoleLoad.Name = "mnuConsoleLoad";
            this.mnuConsoleLoad.Size = new System.Drawing.Size(112, 22);
            this.mnuConsoleLoad.Text = "Load";
            this.mnuConsoleLoad.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // mnuConsoleUnload
            // 
            this.mnuConsoleUnload.Enabled = false;
            this.mnuConsoleUnload.Name = "mnuConsoleUnload";
            this.mnuConsoleUnload.Size = new System.Drawing.Size(112, 22);
            this.mnuConsoleUnload.Text = "Unload";
            this.mnuConsoleUnload.Click += new System.EventHandler(this.mnuConsoleUnload_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem1,
            this.restartToolStripMenuItem,
            this.shutdownToolStripMenuItem});
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.statusToolStripMenuItem.Text = "Server";
            // 
            // statusToolStripMenuItem1
            // 
            this.statusToolStripMenuItem1.Name = "statusToolStripMenuItem1";
            this.statusToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.statusToolStripMenuItem1.Text = "Status";
            this.statusToolStripMenuItem1.Click += new System.EventHandler(this.statusToolStripMenuItem1_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Command:";
            this.label1.Click += new System.EventHandler(this.lblConsoleOutput_Click);
            // 
            // frmSandbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 332);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblConsoleOutput);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtEntrarComando);
            this.Controls.Add(this.txtCommandResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSandbox";
            this.Text = "Server console Sandbox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSandbox_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSandbox_FormClosed);
            this.Load += new System.EventHandler(this.frmSandbox_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCommandResult;
        private System.Windows.Forms.TextBox txtEntrarComando;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Label lblConsoleOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConsoleStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuConsole;
        private System.Windows.Forms.ToolStripMenuItem mnuConsoleLoad;
        private System.Windows.Forms.ToolStripMenuItem mnuConsoleUnload;
        private System.Windows.Forms.ToolStripSplitButton btnConsoleStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedAccount;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}