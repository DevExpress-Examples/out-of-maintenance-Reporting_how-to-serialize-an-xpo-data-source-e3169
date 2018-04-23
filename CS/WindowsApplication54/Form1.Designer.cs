namespace WindowsApplication54 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.createReportWhithDataSourceButton = new System.Windows.Forms.Button();
            this.createEmptyReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createReportWhithDataSourceButton
            // 
            this.createReportWhithDataSourceButton.Location = new System.Drawing.Point(12, 47);
            this.createReportWhithDataSourceButton.Name = "createReportWhithDataSourceButton";
            this.createReportWhithDataSourceButton.Size = new System.Drawing.Size(260, 42);
            this.createReportWhithDataSourceButton.TabIndex = 0;
            this.createReportWhithDataSourceButton.Text = "Create a Data-Aware Report";
            this.createReportWhithDataSourceButton.UseVisualStyleBackColor = true;
            this.createReportWhithDataSourceButton.Click += new System.EventHandler(this.createReportWhithDataSourceButton_Click);
            // 
            // createEmptyReportButton
            // 
            this.createEmptyReportButton.Location = new System.Drawing.Point(12, 124);
            this.createEmptyReportButton.Name = "createEmptyReportButton";
            this.createEmptyReportButton.Size = new System.Drawing.Size(260, 42);
            this.createEmptyReportButton.TabIndex = 0;
            this.createEmptyReportButton.Text = "Create a Blank Report";
            this.createEmptyReportButton.UseVisualStyleBackColor = true;
            this.createEmptyReportButton.Click += new System.EventHandler(this.createEmptyReportButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.createEmptyReportButton);
            this.Controls.Add(this.createReportWhithDataSourceButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createReportWhithDataSourceButton;
        private System.Windows.Forms.Button createEmptyReportButton;
    }
}

