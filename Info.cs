using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoFill
{
    class InfoRow
    {
        public String Text { get; set; }
        public int Style { get; set; }

        public InfoRow(String text)
        {
            this.Text = text;
            this.Style = 0;
        }

        public InfoRow(String text, int style)
        {
            this.Text = text;
            this.Style = style;
        }
    }

    class Info
    {
        public event EventHandler InfoChanged;
        public event EventHandler UpdateInfo;

        public List<InfoRow> InfoRows { get; private set; }
        public Color color;
        public Info()
        {
            InfoRows = new List<InfoRow>();
            color = Color.Black;
        }
        public int Count
        {
            get
            {
                return InfoRows.Count;
            }
        }
        public InfoRow this[int index]
        {
            get
            {
                return InfoRows[index];
            }
            set
            {
                InfoRows[index] = value;
            }
        }
        public void Add(String info)
        {
            info = info.Trim();
            Regex pattern = new Regex(@"^2fa:(.*?)$", RegexOptions.IgnoreCase);
            if (info.IndexOf('@') == -1 && !pattern.IsMatch(info))
                info = Regex.Replace(info.ToLower(), "(?:^|\\s)\\w", new MatchEvaluator(delegate(Match m) { return m.Value.ToUpper(); }));
            InfoRows.Add(new InfoRow(info));
        }

        public void Remove(int index)
        {
            InfoRows.RemoveAt(index);
            if(InfoChanged!=null)
            {
                InfoChanged(this, EventArgs.Empty);
            }
        }

        public void Update()
        {
            if (UpdateInfo != null)
            {
                UpdateInfo(this, EventArgs.Empty);
            }
        }

        public void setColor(Color color)
        {
            this.color = color;
        }
    }
}
