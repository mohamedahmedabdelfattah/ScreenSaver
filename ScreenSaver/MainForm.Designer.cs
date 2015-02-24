namespace ScreenSaver
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timerBackgroundImage = new System.Windows.Forms.Timer(this.components);
            this.labelDateTime = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.bgSpeech = new System.ComponentModel.BackgroundWorker();
            this.labeltimerBackgroundImageStatus = new System.Windows.Forms.Label();
            this.bgLoadImages = new System.ComponentModel.BackgroundWorker();
            this.pictureBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // timerBackgroundImage
            // 
            this.timerBackgroundImage.Interval = 2000;
            this.timerBackgroundImage.Tick += new System.EventHandler(this.timerBackgroundImage_Tick);
            // 
            // labelDateTime
            // 
            this.labelDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.BackColor = System.Drawing.Color.Black;
            this.labelDateTime.Font = new System.Drawing.Font("Pragmata TT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDateTime.Location = new System.Drawing.Point(12, 419);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(150, 35);
            this.labelDateTime.TabIndex = 0;
            this.labelDateTime.Text = "Time&&Date";
            this.labelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDateTime.Visible = false;
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // bgSpeech
            // 
            this.bgSpeech.WorkerSupportsCancellation = true;
            this.bgSpeech.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSpeech_DoWork);
            // 
            // labeltimerBackgroundImageStatus
            // 
            this.labeltimerBackgroundImageStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labeltimerBackgroundImageStatus.AutoSize = true;
            this.labeltimerBackgroundImageStatus.BackColor = System.Drawing.Color.Black;
            this.labeltimerBackgroundImageStatus.Font = new System.Drawing.Font("Pragmata TT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltimerBackgroundImageStatus.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labeltimerBackgroundImageStatus.Location = new System.Drawing.Point(871, 14);
            this.labeltimerBackgroundImageStatus.Name = "labeltimerBackgroundImageStatus";
            this.labeltimerBackgroundImageStatus.Size = new System.Drawing.Size(105, 35);
            this.labeltimerBackgroundImageStatus.TabIndex = 1;
            this.labeltimerBackgroundImageStatus.Text = "Status";
            this.labeltimerBackgroundImageStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labeltimerBackgroundImageStatus.Visible = false;
            // 
            // bgLoadImages
            // 
            this.bgLoadImages.WorkerSupportsCancellation = true;
            this.bgLoadImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadImages_DoWork);
            this.bgLoadImages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadImages_RunWorkerCompleted);
            // 
            // pictureBackground
            // 
            this.pictureBackground.BackColor = System.Drawing.Color.Transparent;
            this.pictureBackground.BackgroundImage = global::ScreenSaver.Properties.Resources.prayer;
            this.pictureBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBackground.Name = "pictureBackground";
            this.pictureBackground.Size = new System.Drawing.Size(1000, 500);
            this.pictureBackground.TabIndex = 2;
            this.pictureBackground.TabStop = false;
            this.pictureBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.pictureBackground.Click += new System.EventHandler(this.MainForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.labeltimerBackgroundImageStatus);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.pictureBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Timer timerBackgroundImage;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Timer timerTime;
        private System.ComponentModel.BackgroundWorker bgSpeech;
        private System.Windows.Forms.Label labeltimerBackgroundImageStatus;
        private System.ComponentModel.BackgroundWorker bgLoadImages;
        private System.Windows.Forms.PictureBox pictureBackground;
    }
}

