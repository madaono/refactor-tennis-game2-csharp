namespace RefactortingTennisGame2
{
    public class Player
    {
        public string Name;
        private int _points = 0;

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
    }
}