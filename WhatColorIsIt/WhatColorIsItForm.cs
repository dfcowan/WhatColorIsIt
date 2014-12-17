using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhatColorIsIt
{
    public partial class WhatColorIsItForm : Form
    {
        private Point previousMouseLocation;
        private Timer refresh;
        private DateTime lastMoved;

        public WhatColorIsItForm()
        {
            InitializeComponent();
        }

        public WhatColorIsItForm(Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;

            UpdateTimeAndColor();
            UpdateLocation();
        }

        private void WhatColorIsItForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;

            refresh = new Timer();
            refresh.Interval = 100;
            refresh.Tick += new EventHandler(refresh_Tick);
            refresh.Start();
        }

        private void WhatColorIsItForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!previousMouseLocation.IsEmpty)
            {
                if (Math.Abs(previousMouseLocation.X - e.X) > 5 ||
                    Math.Abs(previousMouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }

            previousMouseLocation = e.Location;
        }

        private void WhatColorIsItForm_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void WhatColorIsItForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void refresh_Tick(object sender, System.EventArgs e)
        {
            UpdateTimeAndColor();
            UpdateLocation();
        }

        private void UpdateTimeAndColor()
        {
            DateTime now = DateTime.Now;

            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;
            int OFFSET = 50;

            this.BackColor = Color.FromArgb(hour, minute, second);
            lblTime.ForeColor = Color.FromArgb(hour + OFFSET, minute + OFFSET, second + OFFSET);

            lblTime.Text = "#" + hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
        }

        private void UpdateLocation()
        {
            DateTime now = DateTime.Now;

            if (lastMoved == null)
            {
                lastMoved = new DateTime();
            }

            if ((now - lastMoved).TotalSeconds > 15)
            {
                Random rand = new Random();
                lblTime.Left = rand.Next(Math.Max(1, Bounds.Width - lblTime.Width));
                lblTime.Top = rand.Next(Math.Max(1, Bounds.Height - lblTime.Height));
                lastMoved = now;
            }
        }
    }
}
