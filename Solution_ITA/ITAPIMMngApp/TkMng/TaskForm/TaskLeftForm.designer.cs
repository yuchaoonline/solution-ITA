namespace ITAMngApp.TkMng.TaskForm
{
    partial class TaskLeftForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_select = new System.Windows.Forms.Button();
            this.lb_dtuno = new System.Windows.Forms.Label();
            this.TB_TaskNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RB_IsofHistory_2 = new System.Windows.Forms.RadioButton();
            this.RB_IsofHistory_1 = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TB_SelectID = new System.Windows.Forms.TextBox();
            this.TB_SelectTaskNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.Lv_TaskinfoList = new System.Windows.Forms.ListView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(199, 29);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(38, 23);
            this.bt_select.TabIndex = 5;
            this.bt_select.Text = "查询";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // lb_dtuno
            // 
            this.lb_dtuno.AutoSize = true;
            this.lb_dtuno.Location = new System.Drawing.Point(12, 36);
            this.lb_dtuno.Name = "lb_dtuno";
            this.lb_dtuno.Size = new System.Drawing.Size(65, 12);
            this.lb_dtuno.TabIndex = 3;
            this.lb_dtuno.Text = "项目编号：";
            // 
            // TB_TaskNo
            // 
            this.TB_TaskNo.Location = new System.Drawing.Point(74, 30);
            this.TB_TaskNo.Name = "TB_TaskNo";
            this.TB_TaskNo.Size = new System.Drawing.Size(120, 21);
            this.TB_TaskNo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "项目状态：";
            // 
            // RB_IsofHistory_2
            // 
            this.RB_IsofHistory_2.AutoSize = true;
            this.RB_IsofHistory_2.Location = new System.Drawing.Point(171, 7);
            this.RB_IsofHistory_2.Name = "RB_IsofHistory_2";
            this.RB_IsofHistory_2.Size = new System.Drawing.Size(71, 16);
            this.RB_IsofHistory_2.TabIndex = 8;
            this.RB_IsofHistory_2.TabStop = true;
            this.RB_IsofHistory_2.Text = "历史项目";
            this.RB_IsofHistory_2.UseVisualStyleBackColor = true;
            // 
            // RB_IsofHistory_1
            // 
            this.RB_IsofHistory_1.AutoSize = true;
            this.RB_IsofHistory_1.Location = new System.Drawing.Point(79, 7);
            this.RB_IsofHistory_1.Name = "RB_IsofHistory_1";
            this.RB_IsofHistory_1.Size = new System.Drawing.Size(71, 16);
            this.RB_IsofHistory_1.TabIndex = 7;
            this.RB_IsofHistory_1.TabStop = true;
            this.RB_IsofHistory_1.Text = "现行项目";
            this.RB_IsofHistory_1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TB_SelectID);
            this.splitContainer1.Panel1.Controls.Add(this.TB_SelectTaskNo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.TB_TaskNo);
            this.splitContainer1.Panel1.Controls.Add(this.RB_IsofHistory_2);
            this.splitContainer1.Panel1.Controls.Add(this.lb_dtuno);
            this.splitContainer1.Panel1.Controls.Add(this.RB_IsofHistory_1);
            this.splitContainer1.Panel1.Controls.Add(this.bt_select);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Lv_TaskinfoList);
            this.splitContainer1.Size = new System.Drawing.Size(367, 609);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.TabIndex = 10;
            // 
            // TB_SelectID
            // 
            this.TB_SelectID.Location = new System.Drawing.Point(205, 61);
            this.TB_SelectID.Name = "TB_SelectID";
            this.TB_SelectID.ReadOnly = true;
            this.TB_SelectID.Size = new System.Drawing.Size(31, 21);
            this.TB_SelectID.TabIndex = 12;
            this.TB_SelectID.Visible = false;
            // 
            // TB_SelectTaskNo
            // 
            this.TB_SelectTaskNo.Location = new System.Drawing.Point(74, 61);
            this.TB_SelectTaskNo.Name = "TB_SelectTaskNo";
            this.TB_SelectTaskNo.ReadOnly = true;
            this.TB_SelectTaskNo.Size = new System.Drawing.Size(128, 21);
            this.TB_SelectTaskNo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "选择项目：";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "项目编号";
            this.columnHeader5.Width = 76;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "标准编号";
            this.columnHeader8.Width = 76;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "项目名称";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "类型";
            this.columnHeader1.Width = 80;
            // 
            // Lv_TaskinfoList
            // 
            this.Lv_TaskinfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader14,
            this.columnHeader1});
            this.Lv_TaskinfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lv_TaskinfoList.FullRowSelect = true;
            this.Lv_TaskinfoList.GridLines = true;
            this.Lv_TaskinfoList.Location = new System.Drawing.Point(0, 0);
            this.Lv_TaskinfoList.MultiSelect = false;
            this.Lv_TaskinfoList.Name = "Lv_TaskinfoList";
            this.Lv_TaskinfoList.Size = new System.Drawing.Size(367, 500);
            this.Lv_TaskinfoList.TabIndex = 5;
            this.Lv_TaskinfoList.UseCompatibleStateImageBehavior = false;
            this.Lv_TaskinfoList.View = System.Windows.Forms.View.Details;
            // 
            // TaskLeftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 609);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TaskLeftForm";
            this.Text = "项目导航页面";
            this.Load += new System.EventHandler(this.TaskLeftForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_select;
        private System.Windows.Forms.Label lb_dtuno;
        private System.Windows.Forms.TextBox TB_TaskNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RB_IsofHistory_2;
        private System.Windows.Forms.RadioButton RB_IsofHistory_1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TB_SelectID;
        private System.Windows.Forms.TextBox TB_SelectTaskNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView Lv_TaskinfoList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    
    }
}