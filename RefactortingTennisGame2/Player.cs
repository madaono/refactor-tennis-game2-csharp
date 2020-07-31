using System.Collections.Generic;

namespace RefactortingTennisGame2
{
    public class Player
    {
        public string Name;
        private int _points = 0;
        private string _score = "";
        
        private Dictionary<int, string> _pointMap = new Dictionary<int, string>()
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        public Player(string name)
        {
            Name = name;
        }

        public void AddPoint()
        {
            _points += 1;
        }

        public int GetPoints()
        {
            return _points;
        }

        public string GetRes()
        {
            return _pointMap[_points];
        }

        public void CheckEqualRes(Player p2)
        {
            if (_points == p2.GetPoints() && _points < 4)
            {
                _score = _pointMap[_points];
                _score += "-All";
            }
        }

        public void CheckDeuce(Player p2)
        {
            if (_points == p2.GetPoints() && _points >= 3)
                _score = "Deuce";
        }

        public void CheckAdvantage(Player p2)
        {
            if (_points > p2.GetPoints() && p2.GetPoints() >= 3)
            {
                _score = $"Advantage {Name}";
            }

            if (p2.GetPoints() > _points && _points >= 3)
            {
                _score = $"Advantage {p2.Name}";
            }
        }

        public void CheckUnequalScore(Player p2)
        {
            var p2Point = p2.GetPoints();
            if ((_points > 0 || p2Point > 0) && (p2Point == 0 || _points == 0) && _points < 4 && p2Point < 4
                || _points > p2Point && _points < 4
                || p2Point > _points && p2Point < 4)
            {
                _score += GetRes() + "-" + p2.GetRes();
            }
        }

        public void CheckWinner(Player p2)
        {
            var p2Point = p2.GetPoints();
            if (_points >= 4 && p2Point >= 0 && (_points - p2Point) >= 2)
            {
                _score = $"Win for {Name}";
            }

            if (p2Point >= 4 && _points >= 0 && (p2Point - _points) >= 2)
            {
                _score = $"Win for {p2.Name}";
            }
        }

        public string GetFinalScore()
        {
            return _score;
        }
    }
}