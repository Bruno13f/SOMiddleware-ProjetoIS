﻿namespace TestSubscription
{
    partial class SubscriptionTester
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
            this.labelNameApp = new System.Windows.Forms.Label();
            this.labelNameContainer = new System.Windows.Forms.Label();
            this.labelAppName2 = new System.Windows.Forms.Label();
            this.textBoxNameContainer = new System.Windows.Forms.TextBox();
            this.textBoxNameApp = new System.Windows.Forms.TextBox();
            this.textBoxNameApp2 = new System.Windows.Forms.TextBox();
            this.btnGetSubscription = new System.Windows.Forms.Button();
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.textBoxEndpoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEvent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxSubscriptions = new System.Windows.Forms.RichTextBox();
            this.btnGetAllSubscriptions = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContainer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNameSubscription = new System.Windows.Forms.TextBox();
            this.groupBoxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(667, 72);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(565, 92);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(565, 50);
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
            this.textBoxParent.Size = new System.Drawing.Size(139, 20);
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
            this.textBoxDTC.Size = new System.Drawing.Size(196, 20);
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
            // labelNameApp
            // 
            this.labelNameApp.AutoSize = true;
            this.labelNameApp.Location = new System.Drawing.Point(260, 16);
            this.labelNameApp.Name = "labelNameApp";
            this.labelNameApp.Size = new System.Drawing.Size(93, 13);
            this.labelNameApp.TabIndex = 27;
            this.labelNameApp.Text = "Application Name ";
            // 
            // labelNameContainer
            // 
            this.labelNameContainer.AutoSize = true;
            this.labelNameContainer.Location = new System.Drawing.Point(262, 253);
            this.labelNameContainer.Name = "labelNameContainer";
            this.labelNameContainer.Size = new System.Drawing.Size(86, 13);
            this.labelNameContainer.TabIndex = 26;
            this.labelNameContainer.Text = "Container Name ";
            // 
            // labelAppName2
            // 
            this.labelAppName2.AutoSize = true;
            this.labelAppName2.Location = new System.Drawing.Point(144, 253);
            this.labelAppName2.Name = "labelAppName2";
            this.labelAppName2.Size = new System.Drawing.Size(90, 13);
            this.labelAppName2.TabIndex = 25;
            this.labelAppName2.Text = "Application Name";
            // 
            // textBoxNameContainer
            // 
            this.textBoxNameContainer.Location = new System.Drawing.Point(256, 268);
            this.textBoxNameContainer.Name = "textBoxNameContainer";
            this.textBoxNameContainer.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameContainer.TabIndex = 24;
            // 
            // textBoxNameApp
            // 
            this.textBoxNameApp.Location = new System.Drawing.Point(154, 14);
            this.textBoxNameApp.Name = "textBoxNameApp";
            this.textBoxNameApp.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameApp.TabIndex = 23;
            // 
            // textBoxNameApp2
            // 
            this.textBoxNameApp2.Location = new System.Drawing.Point(138, 268);
            this.textBoxNameApp2.Name = "textBoxNameApp2";
            this.textBoxNameApp2.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameApp2.TabIndex = 22;
            // 
            // btnGetSubscription
            // 
            this.btnGetSubscription.Location = new System.Drawing.Point(10, 266);
            this.btnGetSubscription.Name = "btnGetSubscription";
            this.btnGetSubscription.Size = new System.Drawing.Size(112, 23);
            this.btnGetSubscription.TabIndex = 21;
            this.btnGetSubscription.Text = "Get Subscription {?}";
            this.btnGetSubscription.UseVisualStyleBackColor = true;
            this.btnGetSubscription.Click += new System.EventHandler(this.btnGetContainer_Click);
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.Controls.Add(this.textBoxEndpoint);
            this.groupBoxContainer.Controls.Add(this.label5);
            this.groupBoxContainer.Controls.Add(this.textBoxEvent);
            this.groupBoxContainer.Controls.Add(this.label4);
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
            this.groupBoxContainer.Location = new System.Drawing.Point(10, 306);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(761, 157);
            this.groupBoxContainer.TabIndex = 20;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "Subscription Info";
            // 
            // textBoxEndpoint
            // 
            this.textBoxEndpoint.Location = new System.Drawing.Point(288, 113);
            this.textBoxEndpoint.Name = "textBoxEndpoint";
            this.textBoxEndpoint.Size = new System.Drawing.Size(237, 20);
            this.textBoxEndpoint.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Endpoint";
            // 
            // textBoxEvent
            // 
            this.textBoxEvent.Location = new System.Drawing.Point(90, 113);
            this.textBoxEvent.Name = "textBoxEvent";
            this.textBoxEvent.Size = new System.Drawing.Size(117, 20);
            this.textBoxEvent.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Event";
            // 
            // richTextBoxSubscriptions
            // 
            this.richTextBoxSubscriptions.Location = new System.Drawing.Point(10, 51);
            this.richTextBoxSubscriptions.Name = "richTextBoxSubscriptions";
            this.richTextBoxSubscriptions.Size = new System.Drawing.Size(762, 176);
            this.richTextBoxSubscriptions.TabIndex = 19;
            this.richTextBoxSubscriptions.Text = "";
            // 
            // btnGetAllSubscriptions
            // 
            this.btnGetAllSubscriptions.Location = new System.Drawing.Point(10, 11);
            this.btnGetAllSubscriptions.Name = "btnGetAllSubscriptions";
            this.btnGetAllSubscriptions.Size = new System.Drawing.Size(128, 23);
            this.btnGetAllSubscriptions.TabIndex = 18;
            this.btnGetAllSubscriptions.Text = "Get All Subscriptions";
            this.btnGetAllSubscriptions.UseVisualStyleBackColor = true;
            this.btnGetAllSubscriptions.Click += new System.EventHandler(this.btnGetAllSubscriptions_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Container Name ";
            // 
            // textBoxContainer
            // 
            this.textBoxContainer.Location = new System.Drawing.Point(364, 14);
            this.textBoxContainer.Name = "textBoxContainer";
            this.textBoxContainer.Size = new System.Drawing.Size(100, 20);
            this.textBoxContainer.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Subscription Name ";
            // 
            // textBoxNameSubscription
            // 
            this.textBoxNameSubscription.Location = new System.Drawing.Point(375, 268);
            this.textBoxNameSubscription.Name = "textBoxNameSubscription";
            this.textBoxNameSubscription.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameSubscription.TabIndex = 30;
            // 
            // SubscriptionTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 505);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNameSubscription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxContainer);
            this.Controls.Add(this.labelNameApp);
            this.Controls.Add(this.labelNameContainer);
            this.Controls.Add(this.labelAppName2);
            this.Controls.Add(this.textBoxNameContainer);
            this.Controls.Add(this.textBoxNameApp);
            this.Controls.Add(this.textBoxNameApp2);
            this.Controls.Add(this.btnGetSubscription);
            this.Controls.Add(this.groupBoxContainer);
            this.Controls.Add(this.richTextBoxSubscriptions);
            this.Controls.Add(this.btnGetAllSubscriptions);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SubscriptionTester";
            this.Text = "Subscription Tester";
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox textBoxParent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDTC;
        private System.Windows.Forms.Label labelDTC;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelNameApp;
        private System.Windows.Forms.Label labelNameContainer;
        private System.Windows.Forms.Label labelAppName2;
        private System.Windows.Forms.TextBox textBoxNameContainer;
        private System.Windows.Forms.TextBox textBoxNameApp;
        private System.Windows.Forms.TextBox textBoxNameApp2;
        private System.Windows.Forms.Button btnGetSubscription;
        private System.Windows.Forms.GroupBox groupBoxContainer;
        private System.Windows.Forms.RichTextBox richTextBoxSubscriptions;
        private System.Windows.Forms.Button btnGetAllSubscriptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNameSubscription;
        private System.Windows.Forms.TextBox textBoxEndpoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEvent;
        private System.Windows.Forms.Label label4;
    }
}

