namespace Roulette.InGame
{
    public class InGameData
    {
        private int _lifeNum;
        public int LifeNum => _lifeNum;
            
        private int _playerNum;
        public int PlayerNum => _playerNum;

        private bool _useItem;
        public bool UseItem => _useItem;
        
        public InGameData(int lifeNum, int playerNum, bool useItem)
        {
            _lifeNum = lifeNum;
            _playerNum = playerNum;
            _useItem = useItem;
        }
    }
}