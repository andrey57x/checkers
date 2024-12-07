using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;

namespace Checkers
{
    internal class Game
    {
        public ShowBoard show_board;
        public GetPlayerPosition get_player_position;
        public ShowMessage show_message;
        public UpdateHistory update_history;
        readonly Board board = new();
        readonly Side player_side;
        readonly Side computer_side;
        readonly int DEPTH;
        private readonly List<List<Move>> history = [];
        public List<List<Move>> History {  get { return history; } }
        public Game(int side, int difficulty)
        {
            show_board = (Board board) => board.ConsolePrint();
            show_message = Console.WriteLine;
            update_history = (List<Move> _) => { };
            get_player_position = () => {
                Console.WriteLine("Enter your position");
                return int.Parse(Console.ReadLine()) - 1;
            };

            player_side = (Side)side;
            computer_side = Board.OppositeSide(player_side);
            DEPTH = difficulty switch
            {
                0 => 3,
                1 => 5,
                2 => 7,
                _ => 6,
            };

            //string file = "board.txt";
            //board.ReadFromFile(file);
        }
        public Game(int side, int difficulty, ShowBoard show_board_, GetPlayerPosition get_player_position_, ShowMessage show_message_, UpdateHistory update_history_) : this(side, difficulty)
        {
            show_board = show_board_;
            get_player_position = get_player_position_;
            show_message = show_message_;
            update_history=update_history_;
        }
        public void Start()
        {
            show_board(board);
            if (player_side == Side.White)
            {
                show_board(board);
                PlayerMove();
            }
            Situation situation = board.CheckSituation(player_side);
            while (situation == Situation.Neutral)
            {
                ComputerMove();
                situation = board.CheckSituation(computer_side);
                if (situation != Situation.Neutral) break;
                show_board(board);
                PlayerMove();
                situation = board.CheckSituation(player_side);
            }
            show_board(board);
            string message = ((int)situation * (int)player_side) switch
            {
                -1 => "You Lost!",
                1 => "You Won!",
                _ => "You broken!"
            };
            show_message(message);
        }
        void PlayerMove()
        {
            List<Move> moves = [];
            Move move = GetPlayerMove();
            board.MakeMove(move);
            moves.Add(move);
            while (move.eat!=0 && board.IsTakeAvailable(player_side, move.final, move.direction))
            {
                show_board(board);
                move = GetPlayerMove();
                board.MakeMove(move);
                moves.Add(move);
            }
            history.Add(moves);
            update_history(moves);
        }
        void ComputerMove()
        {
            List<Move> moves = [];
            MaxorMin act;
            double value;
            if (computer_side == Side.White)
            {
                act = MaxorMin.Max;
                value = 300;
            }
            else
            {
                act = MaxorMin.Min;
                value = -300;
            }
            board.BestMove(computer_side, DEPTH, act, value, out Move move);
            board.MakeMove(move);
            moves.Add(move);
            while (move.eat != 0 && board.IsTakeAvailable(computer_side, move.final, move.direction))
            {
                board.BestMove(computer_side, DEPTH, act, value, out move, move.final);
                board.MakeMove(move);
                moves.Add(move);
            }
            history.Add(moves);
            update_history(moves);
        }
        Move GetPlayerMove()
        {
            List<Move> possible = board.PossibleMoves(player_side);
            while (true)
            {
                show_board(board);
                int first = get_player_position();
                List<Move> temp = [];
                for (int i = 0; i < possible.Count; i++)
                {
                    if (possible[i].initial == first)
                    {
                        temp.Add(possible[i]);
                    }
                }
                if (temp.Count == 0)
                {
                    show_message("No possible moves from this position(\nTry again");
                    continue;
                }
                int second = get_player_position();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].final == second) return temp[i];
                }
                show_message("Wrong move!\nTry again");
            }
        }

        public static void ChangeDirectory()
        {
            string path = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                Directory.SetCurrentDirectory(Directory.GetParent(path).ToString());
                path = Directory.GetCurrentDirectory();
            }
        }
        void InitialiseBoard()
        {
            Console.WriteLine("Would you like to start a new game? (y/n)");
            string ans = Console.ReadLine();
            while (true)
            {
                if (ans == "y") break;
                else if (ans == "n")
                {
                    ChangeDirectory();
                    string file = "board.txt";
                    board.ReadFromFile(file);
                    break;
                }
                Console.WriteLine("Wrong! Try again!");
                ans = Console.ReadLine();
            }
        }
    }

    delegate void ShowBoard(Board board);

    delegate int GetPlayerPosition();

    delegate Side GetPlayerSide();

    delegate void EndGame(Situation situation);

    delegate void ShowMessage(string message);

    delegate void UpdateHistory(List<Move> moves);

    enum HighlightMode { Chosen = 0, Possible = 1, Made = 2 }
}
