namespace WindowsFormsApplication1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.usersButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.UserIDEntry = new System.Windows.Forms.TextBox();
            this.adminCheckBox = new System.Windows.Forms.CheckBox();
            this.fnameBox = new System.Windows.Forms.TextBox();
            this.lnameBox = new System.Windows.Forms.TextBox();
            this.submitUser = new System.Windows.Forms.Button();
            this.getUserRanks = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Map Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.mapButton_click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(561, 305);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 22);
            this.textBox1.TabIndex = 1;
            // 
            // usersButton
            // 
            this.usersButton.Location = new System.Drawing.Point(992, 440);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(75, 23);
            this.usersButton.TabIndex = 2;
            this.usersButton.Text = "users";
            this.usersButton.UseVisualStyleBackColor = true;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(314, 440);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Exit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // UserIDEntry
            // 
            this.UserIDEntry.Location = new System.Drawing.Point(53, 53);
            this.UserIDEntry.Name = "UserIDEntry";
            this.UserIDEntry.Size = new System.Drawing.Size(100, 22);
            this.UserIDEntry.TabIndex = 4;
            this.UserIDEntry.TextChanged += new System.EventHandler(this.UserIDEntry_TextChanged);
            // 
            // adminCheckBox
            // 
            this.adminCheckBox.AutoSize = true;
            this.adminCheckBox.Location = new System.Drawing.Point(199, 53);
            this.adminCheckBox.Name = "adminCheckBox";
            this.adminCheckBox.Size = new System.Drawing.Size(77, 21);
            this.adminCheckBox.TabIndex = 5;
            this.adminCheckBox.Text = "Admin?";
            this.adminCheckBox.UseVisualStyleBackColor = true;
            this.adminCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // fnameBox
            // 
            this.fnameBox.Location = new System.Drawing.Point(314, 52);
            this.fnameBox.Name = "fnameBox";
            this.fnameBox.Size = new System.Drawing.Size(100, 22);
            this.fnameBox.TabIndex = 6;
            // 
            // lnameBox
            // 
            this.lnameBox.Location = new System.Drawing.Point(474, 52);
            this.lnameBox.Name = "lnameBox";
            this.lnameBox.Size = new System.Drawing.Size(100, 22);
            this.lnameBox.TabIndex = 7;
            // 
            // submitUser
            // 
            this.submitUser.Location = new System.Drawing.Point(292, 101);
            this.submitUser.Name = "submitUser";
            this.submitUser.Size = new System.Drawing.Size(75, 53);
            this.submitUser.TabIndex = 8;
            this.submitUser.Text = "Create new user";
            this.submitUser.UseVisualStyleBackColor = true;
            this.submitUser.Click += new System.EventHandler(this.submitUser_Click);
            // 
            // getUserRanks
            // 
            this.getUserRanks.Location = new System.Drawing.Point(71, 130);
            this.getUserRanks.Name = "getUserRanks";
            this.getUserRanks.Size = new System.Drawing.Size(75, 79);
            this.getUserRanks.TabIndex = 9;
            this.getUserRanks.Text = "Retrieve user rankings";
            this.getUserRanks.UseVisualStyleBackColor = true;
            this.getUserRanks.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "First name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Last name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 505);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getUserRanks);
            this.Controls.Add(this.submitUser);
            this.Controls.Add(this.lnameBox);
            this.Controls.Add(this.fnameBox);
            this.Controls.Add(this.adminCheckBox);
            this.Controls.Add(this.UserIDEntry);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.usersButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button usersButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.TextBox UserIDEntry;
        private System.Windows.Forms.CheckBox adminCheckBox;
        private System.Windows.Forms.TextBox fnameBox;
        private System.Windows.Forms.TextBox lnameBox;
        private System.Windows.Forms.Button submitUser;
        private System.Windows.Forms.Button getUserRanks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

