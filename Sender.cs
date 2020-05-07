using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AutoFill
{
    class Sender
    {
        public String Text { get; set; }
        public Timer T2Timer { get; set; }
        private HookControl hc;
        private AutoFill at;
        private int charId;
        private String kt;

        private char[] Str
        {
            get
            {
                return Text.ToCharArray();
            }
        }

        public Sender()
        {
            Text = String.Empty;
            T2Timer = new Timer();
            T2Timer.Tick += t2Timer_Tick;
            charId = 0;
        }

        public Sender(HookControl hc)
            : this()
        {
            this.hc = hc;
        }

        public Sender(HookControl hc, AutoFill at)
            : this(hc)
        {
            this.at = at;
        }

        public void SetInterval(int miliseconds)
        {
            T2Timer.Interval = miliseconds;
        }

        public void Start()
        {
            T2Timer.Enabled = true;
        }



        public void Stop()
        {
            T2Timer.Enabled = false;
        }


        private void t2Timer_Tick(object sender, EventArgs e)
        {
            if (charId >= Text.Length)
            {
                charId = 0;
                T2Timer.Enabled = false;
                return;
            }


            if (Control.ModifierKeys == Keys.None)
            {
                if (at.ClearText && charId == 0)
                {
                    SendKeys.Send("{HOME}");
                    SendKeys.Send("+{END}");
                }
                kt = Str[charId].ToString();
                if (kt.Equals("+"))
                {
                    kt = "{+}";
                }
                else if (kt.Equals("("))
                {
                    kt = "{(}";
                }
                else if (kt.Equals(")"))
                {
                    kt = "{)}";
                }
                else if (kt.Equals("^"))
                {
                    kt = "{^}";
                }
                else if (kt.Equals("!"))
                {
                    kt = "{!}";
                }
                else if (kt.Equals("%"))
                {
                    kt = "{%}";
                }
                else if (kt.Equals("~"))
                {
                    kt = "{~}";
                }
                else if (kt.Equals("{"))
                {
                    kt = "{{}";
                }
                else if (kt.Equals("}"))
                {
                    kt = "{}}";
                }
                SendKeys.Send(kt);
                charId++;
            }
        }
    }
}
