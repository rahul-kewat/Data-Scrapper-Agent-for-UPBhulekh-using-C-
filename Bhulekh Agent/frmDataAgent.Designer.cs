namespace Bhulekh_Agent
{
    partial class frmDataAgent
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
            this.dataFetchedView = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSelectDistrict = new System.Windows.Forms.ComboBox();
            this.lblselectDistrict = new System.Windows.Forms.Label();
            this.cmbSelectTehsil = new System.Windows.Forms.ComboBox();
            this.lblselectTehsil = new System.Windows.Forms.Label();
            this.cmbSelectGram = new System.Windows.Forms.ComboBox();
            this.lblselectGramNameorCode = new System.Windows.Forms.Label();
            this.hiddenDetails = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDataFetched = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataFetchedView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataFetchedView
            // 
            this.dataFetchedView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataFetchedView.BackgroundColor = System.Drawing.Color.White;
            this.dataFetchedView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataFetchedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFetchedView.Location = new System.Drawing.Point(0, 219);
            this.dataFetchedView.Name = "dataFetchedView";
            this.dataFetchedView.Size = new System.Drawing.Size(1363, 430);
            this.dataFetchedView.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1255, 147);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 22);
            this.button3.TabIndex = 31;
            this.button3.Text = "Run Data Loader";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1368, 25);
            this.panel1.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(659, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Ansh Data Agent";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1323, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // cmbSelectDistrict
            // 
            this.cmbSelectDistrict.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSelectDistrict.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSelectDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbSelectDistrict.FormattingEnabled = true;
            this.cmbSelectDistrict.Location = new System.Drawing.Point(164, 36);
            this.cmbSelectDistrict.Name = "cmbSelectDistrict";
            this.cmbSelectDistrict.Size = new System.Drawing.Size(297, 28);
            this.cmbSelectDistrict.TabIndex = 33;
            this.cmbSelectDistrict.SelectedIndexChanged += new System.EventHandler(this.cmbSelectDistrict_SelectedIndexChanged);
            // 
            // lblselectDistrict
            // 
            this.lblselectDistrict.AutoSize = true;
            this.lblselectDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblselectDistrict.Location = new System.Drawing.Point(56, 39);
            this.lblselectDistrict.Name = "lblselectDistrict";
            this.lblselectDistrict.Size = new System.Drawing.Size(102, 17);
            this.lblselectDistrict.TabIndex = 34;
            this.lblselectDistrict.Text = "Select District :";
            // 
            // cmbSelectTehsil
            // 
            this.cmbSelectTehsil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSelectTehsil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSelectTehsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbSelectTehsil.FormattingEnabled = true;
            this.cmbSelectTehsil.Location = new System.Drawing.Point(164, 72);
            this.cmbSelectTehsil.Name = "cmbSelectTehsil";
            this.cmbSelectTehsil.Size = new System.Drawing.Size(297, 28);
            this.cmbSelectTehsil.TabIndex = 33;
            this.cmbSelectTehsil.SelectedIndexChanged += new System.EventHandler(this.cmbSelectTehsil_SelectedIndexChanged);
            // 
            // lblselectTehsil
            // 
            this.lblselectTehsil.AutoSize = true;
            this.lblselectTehsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblselectTehsil.Location = new System.Drawing.Point(61, 78);
            this.lblselectTehsil.Name = "lblselectTehsil";
            this.lblselectTehsil.Size = new System.Drawing.Size(97, 17);
            this.lblselectTehsil.TabIndex = 34;
            this.lblselectTehsil.Text = "Select Tehsil :";
            // 
            // cmbSelectGram
            // 
            this.cmbSelectGram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSelectGram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cmbSelectGram.FormattingEnabled = true;
            this.cmbSelectGram.Location = new System.Drawing.Point(164, 109);
            this.cmbSelectGram.Name = "cmbSelectGram";
            this.cmbSelectGram.Size = new System.Drawing.Size(297, 28);
            this.cmbSelectGram.TabIndex = 33;
            this.cmbSelectGram.SelectedIndexChanged += new System.EventHandler(this.cmbSelectGram_SelectedIndexChanged);
            // 
            // lblselectGramNameorCode
            // 
            this.lblselectGramNameorCode.AutoSize = true;
            this.lblselectGramNameorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblselectGramNameorCode.Location = new System.Drawing.Point(12, 100);
            this.lblselectGramNameorCode.Name = "lblselectGramNameorCode";
            this.lblselectGramNameorCode.Size = new System.Drawing.Size(146, 34);
            this.lblselectGramNameorCode.TabIndex = 34;
            this.lblselectGramNameorCode.Text = "Select Gram \r\nName or Gram Code :";
            // 
            // hiddenDetails
            // 
            this.hiddenDetails.FormattingEnabled = true;
            this.hiddenDetails.Location = new System.Drawing.Point(661, 36);
            this.hiddenDetails.Name = "hiddenDetails";
            this.hiddenDetails.Size = new System.Drawing.Size(529, 95);
            this.hiddenDetails.TabIndex = 35;
            this.hiddenDetails.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1239, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Total Data Fetched :";
            // 
            // lblDataFetched
            // 
            this.lblDataFetched.AutoSize = true;
            this.lblDataFetched.Location = new System.Drawing.Point(1341, 177);
            this.lblDataFetched.Name = "lblDataFetched";
            this.lblDataFetched.Size = new System.Drawing.Size(13, 13);
            this.lblDataFetched.TabIndex = 36;
            this.lblDataFetched.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1066, 193);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 20);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 37;
            this.progressBar1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "श्रेणी : 1 / ऐसी भूमि, जिसमें सरकार अथवा गाँवसभा या अन्य स्थानीय अधिकारिकी जिसे19" +
                "50 ई. के उ. प्र. ज. वि.एवं भू. व्य. अधि.की धारा 117 - क के अधीन भूमि का प्रबन्ध " +
                "सौंपा गया हो , खेती करता हो ।",
            "श्रेणी : 1-क / भूमि जो संक्रमणीय भूमिधरों केअधिकार में हो।",
            "श्रेणी : 2 / भूमि जो असंक्रमणीय भूमिधरो केअधिकार में हो।",
            "श्रेणी : 4 / भूमि जो उस दशा में बिना आगम केअध्यासीनों के अधिकार  में हो जब खसरेके" +
                " स्तम्भ 4 में पहले से ही किसी व्यक्तिका नाम अभिलिखित न  हो।",
            "श्रेणी : 4-क / उ.प्र. अधिकतम जोत सीमा आरोपण.अधि.अन्तर्गत अर्जित की गई अतिरिक्त भू" +
                "मि -(क)जो उ.प्र.जोत सी.आ.अ.के उपबन्धो केअधीन किसी अन्तरिम अवधि के लिये किसी पट्ट" +
                "ेदार द्वारा रखी गयी हो ।",
            "श्रेणी : 5-1 / कृषि योग्य भूमि - नई परती (परतीजदीद)",
            "श्रेणी : 5-2 / कृषि योग्य भूमि - पुरानी परती (परतीकदीम)",
            "श्रेणी : 5-3-क / कृषि योग्य बंजर - इमारती लकड़ी केवन।",
            "श्रेणी : 5-3-ख / कृषि योग्य बंजर - ऐसे वन जिसमें अन्यप्रकर के वृक्ष,झाडि़यों के झ" +
                "ुन्ड,झाडि़याँ इत्यादि हों।",
            "श्रेणी : 5-3-ग / कृषि योग्य बंजर -  स्थाई पशुचर भूमि तथा अन्य चराई की भूमियाँ ।",
            "श्रेणी : 5-3-ङ / अन्य कृषि योग्य बंजर भूमि।",
            "श्रेणी : 6-1 / अकृषिक भूमि - जलमग्न भूमि ।",
            "श्रेणी : 6-2 / अकृषिक भूमि - स्थल, सड़कें, रेलवे,भवन और ऐसी दूसरी भूमियां जोअकृषि" +
                "त उपयोगों के काम में लायी जाती हो।",
            "श्रेणी : 6-3 / कब्रिस्तान और श्मशान (मरघट) , ऐसेकब्रस्तानों और श्मशानों को छोड़ क" +
                "रजो खातेदारों की भूमि या आबादी क्षेत्र में स्थित हो।",
            "श्रेणी : 6-4 / जो अन्य कारणों से अकृषित हो ।"});
            this.comboBox2.Location = new System.Drawing.Point(164, 143);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(1085, 27);
            this.comboBox2.TabIndex = 39;
            this.comboBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(42, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Select Category :";
            this.label2.Visible = false;
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.Color.Aqua;
            this.btnSaveData.FlatAppearance.BorderSize = 0;
            this.btnSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnSaveData.Location = new System.Drawing.Point(1255, 105);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(99, 36);
            this.btnSaveData.TabIndex = 40;
            this.btnSaveData.Text = "Save Data";
            this.btnSaveData.UseVisualStyleBackColor = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // frmDataAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 668);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblDataFetched);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hiddenDetails);
            this.Controls.Add(this.lblselectGramNameorCode);
            this.Controls.Add(this.cmbSelectGram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblselectTehsil);
            this.Controls.Add(this.cmbSelectTehsil);
            this.Controls.Add(this.lblselectDistrict);
            this.Controls.Add(this.cmbSelectDistrict);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataFetchedView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDataAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataAgent";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataFetchedView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataFetchedView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbSelectDistrict;
        private System.Windows.Forms.Label lblselectDistrict;
        private System.Windows.Forms.ComboBox cmbSelectTehsil;
        private System.Windows.Forms.Label lblselectTehsil;
        private System.Windows.Forms.ComboBox cmbSelectGram;
        private System.Windows.Forms.Label lblselectGramNameorCode;
        private System.Windows.Forms.ListBox hiddenDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDataFetched;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveData;
    }
}

