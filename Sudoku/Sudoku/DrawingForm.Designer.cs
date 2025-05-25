namespace Sudoku
{
    partial class DrawingForm
    {
        private PictureBox pictureBox;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingForm));
            pictureBox = new PictureBox();
            DrawButtonReset = new RoundButton();
            RecognizeButton = new RoundButton();
            DrawingInfoLabel = new RoundedLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(12, 58);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(320, 448);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            // 
            // DrawButtonReset
            // 
            DrawButtonReset.BackColor = Color.Gray;
            DrawButtonReset.Image = (Image)resources.GetObject("DrawButtonReset.Image");
            DrawButtonReset.Location = new Point(25, 529);
            DrawButtonReset.Name = "DrawButtonReset";
            DrawButtonReset.Size = new Size(64, 61);
            DrawButtonReset.TabIndex = 1;
            DrawButtonReset.UseVisualStyleBackColor = false;
            DrawButtonReset.Click += DrawButtonReset_Click;
            // 
            // RecognizeButton
            // 
            RecognizeButton.BackColor = Color.Gray;
            RecognizeButton.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RecognizeButton.ForeColor = Color.Plum;
            RecognizeButton.Location = new Point(115, 529);
            RecognizeButton.Name = "RecognizeButton";
            RecognizeButton.Size = new Size(196, 61);
            RecognizeButton.TabIndex = 2;
            RecognizeButton.Text = "RECOGNIZE IT!";
            RecognizeButton.UseVisualStyleBackColor = false;
            RecognizeButton.Click += RecognizeButton_Click;
            // 
            // DrawingInfoLabel
            // 
            DrawingInfoLabel.AutoSize = true;
            DrawingInfoLabel.BackColor = Color.Gray;
            DrawingInfoLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DrawingInfoLabel.ForeColor = Color.Plum;
            DrawingInfoLabel.Location = new Point(66, 20);
            DrawingInfoLabel.Name = "DrawingInfoLabel";
            DrawingInfoLabel.Size = new Size(279, 35);
            DrawingInfoLabel.TabIndex = 3;
            DrawingInfoLabel.Text = "Stick to the lines";
            // 
            // DrawingForm
            // 
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(347, 615);
            Controls.Add(DrawingInfoLabel);
            Controls.Add(RecognizeButton);
            Controls.Add(DrawButtonReset);
            Controls.Add(pictureBox);
            Name = "DrawingForm";
            Text = "Рисование цифры";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private RoundButton DrawButtonReset;
        private RoundButton RecognizeButton;
        private RoundedLabel DrawingInfoLabel;
    }
}
