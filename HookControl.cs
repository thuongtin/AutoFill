using System;
using System.Collections.Generic;
using System.Text;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace AutoFill
{
    class HookControl
    {


        public enum MouseEventType : int
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x10
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public static void LeftClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }


        private readonly KeyboardHookListener m_KeyboardHookManager;
        private readonly MouseHookListener m_MouseHookManager;
        private SmartForm sf;
        private AutoFill at;
        private bool mouseDown;
        private long mouseDownTime;
        private bool canType;
        private Sender sender;
        private System.Drawing.Point smartPoint, smartPoint2;

        public long Now
        {
            get { return DateTime.Now.Ticks; }
        }

        public HookControl()
        {
            m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            m_KeyboardHookManager.Enabled = true;
            m_KeyboardHookManager.KeyUp += m_KeyboardHookManager_KeyUp;
            



            m_MouseHookManager = new MouseHookListener(new GlobalHooker());
            m_MouseHookManager.Enabled = true;
            m_MouseHookManager.MouseDown += m_MouseHookManager_MouseDown;
            m_MouseHookManager.MouseUp += m_MouseHookManager_MouseUp;
            m_MouseHookManager.MouseDoubleClick += m_MouseHookManager_MouseDoubleClick;
            m_MouseHookManager.MouseClick += m_MouseHookManager_MouseClick;

            
            mouseDown = false;
            canType = false;
        }

        void m_MouseHookManager_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && sf.Visible && canWork())
            {
                smartPoint2 = Cursor.Position;
            }
        }

        void m_MouseHookManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (canWork())
            {
                if (e.Button == MouseButtons.Right && at.OnOff)
                {
                    sf.SmartClick = true;
                    smartPoint = Cursor.Position;
                    sf.setHeader(true);

                    int x = Cursor.Position.X;
                    int y = Cursor.Position.Y;
                    if (Screen.PrimaryScreen.WorkingArea.Height - y < sf.Height)
                    {
                        y = Screen.PrimaryScreen.WorkingArea.Height - sf.Height;
                    }

                    //sf.Location = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y, sf.Width, sf.Height);
                    sf.SetDesktopBounds(x, y, sf.Width, sf.Height);
                }
            }
        }

        public HookControl(SmartForm sf)
            : this()
        {
            this.sf = sf;
            this.sf.LeftClick += sf_LeftClick;
            this.sf.LeftClick2 += sf_LeftClick2;
        }

        void sf_LeftClick2(object sender, EventArgs e)
        {
            LeftClick(smartPoint2.X, smartPoint2.Y);
            Type(sf.getSelectedText());
        }

        void sf_LeftClick(object sender, EventArgs e)
        {
            LeftClick(smartPoint.X, smartPoint.Y);
            
            Type(sf.getSelectedText());
        }

        public HookControl(AutoFill at, SmartForm sf)
            : this(sf)
        {
            this.at = at;
            sender = new Sender(this, at);
           
        }



        void m_MouseHookManager_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            mouseDownTime = Now;

            if (canType && ((Control.ModifierKeys & Keys.Alt) == 0) && canWork() && sf.Visible)
            {
                //LeftClick(smartPoint2.X, smartPoint2.Y);
               // Type(sf.getSelectedText());
                canType = false;
                sf_LeftClick2(this, EventArgs.Empty);
            }
        }

        void m_MouseHookManager_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseDownTime = Now;
        }

        void m_KeyboardHookManager_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        int index = sf.InfoId + 1;
                        sf.updateListView(index);
                    }
                    break;
                case Keys.Up:
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        int index = sf.InfoId - 1;
                        sf.updateListView(index);
                    }
                    break;
                case Keys.LMenu:
                    if (mouseDown && ((Now - mouseDownTime) / 1000000 > 2))
                    {
                        sf.next();
                        canType = true;
                    }
                    break;
                case Keys.LControlKey:
                    if (mouseDown && ((Now - mouseDownTime) / 1000000 > 2))
                    {
                        sf.pre();
                        canType = true;
                    }
                    break;
                case Keys.LShiftKey:
                    if (mouseDown && ((Now - mouseDownTime) / 1000000 > 2))
                    {
                        sf.Visible = !sf.Visible;
                    }
                    break;
                case Keys.Escape:
                    
                    this.sender.Stop();
                    sf.setHeader(false);
                    sf.SetDesktopBounds(Screen.PrimaryScreen.WorkingArea.Width - sf.Width, Screen.PrimaryScreen.WorkingArea.Height - sf.Height, sf.Width, sf.Height);
                    break;
                case Keys.F2:
                    if (sf.Visible)
                    {
                        this.sender.Text = sf.getSelectedText();
                        this.sender.Start();
                    }
                    break;
                case Keys.F3:
                    
                    sf.pre();
                    break;
                case Keys.F4:
                    
                    sf.next();
                    break;
                case Keys.F9:
                    int idInfo = at.getIdInfoSelected();
                    if (idInfo != -1)
                        sf.updateListView(idInfo);
                    break;
                case Keys.F10:

                    sf.copy();
                    break;
                    
            }
        }


        


        public bool canWork()
        {
            return Cursor.Position.X < (Screen.PrimaryScreen.WorkingArea.Width - sf.Width) || Cursor.Position.Y < (Screen.PrimaryScreen.WorkingArea.Height - sf.Height);
        }


        private void Type(String text)
        {
            sender.SetInterval(at.Delay);
            sender.Text = text;
            //sender.Start();
            sender.T2Timer.Enabled = true;
        }


    }
}
