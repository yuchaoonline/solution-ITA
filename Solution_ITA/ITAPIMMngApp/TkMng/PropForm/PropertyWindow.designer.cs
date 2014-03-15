namespace ITAMngApp.TkMng.PropForm
{
    partial class PropertyWindow
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
            this.components = new System.ComponentModel.Container();
            this.propertyGridEx1 = new PropertyGridEx.PropertyGridEx();
            this.SuspendLayout();
            // 
            // propertyGridEx1
            // 
            // 
            // 
            // 
            this.propertyGridEx1.DocCommentDescription.AutoEllipsis = true;
            this.propertyGridEx1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridEx1.DocCommentDescription.Location = new System.Drawing.Point(3, 19);
            this.propertyGridEx1.DocCommentDescription.Name = "";
            this.propertyGridEx1.DocCommentDescription.Size = new System.Drawing.Size(418, 36);
            this.propertyGridEx1.DocCommentDescription.TabIndex = 1;
            this.propertyGridEx1.DocCommentImage = null;
            // 
            // 
            // 
            this.propertyGridEx1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridEx1.DocCommentTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.propertyGridEx1.DocCommentTitle.Location = new System.Drawing.Point(3, 3);
            this.propertyGridEx1.DocCommentTitle.Name = "";
            this.propertyGridEx1.DocCommentTitle.Size = new System.Drawing.Size(418, 16);
            this.propertyGridEx1.DocCommentTitle.TabIndex = 0;
            this.propertyGridEx1.DocCommentTitle.UseMnemonic = false;
            this.propertyGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridEx1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridEx1.Name = "propertyGridEx1";
            this.propertyGridEx1.Size = new System.Drawing.Size(318, 464);
            this.propertyGridEx1.TabIndex = 1;
            // 
            // 
            // 
            this.propertyGridEx1.ToolStrip.AccessibleName = "工具栏";
            this.propertyGridEx1.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.propertyGridEx1.ToolStrip.AllowMerge = false;
            this.propertyGridEx1.ToolStrip.AutoSize = false;
            this.propertyGridEx1.ToolStrip.CanOverflow = false;
            this.propertyGridEx1.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.propertyGridEx1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.propertyGridEx1.ToolStrip.Location = new System.Drawing.Point(0, 1);
            this.propertyGridEx1.ToolStrip.Name = "";
            this.propertyGridEx1.ToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.propertyGridEx1.ToolStrip.Size = new System.Drawing.Size(318, 25);
            this.propertyGridEx1.ToolStrip.TabIndex = 1;
            this.propertyGridEx1.ToolStrip.TabStop = true;
            this.propertyGridEx1.ToolStrip.Text = "PropertyGridToolBar";
            this.propertyGridEx1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.propertyGridEx1_MouseDoubleClick);
            // 
            // PropertyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 464);
            this.CloseButtonVisible = false;
            this.Controls.Add(this.propertyGridEx1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PropertyWindow";
            this.Text = "属性窗口";
            this.Load += new System.EventHandler(this.PropertyWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertyWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertyGridEx.PropertyGridEx propertyGridEx1;
    }
}