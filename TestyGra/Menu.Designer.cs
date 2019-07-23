namespace TestyGra
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
            this.PrzyciskStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrzyciskStart
            // 
            this.PrzyciskStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrzyciskStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrzyciskStart.Location = new System.Drawing.Point(0, 0);
            this.PrzyciskStart.Name = "PrzyciskStart";
            this.PrzyciskStart.Size = new System.Drawing.Size(800, 450);
            this.PrzyciskStart.TabIndex = 0;
            this.PrzyciskStart.Text = "START";
            this.PrzyciskStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PrzyciskStart.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrzyciskStart);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PrzyciskStart;
    }
}