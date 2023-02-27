namespace exceltool
{
    partial class FormReceiveExcel
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Start_Converting = new System.Windows.Forms.Button();
            this.fromDatePkr = new System.Windows.Forms.DateTimePicker();
            this.toDatePkr = new System.Windows.Forms.DateTimePicker();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.taskCombo = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Start_Converting
            // 
            this.btn_Start_Converting.Location = new System.Drawing.Point(544, 114);
            this.btn_Start_Converting.Name = "btn_Start_Converting";
            this.btn_Start_Converting.Size = new System.Drawing.Size(196, 54);
            this.btn_Start_Converting.TabIndex = 0;
            this.btn_Start_Converting.Text = "Start Task";
            this.btn_Start_Converting.UseVisualStyleBackColor = true;
            this.btn_Start_Converting.Click += new System.EventHandler(this.btn_Start_Converting_Click);
            // 
            // fromDatePkr
            // 
            this.fromDatePkr.Location = new System.Drawing.Point(48, 84);
            this.fromDatePkr.Name = "fromDatePkr";
            this.fromDatePkr.Size = new System.Drawing.Size(200, 28);
            this.fromDatePkr.TabIndex = 4;
            // 
            // toDatePkr
            // 
            this.toDatePkr.Location = new System.Drawing.Point(265, 84);
            this.toDatePkr.Name = "toDatePkr";
            this.toDatePkr.Size = new System.Drawing.Size(200, 28);
            this.toDatePkr.TabIndex = 5;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(48, 135);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(200, 28);
            this.txtDepartment.TabIndex = 6;
            this.txtDepartment.Text = "패션연구소";
            // 
            // taskCombo
            // 
            this.taskCombo.FormattingEnabled = true;
            this.taskCombo.Items.AddRange(new object[] {
            "다운로드",
            "폴더조회"});
            this.taskCombo.Location = new System.Drawing.Point(265, 135);
            this.taskCombo.Name = "taskCombo";
            this.taskCombo.Size = new System.Drawing.Size(200, 26);
            this.taskCombo.TabIndex = 7;
            this.taskCombo.SelectedIndexChanged += new System.EventHandler(this.taskCombo_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "파일이름";
            this.openFileDialog.Filter = "CSV 파일(*.csv)|*.csv|모든파일(*.*)|*.*";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(48, 27);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(417, 28);
            this.txtFilePath.TabIndex = 8;
            this.txtFilePath.Text = "Click \"Open File\" to Choose";
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Location = new System.Drawing.Point(544, 27);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(196, 54);
            this.btnFileOpen.TabIndex = 9;
            this.btnFileOpen.Text = "Open File";
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // FormReceiveExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 209);
            this.Controls.Add(this.btnFileOpen);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.taskCombo);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.toDatePkr);
            this.Controls.Add(this.fromDatePkr);
            this.Controls.Add(this.btn_Start_Converting);
            this.Name = "FormReceiveExcel";
            this.Text = "csv_To_Report 1_0_0_3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start_Converting;
        private System.Windows.Forms.DateTimePicker fromDatePkr;
        private System.Windows.Forms.DateTimePicker toDatePkr;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.ComboBox taskCombo;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnFileOpen;
    }
}

