namespace DataEntryFirstStep
{
    partial class SelectProperty
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnHen = new System.Windows.Forms.RadioButton();
            this.rbtnShu = new System.Windows.Forms.RadioButton();
            this.rbtnPie = new System.Windows.Forms.RadioButton();
            this.rbtnNa = new System.Windows.Forms.RadioButton();
            this.txtText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rbtnReset = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbtnHen
            // 
            this.rbtnHen.AutoSize = true;
            this.rbtnHen.Location = new System.Drawing.Point(87, 68);
            this.rbtnHen.Name = "rbtnHen";
            this.rbtnHen.Size = new System.Drawing.Size(51, 22);
            this.rbtnHen.TabIndex = 0;
            this.rbtnHen.TabStop = true;
            this.rbtnHen.Text = "横";
            this.rbtnHen.UseVisualStyleBackColor = true;
            // 
            // rbtnShu
            // 
            this.rbtnShu.AutoSize = true;
            this.rbtnShu.Location = new System.Drawing.Point(87, 114);
            this.rbtnShu.Name = "rbtnShu";
            this.rbtnShu.Size = new System.Drawing.Size(51, 22);
            this.rbtnShu.TabIndex = 1;
            this.rbtnShu.TabStop = true;
            this.rbtnShu.Text = "竖";
            this.rbtnShu.UseVisualStyleBackColor = true;
            // 
            // rbtnPie
            // 
            this.rbtnPie.AutoSize = true;
            this.rbtnPie.Location = new System.Drawing.Point(87, 153);
            this.rbtnPie.Name = "rbtnPie";
            this.rbtnPie.Size = new System.Drawing.Size(51, 22);
            this.rbtnPie.TabIndex = 2;
            this.rbtnPie.TabStop = true;
            this.rbtnPie.Text = "撇";
            this.rbtnPie.UseVisualStyleBackColor = true;
            // 
            // rbtnNa
            // 
            this.rbtnNa.AutoSize = true;
            this.rbtnNa.Location = new System.Drawing.Point(87, 195);
            this.rbtnNa.Name = "rbtnNa";
            this.rbtnNa.Size = new System.Drawing.Size(51, 22);
            this.rbtnNa.TabIndex = 3;
            this.rbtnNa.TabStop = true;
            this.rbtnNa.Text = "捺";
            this.rbtnNa.UseVisualStyleBackColor = true;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(87, 272);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(141, 28);
            this.txtText.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 323);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rbtnReset
            // 
            this.rbtnReset.AutoSize = true;
            this.rbtnReset.Location = new System.Drawing.Point(87, 236);
            this.rbtnReset.Name = "rbtnReset";
            this.rbtnReset.Size = new System.Drawing.Size(69, 22);
            this.rbtnReset.TabIndex = 7;
            this.rbtnReset.TabStop = true;
            this.rbtnReset.Text = "重画";
            this.rbtnReset.UseVisualStyleBackColor = true;
            // 
            // SelectProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 381);
            this.Controls.Add(this.rbtnReset);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.rbtnNa);
            this.Controls.Add(this.rbtnPie);
            this.Controls.Add(this.rbtnShu);
            this.Controls.Add(this.rbtnHen);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SelectProperty";
            this.Load += new System.EventHandler(this.SelectProperty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnHen;
        private System.Windows.Forms.RadioButton rbtnShu;
        private System.Windows.Forms.RadioButton rbtnPie;
        private System.Windows.Forms.RadioButton rbtnNa;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbtnReset;
    }
}
