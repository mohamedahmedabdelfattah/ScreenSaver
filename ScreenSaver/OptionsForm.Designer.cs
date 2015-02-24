namespace ScreenSaver
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.textImagesPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupImages = new System.Windows.Forms.GroupBox();
            this.labelFont = new System.Windows.Forms.LinkLabel();
            this.labelSlideShowSpeed = new System.Windows.Forms.Label();
            this.comboSlideShowSpeed = new System.Windows.Forms.ComboBox();
            this.checkResize = new System.Windows.Forms.CheckBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkLockWorkStation = new System.Windows.Forms.CheckBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.groupImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // textImagesPath
            // 
            this.textImagesPath.Location = new System.Drawing.Point(14, 22);
            this.textImagesPath.Name = "textImagesPath";
            this.textImagesPath.Size = new System.Drawing.Size(336, 20);
            this.textImagesPath.TabIndex = 1;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // groupImages
            // 
            this.groupImages.Controls.Add(this.labelFont);
            this.groupImages.Controls.Add(this.labelSlideShowSpeed);
            this.groupImages.Controls.Add(this.comboSlideShowSpeed);
            this.groupImages.Controls.Add(this.checkResize);
            this.groupImages.Controls.Add(this.textImagesPath);
            this.groupImages.Controls.Add(this.buttonBrowse);
            this.groupImages.Location = new System.Drawing.Point(12, 10);
            this.groupImages.Name = "groupImages";
            this.groupImages.Size = new System.Drawing.Size(401, 116);
            this.groupImages.TabIndex = 3;
            this.groupImages.TabStop = false;
            this.groupImages.Text = "Use pictures from: ";
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(318, 81);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(69, 13);
            this.labelFont.TabIndex = 5;
            this.labelFont.TabStop = true;
            this.labelFont.Text = "Change Font";
            this.labelFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelFont_LinkClicked);
            // 
            // labelSlideShowSpeed
            // 
            this.labelSlideShowSpeed.AutoSize = true;
            this.labelSlideShowSpeed.Location = new System.Drawing.Point(11, 81);
            this.labelSlideShowSpeed.Name = "labelSlideShowSpeed";
            this.labelSlideShowSpeed.Size = new System.Drawing.Size(93, 13);
            this.labelSlideShowSpeed.TabIndex = 7;
            this.labelSlideShowSpeed.Text = "Slide show speed:";
            // 
            // comboSlideShowSpeed
            // 
            this.comboSlideShowSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSlideShowSpeed.FormattingEnabled = true;
            this.comboSlideShowSpeed.Items.AddRange(new object[] {
            "Slow",
            "Medium",
            "Fast"});
            this.comboSlideShowSpeed.Location = new System.Drawing.Point(140, 78);
            this.comboSlideShowSpeed.Name = "comboSlideShowSpeed";
            this.comboSlideShowSpeed.Size = new System.Drawing.Size(121, 21);
            this.comboSlideShowSpeed.TabIndex = 6;
            // 
            // checkResize
            // 
            this.checkResize.AutoSize = true;
            this.checkResize.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkResize.Location = new System.Drawing.Point(14, 55);
            this.checkResize.Name = "checkResize";
            this.checkResize.Size = new System.Drawing.Size(105, 17);
            this.checkResize.TabIndex = 5;
            this.checkResize.Text = "Resize to screen";
            this.checkResize.UseVisualStyleBackColor = true;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Image = global::ScreenSaver.Properties.Resources.folder_open;
            this.buttonBrowse.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonBrowse.Location = new System.Drawing.Point(356, 17);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(31, 31);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(175, 155);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkLockWorkStation
            // 
            this.checkLockWorkStation.AutoSize = true;
            this.checkLockWorkStation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkLockWorkStation.Location = new System.Drawing.Point(26, 132);
            this.checkLockWorkStation.Name = "checkLockWorkStation";
            this.checkLockWorkStation.Size = new System.Drawing.Size(108, 17);
            this.checkLockWorkStation.TabIndex = 4;
            this.checkLockWorkStation.Text = "Lock Workstation";
            this.checkLockWorkStation.UseVisualStyleBackColor = true;
            // 
            // fontDialog
            // 
            this.fontDialog.Font = new System.Drawing.Font("Pragmata TT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 189);
            this.Controls.Add(this.checkLockWorkStation);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupImages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsForm_KeyDown);
            this.groupImages.ResumeLayout(false);
            this.groupImages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textImagesPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupImages;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.CheckBox checkLockWorkStation;
        private System.Windows.Forms.CheckBox checkResize;
        private System.Windows.Forms.Label labelSlideShowSpeed;
        private System.Windows.Forms.ComboBox comboSlideShowSpeed;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.LinkLabel labelFont;
    }
}