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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inputRulesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.inputRulesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputRulesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Match,
            this.Replace});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inputRulesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.inputRulesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.inputRulesDataGridView.Name = "inputRulesDataGridView";
            this.inputRulesDataGridView.Size = new System.Drawing.Size(315, 366);
            this.inputRulesDataGridView.TabIndex = 0;
            this.inputRulesDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.inputRulesDataGridView_EditingControlShowing);
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