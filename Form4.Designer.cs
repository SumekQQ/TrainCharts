
namespace TrainChart
{
    partial class Form4
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
            this.button1 = new System.Windows.Forms.Button();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cartesianChart2.Location = new System.Drawing.Point(36, 12);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(4000, 2000);
            this.cartesianChart2.TabIndex = 2;
            this.cartesianChart2.Text = "cartesianChart1";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1604, 875);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.button1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button button1;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
    }
}