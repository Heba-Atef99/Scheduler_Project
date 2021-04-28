
namespace Scheduler_GUI
{
    partial class SJF_FCFS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbArrival = new System.Windows.Forms.TextBox();
            this.tbBurst = new System.Windows.Forms.TextBox();
            this.dgv3cells = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInsert = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3cells)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Process ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arrival time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Burst time";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(288, 73);
            this.tbID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(132, 22);
            this.tbID.TabIndex = 5;
            // 
            // tbArrival
            // 
            this.tbArrival.Location = new System.Drawing.Point(288, 110);
            this.tbArrival.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbArrival.Name = "tbArrival";
            this.tbArrival.Size = new System.Drawing.Size(132, 22);
            this.tbArrival.TabIndex = 6;
            // 
            // tbBurst
            // 
            this.tbBurst.Location = new System.Drawing.Point(288, 148);
            this.tbBurst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBurst.Name = "tbBurst";
            this.tbBurst.Size = new System.Drawing.Size(132, 22);
            this.tbBurst.TabIndex = 7;
            // 
            // dgv3cells
            // 
            this.dgv3cells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv3cells.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgv3cells.Location = new System.Drawing.Point(472, 48);
            this.dgv3cells.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv3cells.Name = "dgv3cells";
            this.dgv3cells.RowHeadersWidth = 51;
            this.dgv3cells.Size = new System.Drawing.Size(461, 239);
            this.dgv3cells.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Arrival";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Burst";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(55, 300);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(165, 28);
            this.btnInsert.TabIndex = 13;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(228, 300);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(193, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "Show Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SJF_FCFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dgv3cells);
            this.Controls.Add(this.tbBurst);
            this.Controls.Add(this.tbArrival);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SJF_FCFS";
            this.Text = "information_input";
            this.Load += new System.EventHandler(this.SJF_FCFS_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv3cells)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbArrival;
        private System.Windows.Forms.TextBox tbBurst;
        private System.Windows.Forms.DataGridView dgv3cells;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}