using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SpeechLib;

namespace ScreenSaver
{
    public partial class MainForm : Form
    {

        #region Global Variables

        int imgIndex = 0;

        private bool IsPreviewMode = false;

        private bool IsResizeToScreen = Properties.Settings.Default.ResizeImage;

        List<string> imgFolderImages = new List<string>();

        Random rand = new Random();

        Point mouseOriginalLocation = new Point(int.MaxValue, int.MaxValue);

        private enum BackgroundStatus
        {
            Null,
            Loading,
            Paused
        };

        #endregion

        #region API's

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool LockWorkStation();

        #endregion

        #region Constructor
        public MainForm(Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;
        }

        // This constructor is to handle the select screen saver dialog preview window
        // It is used when in preview mode (/p)
        public MainForm(IntPtr PreviewHandle)
        {
            InitializeComponent();

            //set the preview window as the parent of this window
            SetParent(this.Handle, PreviewHandle);

            //make this a child window, so when the select screen saver dialog closes, this will also close
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            //set our window's size to the size of our window's new parent
            Rectangle ParentRect;
            GetClientRect(PreviewHandle, out ParentRect);
            this.Size = ParentRect.Size;

            //set our location at (0, 0)
            this.Location = new Point(0, 0);

            IsPreviewMode = true;
        }

        #endregion

        #region Methods

        private void SetBackgroundStatus(BackgroundStatus status, bool visible)
        {
            switch (status)
            {
                case BackgroundStatus.Paused:
                    {
                        labeltimerBackgroundImageStatus.Text = "Paused";
                        break;
                    }
                case BackgroundStatus.Loading:
                    {
                        labeltimerBackgroundImageStatus.Text = "Loading";
                        break;
                    }

                case BackgroundStatus.Null:
                default:
                    {
                        labeltimerBackgroundImageStatus.Text = "";
                        break;
                    }
            }

            if (visible)
                labeltimerBackgroundImageStatus.Visible = true;
            else
                labeltimerBackgroundImageStatus.Visible = false;
        }

        private void ChangeImage()
        {
            if (imgIndex < imgFolderImages.Count)
            {
                Image img = new Bitmap(imgFolderImages[imgIndex]);

                if (IsResizeToScreen)
                    pictureBackground.Image = ResizeImage(img, this.Size);
                else
                    pictureBackground.Image = img;

                imgIndex++;
            }
            else
                imgIndex = 0;
        }

        private void LoadImages(bool isBackgroundLoading)
        {
            if (Properties.Settings.Default.imgsFolder == "")
                ChangeSettings();
            else
            {
                if (isBackgroundLoading)
                {
                    if (bgLoadImages.IsBusy)
                        bgSpeech.CancelAsync();

                    bgLoadImages.RunWorkerAsync();

                    timerBackgroundImage.Start();

                    SetBackgroundStatus(BackgroundStatus.Loading, true);
                }
                else
                {
                    imgFolderImages.Clear();

                    string[] imgfolderFiles = Directory.GetFiles(Properties.Settings.Default.imgsFolder, "*.*", SearchOption.AllDirectories);

                    foreach (string s in imgfolderFiles)
                    {
                        if (s.EndsWith("jpg", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("jpeg", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("bmp", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("png", StringComparison.CurrentCultureIgnoreCase))
                            imgFolderImages.Add(s);
                    }

                    if (imgFolderImages.Count > 0)
                        timerBackgroundImage.Start();
                    else
                    {
                        pictureBackground.Image = Properties.Resources.prayer;

                        Cursor.Show();

                        DialogResult result = MessageBox.Show("Can't locate any images at the specific location.", Application.ProductName + " Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                        if (result == DialogResult.Retry)
                            ChangeSettings();
                        else
                        {
                            mouseOriginalLocation = Cursor.Position;
                            Cursor.Hide();
                        }
                    }
                }
            }
        }

        private void SetSlideShowSpeed()
        {
            switch (Properties.Settings.Default.SlideShowSpeed)
            {
                case "Slow":
                    {
                        timerBackgroundImage.Interval = (5000);
                        break;
                    }

                case "Medium":
                    {
                        timerBackgroundImage.Interval = (3000);
                        break;
                    }

                case "Fast":
                    {
                        timerBackgroundImage.Interval = (500);
                        break;
                    }

                default:
                    {
                        timerBackgroundImage.Interval = 3000;
                        break;
                    }
            }
        }

        private void ChangeSettings()
        {
            timerBackgroundImage.Stop();

            Cursor.Show();

            new OptionsForm().ShowDialog();

            Cursor.Hide();
            mouseOriginalLocation = Cursor.Position;

            SetSlideShowSpeed();

            LoadImages(true);

            if (Properties.Settings.Default.FontSettings != null)
            {
                labelDateTime.Font = Properties.Settings.Default.FontSettings;
                labeltimerBackgroundImageStatus.Font = Properties.Settings.Default.FontSettings;
            }
        }

        private Image ResizeImage(Image image, Size size)
        {
            Image newImage = new Bitmap(size.Width, size.Height);

            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, size.Width, size.Height);
            }

            return newImage;
        }

        #endregion

        #region Form

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadImages(true);

            //bg.RunWorkerAsync();

            //Speechthreaded();

            if (!IsPreviewMode)
            {
                Cursor.Hide();

                if (Properties.Settings.Default.FontSettings != null)
                {
                    labelDateTime.Font = Properties.Settings.Default.FontSettings;
                    labeltimerBackgroundImageStatus.Font = Properties.Settings.Default.FontSettings;
                }
            }
        }

        //start off OriginalLoction with an X and Y of int.MaxValue, because
        //it is impossible for the cursor to be at that position. That way, we
        //know if this variable has been set yet.
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsPreviewMode) //disable exit functions for preview
            {
                //see if originallocation has been set
                if (mouseOriginalLocation.X == int.MaxValue & mouseOriginalLocation.Y == int.MaxValue)
                    mouseOriginalLocation = e.Location;

                //see if the mouse has moved more than 20 pixels in any direction. If it has, close the application.
                if (Math.Abs(e.X - mouseOriginalLocation.X) > 20 | Math.Abs(e.Y - mouseOriginalLocation.Y) > 20)
                    Application.Exit();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsPreviewMode) //disable exit functions for preview
            {
                if (e.KeyCode == Keys.F1)
                    ChangeSettings();
                else
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        if (timerBackgroundImage.Enabled)
                        {
                            timerBackgroundImage.Stop();
                            SetBackgroundStatus(BackgroundStatus.Paused, true);
                        }
                        else
                        {
                            timerBackgroundImage.Start();
                            SetBackgroundStatus(BackgroundStatus.Null, false);
                        }
                    }
                    else
                        Application.Exit();
                }
            }
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            if (!IsPreviewMode) //disable exit functions for preview
                Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!IsPreviewMode)
            {
                if (Properties.Settings.Default.LockWorkStation)
                    LockWorkStation();

                Application.Exit();
            }
        }

        #endregion

        #region Timers

        private void timerBackgroundImage_Tick(object sender, EventArgs e)
        {
            SetSlideShowSpeed();

            ChangeImage();

            //TODO
            //DisplayTime();

            //labelDateTime.ForeColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            if (!IsPreviewMode)
            {
                labelDateTime.Text = "Welcome, " + Environment.UserName + Environment.NewLine;
                labelDateTime.Text += DateTime.Now.ToLongDateString().ToString() + " ";
                labelDateTime.Text += DateTime.Now.ToLongTimeString();

                if (labeltimerBackgroundImageStatus.Visible)
                    labeltimerBackgroundImageStatus.ForeColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

                //TODO
                //DisplayTime();
            }
        }

        //TODO
        //private void DisplayTime()
        //{
        //    if (imgIndex > 0)
        //    {
        //        Graphics g = Graphics.FromImage(pictureBackground.Image);

        //        g.DrawString("Welcome, " + Environment.UserName + Environment.NewLine +
        //            DateTime.Now.ToLongDateString().ToString() + " " +
        //            DateTime.Now.ToLongTimeString(), labelDateTime.Font, new SolidBrush(Color.Red), labelDateTime.Location.X, labelDateTime.Location.Y);
        //    }
        //}

        #endregion

        #region Speech

        /// <summary>
        /// Speech with Multithreading
        /// </summary>
        private void Speechthreaded()
        {
            System.Threading.Thread SpeechThread = new System.Threading.Thread(Speech);
            SpeechThread.Start();
            //SpeechThread.Join();
        }

        private void Speech()
        {
            SpVoice Talk = new SpVoice();
            Talk.Speak("Welcome Sir", 0);
        }

        /// <summary>
        /// BackgroundWorker
        /// </summary>
        private void bgSpeech_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Speech();
        }

        #endregion

        #region bgLoadImages

        private void bgLoadImages_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (bgLoadImages.CancellationPending)
                e.Cancel = true;
            else
            {
                imgFolderImages.Clear();

                string[] imgfolderFiles = Directory.GetFiles(Properties.Settings.Default.imgsFolder, "*.*", SearchOption.AllDirectories);

                foreach (string s in imgfolderFiles)
                {
                    if (s.EndsWith("jpg", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("jpeg", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("bmp", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith("png", StringComparison.CurrentCultureIgnoreCase))
                        imgFolderImages.Add(s);
                }
            }
        }

        private void bgLoadImages_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            SetBackgroundStatus(BackgroundStatus.Null, false);

            if (imgFolderImages.Count > 0)
                timerBackgroundImage.Start();
            else
            {
                pictureBackground.Image = Properties.Resources.prayer;

                Cursor.Show();

                DialogResult result = MessageBox.Show("Can't locate any images at the specific location.", Application.ProductName + " Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                    ChangeSettings();
                else
                {
                    mouseOriginalLocation = Cursor.Position;
                    Cursor.Hide();
                }
            }
        }

        #endregion

    }
}