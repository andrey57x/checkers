using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class PlayingForm : Form
    {
        private readonly Game game;
        private readonly MenuForm menu;
        private int position;
        private Image black_man;
        private Image black_king;
        private Image white_man;
        private Image white_king;
        public PlayingForm(MenuForm menuForm, int side, int difficulty)
        {
            InitializeComponent();
            PlayingFormSizeChanged(this, new EventArgs());
            Game.ChangeDirectory();
            black_man = Image.FromFile("black_man.png");
            black_king = Image.FromFile("black_king.png");
            white_man = Image.FromFile("white_man.png");
            white_king = Image.FromFile("white_king.png");
            position = -1;

            this.FormClosed += PlayingFormClose;
            this.SizeChanged += PlayingFormSizeChanged;


            for (int i = 0; i != 64; i++)
            {
                if (((i % 2) + (i / 8) % 2) % 2 == 0)
                {
                    Label fill = new()
                    {
                        AutoSize = true,
                        Location = new Point(0, 0),
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 20F),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(0),
                        BackColor = Color.FromArgb(152, 118, 84),
                    };
                    FieldTable.Controls.Add(fill);
                }
                else
                {
                    Button button = new()
                    {
                        AutoSize = true,
                        Location = new Point(0, 0),
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        BackColor = Color.FromArgb(101, 67, 33),
                        Cursor = Cursors.Hand,
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i / 2
                    };
                    button.Click += ButtonClick;
                    FieldTable.Controls.Add(button);
                }
            }

            game = new(side, difficulty, ShowBoard, GetPos, ShowMessage, AddToHistory);
            menu = menuForm;
        }

        public void StartGame()
        {
            Thread temp = new Thread(game.Start);
            temp.Start();
        }

        private void PlayingFormClose(object? sender, EventArgs e) { menu.Close(); }

        private void PlayingFormSizeChanged(object? sender, EventArgs e)
        {
            HistoryTable.Location = new Point(0, 0);
            HistoryTable.Width = (int)(MainTable.Width * 0.2);
            HistoryTable.Height = MainTable.Height;

            int height = MainTable.Height;
            int width = (int)(MainTable.Width * 0.8);
            int size = height < width ? height : width;
            FieldTable.Size = new Size(size, size);
            FieldTable.Location = new Point((height - size) / 2, (width - size) / 2);
        }

        private void ShowBoard(Board board)
        {
            for (int i = 0; i != 32; i++)
            {
                int field = board.Fields[i];
                FieldTable.Controls[i * 2 + (1 - (i / 4) % 2)].BackgroundImage = field switch
                {
                    -2 => black_king,
                    -1 => black_man,
                    1 => white_man,
                    2 => white_king,
                    _ => null
                };
            }
        }

        private void AddToHistory(List<Move> moves)
        {
            string s = moves[0].ToString();
            for (int i = 1; i < moves.Count; i++)
            {
                s += moves[i].ToString()[2];
                s += moves[i].ToString()[3];
                s += moves[i].ToString()[4];
            }
            Label label = new()
            {
                AutoSize = true,
                Location = new Point(0, 0),
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 20F),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = s
            };
            Action action = () => HistoryTable.Controls.Add(label);
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private int GetPos()
        {
            position = -1;
            while (position == -1) { Thread.Sleep(1); }
            return position;
        }

        private void ButtonClick(object? sender, EventArgs e) { position = int.Parse(((Button)sender).Tag.ToString()); }
    }
}
