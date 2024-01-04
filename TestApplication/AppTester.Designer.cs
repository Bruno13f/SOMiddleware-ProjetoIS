namespace TestApplication
{
    partial class AppTester
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
            this.btnGetApps = new System.Windows.Forms.Button();
            this.groupAppInfo = new System.Windows.Forms.GroupBox();
            this.btnCreateApp = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDeleteApp = new System.Windows.Forms.Button();
            this.textBoxCDT = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idApp = new System.Windows.Forms.Label();
            this.richTextBoxApps = new System.Windows.Forms.RichTextBox();
            this.btnGetApp = new System.Windows.Forms.Button();
            this.textBoxNameApp = new System.Windows.Forms.TextBox();
            this.btnEditApp = new System.Windows.Forms.Button();
            this.groupAppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetApps
            // 
            this.btnGetApps.Location = new System.Drawing.Point(27, 23);
            this.btnGetApps.Name = "btnGetApps";
            this.btnGetApps.Size = new System.Drawing.Size(94, 23);
            this.btnGetApps.TabIndex = 0;
            this.btnGetApps.Text = "Get Apps";
            this.btnGetApps.UseVisualStyleBackColor = true;
            this.btnGetApps.Click += new System.EventHandler(this.btnGetApps_Click);
            // 
            // groupAppInfo
            // 
            this.groupAppInfo.Controls.Add(this.btnEditApp);
            this.groupAppInfo.Controls.Add(this.btnCreateApp);
            this.groupAppInfo.Controls.Add(this.btnClear);
            this.groupAppInfo.Controls.Add(this.btnDeleteApp);
            this.groupAppInfo.Controls.Add(this.textBoxCDT);
            this.groupAppInfo.Controls.Add(this.textBoxName);
            this.groupAppInfo.Controls.Add(this.textBoxID);
            this.groupAppInfo.Controls.Add(this.label3);
            this.groupAppInfo.Controls.Add(this.label2);
            this.groupAppInfo.Controls.Add(this.idApp);
            this.groupAppInfo.Location = new System.Drawing.Point(27, 311);
            this.groupAppInfo.Name = "groupAppInfo";
            this.groupAppInfo.Size = new System.Drawing.Size(736, 114);
            this.groupAppInfo.TabIndex = 2;
            this.groupAppInfo.TabStop = false;
            this.groupAppInfo.Text = "App Info";
            // 
            // btnCreateApp
            // 
            this.btnCreateApp.Location = new System.Drawing.Point(540, 31);
            this.btnCreateApp.Name = "btnCreateApp";
            this.btnCreateApp.Size = new System.Drawing.Size(78, 23);
            this.btnCreateApp.TabIndex = 8;
            this.btnCreateApp.Text = "Create";
            this.btnCreateApp.UseVisualStyleBackColor = true;
            this.btnCreateApp.Click += new System.EventHandler(this.btnCreateApp_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(638, 67);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDeleteApp
            // 
            this.btnDeleteApp.Location = new System.Drawing.Point(540, 68);
            this.btnDeleteApp.Name = "btnDeleteApp";
            this.btnDeleteApp.Size = new System.Drawing.Size(78, 23);
            this.btnDeleteApp.TabIndex = 6;
            this.btnDeleteApp.Text = "Delete";
            this.btnDeleteApp.UseVisualStyleBackColor = true;
            this.btnDeleteApp.Click += new System.EventHandler(this.btnDeleteApp_Click);
            // 
            // textBoxCDT
            // 
            this.textBoxCDT.Enabled = false;
            this.textBoxCDT.Location = new System.Drawing.Point(302, 33);
            this.textBoxCDT.Name = "textBoxCDT";
            this.textBoxCDT.Size = new System.Drawing.Size(206, 20);
            this.textBoxCDT.TabIndex = 5;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(106, 70);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(402, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(106, 33);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(58, 20);
            this.textBoxID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date of Creation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // idApp
            // 
            this.idApp.AutoSize = true;
            this.idApp.Location = new System.Drawing.Point(35, 36);
            this.idApp.Name = "idApp";
            this.idApp.Size = new System.Drawing.Size(18, 13);
            this.idApp.TabIndex = 0;
            this.idApp.Text = "ID";
            // 
            // richTextBoxApps
            // 
            this.richTextBoxApps.Location = new System.Drawing.Point(27, 64);
            this.richTextBoxApps.Name = "richTextBoxApps";
            this.richTextBoxApps.Size = new System.Drawing.Size(736, 179);
            this.richTextBoxApps.TabIndex = 3;
            this.richTextBoxApps.Text = "";
            // 
            // btnGetApp
            // 
            this.btnGetApp.Location = new System.Drawing.Point(27, 272);
            this.btnGetApp.Name = "btnGetApp";
            this.btnGetApp.Size = new System.Drawing.Size(112, 23);
            this.btnGetApp.TabIndex = 4;
            this.btnGetApp.Text = "Get Application {?}";
            this.btnGetApp.UseVisualStyleBackColor = true;
            this.btnGetApp.Click += new System.EventHandler(this.btnGetApp_Click);
            // 
            // textBoxNameApp
            // 
            this.textBoxNameApp.Location = new System.Drawing.Point(145, 275);
            this.textBoxNameApp.Name = "textBoxNameApp";
            this.textBoxNameApp.Size = new System.Drawing.Size(99, 20);
            this.textBoxNameApp.TabIndex = 9;
            // 
            // btnEditApp
            // 
            this.btnEditApp.Location = new System.Drawing.Point(638, 30);
            this.btnEditApp.Name = "btnEditApp";
            this.btnEditApp.Size = new System.Drawing.Size(78, 23);
            this.btnEditApp.TabIndex = 9;
            this.btnEditApp.Text = "Edit";
            this.btnEditApp.UseVisualStyleBackColor = true;
            this.btnEditApp.Click += new System.EventHandler(this.btnEditApp_Click);
            // 
            // AppTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxNameApp);
            this.Controls.Add(this.btnGetApp);
            this.Controls.Add(this.richTextBoxApps);
            this.Controls.Add(this.groupAppInfo);
            this.Controls.Add(this.btnGetApps);
            this.Name = "AppTester";
            this.Text = "Application Tester";
            this.groupAppInfo.ResumeLayout(false);
            this.groupAppInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetApps;
        private System.Windows.Forms.GroupBox groupAppInfo;
        private System.Windows.Forms.TextBox textBoxCDT;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label idApp;
        private System.Windows.Forms.Button btnCreateApp;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDeleteApp;
        private System.Windows.Forms.RichTextBox richTextBoxApps;
        private System.Windows.Forms.Button btnGetApp;
        private System.Windows.Forms.TextBox textBoxNameApp;
        private System.Windows.Forms.Button btnEditApp;
    }
}

