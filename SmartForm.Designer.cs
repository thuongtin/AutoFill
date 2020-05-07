namespace AutoFill
{
    partial class SmartForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Auto Type");
            this.infoListView = new System.Windows.Forms.ListView();
            this.t2_info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // infoListView
            // 
            this.infoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.t2_info});
            this.infoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoListView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoListView.FullRowSelect = true;
            this.infoListView.GridLines = true;
            this.infoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.infoListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.infoListView.LabelEdit = true;
            this.infoListView.Location = new System.Drawing.Point(0, 0);
            this.infoListView.Name = "infoListView";
            this.infoListView.ShowGroups = false;
            this.infoListView.Size = new System.Drawing.Size(228, 350);
            this.infoListView.TabIndex = 0;
            this.infoListView.UseCompatibleStateImageBehavior = false;
            this.infoListView.View = System.Windows.Forms.View.Details;
            this.infoListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.infoListView_AfterLabelEdit);
            this.infoListView.SelectedIndexChanged += new System.EventHandler(this.infoListView_SelectedIndexChanged);
            this.infoListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.infoListView_MouseDoubleClick);
            this.infoListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.infoListView_MouseUp);
            // 
            // t2_info
            // 
            this.t2_info.Text = "PRESS ESC TO CLOSE";
            this.t2_info.Width = 228;
            // 
            // SmartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 350);
            this.Controls.Add(this.infoListView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SmartForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SmartForm";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView infoListView;
        private System.Windows.Forms.ColumnHeader t2_info;
    }
}