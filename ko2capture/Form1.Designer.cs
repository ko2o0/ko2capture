namespace ko2capture
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.selectFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boundaryColor = new System.Windows.Forms.Panel();
            this.ChooseBoundaryColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectFolder
            // 
            this.selectFolder.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selectFolder.Location = new System.Drawing.Point(323, 21);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(64, 28);
            this.selectFolder.TabIndex = 0;
            this.selectFolder.Text = "閲覧";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "保存先フォルダ";
            // 
            // folderPath
            // 
            this.folderPath.Location = new System.Drawing.Point(12, 27);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(305, 19);
            this.folderPath.TabIndex = 2;
            // 
            // captureButton
            // 
            this.captureButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.captureButton.Location = new System.Drawing.Point(295, 62);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(92, 55);
            this.captureButton.TabIndex = 4;
            this.captureButton.Text = "キャプチャ開始";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "01. 境界色を使う",
            "02. 類似パータンを境界とする",
            "03. 境界を指定する"});
            this.comboBox1.Location = new System.Drawing.Point(73, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 23);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "検出方法";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "境界色";
            // 
            // boundaryColor
            // 
            this.boundaryColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.boundaryColor.Location = new System.Drawing.Point(74, 62);
            this.boundaryColor.Name = "boundaryColor";
            this.boundaryColor.Size = new System.Drawing.Size(66, 23);
            this.boundaryColor.TabIndex = 8;
            // 
            // ChooseBoundaryColor
            // 
            this.ChooseBoundaryColor.Location = new System.Drawing.Point(164, 62);
            this.ChooseBoundaryColor.Name = "ChooseBoundaryColor";
            this.ChooseBoundaryColor.Size = new System.Drawing.Size(89, 24);
            this.ChooseBoundaryColor.TabIndex = 9;
            this.ChooseBoundaryColor.Text = "境界色を選択";
            this.ChooseBoundaryColor.UseVisualStyleBackColor = true;
            this.ChooseBoundaryColor.Click += new System.EventHandler(this.ChooseBoundaryColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 136);
            this.Controls.Add(this.ChooseBoundaryColor);
            this.Controls.Add(this.boundaryColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFolder);
            this.Name = "Form1";
            this.Text = "ko2capture, v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folderPath;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel boundaryColor;
        private System.Windows.Forms.Button ChooseBoundaryColor;
    }
}

