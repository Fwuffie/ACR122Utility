namespace ACRUtility
{
    partial class ACRUtility
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
            this.output = new System.Windows.Forms.ListBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.Write = new System.Windows.Forms.TabPage();
            this.Read = new System.Windows.Forms.TabPage();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.Debug = new System.Windows.Forms.TabPage();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.Read.SuspendLayout();
            this.Debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.FormattingEnabled = true;
            this.output.HorizontalScrollbar = true;
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.output.MinimumSize = new System.Drawing.Size(400, 400);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(1000, 511);
            this.output.TabIndex = 4;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.Write);
            this.tabs.Controls.Add(this.Read);
            this.tabs.Controls.Add(this.Debug);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1008, 568);
            this.tabs.TabIndex = 6;
            // 
            // Write
            // 
            this.Write.Location = new System.Drawing.Point(4, 22);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(1000, 542);
            this.Write.TabIndex = 2;
            this.Write.Text = "Write Card Data";
            this.Write.UseVisualStyleBackColor = true;
            // 
            // Read
            // 
            this.Read.Controls.Add(this.lblConnectionStatus);
            this.Read.Location = new System.Drawing.Point(4, 22);
            this.Read.Name = "Read";
            this.Read.Padding = new System.Windows.Forms.Padding(3);
            this.Read.Size = new System.Drawing.Size(1000, 542);
            this.Read.TabIndex = 1;
            this.Read.Text = "Read Card Data";
            this.Read.UseVisualStyleBackColor = true;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(846, 15);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(109, 13);
            this.lblConnectionStatus.TabIndex = 0;
            this.lblConnectionStatus.Text = "Status: Disconnected";
            // 
            // Debug
            // 
            this.Debug.Controls.Add(this.cmdExecute);
            this.Debug.Controls.Add(this.txtCommand);
            this.Debug.Controls.Add(this.output);
            this.Debug.Location = new System.Drawing.Point(4, 22);
            this.Debug.Name = "Debug";
            this.Debug.Padding = new System.Windows.Forms.Padding(3);
            this.Debug.Size = new System.Drawing.Size(1000, 542);
            this.Debug.TabIndex = 0;
            this.Debug.Text = "Debug Console";
            this.Debug.UseVisualStyleBackColor = true;
            // 
            // cmdExecute
            // 
            this.cmdExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExecute.Location = new System.Drawing.Point(924, 516);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(76, 20);
            this.cmdExecute.TabIndex = 6;
            this.cmdExecute.Text = "Execute";
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(0, 516);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(918, 20);
            this.txtCommand.TabIndex = 5;
            // 
            // ACRUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 568);
            this.Controls.Add(this.tabs);
            this.Name = "ACRUtility";
            this.Text = "Form1";
            this.tabs.ResumeLayout(false);
            this.Read.ResumeLayout(false);
            this.Read.PerformLayout();
            this.Debug.ResumeLayout(false);
            this.Debug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox output;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage Read;
        private System.Windows.Forms.TabPage Debug;
        private System.Windows.Forms.TabPage Write;
        private System.Windows.Forms.Button cmdExecute;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblConnectionStatus;
    }
}

