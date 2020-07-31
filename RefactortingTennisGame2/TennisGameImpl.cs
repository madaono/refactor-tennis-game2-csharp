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
            _player1.CheckEqualRes(_player2);

            _player1.CheckDeuce(_player2);

            _player1.CheckUnequalScore(_player2);
            
            _player1.CheckAdvantage(_player2);

            _player1.CheckWinner(_player2);
            
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