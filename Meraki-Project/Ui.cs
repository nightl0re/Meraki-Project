using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Meraki_Project
{
    // Small UI helpers shared by every form, so the same code isn't repeated
    // in each one.
    internal static class Ui
    {
        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private const int SB_BOTH = 3;

        // Keeps a panel scrollable (mouse wheel still works) but never shows the
        // scrollbars themselves. Windows re-adds them after layout/scroll, so we
        // hide them again on every event that could bring them back.
        public static void HideScrollbars(ScrollableControl panel)
        {
            // Some forms call their Load handler again as a "refresh"; only wire
            // the events once per control.
            if (panel.Tag is "no-scrollbars") return;
            panel.Tag = "no-scrollbars";

            panel.AutoScroll = true;

            void Hide()
            {
                if (!panel.IsHandleCreated) return;
                ShowScrollBar(panel.Handle, SB_BOTH, false);
                // Windows recalculates scrollbar visibility internally right after
                // layout/scroll, which can silently re-show it in the same message
                // pass. A deferred second hide (next idle tick) catches that.
                panel.BeginInvoke(new Action(() =>
                {
                    if (panel.IsHandleCreated) ShowScrollBar(panel.Handle, SB_BOTH, false);
                }));
            }
            panel.Layout += (s, e) => Hide();
            panel.Resize += (s, e) => Hide();
            panel.Scroll += (s, e) => Hide();
            panel.MouseWheel += (s, e) => Hide();
            panel.ControlAdded += (s, e) => Hide();
            panel.HandleCreated += (s, e) => Hide();
            Hide();
        }

        // Mixes a color toward white; amount 0 = unchanged, 1 = white.
        public static Color Lighten(Color c, double amount)
        {
            int r = (int)(c.R + (255 - c.R) * amount);
            int g = (int)(c.G + (255 - c.G) * amount);
            int b = (int)(c.B + (255 - c.B) * amount);
            return Color.FromArgb(r, g, b);
        }
    }
}
