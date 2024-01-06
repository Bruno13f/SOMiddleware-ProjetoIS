namespace TestContainer
{
    partial class ContainerTester
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
            this.btnGetAllContainers = new System.Windows.Forms.Button();
            this.richTextBoxContainers = new System.Windows.Forms.RichTextBox();
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.textBoxParent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDTC = new System.Windows.Forms.TextBox();
            this.labelDTC = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.btnGetContainer = new System.Windows.Forms.Button();
            this.textBoxNameApp2 = new System.Windows.Forms.TextBox();
            this.textBoxNameApp = new System.Windows.Forms.TextBox();
            this.textBoxNameContainer = new System.Windows.Forms.TextBox();
            this.labelAppName2 = new System.Windows.Forms.Label();
            this.labelNameContainer = new System.Windows.Forms.Label();
            this.labelNameApp = new System.Windows.Forms.Label();
            this.groupBoxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetAllContainers
            // 
            this.btnGetAllContainers.Location = new System.Drawing.Point(21, 17);
            this.btnGetAllContainers.Name = "btnGetAllContainers";
            this.btnGetAllContainers.Size = new System.Drawing.Size(128, 23);
            this.btnGetAllContainers.TabIndex = 0;
            this.btnGetAllContainers.Text = "Get All Containers";
            this.btnGetAllContainers.UseVisualStyleBackColor = true;
            this.btnGetAllContainers.Click += new System.EventHandler(this.btnGetAllContainers_Click);
            // 
            // richTextBoxContainers
            // 
            this.richTextBoxContainers.Location = new System.Drawing.Point(21, 58);
            this.richTextBoxContainers.Name = "richTextBoxContainers";
            this.richTextBoxContainers.ReadOnly = true;
            this.richTextBoxContainers.Size = new System.Drawing.Size(743, 176);
            this.richTextBoxContainers.TabIndex = 1;
            this.richTextBoxContainers.Text = "";
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.Controls.Add(this.btnEdit);
            this.groupBoxContainer.Controls.Add(this.btnClear);
            this.groupBoxContainer.Controls.Add(this.btnDelete);
            this.groupBoxContainer.Controls.Add(this.btnCreate);
            this.groupBoxContainer.Controls.Add(this.textBoxParent);
            this.groupBoxContainer.Controls.Add(this.label1);
            this.groupBoxContainer.Controls.Add(this.textBoxDTC);
            this.groupBoxContainer.Controls.Add(this.labelDTC);
            this.groupBoxContainer.Controls.Add(this.textBoxName);
            this.groupBoxContainer.Controls.Add(this.textBoxID);
            this.groupBoxContainer.Controls.Add(this.labelName);
            this.groupBoxContainer.Controls.Add(this.labelID);
            this.groupBoxContainer.Location = new System.Drawing.Point(21, 312);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(743, 114);
            this.groupBoxContainer.TabIndex = 2;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "Container Info";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(636, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(636, 72);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(532, 71);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(532, 28);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // textBoxParent
            // 
            this.textBoxParent.Enabled = false;
            this.textBoxParent.Location = new System.Drawing.Point(386, 74);
            this.textBoxParent.Name = "textBoxParent";
            this.textBoxParent.Size = new System.Drawing.Size(117, 20);
            this.textBoxParent.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Parent";
            // 
            // textBoxDTC
            // 
            this.textBoxDTC.Enabled = false;
            this.textBoxDTC.Location = new System.Drawing.Point(329, 28);
            this.textBoxDTC.Name = "textBoxDTC";
            this.textBoxDTC.Size = new System.Drawing.Size(174, 20);
            this.textBoxDTC.TabIndex = 8;
            // 
            // labelDTC
            // 
            this.labelDTC.AutoSize = true;
            this.labelDTC.Location = new System.Drawing.Point(223, 31);
            this.labelDTC.Name = "labelDTC";
            this.labelDTC.Size = new System.Drawing.Size(84, 13);
            this.labelDTC.TabIndex = 7;
            this.labelDTC.Text = "Date of Creation";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(90, 74);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(217, 20);
            this.textBoxName.TabIndex = 6;
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(90, 28);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(20, 74);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(28, 31);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID";
            // 
            // btnGetContainer
            // 
            this.btnGetContainer.Location = new System.Drawing.Point(21, 273);
            this.btnGetContainer.Name = "btnGetContainer";
            this.btnGetContainer.Size = new System.Drawing.Size(112, 23);
            this.btnGetContainer.TabIndex = 3;
            this.btnGetContainer.Text = "Get Container {?}";
            this.btnGetContainer.UseVisualStyleBackColor = true;
            this.btnGetContainer.Click += new System.EventHandler(this.btnGetContainer_Click);
            // 
            // textBoxNameApp2
            // 
            this.textBoxNameApp2.Location = new System.Drawing.Point(149, 275);
            this.textBoxNameApp2.Name = "textBoxNameApp2";
            this.textBoxNameApp2.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameApp2.TabIndex = 4;
            // 
            // textBoxNameApp
            // 
            this.textBoxNameApp.Location = new System.Drawing.Point(165, 20);
            this.textBoxNameApp.Name = "textBoxNameApp";
            this.textBoxNameApp.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameApp.TabIndex = 5;
            // 
            // textBoxNameContainer
            // 
            this.textBoxNameContainer.Location = new System.Drawing.Point(267, 275);
            this.textBoxNameContainer.Name = "textBoxNameContainer";
            this.textBoxNameContainer.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameContainer.TabIndex = 6;
            // 
            // labelAppName2
            // 
            this.labelAppName2.AutoSize = true;
            this.labelAppName2.Location = new System.Drawing.Point(154, 259);
            this.labelAppName2.Name = "labelAppName2";
            this.labelAppName2.Size = new System.Drawing.Size(90, 13);
            this.labelAppName2.TabIndex = 15;
            this.labelAppName2.Text = "Application Name";
            // 
            // labelNameContainer
            // 
            this.labelNameContainer.AutoSize = true;
            this.labelNameContainer.Location = new System.Drawing.Point(273, 259);
            this.labelNameContainer.Name = "labelNameContainer";
            this.labelNameContainer.Size = new System.Drawing.Size(86, 13);
            this.labelNameContainer.TabIndex = 16;
            this.labelNameContainer.Text = "Container Name ";
            // 
            // labelNameApp
            // 
            this.labelNameApp.AutoSize = true;
            this.labelNameApp.Location = new System.Drawing.Point(271, 23);
            this.labelNameApp.Name = "labelNameApp";
            this.labelNameApp.Size = new System.Drawing.Size(93, 13);
            this.labelNameApp.TabIndex = 17;
            this.labelNameApp.Text = "Application Name ";
            // 
            // ContainerTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNameApp);
            this.Controls.Add(this.labelNameContainer);
            this.Controls.Add(this.labelAppName2);
            this.Controls.Add(this.textBoxNameContainer);
            this.Controls.Add(this.textBoxNameApp);
            this.Controls.Add(this.textBoxNameApp2);
            this.Controls.Add(this.btnGetContainer);
            this.Controls.Add(this.groupBoxContainer);
            this.Controls.Add(this.richTextBoxContainers);
            this.Controls.Add(this.btnGetAllContainers);
            this.Name = "ContainerTester";
            this.Text = "Container Tester";
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetAllContainers;
        private System.Windows.Forms.RichTextBox richTextBoxContainers;
        private System.Windows.Forms.GroupBox groupBoxContainer;
        private System.Windows.Forms.Button btnGetContainer;
        private System.Windows.Forms.TextBox textBoxNameApp2;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelDTC;
        private System.Windows.Forms.TextBox textBoxParent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDTC;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox textBoxNameApp;
        private System.Windows.Forms.TextBox textBoxNameContainer;
        private System.Windows.Forms.Label labelAppName2;
        private System.Windows.Forms.Label labelNameContainer;
        private System.Windows.Forms.Label labelNameApp;
        private System.Windows.Forms.Button btnEdit;
    }
}

