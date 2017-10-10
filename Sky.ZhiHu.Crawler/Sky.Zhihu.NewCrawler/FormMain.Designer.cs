namespace Sky.Zhihu.NewCrawler
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
            this.grpParam = new System.Windows.Forms.GroupBox();
            this.txtCookie = new System.Windows.Forms.TextBox();
            this.lblCookie = new System.Windows.Forms.Label();
            this.btnSaveSrc = new System.Windows.Forms.Button();
            this.txtSaveSrc = new System.Windows.Forms.TextBox();
            this.lblSaveSrc = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSaveCount = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.LVLog = new System.Windows.Forms.ListView();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpParam.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpParam
            // 
            this.grpParam.Controls.Add(this.btnStart);
            this.grpParam.Controls.Add(this.txtCookie);
            this.grpParam.Controls.Add(this.lblCookie);
            this.grpParam.Controls.Add(this.btnSaveSrc);
            this.grpParam.Controls.Add(this.txtSaveSrc);
            this.grpParam.Controls.Add(this.lblSaveSrc);
            this.grpParam.Controls.Add(this.textBox1);
            this.grpParam.Controls.Add(this.lblSaveCount);
            this.grpParam.Controls.Add(this.txtId);
            this.grpParam.Controls.Add(this.lblId);
            this.grpParam.Location = new System.Drawing.Point(12, 12);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new System.Drawing.Size(437, 129);
            this.grpParam.TabIndex = 0;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "参数配置";
            // 
            // txtCookie
            // 
            this.txtCookie.Location = new System.Drawing.Point(61, 51);
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.Size = new System.Drawing.Size(356, 21);
            this.txtCookie.TabIndex = 8;
            // 
            // lblCookie
            // 
            this.lblCookie.AutoSize = true;
            this.lblCookie.Location = new System.Drawing.Point(9, 60);
            this.lblCookie.Name = "lblCookie";
            this.lblCookie.Size = new System.Drawing.Size(41, 12);
            this.lblCookie.TabIndex = 7;
            this.lblCookie.Text = "Cookie";
            // 
            // btnSaveSrc
            // 
            this.btnSaveSrc.Location = new System.Drawing.Point(197, 89);
            this.btnSaveSrc.Name = "btnSaveSrc";
            this.btnSaveSrc.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSrc.TabIndex = 6;
            this.btnSaveSrc.Text = "打开";
            this.btnSaveSrc.UseVisualStyleBackColor = true;
            // 
            // txtSaveSrc
            // 
            this.txtSaveSrc.Location = new System.Drawing.Point(75, 89);
            this.txtSaveSrc.Name = "txtSaveSrc";
            this.txtSaveSrc.Size = new System.Drawing.Size(100, 21);
            this.txtSaveSrc.TabIndex = 5;
            // 
            // lblSaveSrc
            // 
            this.lblSaveSrc.AutoSize = true;
            this.lblSaveSrc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSaveSrc.Location = new System.Drawing.Point(6, 96);
            this.lblSaveSrc.Name = "lblSaveSrc";
            this.lblSaveSrc.Size = new System.Drawing.Size(63, 14);
            this.lblSaveSrc.TabIndex = 4;
            this.lblSaveSrc.Text = "保存路径";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(317, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // lblSaveCount
            // 
            this.lblSaveCount.AutoSize = true;
            this.lblSaveCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSaveCount.Location = new System.Drawing.Point(167, 27);
            this.lblSaveCount.Name = "lblSaveCount";
            this.lblSaveCount.Size = new System.Drawing.Size(147, 14);
            this.lblSaveCount.TabIndex = 2;
            this.lblSaveCount.Text = "一个文件夹多少张图片";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(61, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblId.Location = new System.Drawing.Point(6, 27);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(49, 14);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "问题ID";
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.LVLog);
            this.grpLog.Location = new System.Drawing.Point(13, 158);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(436, 293);
            this.grpLog.TabIndex = 1;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "日志";
            // 
            // LVLog
            // 
            this.LVLog.Location = new System.Drawing.Point(21, 20);
            this.LVLog.Name = "LVLog";
            this.LVLog.Size = new System.Drawing.Size(395, 267);
            this.LVLog.TabIndex = 0;
            this.LVLog.UseCompatibleStateImageBehavior = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(317, 89);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(461, 463);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.grpParam);
            this.Name = "FormMain";
            this.Text = "知乎问题图片爬取";
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpParam;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ListView LVLog;
        private System.Windows.Forms.Button btnSaveSrc;
        private System.Windows.Forms.TextBox txtSaveSrc;
        private System.Windows.Forms.Label lblSaveSrc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblSaveCount;
        private System.Windows.Forms.TextBox txtCookie;
        private System.Windows.Forms.Label lblCookie;
        private System.Windows.Forms.Button btnStart;
    }
}

