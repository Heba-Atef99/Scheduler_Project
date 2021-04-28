
namespace Scheduler_GUI
{
    partial class main_form
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
            this.NoProcesses = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CbSehedulerType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(90, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of processes:";
            // 
            // NoProcesses
            // 
            this.NoProcesses.Location = new System.Drawing.Point(351, 116);
            this.NoProcesses.Multiline = true;
            this.NoProcesses.Name = "NoProcesses";
            this.NoProcesses.Size = new System.Drawing.Size(109, 23);
            this.NoProcesses.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(90, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type of scheduler:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CbSehedulerType
            // 
            this.CbSehedulerType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbSehedulerType.FormattingEnabled = true;
            this.CbSehedulerType.Items.AddRange(new object[] {
            "FCFS",
            "SJF Nonpreemtive",
            "SJF Preemtive",
            "Priority Nonpreemtive",
            "Priority Preemtive",
            "Round Robin"});
            this.CbSehedulerType.Location = new System.Drawing.Point(338, 168);
            this.CbSehedulerType.Name = "CbSehedulerType";
            this.CbSehedulerType.Size = new System.Drawing.Size(192, 27);
            this.CbSehedulerType.TabIndex = 3;
            this.CbSehedulerType.Text = "     Select ";
            this.CbSehedulerType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(177, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 45);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPU Scheduler";
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(647, 265);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbSehedulerType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NoProcesses);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.main_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NoProcesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbSehedulerType;
        private System.Windows.Forms.Label label3;
    }
}

