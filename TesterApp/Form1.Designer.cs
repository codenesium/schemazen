namespace TesterApp
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
            this.textBoxDestinationDirectory = new System.Windows.Forms.TextBox();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreateSnapshot = new System.Windows.Forms.Button();
            this.buttonDeploySnapshot = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.checkBoxAzureMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxDestinationDirectory
            // 
            this.textBoxDestinationDirectory.Location = new System.Drawing.Point(33, 106);
            this.textBoxDestinationDirectory.Name = "textBoxDestinationDirectory";
            this.textBoxDestinationDirectory.Size = new System.Drawing.Size(441, 20);
            this.textBoxDestinationDirectory.TabIndex = 0;
            this.textBoxDestinationDirectory.Text = "c:\\tmp\\scripts";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(33, 44);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(441, 20);
            this.textBoxConnectionString.TabIndex = 1;
            this.textBoxConnectionString.Text = "Data Source=localhost\\codenesium;Initial Catalog=codenesium_schema;Integrated Sec" +
    "urity=False;User Id=test;Password=Passw0rd;MultipleActiveResultSets=True";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connection String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination Directory";
            // 
            // buttonCreateSnapshot
            // 
            this.buttonCreateSnapshot.Location = new System.Drawing.Point(36, 164);
            this.buttonCreateSnapshot.Name = "buttonCreateSnapshot";
            this.buttonCreateSnapshot.Size = new System.Drawing.Size(146, 23);
            this.buttonCreateSnapshot.TabIndex = 4;
            this.buttonCreateSnapshot.Text = "Create Snapshot";
            this.buttonCreateSnapshot.UseVisualStyleBackColor = true;
            this.buttonCreateSnapshot.Click += new System.EventHandler(this.buttonCreateSnapshot_Click);
            // 
            // buttonDeploySnapshot
            // 
            this.buttonDeploySnapshot.Location = new System.Drawing.Point(328, 164);
            this.buttonDeploySnapshot.Name = "buttonDeploySnapshot";
            this.buttonDeploySnapshot.Size = new System.Drawing.Size(146, 23);
            this.buttonDeploySnapshot.TabIndex = 7;
            this.buttonDeploySnapshot.Text = "Deploy Snapshot";
            this.buttonDeploySnapshot.UseVisualStyleBackColor = true;
            this.buttonDeploySnapshot.Click += new System.EventHandler(this.buttonDeploySnapshot_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(36, 277);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(438, 182);
            this.textBoxLog.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Log";
            // 
            // checkBoxOverwrite
            // 
            this.checkBoxOverwrite.AutoSize = true;
            this.checkBoxOverwrite.Location = new System.Drawing.Point(36, 210);
            this.checkBoxOverwrite.Name = "checkBoxOverwrite";
            this.checkBoxOverwrite.Size = new System.Drawing.Size(71, 17);
            this.checkBoxOverwrite.TabIndex = 10;
            this.checkBoxOverwrite.Text = "Overwrite";
            this.checkBoxOverwrite.UseVisualStyleBackColor = true;
            // 
            // checkBoxAzureMode
            // 
            this.checkBoxAzureMode.AutoSize = true;
            this.checkBoxAzureMode.Location = new System.Drawing.Point(36, 233);
            this.checkBoxAzureMode.Name = "checkBoxAzureMode";
            this.checkBoxAzureMode.Size = new System.Drawing.Size(83, 17);
            this.checkBoxAzureMode.TabIndex = 11;
            this.checkBoxAzureMode.Text = "Azure Mode";
            this.checkBoxAzureMode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 499);
            this.Controls.Add(this.checkBoxAzureMode);
            this.Controls.Add(this.checkBoxOverwrite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonDeploySnapshot);
            this.Controls.Add(this.buttonCreateSnapshot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxConnectionString);
            this.Controls.Add(this.textBoxDestinationDirectory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDestinationDirectory;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreateSnapshot;
        private System.Windows.Forms.Button buttonDeploySnapshot;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxOverwrite;
        private System.Windows.Forms.CheckBox checkBoxAzureMode;
    }
}

