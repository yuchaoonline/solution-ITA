namespace GMngMainForm.SysDb
{
    partial class DbConfigForm
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
            this.bt_cancle = new System.Windows.Forms.Button();
            this.bt_submit = new System.Windows.Forms.Button();
            this.tB_pwd = new System.Windows.Forms.TextBox();
            this.lb_pwd = new System.Windows.Forms.Label();
            this.tB_user = new System.Windows.Forms.TextBox();
            this.lb_user = new System.Windows.Forms.Label();
            this.tB_dbsource = new System.Windows.Forms.TextBox();
            this.lb_dbsouce = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_cancle
            // 
            this.bt_cancle.Location = new System.Drawing.Point(164, 134);
            this.bt_cancle.Name = "bt_cancle";
            this.bt_cancle.Size = new System.Drawing.Size(75, 23);
            this.bt_cancle.TabIndex = 15;
            this.bt_cancle.Text = "取消";
            this.bt_cancle.UseVisualStyleBackColor = true;
            this.bt_cancle.Click += new System.EventHandler(this.bt_cancle_Click);
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(63, 134);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(75, 23);
            this.bt_submit.TabIndex = 14;
            this.bt_submit.Text = "确定";
            this.bt_submit.UseVisualStyleBackColor = true;
            this.bt_submit.Click += new System.EventHandler(this.bt_submit_Click);
            // 
            // tB_pwd
            // 
            this.tB_pwd.Location = new System.Drawing.Point(142, 90);
            this.tB_pwd.Name = "tB_pwd";
            this.tB_pwd.Size = new System.Drawing.Size(100, 21);
            this.tB_pwd.TabIndex = 13;
            // 
            // lb_pwd
            // 
            this.lb_pwd.AutoSize = true;
            this.lb_pwd.Location = new System.Drawing.Point(61, 99);
            this.lb_pwd.Name = "lb_pwd";
            this.lb_pwd.Size = new System.Drawing.Size(41, 12);
            this.lb_pwd.TabIndex = 12;
            this.lb_pwd.Text = "密码：";
            // 
            // tB_user
            // 
            this.tB_user.Location = new System.Drawing.Point(142, 49);
            this.tB_user.Name = "tB_user";
            this.tB_user.Size = new System.Drawing.Size(100, 21);
            this.tB_user.TabIndex = 11;
            // 
            // lb_user
            // 
            this.lb_user.AutoSize = true;
            this.lb_user.Location = new System.Drawing.Point(61, 58);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(53, 12);
            this.lb_user.TabIndex = 10;
            this.lb_user.Text = "用户名：";
            // 
            // tB_dbsource
            // 
            this.tB_dbsource.Location = new System.Drawing.Point(142, 12);
            this.tB_dbsource.Name = "tB_dbsource";
            this.tB_dbsource.Size = new System.Drawing.Size(100, 21);
            this.tB_dbsource.TabIndex = 9;
            // 
            // lb_dbsouce
            // 
            this.lb_dbsouce.AutoSize = true;
            this.lb_dbsouce.Location = new System.Drawing.Point(61, 21);
            this.lb_dbsouce.Name = "lb_dbsouce";
            this.lb_dbsouce.Size = new System.Drawing.Size(65, 12);
            this.lb_dbsouce.TabIndex = 8;
            this.lb_dbsouce.Text = "数据库名：";
            // 
            // DbConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 180);
            this.Controls.Add(this.bt_cancle);
            this.Controls.Add(this.bt_submit);
            this.Controls.Add(this.tB_pwd);
            this.Controls.Add(this.lb_pwd);
            this.Controls.Add(this.tB_user);
            this.Controls.Add(this.lb_user);
            this.Controls.Add(this.tB_dbsource);
            this.Controls.Add(this.lb_dbsouce);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbConfigForm";
            this.Text = "数据库连接配置";
            this.Load += new System.EventHandler(this.DbConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_cancle;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.TextBox tB_pwd;
        private System.Windows.Forms.Label lb_pwd;
        private System.Windows.Forms.TextBox tB_user;
        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.TextBox tB_dbsource;
        private System.Windows.Forms.Label lb_dbsouce;
    }
}