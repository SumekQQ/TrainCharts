
namespace TrainChart
{
    partial class Form2
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
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.buttonTrainForce = new System.Windows.Forms.Button();
            this.buttonSpeeds = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxSa133 = new System.Windows.Forms.CheckBox();
            this.checkBoxEn57 = new System.Windows.Forms.CheckBox();
            this.checkBoxLine1 = new System.Windows.Forms.CheckBox();
            this.checkBoxLine2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Location = new System.Drawing.Point(4, 184);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(68, 23);
            this.buttonSchedule.TabIndex = 1;
            this.buttonSchedule.Text = "Rozkład";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // buttonTrainForce
            // 
            this.buttonTrainForce.Location = new System.Drawing.Point(4, 82);
            this.buttonTrainForce.Name = "buttonTrainForce";
            this.buttonTrainForce.Size = new System.Drawing.Size(176, 23);
            this.buttonTrainForce.TabIndex = 4;
            this.buttonTrainForce.Text = "Wykres sił";
            this.buttonTrainForce.UseVisualStyleBackColor = true;
            this.buttonTrainForce.Click += new System.EventHandler(this.buttonTrainForce_Click);
            // 
            // buttonSpeeds
            // 
            this.buttonSpeeds.Location = new System.Drawing.Point(101, 184);
            this.buttonSpeeds.Name = "buttonSpeeds";
            this.buttonSpeeds.Size = new System.Drawing.Size(79, 23);
            this.buttonSpeeds.TabIndex = 5;
            this.buttonSpeeds.Text = "Prędkości";
            this.buttonSpeeds.UseVisualStyleBackColor = true;
            this.buttonSpeeds.Click += new System.EventHandler(this.buttonSpeeds_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxSa133);
            this.groupBox2.Controls.Add(this.checkBoxEn57);
            this.groupBox2.Location = new System.Drawing.Point(4, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 67);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pociąg";
            // 
            // checkBoxSa133
            // 
            this.checkBoxSa133.AutoSize = true;
            this.checkBoxSa133.Location = new System.Drawing.Point(7, 42);
            this.checkBoxSa133.Name = "checkBoxSa133";
            this.checkBoxSa133.Size = new System.Drawing.Size(58, 17);
            this.checkBoxSa133.TabIndex = 4;
            this.checkBoxSa133.Text = "SA133";
            this.checkBoxSa133.UseVisualStyleBackColor = true;
            this.checkBoxSa133.Click += new System.EventHandler(this.checkBoxSa133_Click);
            // 
            // checkBoxEn57
            // 
            this.checkBoxEn57.AutoSize = true;
            this.checkBoxEn57.Location = new System.Drawing.Point(7, 19);
            this.checkBoxEn57.Name = "checkBoxEn57";
            this.checkBoxEn57.Size = new System.Drawing.Size(53, 17);
            this.checkBoxEn57.TabIndex = 3;
            this.checkBoxEn57.Text = "EN57";
            this.checkBoxEn57.UseVisualStyleBackColor = true;
            this.checkBoxEn57.Click += new System.EventHandler(this.checkBoxEn57_Click);
            // 
            // checkBoxLine1
            // 
            this.checkBoxLine1.AutoSize = true;
            this.checkBoxLine1.Location = new System.Drawing.Point(7, 19);
            this.checkBoxLine1.Name = "checkBoxLine1";
            this.checkBoxLine1.Size = new System.Drawing.Size(65, 17);
            this.checkBoxLine1.TabIndex = 3;
            this.checkBoxLine1.Text = "Parzysty";
            this.checkBoxLine1.UseVisualStyleBackColor = true;
            this.checkBoxLine1.Click += new System.EventHandler(this.checkBoxLine1_Click);
            // 
            // checkBoxLine2
            // 
            this.checkBoxLine2.AutoSize = true;
            this.checkBoxLine2.Location = new System.Drawing.Point(7, 42);
            this.checkBoxLine2.Name = "checkBoxLine2";
            this.checkBoxLine2.Size = new System.Drawing.Size(83, 17);
            this.checkBoxLine2.TabIndex = 4;
            this.checkBoxLine2.Text = "Nie parzysty";
            this.checkBoxLine2.UseVisualStyleBackColor = true;
            this.checkBoxLine2.Click += new System.EventHandler(this.checkBoxLine2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxLine2);
            this.groupBox1.Controls.Add(this.checkBoxLine1);
            this.groupBox1.Location = new System.Drawing.Point(4, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linia";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 213);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonSpeeds);
            this.Controls.Add(this.buttonTrainForce);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSchedule);
            this.MaximumSize = new System.Drawing.Size(208, 252);
            this.MinimumSize = new System.Drawing.Size(208, 252);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSchedule;
        private System.Windows.Forms.Button buttonTrainForce;
        private System.Windows.Forms.Button buttonSpeeds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxSa133;
        private System.Windows.Forms.CheckBox checkBoxEn57;
        private System.Windows.Forms.CheckBox checkBoxLine1;
        private System.Windows.Forms.CheckBox checkBoxLine2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}