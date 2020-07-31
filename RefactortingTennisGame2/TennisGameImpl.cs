using System.Collections.Generic;
using System.Globalization;

namespace RefactortingTennisGame2
{
    public class TennisGameImpl : ITennisGame
    {
        private string _p1Res = "";
        private string _p2Res = "";
        private Player _player1;
        private Player _player2;

        public TennisGameImpl(string player1, string player2)
        {
            _player1 = new Player(player1);
            _player2 = new Player(player2);
        }

        public string GetScore()
        {
            var p1Point = _player1.GetPoints();
            var p2Point = _player2.GetPoints();
            
            string score = "";
            score = _player1.GetEqualRes(p2Point);

            if (p1Point == p2Point && p1Point >= 3)
                score = "Deuce";

            if ((p1Point > 0 || p2Point > 0) && (p2Point == 0 || p1Point == 0) && p1Point < 4 && p2Point < 4
                || p1Point > p2Point && p1Point < 4 
                || p2Point > p1Point && p2Point < 4)
            {
                _p1Res = _player1.GetRes();
                _p2Res = _player2.GetRes();
                score = _p1Res + "-" + _p2Res;
            }
            
            
            if (p1Point > p2Point && p2Point >= 3)
            {
                score = $"Advantage {_player1.Name}";
            }

            if (p2Point > p1Point && p1Point >= 3)
            {
                score = $"Advantage {_player2.Name}";
            }

            if (p1Point >= 4 && p2Point >= 0 && (p1Point - p2Point) >= 2)
            {
                score = $"Win for {_player1.Name}";
            }

            if (p2Point >= 4 && p1Point >= 0 && (p2Point - p1Point) >= 2)
            {
                score = $"Win for {_player2.Name}";
            }

            return score;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                _player1.AddPoint();
            else
                _player2.AddPoint();
        }
    }
}