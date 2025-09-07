namespace StartService
{
    partial class FormStartService
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
            this.textBoxVirtualPath = new System.Windows.Forms.TextBox();
            this.textBoxWebServer = new System.Windows.Forms.TextBox();
            this.textBoxPhysicalPath = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonBrowseServer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialogServer = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogPhysicalPath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBoxVirtualPath
            // 
            this.textBoxVirtualPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVirtualPath.Location = new System.Drawing.Point(12, 90);
            this.textBoxVirtualPath.Name = "textBoxVirtualPath";
            this.textBoxVirtualPath.Size = new System.Drawing.Size(489, 20);
            this.textBoxVirtualPath.TabIndex = 0;
            this.textBoxVirtualPath.Text = "/";
            // 
            // textBoxWebServer
            // 
            this.textBoxWebServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWebServer.Location = new System.Drawing.Point(12, 12);
            this.textBoxWebServer.Name = "textBoxWebServer";
            this.textBoxWebServer.Size = new System.Drawing.Size(489, 20);
            this.textBoxWebServer.TabIndex = 0;
            this.textBoxWebServer.Text = "C:\\Program Files\\Common Files\\Microsoft Shared\\DevServer\\9.0\\WebDev.WebServer.exe" +
                "";
            // 
            // textBoxPhysicalPath
            // 
            this.textBoxPhysicalPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPhysicalPath.Location = new System.Drawing.Point(12, 64);
            this.textBoxPhysicalPath.Name = "textBoxPhysicalPath";
            this.textBoxPhysicalPath.Size = new System.Drawing.Size(489, 20);
            this.textBoxPhysicalPath.TabIndex = 0;
            this.textBoxPhysicalPath.Text = "D:\\Documents\\КПИ\\Комп\'ютерне забезпечення телекомунiкацiй\\Labs\\Lab2\\SortService";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPort.Location = new System.Drawing.Point(12, 38);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(489, 20);
            this.textBoxPort.TabIndex = 0;
            this.textBoxPort.Text = "7017";
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRun.Location = new System.Drawing.Point(250, 138);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseServer.Location = new System.Drawing.Point(508, 12);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(34, 20);
            this.buttonBrowseServer.TabIndex = 2;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.UseVisualStyleBackColor = true;
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(507, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 20);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialogServer
            // 
            this.openFileDialogServer.DefaultExt = "WebDev.WebServer.exe";
            this.openFileDialogServer.FileName = "C:\\Program Files\\Common Files\\Microsoft Shared\\DevServer\\9.0\\WebDev.WebServer.exe" +
                "";
            this.openFileDialogServer.Filter = "EXE files|*.exe";
            this.openFileDialogServer.Title = "WebDev.WebServer.exe";
            // 
            // folderBrowserDialogPhysicalPath
            // 
            this.folderBrowserDialogPhysicalPath.Description = "Physical path";
            this.folderBrowserDialogPhysicalPath.ShowNewFolderButton = false;
            // 
            // FormStartService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 173);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonBrowseServer);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxPhysicalPath);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxWebServer);
            this.Controls.Add(this.textBoxVirtualPath);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FormStartService";
            this.Text = "StartService by Podolsky Sergey KV-64";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxVirtualPath;
        private System.Windows.Forms.TextBox textBoxWebServer;
        private System.Windows.Forms.TextBox textBoxPhysicalPath;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonBrowseServer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialogServer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPhysicalPath;
    }
}

