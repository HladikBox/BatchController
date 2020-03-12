namespace Helpfooter
{
    partial class BatchController
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.pgbP = new System.Windows.Forms.ProgressBar();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblNextTime = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "名称";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(6, 20);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 12);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "接口";
            // 
            // pgbP
            // 
            this.pgbP.Location = new System.Drawing.Point(8, 36);
            this.pgbP.Name = "pgbP";
            this.pgbP.Size = new System.Drawing.Size(510, 23);
            this.pgbP.Step = 1;
            this.pgbP.TabIndex = 2;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(6, 66);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(53, 12);
            this.lblInterval.TabIndex = 3;
            this.lblInterval.Text = "运行间隔";
            // 
            // lblNextTime
            // 
            this.lblNextTime.AutoSize = true;
            this.lblNextTime.Location = new System.Drawing.Point(315, 66);
            this.lblNextTime.Name = "lblNextTime";
            this.lblNextTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNextTime.Size = new System.Drawing.Size(203, 12);
            this.lblNextTime.TabIndex = 4;
            this.lblNextTime.Text = "下次运行时间：xxxx-xx-xx xx:xx:xx";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(536, 10);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(266, 68);
            this.txtResult.TabIndex = 5;
            this.txtResult.Text = "";
            // 
            // BatchController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblNextTime);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.pgbP);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblName);
            this.Name = "BatchController";
            this.Size = new System.Drawing.Size(811, 87);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblUrl;
        public System.Windows.Forms.ProgressBar pgbP;
        public System.Windows.Forms.Label lblInterval;
        public System.Windows.Forms.Label lblNextTime;
        public System.Windows.Forms.RichTextBox txtResult;
    }
}
