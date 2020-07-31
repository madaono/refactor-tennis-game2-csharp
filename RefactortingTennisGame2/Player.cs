using System.Collections.Generic;

namespace RefactortingTennisGame2
{
    public class Player
    {
        public string Name;
        private int _points = 0;
        
        private Dictionary<int,string> _pointMap = new Dictionary<int, string>()
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

        public string GetEqualRes(int p2Point)
        {
            var score = "";
            if (_points != p2Point || _points >= 4) return score;
            score = GetRes();
            score += "-All";

            return score;
        }
    }
}