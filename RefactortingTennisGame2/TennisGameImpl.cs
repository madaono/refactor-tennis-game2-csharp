using System.Collections.Generic;
using System.Globalization;

namespace RefactortingTennisGame2
{
    public class TennisGameImpl : ITennisGame
    {
        private int _p1Point = 0;
        private int _p2Point = 0;

        private string _p1Res = "";
        private string _p2Res = "";
        private Player _player1;
        private Player _player2;

        public TennisGameImpl(string player1, string player2)
        {
            _player1 = new Player(player1);
            _player2 = new Player(player2);
        }
        
        private Dictionary<int,string> _pointMap = new Dictionary<int, string>()
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        public string GetScore()
        {
            string score = "";
            if (_p1Point == _p2Point && _p1Point < 4)
            {
                score = _pointMap[_p1Point];
                score += "-All";
            }

            if (_p1Point == _p2Point && _p1Point >= 3)
                score = "Deuce";

            if (_p1Point > 0 && _p2Point == 0)
            {
                _p1Res = _pointMap[_p1Point];
                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p2Point > 0 && _p1Point == 0)
            {
                _p2Res = _pointMap[_p2Point];

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p1Point < 4)
            {
                _p1Res = _pointMap[_p1Point];
                _p2Res = _pointMap[_p2Point];
                score = _p1Res + "-" + _p2Res;
            }

            if (_p2Point > _p1Point && _p2Point < 4)
            {
                _p1Res = _pointMap[_p1Point];
                _p2Res = _pointMap[_p2Point];
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                score = "Win for player1";
            }

            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                score = "Win for player2";
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