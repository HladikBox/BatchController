namespace Helpfooter
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUploadPatch = new System.Windows.Forms.Button();
            this.lblRootFile = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlBatcher = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnUploadPatch
            // 
            this.btnUploadPatch.Location = new System.Drawing.Point(14, 12);
            this.btnUploadPatch.Name = "btnUploadPatch";
            this.btnUploadPatch.Size = new System.Drawing.Size(75, 23);
            this.btnUploadPatch.TabIndex = 0;
            this.btnUploadPatch.Text = "选择文件";
            this.btnUploadPatch.UseVisualStyleBackColor = true;
            this.btnUploadPatch.Click += new System.EventHandler(this.BtnUploadPatch_Click);
            // 
            // lblRootFile
            // 
            this.lblRootFile.AutoSize = true;
            this.lblRootFile.Location = new System.Drawing.Point(24, 38);
            this.lblRootFile.Name = "lblRootFile";
            this.lblRootFile.Size = new System.Drawing.Size(0, 12);
            this.lblRootFile.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(761, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // pnlBatcher
            // 
            this.pnlBatcher.AutoScroll = true;
            this.pnlBatcher.Location = new System.Drawing.Point(14, 86);
            this.pnlBatcher.Name = "pnlBatcher";
            this.pnlBatcher.Size = new System.Drawing.Size(822, 496);
            this.pnlBatcher.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 594);
            this.Controls.Add(this.pnlBatcher);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblRootFile);
            this.Controls.Add(this.btnUploadPatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMain";
            this.Text = "主控台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUploadPatch;
        private System.Windows.Forms.Label lblRootFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.FlowLayoutPanel pnlBatcher;
    }
}

