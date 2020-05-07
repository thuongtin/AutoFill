using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
using OtpNet;

namespace AutoFill
{
    public partial class AutoFill : Telerik.WinControls.UI.RadForm
    {
        private InfoList infoList;
        private SmartForm sm;
        private HookControl hc;

        public bool ClearText
        {
            get
            {
                return clearTextCb.Checked;
            }
        }

        public bool OnOff
        {
            get
            {
                return onOffCb.Checked;
            }
        }

        public int Delay
        {
            get
            {
                return Convert.ToInt32(delayNum.Value);
            }
        }

        public AutoFill()
        {
            InitializeComponent();
            infoList = new InfoList();
            sm = new SmartForm(infoList);
            hc = new HookControl(this, sm);
        }

        private void inTxt_TextChanged(object sender, EventArgs e)
        {
            infoList.Set(inTxt.Text);
            changeListView();
        }

        private void changeListView()
        {
            infoListView.Items.Clear();
            int i = 0;
            int j = 0;
            foreach (Info info in infoList.ListInfo)
            {
                info.InfoChanged += info_InfoChanged;
                info.UpdateInfo += info_UpdateInfo;
                foreach (var str in info.InfoRows)
                {
                    //MessageBox.Show(str);
                    infoListView.Items.Add(str.Text);                 
                    infoListView.Items[i].ForeColor = info.color;
                    infoListView.Items[i].Name = j.ToString();
                    i++;
                }
                j++;
            }
            sm.update();
        }

        void info_UpdateInfo(object sender, EventArgs e)
        {
            updateInText();
        }

        void info_InfoChanged(object sender, EventArgs e)
        {
            updateInText();
        }

        private void updateInText()
        {
            String str = "";
            foreach (Info info in infoList.ListInfo)
            {
                foreach (var infoRow in info.InfoRows)
                {
                    str += infoRow.Text + "|";
                }
                str += "\n";
            }
            inTxt.Text = str;
        }

        private void AytoType_Load(object sender, EventArgs e)
        {
            inTxt_TextChanged(null, null);
            sm.Show();
            //sm.update();
        }


        private int getSelectedIndex()
        {
            int index = -1;
            if (infoListView.SelectedItems.Count > 0)
                index = infoListView.SelectedIndices[0];
            return index;
        }

        public int getIdInfoSelected()
        {
            int index = getSelectedIndex();
            if (index != -1)
            {
                return Convert.ToInt32(infoListView.Items[index].Name);
            }
            return -1;
        }

        private void AutoType_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void inTxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
