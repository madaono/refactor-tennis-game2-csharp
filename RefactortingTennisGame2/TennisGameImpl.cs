using System.Collections.Generic;
using System.Globalization;

namespace RefactortingTennisGame2
{
    public class TennisGameImpl : ITennisGame
    {
        private Player _player1;
        private Player _player2;

        public TennisGameImpl(string player1, string player2)
        {
            _player1 = new Player(player1);
            _player2 = new Player(player2);
        }

        public string GetScore()
        {
            _player1.GetEqualRes(_player2);

            _player1.GetDeuce(_player2);

            _player1.GetUnequalScore(_player2);
            
            _player1.GetAdvantage(_player2);

            _player1.GetWinner(_player2);
            
            return _player1.GetFinalScore();
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