namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connectButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.publicButton = new System.Windows.Forms.Button();
            this.privateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.createGroup = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addPeople = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.create = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.toGroup = new System.Windows.Forms.Button();
            this.sendFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.PowderBlue;
            this.connectButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.connectButton.Location = new System.Drawing.Point(620, 67);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(154, 169);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "CONNECT";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox3.Location = new System.Drawing.Point(63, 378);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(532, 27);
            this.textBox3.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendButton.Location = new System.Drawing.Point(620, 365);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(155, 40);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(63, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(532, 304);
            this.listBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status: Not connected";
            // 
            // publicButton
            // 
            this.publicButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.publicButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.publicButton.Location = new System.Drawing.Point(620, 253);
            this.publicButton.Name = "publicButton";
            this.publicButton.Size = new System.Drawing.Size(76, 53);
            this.publicButton.TabIndex = 7;
            this.publicButton.Text = "Public";
            this.publicButton.UseVisualStyleBackColor = false;
            this.publicButton.Click += new System.EventHandler(this.publicButton_Click);
            // 
            // privateButton
            // 
            this.privateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.privateButton.Location = new System.Drawing.Point(703, 253);
            this.privateButton.Name = "privateButton";
            this.privateButton.Size = new System.Drawing.Size(72, 54);
            this.privateButton.TabIndex = 8;
            this.privateButton.Text = "Private";
            this.privateButton.UseVisualStyleBackColor = false;
            this.privateButton.Click += new System.EventHandler(this.privateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enter your name here:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(597, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 27);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(620, 321);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 27);
            this.textBox2.TabIndex = 11;
            // 
            // createGroup
            // 
            this.createGroup.Location = new System.Drawing.Point(63, 411);
            this.createGroup.Name = "createGroup";
            this.createGroup.Size = new System.Drawing.Size(112, 29);
            this.createGroup.TabIndex = 12;
            this.createGroup.Text = "Create Group";
            this.createGroup.UseVisualStyleBackColor = true;
            this.createGroup.Click += new System.EventHandler(this.createGroup_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(291, 413);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(137, 27);
            this.textBox4.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Group name:";
            // 
            // addPeople
            // 
            this.addPeople.Location = new System.Drawing.Point(63, 446);
            this.addPeople.Name = "addPeople";
            this.addPeople.Size = new System.Drawing.Size(112, 29);
            this.addPeople.TabIndex = 15;
            this.addPeople.Text = "Add People";
            this.addPeople.UseVisualStyleBackColor = true;
            this.addPeople.Click += new System.EventHandler(this.addPeople_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(291, 446);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(137, 27);
            this.textBox5.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "People\'s name";
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(451, 411);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(94, 29);
            this.create.TabIndex = 18;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(451, 446);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(94, 28);
            this.add.TabIndex = 19;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // toGroup
            // 
            this.toGroup.Location = new System.Drawing.Point(621, 413);
            this.toGroup.Name = "toGroup";
            this.toGroup.Size = new System.Drawing.Size(154, 35);
            this.toGroup.TabIndex = 20;
            this.toGroup.Text = "Send to Group";
            this.toGroup.UseVisualStyleBackColor = true;
            this.toGroup.Click += new System.EventHandler(this.toGroup_Click);
            // 
            // sendFile
            // 
            this.sendFile.Location = new System.Drawing.Point(621, 451);
            this.sendFile.Name = "sendFile";
            this.sendFile.Size = new System.Drawing.Size(151, 35);
            this.sendFile.TabIndex = 21;
            this.sendFile.Text = "Send File";
            this.sendFile.UseVisualStyleBackColor = true;
            this.sendFile.Click += new System.EventHandler(this.sendFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.sendFile);
            this.Controls.Add(this.toGroup);
            this.Controls.Add(this.add);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.addPeople);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.createGroup);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.privateButton);
            this.Controls.Add(this.publicButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.connectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button publicButton;
        private System.Windows.Forms.Button privateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button createGroup;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addPeople;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button toGroup;
        private System.Windows.Forms.Button sendFile;
    }
}

