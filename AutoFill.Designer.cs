namespace AutoFill
{
    partial class AutoFill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoFill));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.delayNum = new System.Windows.Forms.NumericUpDown();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.clearTextCb = new Telerik.WinControls.UI.RadCheckBox();
            this.onOffCb = new Telerik.WinControls.UI.RadCheckBox();
            this.inTxt = new System.Windows.Forms.RichTextBox();
            this.infoListView = new System.Windows.Forms.ListView();
            this.t2_info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearTextCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onOffCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(14, 358);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.AccessibleDescription = null;
            this.radLabel1.RootElement.AccessibleName = null;
            this.radLabel1.RootElement.ControlBounds = new System.Drawing.Rectangle(14, 358, 100, 18);
            this.radLabel1.Size = new System.Drawing.Size(42, 17);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Delay:";
            // 
            // delayNum
            // 
            this.delayNum.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delayNum.Location = new System.Drawing.Point(54, 356);
            this.delayNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.delayNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.delayNum.Name = "delayNum";
            this.delayNum.Size = new System.Drawing.Size(47, 28);
            this.delayNum.TabIndex = 2;
            this.delayNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.delayNum.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(103, 358);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.AccessibleDescription = null;
            this.radLabel2.RootElement.AccessibleName = null;
            this.radLabel2.RootElement.ControlBounds = new System.Drawing.Rectangle(103, 358, 100, 18);
            this.radLabel2.Size = new System.Drawing.Size(71, 17);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "miliseconds";
            // 
            // clearTextCb
            // 
            this.clearTextCb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearTextCb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTextCb.Location = new System.Drawing.Point(193, 356);
            this.clearTextCb.Name = "clearTextCb";
            // 
            // 
            // 
            this.clearTextCb.RootElement.AccessibleDescription = null;
            this.clearTextCb.RootElement.AccessibleName = null;
            this.clearTextCb.RootElement.ControlBounds = new System.Drawing.Rectangle(193, 356, 100, 18);
            this.clearTextCb.RootElement.StretchHorizontally = true;
            this.clearTextCb.RootElement.StretchVertically = true;
            this.clearTextCb.Size = new System.Drawing.Size(78, 17);
            this.clearTextCb.TabIndex = 3;
            this.clearTextCb.Text = "Clear Text";
            this.clearTextCb.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // onOffCb
            // 
            this.onOffCb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.onOffCb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onOffCb.Location = new System.Drawing.Point(301, 355);
            this.onOffCb.Name = "onOffCb";
            // 
            // 
            // 
            this.onOffCb.RootElement.AccessibleDescription = null;
            this.onOffCb.RootElement.AccessibleName = null;
            this.onOffCb.RootElement.ControlBounds = new System.Drawing.Rectangle(301, 355, 100, 18);
            this.onOffCb.RootElement.StretchHorizontally = true;
            this.onOffCb.RootElement.StretchVertically = true;
            this.onOffCb.Size = new System.Drawing.Size(57, 17);
            this.onOffCb.TabIndex = 4;
            this.onOffCb.Text = "On/Off";
            this.onOffCb.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // inTxt
            // 
            this.inTxt.Location = new System.Drawing.Point(14, 381);
            this.inTxt.Name = "inTxt";
            this.inTxt.Size = new System.Drawing.Size(344, 96);
            this.inTxt.TabIndex = 5;
            this.inTxt.Text = resources.GetString("inTxt.Text");
            this.inTxt.TextChanged += new System.EventHandler(this.inTxt_TextChanged);
            this.inTxt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.inTxt_MouseDoubleClick);
            // 
            // infoListView
            // 
            this.infoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.t2_info});
            this.infoListView.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoListView.FullRowSelect = true;
            this.infoListView.GridLines = true;
            this.infoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.infoListView.HideSelection = false;
            this.infoListView.Location = new System.Drawing.Point(14, 14);
            this.infoListView.Name = "infoListView";
            this.infoListView.ShowGroups = false;
            this.infoListView.Size = new System.Drawing.Size(344, 335);
            this.infoListView.TabIndex = 6;
            this.infoListView.UseCompatibleStateImageBehavior = false;
            this.infoListView.View = System.Windows.Forms.View.Details;
            // 
            // t2_info
            // 
            this.t2_info.Width = 340;
            // 
            // AutoFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 495);
            this.Controls.Add(this.infoListView);
            this.Controls.Add(this.inTxt);
            this.Controls.Add(this.onOffCb);
            this.Controls.Add(this.clearTextCb);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.delayNum);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoFill";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Fill";
            this.ThemeName = "ControlDefault";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AutoType_FormClosed);
            this.Load += new System.EventHandler(this.AytoType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearTextCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onOffCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.NumericUpDown delayNum;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadCheckBox clearTextCb;
        private Telerik.WinControls.UI.RadCheckBox onOffCb;
        private System.Windows.Forms.RichTextBox inTxt;
        private System.Windows.Forms.ListView infoListView;
        private System.Windows.Forms.ColumnHeader t2_info;
    }
}
