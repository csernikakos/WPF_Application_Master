namespace WFApp1
{
    partial class Form1
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
            this.btn_Get = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtLocationID = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.dgvLocationAdmin = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEditLocation = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCurrentDecisionLevel = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRequestType = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtValidityEnd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtValidityStart = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstActiveRequests = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationAdmin)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(17, 101);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(75, 23);
            this.btn_Get.TabIndex = 0;
            this.btn_Get.Text = "Get";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(13, 150);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(369, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(17, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(369, 69);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(13, 195);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(369, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(13, 240);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(369, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(13, 330);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(369, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(13, 420);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(369, 20);
            this.txtPosition.TabIndex = 6;
            // 
            // txtLocationID
            // 
            this.txtLocationID.Location = new System.Drawing.Point(13, 465);
            this.txtLocationID.Name = "txtLocationID";
            this.txtLocationID.Size = new System.Drawing.Size(369, 20);
            this.txtLocationID.TabIndex = 7;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(98, 101);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(13, 491);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(369, 20);
            this.txtLocation.TabIndex = 9;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(179, 101);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(260, 101);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(13, 285);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(369, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(13, 375);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(369, 20);
            this.txtManager.TabIndex = 13;
            // 
            // dgvLocationAdmin
            // 
            this.dgvLocationAdmin.AllowUserToResizeColumns = false;
            this.dgvLocationAdmin.AllowUserToResizeRows = false;
            this.dgvLocationAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocationAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocationAdmin.Location = new System.Drawing.Point(21, 18);
            this.dgvLocationAdmin.Name = "dgvLocationAdmin";
            this.dgvLocationAdmin.Size = new System.Drawing.Size(314, 121);
            this.dgvLocationAdmin.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(415, 557);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtManager);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.btn_Get);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.txtFirstName);
            this.tabPage1.Controls.Add(this.btnNew);
            this.tabPage1.Controls.Add(this.txtLastName);
            this.tabPage1.Controls.Add(this.txtLocation);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Controls.Add(this.btn_Update);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtLocationID);
            this.tabPage1.Controls.Add(this.txtPosition);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "People";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Position:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Manager:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Last name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "First name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEditLocation);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dgvLocationAdmin);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Locations";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEditLocation
            // 
            this.btnEditLocation.Location = new System.Drawing.Point(133, 159);
            this.btnEditLocation.Name = "btnEditLocation";
            this.btnEditLocation.Size = new System.Drawing.Size(107, 23);
            this.btnEditLocation.TabIndex = 16;
            this.btnEditLocation.Text = "Edit location";
            this.btnEditLocation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add new location";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.txtCurrentDecisionLevel);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.txtRequestType);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.txtValidityEnd);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.txtValidityStart);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.txtRole);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.txtPersonName);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.lstActiveRequests);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(407, 531);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Requests";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(280, 490);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "New Request";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtCurrentDecisionLevel
            // 
            this.txtCurrentDecisionLevel.Location = new System.Drawing.Point(18, 338);
            this.txtCurrentDecisionLevel.Name = "txtCurrentDecisionLevel";
            this.txtCurrentDecisionLevel.Size = new System.Drawing.Size(359, 20);
            this.txtCurrentDecisionLevel.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 319);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Current Decision Level";
            // 
            // txtRequestType
            // 
            this.txtRequestType.Location = new System.Drawing.Point(18, 293);
            this.txtRequestType.Name = "txtRequestType";
            this.txtRequestType.Size = new System.Drawing.Size(359, 20);
            this.txtRequestType.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 274);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Request Type:";
            // 
            // txtValidityEnd
            // 
            this.txtValidityEnd.Location = new System.Drawing.Point(207, 246);
            this.txtValidityEnd.Name = "txtValidityEnd";
            this.txtValidityEnd.Size = new System.Drawing.Size(170, 20);
            this.txtValidityEnd.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(204, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Validity End:";
            // 
            // txtValidityStart
            // 
            this.txtValidityStart.Location = new System.Drawing.Point(18, 246);
            this.txtValidityStart.Name = "txtValidityStart";
            this.txtValidityStart.Size = new System.Drawing.Size(170, 20);
            this.txtValidityStart.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Validity Start:";
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(18, 203);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(359, 20);
            this.txtRole.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Role:";
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(18, 165);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(359, 20);
            this.txtPersonName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Person Name:";
            // 
            // lstActiveRequests
            // 
            this.lstActiveRequests.FormattingEnabled = true;
            this.lstActiveRequests.Location = new System.Drawing.Point(18, 16);
            this.lstActiveRequests.Name = "lstActiveRequests";
            this.lstActiveRequests.Size = new System.Drawing.Size(362, 108);
            this.lstActiveRequests.TabIndex = 0;
            this.lstActiveRequests.SelectedIndexChanged += new System.EventHandler(this.lstActiveRequests_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 579);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocationAdmin)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtLocationID;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.DataGridView dgvLocationAdmin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnEditLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCurrentDecisionLevel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRequestType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtValidityEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtValidityStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstActiveRequests;
    }
}

