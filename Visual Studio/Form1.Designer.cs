namespace WindowsFormsApplication2
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
            this.top1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bottom1 = new System.Windows.Forms.TextBox();
            this.right1 = new System.Windows.Forms.TextBox();
            this.left1 = new System.Windows.Forms.TextBox();
            this.right2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // top1
            // 
            this.top1.AccessibleName = "";
            this.top1.BackColor = System.Drawing.SystemColors.InfoText;
            this.top1.Location = new System.Drawing.Point(161, 185);
            this.top1.Name = "top1";
            this.top1.Size = new System.Drawing.Size(100, 20);
            this.top1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bottom1
            // 
            this.bottom1.AccessibleName = "";
            this.bottom1.BackColor = System.Drawing.SystemColors.InfoText;
            this.bottom1.Location = new System.Drawing.Point(161, 317);
            this.bottom1.Name = "bottom1";
            this.bottom1.Size = new System.Drawing.Size(100, 20);
            this.bottom1.TabIndex = 2;
            // 
            // right1
            // 
            this.right1.AccessibleName = "";
            this.right1.BackColor = System.Drawing.SystemColors.InfoText;
            this.right1.Location = new System.Drawing.Point(267, 211);
            this.right1.Multiline = true;
            this.right1.Name = "right1";
            this.right1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.right1.Size = new System.Drawing.Size(20, 100);
            this.right1.TabIndex = 3;
            // 
            // left1
            // 
            this.left1.AccessibleName = "";
            this.left1.BackColor = System.Drawing.SystemColors.InfoText;
            this.left1.Location = new System.Drawing.Point(135, 211);
            this.left1.Multiline = true;
            this.left1.Name = "left1";
            this.left1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.left1.Size = new System.Drawing.Size(20, 100);
            this.left1.TabIndex = 4;
            // 
            // right2
            // 
            this.right2.AccessibleName = "";
            this.right2.BackColor = System.Drawing.SystemColors.InfoText;
            this.right2.Location = new System.Drawing.Point(293, 211);
            this.right2.Multiline = true;
            this.right2.Name = "right2";
            this.right2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.right2.Size = new System.Drawing.Size(20, 100);
            this.right2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 555);
            this.Controls.Add(this.right2);
            this.Controls.Add(this.left1);
            this.Controls.Add(this.right1);
            this.Controls.Add(this.bottom1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.top1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox top1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox bottom1;
        private System.Windows.Forms.TextBox right1;
        private System.Windows.Forms.TextBox left1;
        private System.Windows.Forms.TextBox right2;
    }
}

