namespace QRNG
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.grpRandom = new System.Windows.Forms.GroupBox();
            this.btnFloat = new System.Windows.Forms.Button();
            this.Memo = new System.Windows.Forms.ListBox();
            this.btnInt = new System.Windows.Forms.Button();
            this.edtNum = new System.Windows.Forms.NumericUpDown();
            this.btnTesting = new System.Windows.Forms.Button();
            this.grpConnect = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSSL = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edtPass = new System.Windows.Forms.TextBox();
            this.edtUser = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpRandom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNum)).BeginInit();
            this.grpConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRandom
            // 
            this.grpRandom.Controls.Add(this.btnFloat);
            this.grpRandom.Controls.Add(this.Memo);
            this.grpRandom.Controls.Add(this.btnInt);
            this.grpRandom.Controls.Add(this.edtNum);
            this.grpRandom.Controls.Add(this.btnTesting);
            this.grpRandom.Location = new System.Drawing.Point(12, 117);
            this.grpRandom.Name = "grpRandom";
            this.grpRandom.Size = new System.Drawing.Size(459, 327);
            this.grpRandom.TabIndex = 0;
            this.grpRandom.TabStop = false;
            this.grpRandom.Text = "  Random Numbers";
            // 
            // btnFloat
            // 
            this.btnFloat.Location = new System.Drawing.Point(213, 16);
            this.btnFloat.Name = "btnFloat";
            this.btnFloat.Size = new System.Drawing.Size(75, 23);
            this.btnFloat.TabIndex = 6;
            this.btnFloat.Text = "Get Float";
            this.btnFloat.UseVisualStyleBackColor = true;
            this.btnFloat.Click += new System.EventHandler(this.BtnFloat_Click);
            // 
            // Memo
            // 
            this.Memo.FormattingEnabled = true;
            this.Memo.Location = new System.Drawing.Point(6, 45);
            this.Memo.Name = "Memo";
            this.Memo.ScrollAlwaysVisible = true;
            this.Memo.Size = new System.Drawing.Size(444, 264);
            this.Memo.TabIndex = 5;
            // 
            // btnInt
            // 
            this.btnInt.Location = new System.Drawing.Point(132, 16);
            this.btnInt.Name = "btnInt";
            this.btnInt.Size = new System.Drawing.Size(75, 23);
            this.btnInt.TabIndex = 2;
            this.btnInt.Text = "Get Integer";
            this.btnInt.UseVisualStyleBackColor = true;
            this.btnInt.Click += new System.EventHandler(this.BtnInt_Click);
            // 
            // edtNum
            // 
            this.edtNum.Location = new System.Drawing.Point(6, 19);
            this.edtNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.edtNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtNum.Name = "edtNum";
            this.edtNum.Size = new System.Drawing.Size(120, 20);
            this.edtNum.TabIndex = 0;
            this.edtNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnTesting
            // 
            this.btnTesting.Location = new System.Drawing.Point(375, 16);
            this.btnTesting.Name = "btnTesting";
            this.btnTesting.Size = new System.Drawing.Size(75, 23);
            this.btnTesting.TabIndex = 3;
            this.btnTesting.Text = "Test";
            this.btnTesting.UseVisualStyleBackColor = true;
            this.btnTesting.Click += new System.EventHandler(this.BtnTesting_Click);
            // 
            // grpConnect
            // 
            this.grpConnect.Controls.Add(this.label3);
            this.grpConnect.Controls.Add(this.chkSSL);
            this.grpConnect.Controls.Add(this.label2);
            this.grpConnect.Controls.Add(this.label1);
            this.grpConnect.Controls.Add(this.edtPass);
            this.grpConnect.Controls.Add(this.edtUser);
            this.grpConnect.Location = new System.Drawing.Point(12, 12);
            this.grpConnect.Name = "grpConnect";
            this.grpConnect.Size = new System.Drawing.Size(173, 99);
            this.grpConnect.TabIndex = 1;
            this.grpConnect.TabStop = false;
            this.grpConnect.Text = "Connecting Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SSL";
            // 
            // chkSSL
            // 
            this.chkSSL.AutoSize = true;
            this.chkSSL.Location = new System.Drawing.Point(62, 74);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Size = new System.Drawing.Size(15, 14);
            this.chkSSL.TabIndex = 4;
            this.chkSSL.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pass";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User";
            // 
            // edtPass
            // 
            this.edtPass.Location = new System.Drawing.Point(62, 48);
            this.edtPass.Name = "edtPass";
            this.edtPass.Size = new System.Drawing.Size(100, 20);
            this.edtPass.TabIndex = 1;
            this.edtPass.UseSystemPasswordChar = true;
            // 
            // edtUser
            // 
            this.edtUser.Location = new System.Drawing.Point(62, 22);
            this.edtUser.Name = "edtUser";
            this.edtUser.Size = new System.Drawing.Size(100, 20);
            this.edtUser.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(191, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(109, 42);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 456);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.grpConnect);
            this.Controls.Add(this.grpRandom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Quantum Random Number Generator Demo";
            this.grpRandom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtNum)).EndInit();
            this.grpConnect.ResumeLayout(false);
            this.grpConnect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRandom;
        private System.Windows.Forms.Button btnTesting;
        private System.Windows.Forms.Button btnInt;
        private System.Windows.Forms.NumericUpDown edtNum;
        private System.Windows.Forms.ListBox Memo;
        private System.Windows.Forms.GroupBox grpConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtPass;
        private System.Windows.Forms.TextBox edtUser;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnFloat;
    }
}

