using R3;
using Roulette.Utility;

namespace Roulette.OutGame
{
    /// <summary>
    /// ModeSelectのモデル
    /// </summary>
    public class ModeSelectModel
    {
        private readonly ReactiveProperty<int> _modeIndex = new ();
        public ReadOnlyReactiveProperty<int> ModeIndex => _modeIndex;

        private bool _moveRight;
        public bool MoveRight => _moveRight;

        public ModeSelectModel()
        {
            _moveRight = true;
        }

        public void ChangeRightMode()
        {
            if (_modeIndex.Value + 1 >= Settings.MaxMode)
            {
                _modeIndex.Value = 0;
            }
            else
            {
                _modeIndex.Value++;
            }
            
            _moveRight = true;
        }
        
        public void ChangeLeftMode()
        {
            if (_modeIndex.Value - 1 <=  -1)
            {
                _modeIndex.Value = Settings.MaxMode - 1;
            }
            else
            {
                _modeIndex.Value--;
            }

            _moveRight = false;
        }

        public void SetIndex(int modeIndex)
        {
            _modeIndex.Value = modeIndex;
        }
    }
}
