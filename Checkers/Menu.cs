namespace Checkers
{
    public partial class MenuForm : Form
    {
        int side = 1;
        int difficulty = 1;
        public MenuForm()
        {
            InitializeComponent();
            WhiteButton.Checked = true;
            NormalDifficultyButton.Checked = true;
            WhiteButton.CheckedChanged += ChooseSide_CheckedChanged;
            BlackButton.CheckedChanged += ChooseSide_CheckedChanged;
            EasyDifficultyButton.CheckedChanged += ChooseDifficulty_CheckedChanged;
            NormalDifficultyButton.CheckedChanged += ChooseDifficulty_CheckedChanged;
            HardDifficultyButton.CheckedChanged += ChooseDifficulty_CheckedChanged;
            this.SizeChanged += SizeChange;
        }
        private void ChooseSide_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                RadioButton obj = (RadioButton)sender;
                if (obj.Checked)
                {
                    side = int.Parse((string)obj.Tag);
                }
            }
        }
        private void ChooseDifficulty_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                RadioButton obj = (RadioButton)sender;
                if (obj.Checked)
                {
                    difficulty = int.Parse((string)obj.Tag);
                }
            }
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            PlayingForm playing_form = new(this, side, difficulty);

            this.Hide();
            playing_form.Show();

            playing_form.StartGame();
        }
        private void SizeChange(object? sender, EventArgs e)
        {
            DifficultyChooseBox.Location = new Point((Width - DifficultyChooseBox.Width) / 2, DifficultyChooseBox.Location.Y);
            SideChooseBox.Location = new Point((Width - SideChooseBox.Width) / 2, SideChooseBox.Location.Y);
            StartGameButton.Location = new Point((Width - StartGameButton.Width) / 2, StartGameButton.Location.Y);
        }
    }
}
