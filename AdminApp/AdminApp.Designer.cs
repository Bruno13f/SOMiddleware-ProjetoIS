namespace AdminApp
{
    partial class AdminApp
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
            this.groupBoxGetAllOffices = new System.Windows.Forms.GroupBox();
            this.richTextBoxOpenOffices = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBoxOccupiedOffices = new System.Windows.Forms.RichTextBox();
            this.groupBoxCreateOffice = new System.Windows.Forms.GroupBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxDeleteOffice = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBoxDeleteOffices = new System.Windows.Forms.ComboBox();
            this.labelChooseOffice = new System.Windows.Forms.Label();
            this.textBoxCreateNameOffice = new System.Windows.Forms.TextBox();
            this.labelOfficeName = new System.Windows.Forms.Label();
            this.groupBoxVacantOffice = new System.Windows.Forms.GroupBox();
            this.labelChooseOffice2 = new System.Windows.Forms.Label();
            this.comboBoxVacantOffice = new System.Windows.Forms.ComboBox();
            this.buttonVacantOffice = new System.Windows.Forms.Button();
            this.groupBoxGetAllOffices.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxCreateOffice.SuspendLayout();
            this.groupBoxDeleteOffice.SuspendLayout();
            this.groupBoxVacantOffice.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGetAllOffices
            // 
            this.groupBoxGetAllOffices.Controls.Add(this.richTextBoxOpenOffices);
            this.groupBoxGetAllOffices.Location = new System.Drawing.Point(12, 36);
            this.groupBoxGetAllOffices.Name = "groupBoxGetAllOffices";
            this.groupBoxGetAllOffices.Size = new System.Drawing.Size(380, 234);
            this.groupBoxGetAllOffices.TabIndex = 2;
            this.groupBoxGetAllOffices.TabStop = false;
            this.groupBoxGetAllOffices.Text = "Open Offices";
            // 
            // richTextBoxOpenOffices
            // 
            this.richTextBoxOpenOffices.Location = new System.Drawing.Point(20, 23);
            this.richTextBoxOpenOffices.Name = "richTextBoxOpenOffices";
            this.richTextBoxOpenOffices.Size = new System.Drawing.Size(336, 190);
            this.richTextBoxOpenOffices.TabIndex = 0;
            this.richTextBoxOpenOffices.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxOccupiedOffices);
            this.groupBox1.Location = new System.Drawing.Point(408, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 234);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Occupied Offices";
            // 
            // richTextBoxOccupiedOffices
            // 
            this.richTextBoxOccupiedOffices.Location = new System.Drawing.Point(20, 23);
            this.richTextBoxOccupiedOffices.Name = "richTextBoxOccupiedOffices";
            this.richTextBoxOccupiedOffices.Size = new System.Drawing.Size(336, 190);
            this.richTextBoxOccupiedOffices.TabIndex = 0;
            this.richTextBoxOccupiedOffices.Text = "";
            // 
            // groupBoxCreateOffice
            // 
            this.groupBoxCreateOffice.Controls.Add(this.labelOfficeName);
            this.groupBoxCreateOffice.Controls.Add(this.textBoxCreateNameOffice);
            this.groupBoxCreateOffice.Controls.Add(this.buttonCreate);
            this.groupBoxCreateOffice.Location = new System.Drawing.Point(12, 293);
            this.groupBoxCreateOffice.Name = "groupBoxCreateOffice";
            this.groupBoxCreateOffice.Size = new System.Drawing.Size(215, 118);
            this.groupBoxCreateOffice.TabIndex = 5;
            this.groupBoxCreateOffice.TabStop = false;
            this.groupBoxCreateOffice.Text = "Create Office";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(69, 84);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            // 
            // groupBoxDeleteOffice
            // 
            this.groupBoxDeleteOffice.Controls.Add(this.labelChooseOffice);
            this.groupBoxDeleteOffice.Controls.Add(this.comboBoxDeleteOffices);
            this.groupBoxDeleteOffice.Controls.Add(this.buttonDelete);
            this.groupBoxDeleteOffice.Location = new System.Drawing.Point(243, 293);
            this.groupBoxDeleteOffice.Name = "groupBoxDeleteOffice";
            this.groupBoxDeleteOffice.Size = new System.Drawing.Size(259, 118);
            this.groupBoxDeleteOffice.TabIndex = 6;
            this.groupBoxDeleteOffice.TabStop = false;
            this.groupBoxDeleteOffice.Text = "Delete Office";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(91, 84);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // comboBoxDeleteOffices
            // 
            this.comboBoxDeleteOffices.FormattingEnabled = true;
            this.comboBoxDeleteOffices.Location = new System.Drawing.Point(27, 49);
            this.comboBoxDeleteOffices.Name = "comboBoxDeleteOffices";
            this.comboBoxDeleteOffices.Size = new System.Drawing.Size(204, 24);
            this.comboBoxDeleteOffices.TabIndex = 1;
            // 
            // labelChooseOffice
            // 
            this.labelChooseOffice.AutoSize = true;
            this.labelChooseOffice.Location = new System.Drawing.Point(88, 24);
            this.labelChooseOffice.Name = "labelChooseOffice";
            this.labelChooseOffice.Size = new System.Drawing.Size(91, 16);
            this.labelChooseOffice.TabIndex = 2;
            this.labelChooseOffice.Text = "Choose Office";
            // 
            // textBoxCreateNameOffice
            // 
            this.textBoxCreateNameOffice.Location = new System.Drawing.Point(20, 51);
            this.textBoxCreateNameOffice.Name = "textBoxCreateNameOffice";
            this.textBoxCreateNameOffice.Size = new System.Drawing.Size(180, 22);
            this.textBoxCreateNameOffice.TabIndex = 1;
            // 
            // labelOfficeName
            // 
            this.labelOfficeName.AutoSize = true;
            this.labelOfficeName.Location = new System.Drawing.Point(66, 29);
            this.labelOfficeName.Name = "labelOfficeName";
            this.labelOfficeName.Size = new System.Drawing.Size(81, 16);
            this.labelOfficeName.TabIndex = 3;
            this.labelOfficeName.Text = "Office Name";
            // 
            // groupBoxVacantOffice
            // 
            this.groupBoxVacantOffice.Controls.Add(this.labelChooseOffice2);
            this.groupBoxVacantOffice.Controls.Add(this.comboBoxVacantOffice);
            this.groupBoxVacantOffice.Controls.Add(this.buttonVacantOffice);
            this.groupBoxVacantOffice.Location = new System.Drawing.Point(518, 293);
            this.groupBoxVacantOffice.Name = "groupBoxVacantOffice";
            this.groupBoxVacantOffice.Size = new System.Drawing.Size(270, 118);
            this.groupBoxVacantOffice.TabIndex = 7;
            this.groupBoxVacantOffice.TabStop = false;
            this.groupBoxVacantOffice.Text = "Vacant Office";
            // 
            // labelChooseOffice2
            // 
            this.labelChooseOffice2.AutoSize = true;
            this.labelChooseOffice2.Location = new System.Drawing.Point(94, 24);
            this.labelChooseOffice2.Name = "labelChooseOffice2";
            this.labelChooseOffice2.Size = new System.Drawing.Size(91, 16);
            this.labelChooseOffice2.TabIndex = 5;
            this.labelChooseOffice2.Text = "Choose Office";
            // 
            // comboBoxVacantOffice
            // 
            this.comboBoxVacantOffice.FormattingEnabled = true;
            this.comboBoxVacantOffice.Location = new System.Drawing.Point(30, 49);
            this.comboBoxVacantOffice.Name = "comboBoxVacantOffice";
            this.comboBoxVacantOffice.Size = new System.Drawing.Size(204, 24);
            this.comboBoxVacantOffice.TabIndex = 4;
            // 
            // buttonVacantOffice
            // 
            this.buttonVacantOffice.Location = new System.Drawing.Point(97, 84);
            this.buttonVacantOffice.Name = "buttonVacantOffice";
            this.buttonVacantOffice.Size = new System.Drawing.Size(75, 23);
            this.buttonVacantOffice.TabIndex = 3;
            this.buttonVacantOffice.Text = "Vacant";
            this.buttonVacantOffice.UseVisualStyleBackColor = true;
            // 
            // AdminApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxVacantOffice);
            this.Controls.Add(this.groupBoxDeleteOffice);
            this.Controls.Add(this.groupBoxCreateOffice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxGetAllOffices);
            this.Name = "AdminApp";
            this.Text = "Library Admin";
            this.groupBoxGetAllOffices.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxCreateOffice.ResumeLayout(false);
            this.groupBoxCreateOffice.PerformLayout();
            this.groupBoxDeleteOffice.ResumeLayout(false);
            this.groupBoxDeleteOffice.PerformLayout();
            this.groupBoxVacantOffice.ResumeLayout(false);
            this.groupBoxVacantOffice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGetAllOffices;
        private System.Windows.Forms.RichTextBox richTextBoxOpenOffices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBoxOccupiedOffices;
        private System.Windows.Forms.GroupBox groupBoxCreateOffice;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxCreateNameOffice;
        private System.Windows.Forms.GroupBox groupBoxDeleteOffice;
        private System.Windows.Forms.Label labelChooseOffice;
        private System.Windows.Forms.ComboBox comboBoxDeleteOffices;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelOfficeName;
        private System.Windows.Forms.GroupBox groupBoxVacantOffice;
        private System.Windows.Forms.Label labelChooseOffice2;
        private System.Windows.Forms.ComboBox comboBoxVacantOffice;
        private System.Windows.Forms.Button buttonVacantOffice;
    }
}

