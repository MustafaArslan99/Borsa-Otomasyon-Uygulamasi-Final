namespace Proje
{
    partial class AdminOnay
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_urunonayla = new System.Windows.Forms.Button();
            this.btn_paraonayla = new System.Windows.Forms.Button();
            this.btn_urunsil = new System.Windows.Forms.Button();
            this.btn_parasil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_urunno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_kullanicino = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(61, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(550, 184);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(696, 138);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(470, 184);
            this.dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(235, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Onay Bekleyen Ürünler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(787, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Onay Bekleyen Para Yüklemeleri";
            // 
            // btn_urunonayla
            // 
            this.btn_urunonayla.Location = new System.Drawing.Point(229, 391);
            this.btn_urunonayla.Name = "btn_urunonayla";
            this.btn_urunonayla.Size = new System.Drawing.Size(113, 40);
            this.btn_urunonayla.TabIndex = 4;
            this.btn_urunonayla.Text = "Onayla";
            this.btn_urunonayla.UseVisualStyleBackColor = true;
            this.btn_urunonayla.Click += new System.EventHandler(this.btn_urunonayla_Click);
            // 
            // btn_paraonayla
            // 
            this.btn_paraonayla.Location = new System.Drawing.Point(842, 391);
            this.btn_paraonayla.Name = "btn_paraonayla";
            this.btn_paraonayla.Size = new System.Drawing.Size(113, 40);
            this.btn_paraonayla.TabIndex = 5;
            this.btn_paraonayla.Text = "Onayla";
            this.btn_paraonayla.UseVisualStyleBackColor = true;
            this.btn_paraonayla.Click += new System.EventHandler(this.btn_paraonayla_Click);
            // 
            // btn_urunsil
            // 
            this.btn_urunsil.Location = new System.Drawing.Point(348, 391);
            this.btn_urunsil.Name = "btn_urunsil";
            this.btn_urunsil.Size = new System.Drawing.Size(113, 40);
            this.btn_urunsil.TabIndex = 6;
            this.btn_urunsil.Text = "Sil";
            this.btn_urunsil.UseVisualStyleBackColor = true;
            this.btn_urunsil.Click += new System.EventHandler(this.btn_urunsil_Click);
            // 
            // btn_parasil
            // 
            this.btn_parasil.Location = new System.Drawing.Point(961, 391);
            this.btn_parasil.Name = "btn_parasil";
            this.btn_parasil.Size = new System.Drawing.Size(113, 40);
            this.btn_parasil.TabIndex = 6;
            this.btn_parasil.Text = "Sil";
            this.btn_parasil.UseVisualStyleBackColor = true;
            this.btn_parasil.Click += new System.EventHandler(this.btn_parasil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ürün Numarası :";
            // 
            // txt_urunno
            // 
            this.txt_urunno.Location = new System.Drawing.Point(331, 346);
            this.txt_urunno.Name = "txt_urunno";
            this.txt_urunno.Size = new System.Drawing.Size(100, 20);
            this.txt_urunno.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(841, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kullanıcı Numarası :";
            // 
            // txt_kullanicino
            // 
            this.txt_kullanicino.Location = new System.Drawing.Point(946, 346);
            this.txt_kullanicino.Name = "txt_kullanicino";
            this.txt_kullanicino.Size = new System.Drawing.Size(100, 20);
            this.txt_kullanicino.TabIndex = 8;
            // 
            // AdminOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 661);
            this.Controls.Add(this.txt_kullanicino);
            this.Controls.Add(this.txt_urunno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_parasil);
            this.Controls.Add(this.btn_urunsil);
            this.Controls.Add(this.btn_paraonayla);
            this.Controls.Add(this.btn_urunonayla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminOnay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin ";
            this.Load += new System.EventHandler(this.AdminOnay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_urunonayla;
        private System.Windows.Forms.Button btn_paraonayla;
        private System.Windows.Forms.Button btn_urunsil;
        private System.Windows.Forms.Button btn_parasil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_urunno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_kullanicino;
    }
}