namespace DUNameplateGUI
{
    partial class InputRuleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inputRulesDataGridView = new System.Windows.Forms.DataGridView();
            this.Match = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Replace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveCloseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputRulesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // inputRulesDataGridView
            // 
            this.inputRulesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inputRulesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.inputRulesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputRulesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Match,
            this.Replace});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inputRulesDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.inputRulesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.inputRulesDataGridView.Name = "inputRulesDataGridView";
            this.inputRulesDataGridView.Size = new System.Drawing.Size(315, 366);
            this.inputRulesDataGridView.TabIndex = 0;
            // 
            // Match
            // 
            this.Match.HeaderText = "Match";
            this.Match.Name = "Match";
            this.Match.Width = 125;
            // 
            // Replace
            // 
            this.Replace.HeaderText = "Replace";
            this.Replace.Name = "Replace";
            this.Replace.Width = 125;
            // 
            // saveCloseBtn
            // 
            this.saveCloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveCloseBtn.Location = new System.Drawing.Point(95, 395);
            this.saveCloseBtn.Name = "saveCloseBtn";
            this.saveCloseBtn.Size = new System.Drawing.Size(148, 34);
            this.saveCloseBtn.TabIndex = 1;
            this.saveCloseBtn.Text = "Save and Close";
            this.saveCloseBtn.UseVisualStyleBackColor = true;
            this.saveCloseBtn.Click += new System.EventHandler(this.saveCloseBtn_Click);
            // 
            // InputRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 450);
            this.Controls.Add(this.saveCloseBtn);
            this.Controls.Add(this.inputRulesDataGridView);
            this.Name = "InputRuleForm";
            this.Text = "Input Rules";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InputRuleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputRulesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView inputRulesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Match;
        private System.Windows.Forms.DataGridViewTextBoxColumn Replace;
        private System.Windows.Forms.Button saveCloseBtn;
    }
}