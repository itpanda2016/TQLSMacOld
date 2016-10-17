namespace ESPlugin
{
    partial class formMain
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
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbReportName = new System.Windows.Forms.ComboBox();
            this.pgbOutput = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(498, 47);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(206, 55);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbReportName
            // 
            this.cmbReportName.FormattingEnabled = true;
            this.cmbReportName.ItemHeight = 24;
            this.cmbReportName.Items.AddRange(new object[] {
            "年度销量汇总报表"});
            this.cmbReportName.Location = new System.Drawing.Point(12, 59);
            this.cmbReportName.Name = "cmbReportName";
            this.cmbReportName.Size = new System.Drawing.Size(432, 32);
            this.cmbReportName.TabIndex = 1;
            // 
            // pgbOutput
            // 
            this.pgbOutput.Location = new System.Drawing.Point(12, 137);
            this.pgbOutput.Name = "pgbOutput";
            this.pgbOutput.Size = new System.Drawing.Size(925, 45);
            this.pgbOutput.TabIndex = 20;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 229);
            this.Controls.Add(this.pgbOutput);
            this.Controls.Add(this.cmbReportName);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "ExcelServer扩展";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbReportName;
        private System.Windows.Forms.ProgressBar pgbOutput;
    }
}