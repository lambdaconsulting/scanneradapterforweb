namespace ScannerAdapter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DevicesList = new System.Windows.Forms.ListBox();
            this.ListDevices = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DevicesList
            // 
            this.DevicesList.FormattingEnabled = true;
            this.DevicesList.Location = new System.Drawing.Point(12, 12);
            this.DevicesList.Name = "DevicesList";
            this.DevicesList.Size = new System.Drawing.Size(186, 186);
            this.DevicesList.TabIndex = 0;
            // 
            // ListDevices
            // 
            this.ListDevices.Location = new System.Drawing.Point(205, 12);
            this.ListDevices.Name = "ListDevices";
            this.ListDevices.Size = new System.Drawing.Size(90, 55);
            this.ListDevices.TabIndex = 1;
            this.ListDevices.Text = "List Device";
            this.ListDevices.UseVisualStyleBackColor = true;
            this.ListDevices.Click += new System.EventHandler(this.ListDevices_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(205, 78);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(90, 55);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(204, 143);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(90, 55);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Adapter Status : ";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(105, 205);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(47, 13);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "Stopped";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 226);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ListDevices);
            this.Controls.Add(this.DevicesList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scanner Adapter By LC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox DevicesList;
        private System.Windows.Forms.Button ListDevices;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StatusLabel;
    }
}

