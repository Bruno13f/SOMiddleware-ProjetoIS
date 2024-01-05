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
            this.richTextBoxOffices = new System.Windows.Forms.RichTextBox();
            this.groupBoxGetAllOffices = new System.Windows.Forms.GroupBox();
            this.groupBoxReserveOffice = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelChooseOffice = new System.Windows.Forms.Label();
            this.btnReserveOffice = new System.Windows.Forms.Button();
            this.comboBoxOffices = new System.Windows.Forms.ComboBox();
            this.groupBoxActiveReserves = new System.Windows.Forms.GroupBox();
            this.richTextBoxActiveReserves = new System.Windows.Forms.RichTextBox();
            this.groupBoxGetAllOffices.SuspendLayout();
            this.groupBoxReserveOffice.SuspendLayout();
            this.groupBoxActiveReserves.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxOffices
            // 
            this.richTextBoxOffices.Location = new System.Drawing.Point(15, 19);
            this.richTextBoxOffices.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxOffices.Name = "richTextBoxOffices";
            this.richTextBoxOffices.Size = new System.Drawing.Size(302, 155);
            this.richTextBoxOffices.TabIndex = 0;
            this.richTextBoxOffices.Text = "";
            // 
            // groupBoxGetAllOffices
            // 
            this.groupBoxGetAllOffices.Controls.Add(this.richTextBoxOffices);
            this.groupBoxGetAllOffices.Location = new System.Drawing.Point(19, 28);
            this.groupBoxGetAllOffices.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxGetAllOffices.Name = "groupBoxGetAllOffices";
            this.groupBoxGetAllOffices.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxGetAllOffices.Size = new System.Drawing.Size(332, 190);
            this.groupBoxGetAllOffices.TabIndex = 1;
            this.groupBoxGetAllOffices.TabStop = false;
            this.groupBoxGetAllOffices.Text = "Offices";
            // 
            // groupBoxReserveOffice
            // 
            this.groupBoxReserveOffice.Controls.Add(this.labelName);
            this.groupBoxReserveOffice.Controls.Add(this.textBoxName);
            this.groupBoxReserveOffice.Controls.Add(this.labelChooseOffice);
            this.groupBoxReserveOffice.Controls.Add(this.btnReserveOffice);
            this.groupBoxReserveOffice.Controls.Add(this.comboBoxOffices);
            this.groupBoxReserveOffice.Location = new System.Drawing.Point(364, 28);
            this.groupBoxReserveOffice.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxReserveOffice.Name = "groupBoxReserveOffice";
            this.groupBoxReserveOffice.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxReserveOffice.Size = new System.Drawing.Size(220, 190);
            this.groupBoxReserveOffice.TabIndex = 2;
            this.groupBoxReserveOffice.TabStop = false;
            this.groupBoxReserveOffice.Text = "Reserve Office";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(80, 92);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Your Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(21, 106);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(177, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // labelChooseOffice
            // 
            this.labelChooseOffice.AutoSize = true;
            this.labelChooseOffice.Location = new System.Drawing.Point(76, 31);
            this.labelChooseOffice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChooseOffice.Name = "labelChooseOffice";
            this.labelChooseOffice.Size = new System.Drawing.Size(74, 13);
            this.labelChooseOffice.TabIndex = 2;
            this.labelChooseOffice.Text = "Choose Office";
            // 
            // btnReserveOffice
            // 
            this.btnReserveOffice.Location = new System.Drawing.Point(70, 154);
            this.btnReserveOffice.Margin = new System.Windows.Forms.Padding(2);
            this.btnReserveOffice.Name = "btnReserveOffice";
            this.btnReserveOffice.Size = new System.Drawing.Size(88, 20);
            this.btnReserveOffice.TabIndex = 1;
            this.btnReserveOffice.Text = "Request Office";
            this.btnReserveOffice.UseVisualStyleBackColor = true;
            this.btnReserveOffice.Click += new System.EventHandler(this.btnReserveOffice_Click);
            // 
            // comboBoxOffices
            // 
            this.comboBoxOffices.FormattingEnabled = true;
            this.comboBoxOffices.Location = new System.Drawing.Point(21, 47);
            this.comboBoxOffices.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOffices.Name = "comboBoxOffices";
            this.comboBoxOffices.Size = new System.Drawing.Size(177, 21);
            this.comboBoxOffices.TabIndex = 0;
            // 
            // groupBoxActiveReserves
            // 
            this.groupBoxActiveReserves.Controls.Add(this.richTextBoxActiveReserves);
            this.groupBoxActiveReserves.Location = new System.Drawing.Point(19, 238);
            this.groupBoxActiveReserves.Name = "groupBoxActiveReserves";
            this.groupBoxActiveReserves.Size = new System.Drawing.Size(565, 101);
            this.groupBoxActiveReserves.TabIndex = 3;
            this.groupBoxActiveReserves.TabStop = false;
            this.groupBoxActiveReserves.Text = "Your Active Reserves";
            // 
            // richTextBoxActiveReserves
            // 
            this.richTextBoxActiveReserves.Location = new System.Drawing.Point(15, 24);
            this.richTextBoxActiveReserves.Name = "richTextBoxActiveReserves";
            this.richTextBoxActiveReserves.Size = new System.Drawing.Size(531, 64);
            this.richTextBoxActiveReserves.TabIndex = 0;
            this.richTextBoxActiveReserves.Text = "";
            // 
            // ClientApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.groupBoxActiveReserves);
            this.Controls.Add(this.groupBoxReserveOffice);
            this.Controls.Add(this.groupBoxGetAllOffices);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientApp";
            this.Text = "Library App";
            this.groupBoxGetAllOffices.ResumeLayout(false);
            this.groupBoxReserveOffice.ResumeLayout(false);
            this.groupBoxReserveOffice.PerformLayout();
            this.groupBoxActiveReserves.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxOffices;
        private System.Windows.Forms.GroupBox groupBoxGetAllOffices;
        private System.Windows.Forms.GroupBox groupBoxReserveOffice;
        private System.Windows.Forms.Button btnReserveOffice;
        private System.Windows.Forms.ComboBox comboBoxOffices;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelChooseOffice;
        private System.Windows.Forms.GroupBox groupBoxActiveReserves;
        private System.Windows.Forms.RichTextBox richTextBoxActiveReserves;
    }
}

