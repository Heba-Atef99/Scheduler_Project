
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of processes:";
            // 
            // NoProcesses
            // 
            this.NoProcesses.Location = new System.Drawing.Point(369, 127);
            this.NoProcesses.Margin = new System.Windows.Forms.Padding(4);
            this.NoProcesses.Multiline = true;
            this.NoProcesses.Name = "NoProcesses";
            this.NoProcesses.Size = new System.Drawing.Size(144, 27);
            this.NoProcesses.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 29);
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
            this.CbSehedulerType.Location = new System.Drawing.Point(369, 172);
            this.CbSehedulerType.Margin = new System.Windows.Forms.Padding(4);
            this.CbSehedulerType.Name = "CbSehedulerType";
            this.CbSehedulerType.Size = new System.Drawing.Size(255, 32);
            this.CbSehedulerType.TabIndex = 3;
            this.CbSehedulerType.Text = "     Select";
            this.CbSehedulerType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(849, 391);
            this.Controls.Add(this.CbSehedulerType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NoProcesses);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.main_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NoProcesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbSehedulerType;
    }
}

