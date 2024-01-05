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
            this.richTextBoxOffices.Location = new System.Drawing.Point(20, 23);
            this.richTextBoxOffices.Name = "richTextBoxOffices";
            this.richTextBoxOffices.Size = new System.Drawing.Size(402, 190);
            this.richTextBoxOffices.TabIndex = 0;
            this.richTextBoxOffices.Text = "";
            // 
            // groupBoxGetAllOffices
            // 
            this.groupBoxGetAllOffices.Controls.Add(this.richTextBoxOffices);
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
            this.groupBoxReserveOffice.Controls.Add(this.textBoxName);
            this.groupBoxReserveOffice.Controls.Add(this.labelChooseOffice);
            this.groupBoxReserveOffice.Controls.Add(this.btnReserveOffice);
            this.groupBoxReserveOffice.Controls.Add(this.comboBoxOffices);
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
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(28, 130);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(235, 22);
            this.textBoxName.TabIndex = 3;
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
            this.btnReserveOffice.Click += new System.EventHandler(this.btnReserveOffice_Click);
            // 
            // comboBoxOffices
            // 
            this.comboBoxOffices.FormattingEnabled = true;
            this.comboBoxOffices.Location = new System.Drawing.Point(28, 58);
            this.comboBoxOffices.Name = "comboBoxOffices";
            this.comboBoxOffices.Size = new System.Drawing.Size(235, 24);
            this.comboBoxOffices.TabIndex = 0;
            // 
            // groupBoxActiveReserves
            // 
            this.groupBoxActiveReserves.Controls.Add(this.richTextBoxActiveReserves);
            this.groupBoxActiveReserves.Location = new System.Drawing.Point(25, 303);
            this.groupBoxActiveReserves.Name = "groupBoxActiveReserves";
            this.groupBoxActiveReserves.Size = new System.Drawing.Size(753, 124);
            this.groupBoxActiveReserves.TabIndex = 3;
            this.groupBoxActiveReserves.TabStop = false;
            this.groupBoxActiveReserves.Text = "Your Active Reserves";
            // 
            // richTextBoxActiveReserves
            // 
            this.richTextBoxActiveReserves.Location = new System.Drawing.Point(20, 31);
            this.richTextBoxActiveReserves.Name = "richTextBoxActiveReserves";
            this.richTextBoxActiveReserves.Size = new System.Drawing.Size(711, 74);
            this.richTextBoxActiveReserves.TabIndex = 0;
            this.richTextBoxActiveReserves.Text = "";
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

