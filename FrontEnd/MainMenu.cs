using Do_An;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Resources
{
    public partial class MainMenu : Form
    {
        // Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activateForm;
        private ObjectId currentUserId;
        // Constructor
        public MainMenu(ObjectId userID)
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.currentUserId = userID;
            this.Load += MainMenu_Load;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Method

        private void ActivateButton(object btnSender, string functionName)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ThemeColor.GetFunctionColor(functionName);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }


        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold); new Font("Segoe UI", 12F, FontStyle.Bold);
                }
            }
        }

        private void OpenChildForm(object child, object btnSender)
        {
            // Clear previous content
            if (activateForm != null)
            {
                activateForm.Close();
                activateForm = null;
            }
            panelDesktopPane.Controls.Clear();

            // Handle UserControl
            if (child is UserControl uc)
            {
                ActivateButton(btnSender, uc.Name);
                uc.Dock = DockStyle.Fill;
                panelDesktopPane.Controls.Add(uc);
                uc.BringToFront();
                lbTitle.Text = uc.Name;
            }
            // Handle Form
            else if (child is Form form)
            {
                ActivateButton(btnSender, form.Text);
                activateForm = form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                panelDesktopPane.Controls.Add(form);
                panelDesktopPane.Tag = form;
                form.BringToFront();
                form.Show();
                lbTitle.Text = form.Text;
            }
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            OpenChildForm(new GameLobby(currentUserId), sender);
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            ActivateButton(sender, "Leaderboard");
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            OpenChildForm(new UserProfile(currentUserId), sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            OpenChildForm(new ClientSettings(currentUserId), sender);
        }
        private void btnFriends_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            OpenChildForm(new FriendPage(currentUserId), sender);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            SoundManager.StopBackgroundMusic();
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            SoundManager.PlayClickSound();
            OpenChildForm(new NotificationPage(currentUserId), sender);
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            btnProfile.PerformClick();
            SoundManager.PlayBackgroundMusic();
        }

    }
}
