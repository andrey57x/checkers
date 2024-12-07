namespace Checkers
{
    internal class Board : ICloneable
    {
        private readonly int[] fields;
        public int[] Fields { get { return fields; } }
        public Board()
        {
            fields = new int[32];
            for (int i = 0; i != 12; i++)
            {
                fields[i] = -1;
            }
            for (int i = 20; i != 32; i++)
            {
                fields[i] = 1;
            }
        }
        public void ReadFromFile(string path)
        {
            StreamReader sr = new(path);
            for (int i = 0; i != 8; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j != 4; j++)
                {
                    char symbol = line[4 * j + 2 * Convert.ToInt16(i % 2 == 0)];
                    switch (symbol)
                    {
                        case 'W':
                            fields[i * 4 + j] = 2;
                            break;
                        case 'w':
                            fields[i * 4 + j] = 1;
                            break;
                        case 'B':
                            fields[i * 4 + j] = -2;
                            break;
                        case 'b':
                            fields[i * 4 + j] = -1;
                            break;
                        default:
                            fields[i * 4 + j] = 0;
                            break;
                    }
                }
            }
            sr.Close();
        }
        public void ConsolePrint()
        {
            Console.Clear();
            for (int i = 0; i != 8; i++)
            {
                for (int j = 0; j != 4; j++)
                {
                    char symbol = fields[i * 4 + j] switch
                    {
                        2 => 'W',
                        1 => 'w',
                        -2 => 'B',
                        -1 => 'b',
                        _ => '0',
                    };
                    if (i % 2 == 0)
                    {
                        Console.Write($"_{symbol}");
                    }
                    else
                    {
                        Console.Write($"{symbol}_");
                    }
                }
                Console.WriteLine();
            }
        }
        public object Clone()
        {
            Board tmp = new();
            for (int i = 0; i != 32; i++)
            {
                tmp.fields[i] = fields[i];
            }
            return tmp;
        }
        private bool CheckMoveEnglish(Move move, Side turn)
        {
            int final = move.final;
            int initial = move.initial;
            int diff = final - initial;
            if ((initial < 0) || (initial > 31) || (final < 0) || (final > 31) || (fields[final] != 0) || (fields[initial] == 0) || ((fields[initial] + (int)turn) / 2 != (int)turn) || (fields[initial] == 1 && diff > 0) || (fields[initial] == -1 && diff < 0))
            {
                return false;
            }
            else if (Math.Abs(diff) == 7 || Math.Abs(diff) == 9)
            {
                if (((initial / 4) % 2 == 0) && ((diff == -9 && (fields[initial - 4] == 0 || (fields[initial - 4] / Math.Abs(fields[initial - 4]) == (int)turn))) || (diff == -7 && (fields[initial - 3] == 0 || (fields[initial - 3] / Math.Abs(fields[initial - 3]) == (int)turn))) || (diff == 9 && (fields[initial + 5] == 0 || (fields[initial + 5] / Math.Abs(fields[initial + 5]) == (int)turn))) || (diff == 7 && (fields[initial + 4] == 0 || (fields[initial + 4] / Math.Abs(fields[initial + 4]) == (int)turn)))))
                {
                    return false;
                }
                else if (((initial / 4) % 2 == 1) && ((diff == -9 && (fields[initial - 5] == 0 || (fields[initial - 5] / Math.Abs(fields[initial - 5]) == (int)turn))) || (diff == -7 && (fields[initial - 4] == 0 || (fields[initial - 4] / Math.Abs(fields[initial - 4]) == (int)turn))) || (diff == 9 && (fields[initial + 4] == 0 || (fields[initial + 4] / Math.Abs(fields[initial + 4]) == (int)turn))) || (diff == 7 && (fields[initial + 3] == 0 || (fields[initial + 3] / Math.Abs(fields[initial + 3]) == (int)turn)))))
                {
                    return false;
                }
                if (initial % 4 == 3 && diff != -9 && diff != 7)
                {
                    return false;
                }
                else if (initial % 4 == 0 && diff != -7 && diff != 9)
                {
                    return false;
                }
            }
            else if (Math.Abs(diff) == 3 || Math.Abs(diff) == 4 || Math.Abs(diff) == 5)
            {
                if ((initial % 4 == 3 && (initial / 4) % 2 == 0) || (initial % 4 == 0 && (initial / 4) % 2 == 1))
                {
                    if (Math.Abs(fields[initial]) == 1 && (diff != (-(int)turn * 4)))
                    {
                        return false;
                    }
                    else if (Math.Abs(fields[initial]) == 2 && (Math.Abs(diff) != 4))
                    {
                        return false;
                    }
                }
                else if (Math.Abs(fields[initial]) == 1)
                {
                    if (((int)turn == 1) && ((((initial / 4) % 2 == 0) && (diff != -4) && (diff != -3)) || (((initial / 4) % 2 == 1) && (diff != -4) && (diff != -5))))
                    {
                        return false;
                    }
                    else if (((int)turn == -1) && ((((initial / 4) % 2 == 0) && (diff != 4) && (diff != 5)) || (((initial / 4) % 2 == 1) && (diff != 4) && (diff != 3))))
                    {
                        return false;
                    }
                }
                else
                {
                    if (((initial / 4) % 2 == 0) && (Math.Abs(diff) != 4) && (diff != -3) && (diff != 5))
                    {
                        return false;
                    }
                    else if (((initial / 4) % 2 == 1) && (Math.Abs(diff) != 4) && (diff != 3) && (diff != -5))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        private bool CheckMoveRussian(Move move, Side turn, out int eat, out int direction, bool ignore_side = false, int ignore_dir = -1)
        {
            int final = move.final;
            int initial = move.initial;
            int diff = Math.Abs(final - initial);
            int dir = final - initial > 0 ? 1 : -1;
            int line = (initial / 4) % 2;
            if ((initial < 0) || (initial > 31) || (final < 0) || (final > 31) || (fields[final] != 0) || (fields[initial] == 0) || (!IsSide(initial, turn) && !ignore_side))
            {
                eat = 0;
                direction = -1;
                return false;
            }
            switch (Math.Abs(fields[initial]))
            {
                case 1:
                    switch (diff * dir)
                    {
                        case -3:
                            direction = 1;
                            if ((dir == (int)turn && !ignore_side) || (line == 0 && initial % 4 == 3) || (line == 1 && initial % 4 == 0) || (line + dir == 0 || line + dir == 1)) { eat = 0; return false; }
                            eat = 0;
                            return true;
                        case 3:
                            direction = 3;
                            if ((dir == (int)turn && !ignore_side) || (line == 0 && initial % 4 == 3) || (line == 1 && initial % 4 == 0) || (line + dir == 0 || line + dir == 1)) { eat = 0; ; return false; }
                            eat = 0;
                            return true;
                        case -4:
                            direction = ((initial / 4) % 2) switch
                            {
                                0 => 0,
                                1 => 1,
                                _ => -1
                            };
                            if ((dir == (int)turn && !ignore_side)) { eat = 0; return false; }
                            eat = 0;
                            return true;
                        case 4:
                            direction = ((initial / 4) % 2) switch
                            {
                                0 => 3,
                                1 => 2,
                                _ => -1
                            };
                            if ((dir == (int)turn && !ignore_side)) { eat = 0; return false; }
                            eat = 0;
                            return true;
                        case -5:
                            direction = 0;
                            if ((dir == (int)turn && !ignore_side) || (line == 0 && initial % 4 == 3) || (line == 1 && initial % 4 == 0) || (line + dir == -1 || line + dir == 2)) { eat = 0; return false; }
                            eat = 0;
                            return true;
                        case 5:
                            direction = 2;
                            if ((dir == (int)turn && !ignore_side) || (line == 0 && initial % 4 == 3) || (line == 1 && initial % 4 == 0) || (line + dir == -1 || line + dir == 2)) { eat = 0; return false; }
                            eat = 0;
                            return true;
                        case -9:
                            direction = 0;
                            if ((line == 0 && !IsSide(initial - 4, OppositeSide(turn))) || (line == 1 && !IsSide(initial - 5, OppositeSide(turn))) || (initial % 4 == 0)) { eat = 0; return false; }
                            eat = line == 0 ? initial - 4 : initial - 5;
                            return true;
                        case -7:
                            direction = 1;
                            if ((line == 0 && !IsSide(initial - 3, OppositeSide(turn))) || (line == 1 && !IsSide(initial - 4, OppositeSide(turn))) || (initial % 4 == 3)) { eat = 0; return false; }
                            eat = line == 0 ? initial - 3 : initial - 4;
                            return true;
                        case 7:
                            direction = 3;
                            if ((line == 0 && !IsSide(initial + 4, OppositeSide(turn))) || (line == 1 && !IsSide(initial + 3, OppositeSide(turn))) || (initial % 4 == 0)) { eat = 0; return false; }
                            eat = line == 0 ? initial + 4 : initial + 3;
                            return true;
                        case 9:
                            direction = 2;
                            if ((line == 0 && !IsSide(initial + 5, OppositeSide(turn))) || (line == 1 && !IsSide(initial + 4, OppositeSide(turn))) || (initial % 4 == 3)) { eat = 0; return false; }
                            eat = line == 0 ? initial + 5 : initial + 4;
                            return true;
                        default: eat = 0; direction = -1; return false;
                    }
                case 2:
                    Board tmp = (Board)Clone();
                    int mock;
                    int delta;
                    int pos;
                    int prepos;
                    Move mv = new();
                    int first;
                    int second;
                    int[] firsts = [-4, -3, 5, 4];
                    int[] seconds = [-5, -4, 4, 3];
                    for (int i = 0; i != 4; i++)
                    {
                        direction = i;
                        first = firsts[i];
                        second = seconds[i];

                        tmp = (Board)Clone();
                        tmp.fields[initial] = fields[initial] / 2;
                        if (line == 0) delta = first;
                        else delta = second;
                        pos = initial + delta;
                        prepos = initial;
                        mv.Update(prepos, pos);
                        while ((pos > final && delta < 0) || (pos < final && delta > 0))
                        {
                            mv.Update(prepos, pos);
                            if (tmp.CheckMoveRussian(mv, turn, out mock, out int _, ignore_side = true))
                            {
                                if (ignore_dir != -1 && Math.Abs(i - ignore_dir) == 2) goto LoopEnd;
                                tmp.MakeMove(mv);
                            }
                            else
                            {
                                break;
                            }
                            delta = delta == first ? second : first;
                            prepos = pos;
                            pos += delta;
                        }
                        mv.Update(prepos, pos);
                        if (pos == final && tmp.CheckMoveRussian(mv, turn, out mock, out int _, ignore_side = true)) { eat = 0; return true; }
                        delta = delta == first ? second : first;
                        pos += delta;
                        mv.Update(prepos, pos);
                        if (tmp.CheckMoveRussian(mv, turn, out mock, out int _, ignore_side = true))
                        {
                            tmp.MakeMove(mv);
                            eat = mock;
                            if (pos == final) { return true; }
                            delta = delta == first ? second : first;
                            prepos = pos;
                            pos += delta;
                            while ((pos > final && delta < 0) || (pos < final && delta > 0))
                            {
                                mv.Update(prepos, pos);
                                if (tmp.CheckMoveRussian(mv, turn, out mock, out int _, ignore_side = true))
                                {
                                    if (i == ignore_dir) goto LoopEnd;
                                    tmp.MakeMove(mv);
                                }
                                else
                                {
                                    break;
                                }
                                delta = delta == first ? second : first;
                                prepos = pos;
                                pos += delta;
                            }
                            mv.Update(prepos, pos);
                            if (pos == final && tmp.CheckMoveRussian(mv, turn, out mock, out int _, ignore_side = true)) { return true; }
                        }

                    LoopEnd: continue;
                    }
                    break;
            }
            eat = 0;
            direction = -1;
            return false;


        }
        public void MakeMove(Move move)
        {
            if (move.initial == move.final) throw new Exception("Wrong Move!");
            int final = move.final;
            int initial = move.initial;
            fields[final] = fields[initial];
            fields[initial] = 0;
            if (move.eat != 0) fields[move.eat] = 0;
            Crown();
        }
        private int CountSide(Side side)
        {
            int counter = 0;
            foreach (int i in fields)
            {
                if ((i + (int)side) / 2 == (int)side) ++counter;
            }
            return counter;
        }
        private double EstimateSide(Side side)
        {
            double result = 0;
            foreach (int i in fields)
            {
                if ((i + (int)side) / 2 == (int)side)
                {
                    double weight = 1;
                    if (Math.Abs(i) == 2)
                    {
                        weight *= Constants.KING_BONUS;
                    }
                    else if ((Math.Abs(i) == 1 && i < 12 && (i + (int)side) / 2 == (int)Side.White) || (Math.Abs(i) == 1 && i > 19 && (i + (int)side) / 2 == (int)Side.Black))
                    {
                        weight *= Constants.MOVE_BONUS;
                    }
                    result += weight;
                }
            }
            if (CountSide(side) == 0) result -= Constants.NO_FIGURES_PENALTY;
            if (!IsMoveAvailable(side)) result -= Constants.NO_MOVES_PENALTY;
            return result;
        }
        private double Estimate()
        {
            return (EstimateSide(Side.White) - EstimateSide(Side.Black));
        }
        public bool IsTakeAvailable(Side side, int start, int direction)
        {
            int eat = 0;
            Move move = new();
            switch (Math.Abs(fields[start]))
            {
                case 1:
                    int[] possible_takes = [-9, -7, 7, 9];
                    foreach (int j in possible_takes)
                    {
                        move.Update(start, start + j);
                        if (CheckMoveRussian(move, side, out eat, out int _) && eat != 0) return true;
                    }
                    break;
                case 2:
                    int[] possible_takes_king = [-9, -14, -13, -18, -23, -22, -27, -7, -11, -10, -17, -21, -25, 9, 14, 13, 18, 23, 22, 27, 7, 11, 10, 17, 21, 25];
                    foreach (int j in possible_takes_king)
                    {
                        move.Update(start, start + j);
                        if (CheckMoveRussian(move, side, out eat, out int _, false, direction) && eat != 0) return true;
                    }
                    break;
            }
            return false;

        }
        private bool IsMoveAvailable(Side side)
        {
            int eat;
            Move move = new();
            for (int i = 0; i != 32; i++)
            {
                switch (Math.Abs(fields[i]))
                {
                    case 1:
                        int[] possible_moves = [-9, -7, 7, 9, -5, -4, -3, 5, 4, 3];
                        foreach (int j in possible_moves)
                        {
                            move.Update(i, i + j);
                            if (CheckMoveRussian(move, side, out eat, out int _)) return true;
                        }
                        break;
                    case 2:
                        int[] possible_takes_king = [-9, -14, -13, -18, -23, -22, -27, -7, -11, -10, -17, -21, -25, 9, 14, 13, 18, 23, 22, 27, 7, 11, 10, 17, 21, 25, -5, -4, -3, 5, 4, 3];
                        foreach (int j in possible_takes_king)
                        {
                            move.Update(i, i + j);
                            if (CheckMoveRussian(move, side, out eat, out int _)) return true;
                        }
                        break;
                }
            }
            return false;
        }
        public List<Move> PossibleMoves(Side side)
        {
            List<Move> result = [];
            int[] possible_moves_plus = [-9, -7, 7, 9, -5, -4, -3];
            int[] possible_moves_minus = [-9, -7, 7, 9, 3, 4, 5,];
            int[] possible_moves_king = [-9, -14, -13, -18, -23, -22, -27, -7, -11, -10, -17, -21, -25, 9, 14, 13, 18, 23, 22, 27, 7, 11, 10, 17, 21, 25, -5, -4, -3, 5, 4, 3];
            int eat;
            int direction;
            bool flag = false;
            Move move = new();
            for (int i = 0; i != 32; i++)
            {
                if (!IsSide(i, side)) continue;
                switch (fields[i])
                {
                    case 1:
                        foreach (int j in possible_moves_plus)
                        {
                            move.Update(i, i + j); ;
                            if (CheckMoveRussian(move, side, out eat, out direction))
                            {
                                if ((eat != 0 && flag) || (eat == 0 && !flag))
                                {
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                                else if (eat != 0 && !flag)
                                {
                                    flag = true;
                                    result.Clear();
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                            }
                        }
                        break;
                    case -1:
                        foreach (int j in possible_moves_minus)
                        {
                            move.Update(i, i + j);
                            if (CheckMoveRussian(move, side, out eat, out direction))
                            {
                                if ((eat != 0 && flag) || (eat == 0 && !flag))
                                {
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                                else if (eat != 0 && !flag)
                                {
                                    flag = true;
                                    result.Clear();
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                            }
                        }
                        break;
                    case 2:
                        foreach (int j in possible_moves_king)
                        {
                            move.Update(i, i + j);
                            if (CheckMoveRussian(move, side, out eat, out direction))
                            {
                                if ((eat != 0 && flag) || (eat == 0 && !flag))
                                {
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                                else if (eat != 0 && !flag)
                                {
                                    flag = true;
                                    result.Clear();
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                            }
                        }
                        break;
                    case -2:
                        foreach (int j in possible_moves_king)
                        {
                            move.Update(i, i + j);
                            if (CheckMoveRussian(move, side, out eat, out direction))
                            {
                                if ((eat != 0 && flag) || (eat == 0 && !flag))
                                {
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                                else if (eat != 0 && !flag)
                                {
                                    flag = true;
                                    result.Clear();
                                    move.eat = eat;
                                    move.direction = direction;
                                    result.Add(move);
                                }
                            }
                        }
                        break;
                    default: break;
                }
            }
            Shuffle(result);
            return result;
        }
        public Situation CheckSituation(Side side)
        {
            if (CountSide(OppositeSide(side)) == 0 || !IsMoveAvailable(OppositeSide(side))) return (Situation)((int)side);
            else return Situation.Neutral;
        }
        private void Crown()
        {
            for (int i = 0; i != 4; i++)
            {
                if (fields[i] == 1) fields[i] = 2;
            }
            for (int i = 28; i != 32; i++)
            {
                if (fields[i] == -1) fields[i] = -2;
            }
        }
        public double BestMove(Side side, int depth, MaxorMin action, double alpha, out Move move, int start = -1)
        {
            if (depth == 0)
            {
                move = new();
                return Estimate();
            }
            List<Move> moves = PossibleMoves(side);
            if (start != -1)
            {
                for (int i = 0; i != moves.Count; i++)
                {
                    if (moves[i].initial != start)
                    {
                        moves.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (moves.Count == 0)
            {
                move = new();
                return Estimate();
            }
            Move temp_move = new();
            double value;
            if (action == MaxorMin.Min) value = 200;
            else value = -200;
            for (int i = 0; i != moves.Count; i++)
            {
                Board tmp = (Board)Clone();
                tmp.MakeMove(moves[i]);
                double price;
                if (moves[i].eat != 0 && tmp.IsTakeAvailable(side, moves[i].final, moves[i].direction)) price = tmp.BestMove(side, depth, action, alpha, out Move _, moves[i].final);
                else price = tmp.BestMove(OppositeSide(side), depth - 1, OppositeAction(action), value, out Move _);
                if (action == MaxorMin.Min && price < value || action == MaxorMin.Max && price > value)
                {
                    value = price;
                    temp_move = moves[i];
                    if (action == MaxorMin.Min && value < alpha || action == MaxorMin.Max && value > alpha)
                        break;
                }
            }
            move = temp_move;
            return value;
        }
        private bool IsSide(int index, Side side) { return (fields[index] + (int)side) / 2 == (int)side; }
        static public Side OppositeSide(Side side)
        {
            if (side == Side.White) return Side.Black;
            return Side.White;
        }
        static private MaxorMin OppositeAction(MaxorMin action)
        {
            if (action == MaxorMin.Min) return MaxorMin.Max;
            return MaxorMin.Min;
        }
        static private void Shuffle(List<Move> moves)
        {
            Random rnd = new Random();
            Move tmp;
            for (int i = 0; i != moves.Count; i++)
            {
                tmp = moves[i];
                int rand = rnd.Next(i, moves.Count);
                moves[i] = moves[rand];
                moves[rand] = tmp;
            }
        }
    }
    internal struct Move(int initial = 0, int final = 0)
    {
        public int initial = initial;
        public int final = final;
        public int eat = 0;
        public int direction = -1;
        public override string ToString()
        {
            char delimiter = eat == 0 ? '-' : ':';
            string chars = "abcdefgh";
            string first = $"{chars[initial % 4 * 2 + (1 - ((initial / 4) % 2))]}{8 - (initial) / 4}";
            string second = $"{chars[final % 4 * 2 + (1 - ((final / 4) % 2))]}{8 - (final) / 4}";
            return first + delimiter + second;
        }
        public void Update(int init, int fin)
        {
            initial = init;
            final = fin;
        }
        static public bool operator ==(Move lhs, Move rhs)
        {
            return lhs.initial == rhs.initial && lhs.final == rhs.final;
        }
        static public bool operator !=(Move lhs, Move rhs)
        {
            return !(rhs == lhs);
        }
        public int Delta { get { return final - initial; } }
    }
    enum Side { Black = -1, White = 1 }
    enum MaxorMin { Min = -1, Max = 1 }
    enum Situation { BlackWin = -1, Neutral = 0, WhiteWin = 1 }
    static internal class Constants
    {
        public const double KING_BONUS = 1.9;
        public const double MOVE_BONUS = 1.1;
        public const int NO_FIGURES_PENALTY = 100;
        public const int NO_MOVES_PENALTY = 50;
    }
}
