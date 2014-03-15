using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ITAMngApp
{
    public class SplashAppContext : ApplicationContext
    {
        private Form mainForm;
        private Timer splashTimer;

        public SplashAppContext(Form mainForm, Form splashForm)
            : base(splashForm)
        {
            this.splashTimer = new Timer();
            this.mainForm = mainForm;
            this.splashTimer.Tick += new EventHandler(this.SplashTimeUp);
            this.splashTimer.Interval = 0x7d0;
            this.splashTimer.Enabled = true;
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (sender is Splash)
            {
                base.MainForm = this.mainForm;
                base.MainForm.Show();
            }
            else if (sender == MainForm)
            {
                base.OnMainFormClosed(sender, e);
            }
        }

        private void SplashTimeUp(object sender, EventArgs e)
        {
            this.splashTimer.Enabled = false;
            this.splashTimer.Dispose();
            base.MainForm.Close();
        }

        public int SecondsSplashShown
        {
            set
            {
                this.splashTimer.Interval = value * 0x3e8;
            }
        }
    }
}
