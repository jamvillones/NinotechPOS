using System;
using System.Windows.Forms;

namespace POS.Misc {
    internal class NotificationHandler {
        public static NotificationHandler Instance { get; private set; } = new NotificationHandler();
        public void ShowTooltip(string title, string details, ToolTipIcon icon) {
            //notifyIcon1.BalloonTipTitle = title;
            //notifyIcon1.BalloonTipText = details;
            //notifyIcon1.ShowBalloonTip(1);
            ShowCallback(title, details, icon);
        }
        public Action<string, string, ToolTipIcon> ShowCallback { get; set; }
    }
}
