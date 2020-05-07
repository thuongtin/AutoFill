using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OtpNet;

namespace AutoFill
{
    partial class SmartForm : Form
    {
        public event EventHandler LeftClick, LeftClick2;
        private InfoList infoList;

        private Info cuInfo;
        public int InfoId { get; set; }
        private bool lockUpdate;

        public int Count
        {
            get
            {
                return infoListView.Items.Count;
            }
        }
        public bool SmartClick { get; set; }

        public int ItemHeight
        {
            get
            {
                if (Count == 0)
                    return 19;
                return infoListView.GetItemRect(0).Height;
            }
        }

        public int HeightValue
        {
            get
            {
                return ItemHeight * Count;
            }
        }

        public SmartForm()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            cuInfo = new Info();
            lockUpdate = false;
            SmartClick = false;
        }

        private void leftClick()
        {
            if (LeftClick != null)
            {
                LeftClick(this, EventArgs.Empty);
            }
        }

        private void leftClick2()
        {
            if (LeftClick2 != null)
            {
                LeftClick2(this, EventArgs.Empty);
            }
        }

        void cuInfo_InfoChanged(object sender, EventArgs e)
        {
            updateListView();
        }
        public SmartForm(InfoList infoList) : this()
        {
            this.infoList = infoList;
        }
        public void setInfoList(InfoList infoList)
        {
            this.infoList = infoList;
        }

        public void update()
        {
            if (!lockUpdate)
            {
                infoListView.Items.Clear();
                if (infoList.Count > 0)
                {
                    InfoId = 0;
                    cuInfo = infoList[0];
                    cuInfo.InfoChanged += cuInfo_InfoChanged;
                    foreach (var infoRow in cuInfo.InfoRows)
                    {
                        infoListView.Items.Add(infoRow.Text);
                        Regex pattern = new Regex(@"^2fa:(.*?)$");
                        Match match = pattern.Match(infoRow.Text);
                    }
                    infoListView.Items[0].Selected = true;
                    infoListView.Items[0].Focused = true;
                }
            }
            else
            {
                infoListView.Items.Clear();
                if (infoList.Count > 0)
                {
                    cuInfo = infoList[InfoId];
                    cuInfo.InfoChanged += cuInfo_InfoChanged;
                    foreach (var infoRow in cuInfo.InfoRows)
                    {
                        infoListView.Items.Add(infoRow.Text);
                    }
                }
                lockUpdate = false;
            }
        }

        public void updateListView(int index)
        {
            if (infoList.Count > 0 && index < infoList.Count && index >= 0)
            {
                infoListView.Items.Clear();
                InfoId = index;
                cuInfo = infoList[index];
                foreach (var infoRow in cuInfo.InfoRows)
                {
                    infoListView.Items.Add(infoRow.Text);
                }
            }
        }

        private void updateListView()
        {
            infoListView.Items.Clear();
            foreach (var infoRow in cuInfo.InfoRows)
            {
                infoListView.Items.Add(infoRow.Text);
            }
        }


        private int getSelectedIndex()
        {
            int index = -1;
            if (infoListView.SelectedItems.Count > 0)
                index = infoListView.SelectedIndices[0];
            return index;
        }

        private void infoListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = getSelectedIndex();
                if (index != -1)
                {
                    if (ModifierKeys == Keys.Alt)
                    {
                        lockUpdate = true;
                        foreach (ListViewItem lvItem in infoListView.SelectedItems)
                        {
                            infoListView.Items.Remove(lvItem);
                        }
                        updateCuInfo();
                    }
                    else if (ModifierKeys == Keys.Control && infoListView.SelectedItems.Count == 1)
                    {
                        lockUpdate = true;
                        string str = infoListView.Items[index].Text;
                        double Num;
                        if (str.Length == 16 && double.TryParse(str, out Num))
                        {
                            var str1 = str.Substring(0, 4);
                            var str2 = str.Substring(4, 4);
                            var str3 = str.Substring(8, 4);
                            var str4 = str.Substring(12, 4);
                            str = str1 + " " + str2 + " " + str3 + " " + str4;
                        }

                        var arr = str.Split(' ');
                        if (arr.Length > 1)
                        {
                            foreach (string s in arr)
                            {
                                index++;
                                infoListView.Items.Insert(index, s);
                                infoListView.Items[index].ForeColor = Color.Maroon;
                            }
                            updateCuInfo();
                        }
                    }
                    else if (infoListView.SelectedItems.Count > 1)
                    {
                        lockUpdate = true;
                        string str = "";
                        foreach (int i in infoListView.SelectedIndices)
                        {
                            str += infoListView.Items[i].Text + " ";
                        }
                        str = str.Trim();
                        var lastSelectedItem = infoListView.SelectedIndices[infoListView.SelectedItems.Count - 1];
                        infoListView.Items.Insert(lastSelectedItem + 1, str);
                        infoListView.Items[lastSelectedItem + 1].ForeColor = Color.DarkOrchid;
                        updateCuInfo();
                    }
                    else
                    {
                        changeStyle(index);
                    }
                }
            }
            //else
            //{
            //    SetDesktopBounds(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height, Width, Height);
            //    setHeader(false);
            //}
        }

        private void updateCuInfo()
        {
            cuInfo.InfoRows.Clear();
            foreach (ListViewItem item in infoListView.Items)
            {
                cuInfo.Add(item.Text);
            }
            cuInfo.Update();
        }

        private void removeInfoItem(int index)
        {
            cuInfo.Remove(index);
        }

        private void changeStyle(int index)
        {
            int cuType = cuInfo[index].Style;
            switch (cuType)
            {
                case 0:
                    cuInfo[index].Text = cuInfo[index].Text.ToLower();
                    cuInfo[index].Style = 1;
                    break;
                case 1:
                    cuInfo[index].Text = cuInfo[index].Text.ToUpper();
                    cuInfo[index].Style = 2;
                    break;
                case 2:
                    cuInfo[index].Text = Regex.Replace(cuInfo[index].Text.ToLower(), "(?:^|\\s)\\w", new MatchEvaluator(delegate (Match m) { return m.Value.ToUpper(); }));
                    cuInfo[index].Style = 0;
                    break;
            }
            infoListView.Items[index].Text = cuInfo[index].Text;
        }

        private void infoListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            updateCuInfo();
        }

        private void infoListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = getSelectedIndex();
            if (index == -1)
            {
                index = 0;
            }

            for (int i = 0; i < infoListView.Items.Count; i++)
            {
                infoListView.Items[i].BackColor = Color.White;
            }
            infoListView.Items[index].BackColor = Color.Aqua;
        }

        public void next()
        {
            if (Visible)
            {
                if (Count != 0)
                {
                    int index = getSelectedIndex();
                    index++;
                    if (index >= Count)
                        index--;
                    unSelectAll();
                    infoListView.Items[index].Selected = true;
                    infoListView.Items[index].Focused = true;
                }
            }
        }

        public void pre()
        {
            if (Visible)
            {
                if (Count != 0)
                {
                    int index = getSelectedIndex();
                    index--;
                    if (index < 0)
                        index = 0;
                    unSelectAll();
                    infoListView.Items[index].Selected = true;
                    infoListView.Items[index].Focused = true;
                }
            }
        }

        public void unSelectAll()
        {
            foreach (int i in infoListView.SelectedIndices)
            {
                infoListView.Items[i].Selected = false;
            }
        }

        public string getSelectedText()
        {
            int index = getSelectedIndex();
            if (index == -1)
                return string.Empty;
            Regex pattern = new Regex(@"^2fa:(.*?)$", RegexOptions.IgnoreCase);
            Match match = pattern.Match(infoListView.Items[index].Text);
            if (!match.Groups[1].Value.Equals(String.Empty))
            {
                var totp = new Totp(Base32Encoding.ToBytes(match.Groups[1].Value.Replace(" ", "")));
                return totp.ComputeTotp();
            }
            return infoListView.Items[index].Text;
        }

        private void infoListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (SmartClick)
                {
                    SetDesktopBounds(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height, Width, Height);
                    setHeader(false);
                    leftClick();
                    SmartClick = false;
                }
                else
                {
                    leftClick2();
                }
            }
        }

        public void setHeader(bool tf)
        {
            if (tf)
                infoListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            else
                infoListView.HeaderStyle = ColumnHeaderStyle.None;
        }

        public void copy()
        {
            string text = string.Empty;
            foreach (InfoRow info in cuInfo.InfoRows)
            {
                text += info.Text + "|";
            }
            Clipboard.SetText(text);
            DateTime dt = DateTime.Now;
            string savePath = @Directory.GetCurrentDirectory() + @"\save";
            CreateIfMissing(savePath);
            string file = string.Format(savePath + @"\Save_{0:yyMMdd}.txt", dt);
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(text);
            }
        }

        private void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

    }
}
