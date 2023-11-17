namespace StudentHousing
{
    partial class Menu
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tbContractType = new TextBox();
            tbHouseType = new TextBox();
            btnPhoto = new Button();
            cbFurnished = new ComboBox();
            btnEditHouse = new Button();
            houseImage = new PictureBox();
            tbDeposit = new TextBox();
            tbRent = new TextBox();
            tbSpace = new TextBox();
            tbCity = new TextBox();
            tbAddress = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lbHouse = new ListBox();
            btnAddHouse = new Button();
            tbHouseNumber = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)houseImage).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbContractType);
            tabPage1.Controls.Add(tbHouseType);
            tabPage1.Controls.Add(btnPhoto);
            tabPage1.Controls.Add(cbFurnished);
            tabPage1.Controls.Add(btnEditHouse);
            tabPage1.Controls.Add(houseImage);
            tabPage1.Controls.Add(tbDeposit);
            tabPage1.Controls.Add(tbRent);
            tabPage1.Controls.Add(tbSpace);
            tabPage1.Controls.Add(tbCity);
            tabPage1.Controls.Add(tbAddress);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(lbHouse);
            tabPage1.Controls.Add(btnAddHouse);
            tabPage1.Controls.Add(tbHouseNumber);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "House Manager";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // tbContractType
            // 
            tbContractType.Location = new Point(145, 194);
            tbContractType.Name = "tbContractType";
            tbContractType.Size = new Size(121, 23);
            tbContractType.TabIndex = 29;
            // 
            // tbHouseType
            // 
            tbHouseType.Location = new Point(145, 107);
            tbHouseType.Name = "tbHouseType";
            tbHouseType.Size = new Size(121, 23);
            tbHouseType.TabIndex = 28;
            // 
            // btnPhoto
            // 
            btnPhoto.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnPhoto.Location = new Point(23, 316);
            btnPhoto.Name = "btnPhoto";
            btnPhoto.Size = new Size(93, 42);
            btnPhoto.TabIndex = 27;
            btnPhoto.Text = "Add Photo";
            btnPhoto.UseVisualStyleBackColor = true;
            btnPhoto.Click += btnPhoto_Click;
            // 
            // cbFurnished
            // 
            cbFurnished.FormattingEnabled = true;
            cbFurnished.Items.AddRange(new object[] { "Choose from this list", "Unfurnished", "Furnished" });
            cbFurnished.Location = new Point(145, 165);
            cbFurnished.Name = "cbFurnished";
            cbFurnished.Size = new Size(121, 23);
            cbFurnished.TabIndex = 26;
            // 
            // btnEditHouse
            // 
            btnEditHouse.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditHouse.Location = new Point(634, 316);
            btnEditHouse.Name = "btnEditHouse";
            btnEditHouse.Size = new Size(128, 42);
            btnEditHouse.TabIndex = 25;
            btnEditHouse.Text = "Edit House";
            btnEditHouse.UseVisualStyleBackColor = true;
            btnEditHouse.Click += btnEditHouse_Click;
            // 
            // houseImage
            // 
            houseImage.Location = new Point(145, 282);
            houseImage.Name = "houseImage";
            houseImage.Size = new Size(170, 110);
            houseImage.TabIndex = 24;
            houseImage.TabStop = false;
            // 
            // tbDeposit
            // 
            tbDeposit.Location = new Point(145, 252);
            tbDeposit.Name = "tbDeposit";
            tbDeposit.Size = new Size(121, 23);
            tbDeposit.TabIndex = 20;
            // 
            // tbRent
            // 
            tbRent.Location = new Point(145, 223);
            tbRent.Name = "tbRent";
            tbRent.Size = new Size(121, 23);
            tbRent.TabIndex = 19;
            // 
            // tbSpace
            // 
            tbSpace.Location = new Point(145, 136);
            tbSpace.Name = "tbSpace";
            tbSpace.Size = new Size(121, 23);
            tbSpace.TabIndex = 16;
            // 
            // tbCity
            // 
            tbCity.Location = new Point(145, 78);
            tbCity.Name = "tbCity";
            tbCity.Size = new Size(121, 23);
            tbCity.TabIndex = 14;
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(145, 49);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(121, 23);
            tbAddress.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(23, 255);
            label9.Name = "label9";
            label9.Size = new Size(68, 20);
            label9.TabIndex = 11;
            label9.Text = "Deposit :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(23, 226);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 10;
            label8.Text = "Rent :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(23, 197);
            label7.Name = "label7";
            label7.Size = new Size(107, 20);
            label7.TabIndex = 9;
            label7.Text = "Contract Type :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(23, 168);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 8;
            label6.Text = "Furnished :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(23, 139);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 7;
            label5.Text = "Space :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(23, 110);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 6;
            label4.Text = "House Type :";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(23, 81);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 5;
            label3.Text = "City :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(23, 52);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 4;
            label2.Text = "Address :";
            // 
            // lbHouse
            // 
            lbHouse.FormattingEnabled = true;
            lbHouse.ItemHeight = 15;
            lbHouse.Location = new Point(457, 20);
            lbHouse.Name = "lbHouse";
            lbHouse.Size = new Size(305, 259);
            lbHouse.TabIndex = 3;
            lbHouse.SelectedIndexChanged += lbHouse_SelectedIndexChanged;
            // 
            // btnAddHouse
            // 
            btnAddHouse.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddHouse.Location = new Point(457, 316);
            btnAddHouse.Name = "btnAddHouse";
            btnAddHouse.Size = new Size(128, 42);
            btnAddHouse.TabIndex = 2;
            btnAddHouse.Text = "Add House";
            btnAddHouse.UseVisualStyleBackColor = true;
            btnAddHouse.Click += button1_Click;
            // 
            // tbHouseNumber
            // 
            tbHouseNumber.Location = new Point(145, 20);
            tbHouseNumber.Name = "tbHouseNumber";
            tbHouseNumber.Size = new Size(121, 23);
            tbHouseNumber.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "House Number :";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Applications Manager";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Menu";
            Text = "Menu";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)houseImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox lbHouse;
        private Button btnAddHouse;
        private TextBox tbHouseNumber;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox tbDeposit;
        private TextBox tbRent;
        private TextBox tbSpace;
        private TextBox tbCity;
        private TextBox tbAddress;
        private Button btnEditHouse;
        private PictureBox houseImage;
        private ComboBox cbFurnished;
        private Button btnPhoto;
        private TextBox tbContractType;
        private TextBox tbHouseType;
    }
}