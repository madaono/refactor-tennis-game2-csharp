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
            score += _player1.GetEqualRes(p2Point);

            score = _player1.GetDeuce(p2Point);

            _player1.GetUnequalScore(_player2);
            
            
            score = _player1.GetAdvantage(_player2);

            score = _player1.GetWinner(_player2);
            
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