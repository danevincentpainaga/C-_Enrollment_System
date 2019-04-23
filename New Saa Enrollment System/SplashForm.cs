using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Saa_Enrollment_System
{
    public partial class SplashForm : Form
    {
        private double i;
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            fadeIn_timer.Start();
        }

        private void fadeIn_timer_Tick(object sender, EventArgs e)
        {
            i += 0.13;
            if (i >= 1)
            {//if form is fully visible, we execute the Fade Out Effect
                this.Opacity = 1;
                fadeIn_timer.Enabled = false;//stop the Fade In Effect
                return;
            }
            this.Opacity = i;
        }
    }
}
