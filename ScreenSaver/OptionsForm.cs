using System;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class OptionsForm : Form
    {

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " Settings";

            if (Properties.Settings.Default.imgsFolder == "")
                textImagesPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            else
                textImagesPath.Text = Properties.Settings.Default.imgsFolder;

            checkLockWorkStation.Checked = Properties.Settings.Default.LockWorkStation;
            checkResize.Checked = Properties.Settings.Default.ResizeImage;
            comboSlideShowSpeed.SelectedItem = Properties.Settings.Default.SlideShowSpeed;
        }

        private void OptionsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }

        private void labelFont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fontDialog.ShowDialog();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textImagesPath.Text;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textImagesPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(textImagesPath.Text))
            {
                Properties.Settings.Default.imgsFolder = textImagesPath.Text;
                Properties.Settings.Default.LockWorkStation = checkLockWorkStation.Checked;
                Properties.Settings.Default.ResizeImage = checkResize.Checked;
                Properties.Settings.Default.SlideShowSpeed = comboSlideShowSpeed.SelectedItem.ToString();
                Properties.Settings.Default.FontSettings = fontDialog.Font;

                Properties.Settings.Default.Save();

                this.Close();
            }
            else
                MessageBox.Show("The Path you typed is not valid.", Application.ProductName + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.imgsFolder == "")
                Properties.Settings.Default.imgsFolder = textImagesPath.Text;
        }
    }
}