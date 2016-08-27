namespace ShotTest1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.PuckPos = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Slope = new System.Windows.Forms.Label();
            this.Shots = new System.Windows.Forms.Label();
            this.Shot2 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.TeamLT = new System.Windows.Forms.Label();
            this.PersonLT = new System.Windows.Forms.Label();
            this.RedS = new System.Windows.Forms.Label();
            this.BlueS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PuckPos
            // 
            this.PuckPos.AutoSize = true;
            this.PuckPos.Location = new System.Drawing.Point(12, 9);
            this.PuckPos.Name = "PuckPos";
            this.PuckPos.Size = new System.Drawing.Size(35, 13);
            this.PuckPos.TabIndex = 0;
            this.PuckPos.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Slope
            // 
            this.Slope.AutoSize = true;
            this.Slope.Location = new System.Drawing.Point(12, 53);
            this.Slope.Name = "Slope";
            this.Slope.Size = new System.Drawing.Size(35, 13);
            this.Slope.TabIndex = 2;
            this.Slope.Text = "label1";
            // 
            // Shots
            // 
            this.Shots.AutoSize = true;
            this.Shots.Location = new System.Drawing.Point(15, 110);
            this.Shots.Name = "Shots";
            this.Shots.Size = new System.Drawing.Size(35, 13);
            this.Shots.TabIndex = 3;
            this.Shots.Text = "label1";
            // 
            // Shot2
            // 
            this.Shot2.AutoSize = true;
            this.Shot2.Location = new System.Drawing.Point(15, 132);
            this.Shot2.Name = "Shot2";
            this.Shot2.Size = new System.Drawing.Size(35, 13);
            this.Shot2.TabIndex = 4;
            this.Shot2.Text = "label1";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(12, 31);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(35, 13);
            this.Time.TabIndex = 5;
            this.Time.Text = "label1";
            // 
            // TeamLT
            // 
            this.TeamLT.AutoSize = true;
            this.TeamLT.Location = new System.Drawing.Point(15, 168);
            this.TeamLT.Name = "TeamLT";
            this.TeamLT.Size = new System.Drawing.Size(35, 13);
            this.TeamLT.TabIndex = 6;
            this.TeamLT.Text = "label1";
            // 
            // PersonLT
            // 
            this.PersonLT.AutoSize = true;
            this.PersonLT.Location = new System.Drawing.Point(15, 185);
            this.PersonLT.Name = "PersonLT";
            this.PersonLT.Size = new System.Drawing.Size(35, 13);
            this.PersonLT.TabIndex = 7;
            this.PersonLT.Text = "label1";
            // 
            // RedS
            // 
            this.RedS.AutoSize = true;
            this.RedS.Location = new System.Drawing.Point(15, 202);
            this.RedS.Name = "RedS";
            this.RedS.Size = new System.Drawing.Size(35, 13);
            this.RedS.TabIndex = 8;
            this.RedS.Text = "label1";
            // 
            // BlueS
            // 
            this.BlueS.AutoSize = true;
            this.BlueS.Location = new System.Drawing.Point(15, 219);
            this.BlueS.Name = "BlueS";
            this.BlueS.Size = new System.Drawing.Size(35, 13);
            this.BlueS.TabIndex = 9;
            this.BlueS.Text = "label2";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(291, 257);
            this.Controls.Add(this.BlueS);
            this.Controls.Add(this.RedS);
            this.Controls.Add(this.PersonLT);
            this.Controls.Add(this.TeamLT);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Shot2);
            this.Controls.Add(this.Shots);
            this.Controls.Add(this.Slope);
            this.Controls.Add(this.PuckPos);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PuckPos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Slope;
        private System.Windows.Forms.Label Shots;
        private System.Windows.Forms.Label Shot2;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label TeamLT;
        private System.Windows.Forms.Label PersonLT;
        private System.Windows.Forms.Label RedS;
        private System.Windows.Forms.Label BlueS;

    }
}

