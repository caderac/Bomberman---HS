namespace WindowsFormsApplication1
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
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmrBombers = new System.Windows.Forms.Timer(this.components);
            this.tmrBomb = new System.Windows.Forms.Timer(this.components);
            this.tmrDead = new System.Windows.Forms.Timer(this.components);
            this.tmrSkull = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 10;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // tmrBombers
            // 
            this.tmrBombers.Enabled = true;
            this.tmrBombers.Interval = 50;
            this.tmrBombers.Tick += new System.EventHandler(this.tmrBombers_Tick);
            // 
            // tmrBomb
            // 
            this.tmrBomb.Enabled = true;
            this.tmrBomb.Interval = 200;
            this.tmrBomb.Tick += new System.EventHandler(this.tmrBomb_Tick);
            // 
            // tmrDead
            // 
            this.tmrDead.Enabled = true;
            this.tmrDead.Interval = 250;
            this.tmrDead.Tick += new System.EventHandler(this.tmrDead_Tick);
            // 
            // tmrSkull
            // 
            this.tmrSkull.Enabled = true;
            this.tmrSkull.Interval = 10;
            this.tmrSkull.Tick += new System.EventHandler(this.tmrSkull_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1273, 574);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Timer tmrBombers;
        private System.Windows.Forms.Timer tmrBomb;
        private System.Windows.Forms.Timer tmrDead;
        private System.Windows.Forms.Timer tmrSkull;
    }
}

