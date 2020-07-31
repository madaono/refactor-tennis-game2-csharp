namespace RefactortingTennisGame2
{
    public class Player
    {
        private string _name;
        private int _points = 0;

        public Player(string name)
        {
            _name = name;
        }

        public void addPoint()
        {
            _points += 1;
        }

        public int getPoint()
        {
            return _points;
        }
    }
}