namespace Tower_Defence_Game
{
    partial class IntroMenu
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
            titleLbl = new Label();
            startBtn = new Button();
            ExitBtn = new Button();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.BackColor = SystemColors.ControlDark;
            titleLbl.Dock = DockStyle.Top;
            titleLbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            titleLbl.ForeColor = SystemColors.Control;
            titleLbl.Location = new Point(0, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(1125, 125);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Winter Defence";
            titleLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startBtn
            // 
            startBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            startBtn.BackColor = Color.DarkGreen;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            startBtn.ForeColor = SystemColors.Control;
            startBtn.Location = new Point(425, 250);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(275, 88);
            startBtn.TabIndex = 1;
            startBtn.Text = "Start Game";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += btnStart_Click;
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = Color.DarkRed;
            ExitBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            ExitBtn.ForeColor = SystemColors.Control;
            ExitBtn.Location = new Point(425, 375);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(275, 88);
            ExitBtn.TabIndex = 2;
            ExitBtn.Text = "Exit";
            ExitBtn.UseVisualStyleBackColor = false;
            ExitBtn.Click += btnExit_Click;
            // 
            // IntroMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1125, 688);
            Controls.Add(ExitBtn);
            Controls.Add(startBtn);
            Controls.Add(titleLbl);
            Name = "IntroMenu";
            Text = "Winter Defence";
            ResumeLayout(false);
        }

        #endregion

        private Label titleLbl;
        private Button startBtn;
        private Button ExitBtn;
    }
}