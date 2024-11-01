using R3;
using Roulette.Utility;

namespace Roulette.OutGame
{
    public class GameSettingModel
    {
        private readonly ReactiveProperty<int> _index = new ();
        public ReadOnlyReactiveProperty<int> Index => _index;

        private bool _moveDown;
        public bool MoveDown => _moveDown;

        private ReactiveProperty<int> _selectPlayNum = new ();
        public ReadOnlyReactiveProperty<int> SelectPlayNum => _selectPlayNum;
        
        private ReactiveProperty<int> _selectLifeNum = new ();
        public ReadOnlyReactiveProperty<int> SelectLifeNum => _selectLifeNum;
        
        private ReactiveProperty<bool> _useItem = new ();
        public ReadOnlyReactiveProperty<bool> UseItem => _useItem;

        public GameSettingModel(bool soloPlay)
        {
            _moveDown = true;
            if (soloPlay)
            {
                _selectPlayNum.Value = Settings.SoloPlayer;
            }
            else
            {
                _selectPlayNum.Value = Settings.MinMultiPlayers;
            }
            _selectLifeNum.Value = Settings.MinLife;
        }

        public void AddPlayNum()
        {
            if (_selectPlayNum.Value + 1 > Settings.MaxMultiPlayers)return;
            
            _selectPlayNum.Value++;
        }
        
        public void SubtractPlayNum()
        {
            if (_selectPlayNum.Value - 1 < Settings.MinMultiPlayers)return;
            
            _selectPlayNum.Value--;
        }

        public void AddLifeNum()
        {
            if (_selectLifeNum.Value + 1 > Settings.MaxLife)return;
            
            _selectLifeNum.Value++;
        }
        
        public void SubtractLifeNum()
        {
            if (_selectLifeNum.Value - 1 < Settings.MinLife)return;
            
            _selectLifeNum.Value--;
        }

        public void SelectDown()
        {
            if (_index.Value + 1 >= Settings.GameSettingNum)
            {
                _index.Value = 0;
            }
            else
            {
                _index.Value++;
            }
            
            _moveDown = true;
        }
        
        public void SelectUp()
        {
            if (_index.Value - 1 <=  -1)
            {
                _index.Value = Settings.GameSettingNum - 1;
            }
            else
            {
                _index.Value--;
            }

            _moveDown = false;
        }

        public void SetUseItem()
        {
            _useItem.Value = _useItem.Value == false;
        }

        public void SetIndex(int modeIndex)
        {
            _index.Value = modeIndex;
        }
    }
}
