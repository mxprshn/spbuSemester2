using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WinFormsClock
{
    public partial class ClockForm : Form
    {
        private PrivateFontCollection clockFonts = new PrivateFontCollection();

        public ClockForm()
        {
            clockFonts.AddFontFile("HelveticaNeueCyr-Bold.ttf");
            clockFonts.AddFontFile("HelveticaNeueCyr-Roman.ttf");
            InitializeComponent();
        }

        private void UpdateTimerTick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            dateLabel.Text = DateTime.Now.ToString("m");
        }

        private void ClockFormLoad(object sender, EventArgs e) => updateTimer.Start();
    }
}
