using System;
using System.Windows.Forms;

namespace WinFormsClock
{
    public partial class ClockForm : Form
    {
        public ClockForm() => InitializeComponent();

        private void UpdateTimerTick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            dateLabel.Text = DateTime.Now.ToString("m");
        }

        private void ClockFormLoad(object sender, EventArgs e) => updateTimer.Start();
    }
}
