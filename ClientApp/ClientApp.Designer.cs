namespace ClientApp
{
    partial class ClientApp
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxGetAllOffices = new System.Windows.Forms.GroupBox();
            this.groupBoxReserveOffice = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelChooseOffice = new System.Windows.Forms.Label();
            this.btnReserveOffice = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxActiveReserves = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.groupBoxGetAllOffices.SuspendLayout();
            this.groupBoxReserveOffice.SuspendLayout();
            this.groupBoxActiveReserves.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(20, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(402, 190);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBoxGetAllOffices
            // 
            this.groupBoxGetAllOffices.Controls.Add(this.richTextBox1);
            this.groupBoxGetAllOffices.Location = new System.Drawing.Point(25, 34);
            this.groupBoxGetAllOffices.Name = "groupBoxGetAllOffices";
            this.groupBoxGetAllOffices.Size = new System.Drawing.Size(442, 234);
            this.groupBoxGetAllOffices.TabIndex = 1;
            this.groupBoxGetAllOffices.TabStop = false;
            this.groupBoxGetAllOffices.Text = "Offices";
            // 
            // groupBoxReserveOffice
            // 
            this.groupBoxReserveOffice.Controls.Add(this.labelName);
            this.groupBoxReserveOffice.Controls.Add(this.textBox1);
            this.groupBoxReserveOffice.Controls.Add(this.labelChooseOffice);
            this.groupBoxReserveOffice.Controls.Add(this.btnReserveOffice);
            this.groupBoxReserveOffice.Controls.Add(this.comboBox1);
            this.groupBoxReserveOffice.Location = new System.Drawing.Point(485, 34);
            this.groupBoxReserveOffice.Name = "groupBoxReserveOffice";
            this.groupBoxReserveOffice.Size = new System.Drawing.Size(293, 234);
            this.groupBoxReserveOffice.TabIndex = 2;
            this.groupBoxReserveOffice.TabStop = false;
            this.groupBoxReserveOffice.Text = "Reserve Office";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(106, 113);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(75, 16);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Your Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 22);
            this.textBox1.TabIndex = 3;
            // 
            // labelChooseOffice
            // 
            this.labelChooseOffice.AutoSize = true;
            this.labelChooseOffice.Location = new System.Drawing.Point(102, 38);
            this.labelChooseOffice.Name = "labelChooseOffice";
            this.labelChooseOffice.Size = new System.Drawing.Size(91, 16);
            this.labelChooseOffice.TabIndex = 2;
            this.labelChooseOffice.Text = "Choose Office";
            // 
            // btnReserveOffice
            // 
            this.btnReserveOffice.Location = new System.Drawing.Point(94, 189);
            this.btnReserveOffice.Name = "btnReserveOffice";
            this.btnReserveOffice.Size = new System.Drawing.Size(118, 24);
            this.btnReserveOffice.TabIndex = 1;
            this.btnReserveOffice.Text = "Request Office";
            this.btnReserveOffice.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(28, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBoxActiveReserves
            // 
            this.groupBoxActiveReserves.Controls.Add(this.richTextBox2);
            this.groupBoxActiveReserves.Location = new System.Drawing.Point(25, 303);
            this.groupBoxActiveReserves.Name = "groupBoxActiveReserves";
            this.groupBoxActiveReserves.Size = new System.Drawing.Size(753, 124);
            this.groupBoxActiveReserves.TabIndex = 3;
            this.groupBoxActiveReserves.TabStop = false;
            this.groupBoxActiveReserves.Text = "Your Active Reserves";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(20, 31);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(711, 74);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // ClientApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxActiveReserves);
            this.Controls.Add(this.groupBoxReserveOffice);
            this.Controls.Add(this.groupBoxGetAllOffices);
            this.Name = "ClientApp";
            this.Text = "Library App";
            this.groupBoxGetAllOffices.ResumeLayout(false);
            this.groupBoxReserveOffice.ResumeLayout(false);
            this.groupBoxReserveOffice.PerformLayout();
            this.groupBoxActiveReserves.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxGetAllOffices;
        private System.Windows.Forms.GroupBox groupBoxReserveOffice;
        private System.Windows.Forms.Button btnReserveOffice;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelChooseOffice;
        private System.Windows.Forms.GroupBox groupBoxActiveReserves;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

