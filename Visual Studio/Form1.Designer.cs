﻿namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonON = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.text_map = new System.Windows.Forms.TextBox();
            this.button_W = new System.Windows.Forms.Button();
            this.button_A = new System.Windows.Forms.Button();
            this.button_D = new System.Windows.Forms.Button();
            this.button_S = new System.Windows.Forms.Button();
            this.text_X_value = new System.Windows.Forms.TextBox();
            this.text_Y_value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_SAVE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonON
            // 
            this.buttonON.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonON.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonON.Location = new System.Drawing.Point(387, 439);
            this.buttonON.Margin = new System.Windows.Forms.Padding(5);
            this.buttonON.Name = "buttonON";
            this.buttonON.Size = new System.Drawing.Size(149, 106);
            this.buttonON.TabIndex = 1;
            this.buttonON.Text = "MAP";
            this.buttonON.UseVisualStyleBackColor = false;
            this.buttonON.Click += new System.EventHandler(this.buttonON_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelX.Location = new System.Drawing.Point(23, 20);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(21, 19);
            this.labelX.TabIndex = 3;
            this.labelX.Text = "X:";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelY.Location = new System.Drawing.Point(24, 53);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(20, 19);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "Y:";
            // 
            // text_map
            // 
            this.text_map.BackColor = System.Drawing.Color.White;
            this.text_map.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text_map.ForeColor = System.Drawing.Color.Black;
            this.text_map.Location = new System.Drawing.Point(68, 109);
            this.text_map.Multiline = true;
            this.text_map.Name = "text_map";
            this.text_map.ReadOnly = true;
            this.text_map.Size = new System.Drawing.Size(712, 304);
            this.text_map.TabIndex = 6;
            // 
            // button_W
            // 
            this.button_W.BackColor = System.Drawing.Color.Black;
            this.button_W.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_W.ForeColor = System.Drawing.Color.White;
            this.button_W.Location = new System.Drawing.Point(611, 439);
            this.button_W.Name = "button_W";
            this.button_W.Size = new System.Drawing.Size(40, 40);
            this.button_W.TabIndex = 7;
            this.button_W.Text = "W";
            this.button_W.UseVisualStyleBackColor = false;
            this.button_W.Click += new System.EventHandler(this.button_W_Click);
            // 
            // button_A
            // 
            this.button_A.BackColor = System.Drawing.Color.Black;
            this.button_A.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_A.ForeColor = System.Drawing.Color.White;
            this.button_A.Location = new System.Drawing.Point(567, 474);
            this.button_A.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.button_A.Name = "button_A";
            this.button_A.Size = new System.Drawing.Size(40, 40);
            this.button_A.TabIndex = 8;
            this.button_A.Text = "A";
            this.button_A.UseVisualStyleBackColor = false;
            this.button_A.Click += new System.EventHandler(this.button_A_Click);
            // 
            // button_D
            // 
            this.button_D.BackColor = System.Drawing.Color.Black;
            this.button_D.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_D.ForeColor = System.Drawing.Color.White;
            this.button_D.Location = new System.Drawing.Point(655, 474);
            this.button_D.Margin = new System.Windows.Forms.Padding(1);
            this.button_D.Name = "button_D";
            this.button_D.Size = new System.Drawing.Size(40, 40);
            this.button_D.TabIndex = 9;
            this.button_D.Text = "D";
            this.button_D.UseVisualStyleBackColor = false;
            this.button_D.Click += new System.EventHandler(this.button_D_Click);
            // 
            // button_S
            // 
            this.button_S.BackColor = System.Drawing.Color.Black;
            this.button_S.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_S.ForeColor = System.Drawing.Color.White;
            this.button_S.Location = new System.Drawing.Point(611, 507);
            this.button_S.Name = "button_S";
            this.button_S.Size = new System.Drawing.Size(40, 40);
            this.button_S.TabIndex = 10;
            this.button_S.Text = "S";
            this.button_S.UseVisualStyleBackColor = false;
            this.button_S.Click += new System.EventHandler(this.button_S_Click);
            // 
            // text_X_value
            // 
            this.text_X_value.BackColor = System.Drawing.Color.White;
            this.text_X_value.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text_X_value.Location = new System.Drawing.Point(50, 17);
            this.text_X_value.Name = "text_X_value";
            this.text_X_value.ReadOnly = true;
            this.text_X_value.Size = new System.Drawing.Size(57, 27);
            this.text_X_value.TabIndex = 11;
            // 
            // text_Y_value
            // 
            this.text_Y_value.BackColor = System.Drawing.Color.White;
            this.text_Y_value.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text_Y_value.Location = new System.Drawing.Point(50, 50);
            this.text_Y_value.Name = "text_Y_value";
            this.text_Y_value.ReadOnly = true;
            this.text_Y_value.Size = new System.Drawing.Size(57, 27);
            this.text_Y_value.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Y: 200 cm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "X: 0 cm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(738, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "200 cm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "20 cm";
            // 
            // button_SAVE
            // 
            this.button_SAVE.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button_SAVE.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SAVE.Location = new System.Drawing.Point(144, 441);
            this.button_SAVE.Name = "button_SAVE";
            this.button_SAVE.Size = new System.Drawing.Size(149, 106);
            this.button_SAVE.TabIndex = 17;
            this.button_SAVE.Text = "SAVE";
            this.button_SAVE.UseVisualStyleBackColor = false;
            this.button_SAVE.Click += new System.EventHandler(this.button_SAVE_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 575);
            this.Controls.Add(this.button_SAVE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_Y_value);
            this.Controls.Add(this.text_X_value);
            this.Controls.Add(this.button_S);
            this.Controls.Add(this.button_D);
            this.Controls.Add(this.button_A);
            this.Controls.Add(this.button_W);
            this.Controls.Add(this.text_map);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.buttonON);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonON;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox text_map;
        private System.Windows.Forms.Button button_W;
        private System.Windows.Forms.Button button_A;
        private System.Windows.Forms.Button button_D;
        private System.Windows.Forms.Button button_S;
        private System.Windows.Forms.TextBox text_X_value;
        private System.Windows.Forms.TextBox text_Y_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_SAVE;
    }
}

