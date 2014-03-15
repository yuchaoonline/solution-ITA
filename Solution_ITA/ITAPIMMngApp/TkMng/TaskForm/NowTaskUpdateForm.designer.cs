namespace ITAMngApp.TkMng.TaskForm
{
    partial class NowTaskUpdateForm
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
            this.TB_Remark = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bt_cancle = new System.Windows.Forms.Button();
            this.bt_submit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.RB_IsofHistory_2 = new System.Windows.Forms.RadioButton();
            this.RB_IsofHistory_1 = new System.Windows.Forms.RadioButton();
            this.RB_TaskType_2 = new System.Windows.Forms.RadioButton();
            this.RB_TaskType_1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_EndTime = new System.Windows.Forms.DateTimePicker();
            this.TB_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_TaskName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_CTVNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_TaskNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Remark
            // 
            this.TB_Remark.Location = new System.Drawing.Point(112, 232);
            this.TB_Remark.Multiline = true;
            this.TB_Remark.Name = "TB_Remark";
            this.TB_Remark.Size = new System.Drawing.Size(389, 62);
            this.TB_Remark.TabIndex = 77;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 237);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 76;
            this.label13.Text = "备注";
            // 
            // bt_cancle
            // 
            this.bt_cancle.Location = new System.Drawing.Point(277, 313);
            this.bt_cancle.Name = "bt_cancle";
            this.bt_cancle.Size = new System.Drawing.Size(115, 23);
            this.bt_cancle.TabIndex = 75;
            this.bt_cancle.Text = "取消";
            this.bt_cancle.UseVisualStyleBackColor = true;
            this.bt_cancle.Click += new System.EventHandler(this.bt_cancle_Click);
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(137, 313);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(115, 23);
            this.bt_submit.TabIndex = 74;
            this.bt_submit.Text = "修改";
            this.bt_submit.UseVisualStyleBackColor = true;
            this.bt_submit.Click += new System.EventHandler(this.bt_submit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(271, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 73;
            this.label8.Text = "是否转为历史";
            // 
            // RB_IsofHistory_2
            // 
            this.RB_IsofHistory_2.AutoSize = true;
            this.RB_IsofHistory_2.Location = new System.Drawing.Point(430, 194);
            this.RB_IsofHistory_2.Name = "RB_IsofHistory_2";
            this.RB_IsofHistory_2.Size = new System.Drawing.Size(71, 16);
            this.RB_IsofHistory_2.TabIndex = 71;
            this.RB_IsofHistory_2.TabStop = true;
            this.RB_IsofHistory_2.Text = "历史项目";
            this.RB_IsofHistory_2.UseVisualStyleBackColor = true;
            // 
            // RB_IsofHistory_1
            // 
            this.RB_IsofHistory_1.AutoSize = true;
            this.RB_IsofHistory_1.Location = new System.Drawing.Point(353, 194);
            this.RB_IsofHistory_1.Name = "RB_IsofHistory_1";
            this.RB_IsofHistory_1.Size = new System.Drawing.Size(71, 16);
            this.RB_IsofHistory_1.TabIndex = 69;
            this.RB_IsofHistory_1.TabStop = true;
            this.RB_IsofHistory_1.Text = "现行项目";
            this.RB_IsofHistory_1.UseVisualStyleBackColor = true;
            // 
            // RB_TaskType_2
            // 
            this.RB_TaskType_2.AutoSize = true;
            this.RB_TaskType_2.Location = new System.Drawing.Point(80, 3);
            this.RB_TaskType_2.Name = "RB_TaskType_2";
            this.RB_TaskType_2.Size = new System.Drawing.Size(71, 16);
            this.RB_TaskType_2.TabIndex = 72;
            this.RB_TaskType_2.TabStop = true;
            this.RB_TaskType_2.Text = "实际项目";
            this.RB_TaskType_2.UseVisualStyleBackColor = true;
            // 
            // RB_TaskType_1
            // 
            this.RB_TaskType_1.AutoSize = true;
            this.RB_TaskType_1.Location = new System.Drawing.Point(3, 3);
            this.RB_TaskType_1.Name = "RB_TaskType_1";
            this.RB_TaskType_1.Size = new System.Drawing.Size(71, 16);
            this.RB_TaskType_1.TabIndex = 70;
            this.RB_TaskType_1.TabStop = true;
            this.RB_TaskType_1.Text = "仿真项目";
            this.RB_TaskType_1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 68;
            this.label7.Text = "项目类型";
            // 
            // TB_EndTime
            // 
            this.TB_EndTime.Location = new System.Drawing.Point(361, 144);
            this.TB_EndTime.Name = "TB_EndTime";
            this.TB_EndTime.Size = new System.Drawing.Size(140, 21);
            this.TB_EndTime.TabIndex = 66;
            // 
            // TB_StartTime
            // 
            this.TB_StartTime.Location = new System.Drawing.Point(112, 144);
            this.TB_StartTime.Name = "TB_StartTime";
            this.TB_StartTime.Size = new System.Drawing.Size(140, 21);
            this.TB_StartTime.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 65;
            this.label5.Text = "结束时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 64;
            this.label6.Text = "开始时间";
            // 
            // TB_TaskName
            // 
            this.TB_TaskName.Location = new System.Drawing.Point(112, 90);
            this.TB_TaskName.Name = "TB_TaskName";
            this.TB_TaskName.Size = new System.Drawing.Size(389, 21);
            this.TB_TaskName.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "项目名称";
            // 
            // TB_CTVNo
            // 
            this.TB_CTVNo.Location = new System.Drawing.Point(361, 46);
            this.TB_CTVNo.Name = "TB_CTVNo";
            this.TB_CTVNo.Size = new System.Drawing.Size(140, 21);
            this.TB_CTVNo.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 60;
            this.label2.Text = "标准编号";
            // 
            // TB_TaskNo
            // 
            this.TB_TaskNo.Location = new System.Drawing.Point(112, 46);
            this.TB_TaskNo.Name = "TB_TaskNo";
            this.TB_TaskNo.Size = new System.Drawing.Size(140, 21);
            this.TB_TaskNo.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 58;
            this.label1.Text = "项目编号";
            // 
            // TB_ID
            // 
            this.TB_ID.Location = new System.Drawing.Point(112, 10);
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.ReadOnly = true;
            this.TB_ID.Size = new System.Drawing.Size(100, 21);
            this.TB_ID.TabIndex = 79;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 78;
            this.label14.Text = "ID编号";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RB_TaskType_2);
            this.panel1.Controls.Add(this.RB_TaskType_1);
            this.panel1.Location = new System.Drawing.Point(110, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 20);
            this.panel1.TabIndex = 80;
            // 
            // NowTaskUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 352);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TB_ID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TB_Remark);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.bt_cancle);
            this.Controls.Add(this.bt_submit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RB_IsofHistory_2);
            this.Controls.Add(this.RB_IsofHistory_1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TB_EndTime);
            this.Controls.Add(this.TB_StartTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_TaskName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_CTVNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_TaskNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NowTaskUpdateForm";
            this.Text = "修改现行项目";
            this.Load += new System.EventHandler(this.NowTaskUpdateForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Remark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bt_cancle;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton RB_IsofHistory_2;
        private System.Windows.Forms.RadioButton RB_IsofHistory_1;
        private System.Windows.Forms.RadioButton RB_TaskType_2;
        private System.Windows.Forms.RadioButton RB_TaskType_1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker TB_EndTime;
        private System.Windows.Forms.DateTimePicker TB_StartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_TaskName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_CTVNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_TaskNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
    }
}