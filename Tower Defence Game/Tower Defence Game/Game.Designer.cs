namespace Tower_Defence_Game
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            gameLayout = new TableLayoutPanel();
            SuspendLayout();
            // 
            // gameLayout
            // 
            gameLayout.BackgroundImage = (Image)resources.GetObject("gameLayout.BackgroundImage");
            gameLayout.ColumnCount = 3;
            gameLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            gameLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            gameLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            gameLayout.Dock = DockStyle.Fill;
            gameLayout.Location = new Point(0, 0);
            gameLayout.Margin = new Padding(0);
            gameLayout.Name = "gameLayout";
            gameLayout.RowCount = 3;
            gameLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            gameLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            gameLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            gameLayout.Size = new Size(1099, 627);
            gameLayout.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 627);
            Controls.Add(gameLayout);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel gameLayout;
    }
}
