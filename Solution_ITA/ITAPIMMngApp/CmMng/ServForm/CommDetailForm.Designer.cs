namespace ITAMngApp.CmMng.ServForm
{
    partial class CommDetailForm
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
            this.Lv_NetinfoList = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.MsgState = new System.Windows.Forms.ColumnHeader();
            this.CommModule = new System.Windows.Forms.ColumnHeader();
            this.MsgID = new System.Windows.Forms.ColumnHeader();
            this.MsgLen = new System.Windows.Forms.ColumnHeader();
            this.MsgSrcId = new System.Windows.Forms.ColumnHeader();
            this.MsgDestId = new System.Windows.Forms.ColumnHeader();
            this.MsgSeq = new System.Windows.Forms.ColumnHeader();
            this.MsgTm = new System.Windows.Forms.ColumnHeader();
            this.MsgSendorResv = new System.Windows.Forms.ColumnHeader();
            this.MsgContent = new System.Windows.Forms.ColumnHeader();
            this.MsgReplyStatus = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // Lv_NetinfoList
            // 
            this.Lv_NetinfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.MsgState,
            this.CommModule,
            this.MsgID,
            this.MsgLen,
            this.MsgSrcId,
            this.MsgDestId,
            this.MsgSeq,
            this.MsgTm,
            this.MsgSendorResv,
            this.MsgContent,
            this.MsgReplyStatus});
            this.Lv_NetinfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lv_NetinfoList.FullRowSelect = true;
            this.Lv_NetinfoList.GridLines = true;
            this.Lv_NetinfoList.Location = new System.Drawing.Point(0, 0);
            this.Lv_NetinfoList.MultiSelect = false;
            this.Lv_NetinfoList.Name = "Lv_NetinfoList";
            this.Lv_NetinfoList.Size = new System.Drawing.Size(936, 198);
            this.Lv_NetinfoList.TabIndex = 6;
            this.Lv_NetinfoList.UseCompatibleStateImageBehavior = false;
            this.Lv_NetinfoList.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // MsgState
            // 
            this.MsgState.Text = "报文状态";
            this.MsgState.Width = 72;
            // 
            // CommModule
            // 
            this.CommModule.Text = "报文模块";
            this.CommModule.Width = 76;
            // 
            // MsgID
            // 
            this.MsgID.Text = "报文编号";
            this.MsgID.Width = 76;
            // 
            // MsgLen
            // 
            this.MsgLen.Text = "报文长度";
            this.MsgLen.Width = 80;
            // 
            // MsgSrcId
            // 
            this.MsgSrcId.Text = "信源";
            this.MsgSrcId.Width = 110;
            // 
            // MsgDestId
            // 
            this.MsgDestId.Text = "信宿";
            this.MsgDestId.Width = 110;
            // 
            // MsgSeq
            // 
            this.MsgSeq.Text = "报文序号";
            this.MsgSeq.Width = 87;
            // 
            // MsgTm
            // 
            this.MsgTm.Text = "处理时间";
            this.MsgTm.Width = 130;
            // 
            // MsgSendorResv
            // 
            this.MsgSendorResv.Text = "报文方向";
            this.MsgSendorResv.Width = 68;
            // 
            // MsgContent
            // 
            this.MsgContent.Text = "报文内容";
            this.MsgContent.Width = 200;
            // 
            // MsgReplyStatus
            // 
            this.MsgReplyStatus.Text = "回复情况";
            this.MsgReplyStatus.Width = 120;
            // 
            // CommDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 198);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.Lv_NetinfoList);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CommDetailForm";
            this.Text = "通讯详细信息";
            this.Load += new System.EventHandler(this.CommDetailForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Lv_NetinfoList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader CommModule;
        private System.Windows.Forms.ColumnHeader MsgID;
        private System.Windows.Forms.ColumnHeader MsgLen;
        private System.Windows.Forms.ColumnHeader MsgSrcId;
        private System.Windows.Forms.ColumnHeader MsgDestId;
        private System.Windows.Forms.ColumnHeader MsgState;
        private System.Windows.Forms.ColumnHeader MsgSeq;
        private System.Windows.Forms.ColumnHeader MsgTm;
        private System.Windows.Forms.ColumnHeader MsgContent;
        private System.Windows.Forms.ColumnHeader MsgSendorResv;
        private System.Windows.Forms.ColumnHeader MsgReplyStatus;
    }
}