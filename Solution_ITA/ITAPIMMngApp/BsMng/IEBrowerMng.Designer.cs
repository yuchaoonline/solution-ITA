namespace ITAMngApp.BsMng
{
    partial class IEBrowerMng
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
            this.m_MyEebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // m_MyEebBrowser
            // 
            this.m_MyEebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_MyEebBrowser.Location = new System.Drawing.Point(0, 0);
            this.m_MyEebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.m_MyEebBrowser.Name = "m_MyEebBrowser";
            this.m_MyEebBrowser.Size = new System.Drawing.Size(836, 403);
            this.m_MyEebBrowser.TabIndex = 0;
            // 
            // IEBrowerMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 403);
            this.Controls.Add(this.m_MyEebBrowser);
            this.Name = "IEBrowerMng";
            this.Text = "IEBrowerMng";
            this.Load += new System.EventHandler(this.IEBrowerMng_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser m_MyEebBrowser;
    }
}