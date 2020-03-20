namespace WFApp1.Forms
{
    partial class AddLocationForm
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
            this.txtNewLocName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveNewLocation = new System.Windows.Forms.Button();
            this.btnCancelNewLocation = new System.Windows.Forms.Button();
            this.cmbLocationManager = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Location Name:";
            // 
            // txtNewLocName
            // 
            this.txtNewLocName.Location = new System.Drawing.Point(38, 65);
            this.txtNewLocName.Name = "txtNewLocName";
            this.txtNewLocName.Size = new System.Drawing.Size(203, 20);
            this.txtNewLocName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location Manager:";
            // 
            // btnSaveNewLocation
            // 
            this.btnSaveNewLocation.Location = new System.Drawing.Point(38, 179);
            this.btnSaveNewLocation.Name = "btnSaveNewLocation";
            this.btnSaveNewLocation.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNewLocation.TabIndex = 4;
            this.btnSaveNewLocation.Text = "Save";
            this.btnSaveNewLocation.UseVisualStyleBackColor = true;
            this.btnSaveNewLocation.Click += new System.EventHandler(this.btnSaveNewLocation_Click);
            // 
            // btnCancelNewLocation
            // 
            this.btnCancelNewLocation.Location = new System.Drawing.Point(166, 179);
            this.btnCancelNewLocation.Name = "btnCancelNewLocation";
            this.btnCancelNewLocation.Size = new System.Drawing.Size(75, 23);
            this.btnCancelNewLocation.TabIndex = 5;
            this.btnCancelNewLocation.Text = "Cancel";
            this.btnCancelNewLocation.UseVisualStyleBackColor = true;
            this.btnCancelNewLocation.Click += new System.EventHandler(this.btnCancelNewLocation_Click);
            // 
            // cmbLocationManager
            // 
            this.cmbLocationManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocationManager.FormattingEnabled = true;
            this.cmbLocationManager.Location = new System.Drawing.Point(38, 110);
            this.cmbLocationManager.Name = "cmbLocationManager";
            this.cmbLocationManager.Size = new System.Drawing.Size(203, 21);
            this.cmbLocationManager.TabIndex = 6;
            // 
            // AddLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 250);
            this.Controls.Add(this.cmbLocationManager);
            this.Controls.Add(this.btnCancelNewLocation);
            this.Controls.Add(this.btnSaveNewLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewLocName);
            this.Controls.Add(this.label1);
            this.Name = "AddLocationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewLocName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveNewLocation;
        private System.Windows.Forms.Button btnCancelNewLocation;
        private System.Windows.Forms.ComboBox cmbLocationManager;
    }
}