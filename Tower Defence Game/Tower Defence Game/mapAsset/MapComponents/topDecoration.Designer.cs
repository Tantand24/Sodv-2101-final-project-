namespace Tower_Defence_Game
{
    partial class topDecoration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(topDecoration));
            topBoundary = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)topBoundary).BeginInit();
            SuspendLayout();
            // 
            // topBoundary
            // 
            topBoundary.BackColor = SystemColors.Control;
            topBoundary.Dock = DockStyle.Fill;
            topBoundary.Image = (Image)resources.GetObject("topBoundary.Image");
            topBoundary.Location = new Point(0, 0);
            topBoundary.Margin = new Padding(0);
            topBoundary.Name = "topBoundary";
            topBoundary.Size = new Size(647, 109);
            topBoundary.SizeMode = PictureBoxSizeMode.StretchImage;
            topBoundary.TabIndex = 0;
            topBoundary.TabStop = false;
            // 
            // topDecoration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(topBoundary);
            Name = "topDecoration";
            Size = new Size(647, 109);
            ((System.ComponentModel.ISupportInitialize)topBoundary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox topBoundary;
    }
}
