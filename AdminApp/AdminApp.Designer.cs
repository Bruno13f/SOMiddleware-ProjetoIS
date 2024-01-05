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
            this.labelOfficeName = new System.Windows.Forms.Label();
            this.textBoxCreateNameOffice = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxDeleteOffice = new System.Windows.Forms.GroupBox();
            this.labelChooseOffice = new System.Windows.Forms.Label();
            this.comboBoxDeleteOffices = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
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
            this.groupBoxGetAllOffices.Location = new System.Drawing.Point(14, 45);
            this.groupBoxGetAllOffices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxGetAllOffices.Name = "groupBoxGetAllOffices";
            this.groupBoxGetAllOffices.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxGetAllOffices.Size = new System.Drawing.Size(428, 292);
            this.groupBoxGetAllOffices.TabIndex = 2;
            this.groupBoxGetAllOffices.TabStop = false;
            this.groupBoxGetAllOffices.Text = "Open Offices";
            // 
            // richTextBoxOpenOffices
            // 
            this.richTextBoxOpenOffices.Location = new System.Drawing.Point(22, 29);
            this.richTextBoxOpenOffices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxOpenOffices.Name = "richTextBoxOpenOffices";
            this.richTextBoxOpenOffices.Size = new System.Drawing.Size(378, 236);
            this.richTextBoxOpenOffices.TabIndex = 0;
            this.richTextBoxOpenOffices.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxOccupiedOffices);
            this.groupBox1.Location = new System.Drawing.Point(459, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(428, 292);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Occupied Offices";
            // 
            // richTextBoxOccupiedOffices
            // 
            this.richTextBoxOccupiedOffices.Location = new System.Drawing.Point(22, 29);
            this.richTextBoxOccupiedOffices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxOccupiedOffices.Name = "richTextBoxOccupiedOffices";
            this.richTextBoxOccupiedOffices.Size = new System.Drawing.Size(378, 236);
            this.richTextBoxOccupiedOffices.TabIndex = 0;
            this.richTextBoxOccupiedOffices.Text = "";
            // 
            // groupBoxCreateOffice
            // 
            this.groupBoxCreateOffice.Controls.Add(this.labelOfficeName);
            this.groupBoxCreateOffice.Controls.Add(this.textBoxCreateNameOffice);
            this.groupBoxCreateOffice.Controls.Add(this.buttonCreate);
            this.groupBoxCreateOffice.Location = new System.Drawing.Point(14, 366);
            this.groupBoxCreateOffice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxCreateOffice.Name = "groupBoxCreateOffice";
            this.groupBoxCreateOffice.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxCreateOffice.Size = new System.Drawing.Size(242, 148);
            this.groupBoxCreateOffice.TabIndex = 5;
            this.groupBoxCreateOffice.TabStop = false;
            this.groupBoxCreateOffice.Text = "Create Office";
            // 
            // labelOfficeName
            // 
            this.labelOfficeName.AutoSize = true;
            this.labelOfficeName.Location = new System.Drawing.Point(74, 36);
            this.labelOfficeName.Name = "labelOfficeName";
            this.labelOfficeName.Size = new System.Drawing.Size(97, 20);
            this.labelOfficeName.TabIndex = 3;
            this.labelOfficeName.Text = "Office Name";
            // 
            // textBoxCreateNameOffice
            // 
            this.textBoxCreateNameOffice.Location = new System.Drawing.Point(22, 64);
            this.textBoxCreateNameOffice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCreateNameOffice.Name = "textBoxCreateNameOffice";
            this.textBoxCreateNameOffice.Size = new System.Drawing.Size(202, 26);
            this.textBoxCreateNameOffice.TabIndex = 1;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(78, 105);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(84, 29);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupBoxDeleteOffice
            // 
            this.groupBoxDeleteOffice.Controls.Add(this.labelChooseOffice);
            this.groupBoxDeleteOffice.Controls.Add(this.comboBoxDeleteOffices);
            this.groupBoxDeleteOffice.Controls.Add(this.buttonDelete);
            this.groupBoxDeleteOffice.Location = new System.Drawing.Point(273, 366);
            this.groupBoxDeleteOffice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDeleteOffice.Name = "groupBoxDeleteOffice";
            this.groupBoxDeleteOffice.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDeleteOffice.Size = new System.Drawing.Size(291, 148);
            this.groupBoxDeleteOffice.TabIndex = 6;
            this.groupBoxDeleteOffice.TabStop = false;
            this.groupBoxDeleteOffice.Text = "Delete Office";
            // 
            // labelChooseOffice
            // 
            this.labelChooseOffice.AutoSize = true;
            this.labelChooseOffice.Location = new System.Drawing.Point(99, 30);
            this.labelChooseOffice.Name = "labelChooseOffice";
            this.labelChooseOffice.Size = new System.Drawing.Size(110, 20);
            this.labelChooseOffice.TabIndex = 2;
            this.labelChooseOffice.Text = "Choose Office";
            // 
            // comboBoxDeleteOffices
            // 
            this.comboBoxDeleteOffices.FormattingEnabled = true;
            this.comboBoxDeleteOffices.Location = new System.Drawing.Point(30, 61);
            this.comboBoxDeleteOffices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxDeleteOffices.Name = "comboBoxDeleteOffices";
            this.comboBoxDeleteOffices.Size = new System.Drawing.Size(229, 28);
            this.comboBoxDeleteOffices.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(102, 105);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(84, 29);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBoxVacantOffice
            // 
            this.groupBoxVacantOffice.Controls.Add(this.labelChooseOffice2);
            this.groupBoxVacantOffice.Controls.Add(this.comboBoxVacantOffice);
            this.groupBoxVacantOffice.Controls.Add(this.buttonVacantOffice);
            this.groupBoxVacantOffice.Location = new System.Drawing.Point(583, 366);
            this.groupBoxVacantOffice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxVacantOffice.Name = "groupBoxVacantOffice";
            this.groupBoxVacantOffice.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxVacantOffice.Size = new System.Drawing.Size(304, 148);
            this.groupBoxVacantOffice.TabIndex = 7;
            this.groupBoxVacantOffice.TabStop = false;
            this.groupBoxVacantOffice.Text = "Vacant Office";
            // 
            // labelChooseOffice2
            // 
            this.labelChooseOffice2.AutoSize = true;
            this.labelChooseOffice2.Location = new System.Drawing.Point(106, 30);
            this.labelChooseOffice2.Name = "labelChooseOffice2";
            this.labelChooseOffice2.Size = new System.Drawing.Size(110, 20);
            this.labelChooseOffice2.TabIndex = 5;
            this.labelChooseOffice2.Text = "Choose Office";
            // 
            // comboBoxVacantOffice
            // 
            this.comboBoxVacantOffice.FormattingEnabled = true;
            this.comboBoxVacantOffice.Location = new System.Drawing.Point(34, 61);
            this.comboBoxVacantOffice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxVacantOffice.Name = "comboBoxVacantOffice";
            this.comboBoxVacantOffice.Size = new System.Drawing.Size(229, 28);
            this.comboBoxVacantOffice.TabIndex = 4;
            // 
            // buttonVacantOffice
            // 
            this.buttonVacantOffice.Location = new System.Drawing.Point(109, 105);
            this.buttonVacantOffice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonVacantOffice.Name = "buttonVacantOffice";
            this.buttonVacantOffice.Size = new System.Drawing.Size(84, 29);
            this.buttonVacantOffice.TabIndex = 3;
            this.buttonVacantOffice.Text = "Vacant";
            this.buttonVacantOffice.UseVisualStyleBackColor = true;
            this.buttonVacantOffice.Click += new System.EventHandler(this.buttonVacantOffice_Click);
            // 
            // AdminApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.groupBoxVacantOffice);
            this.Controls.Add(this.groupBoxDeleteOffice);
            this.Controls.Add(this.groupBoxCreateOffice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxGetAllOffices);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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

