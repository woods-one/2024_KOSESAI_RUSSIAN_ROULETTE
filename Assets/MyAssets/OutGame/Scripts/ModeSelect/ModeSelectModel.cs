using R3;
using Roulette.Utility;
using UnityEngine;

namespace Roulette.OutGame
{
    public class ModeSelectModel
    {
        private readonly ReactiveProperty<int> _modeIndex = new ();
        public ReadOnlyReactiveProperty<int> ModeIndex => _modeIndex;

        private bool _moveRight;
        public bool MoveRight => _moveRight;

        public ModeSelectModel()
        {
            _moveRight = true;
            _modeIndex.Value = 0;
        }

        public void ChangeRightMode()
        {
            _modeIndex.Value++;

            if (_modeIndex.Value >= RouletteConst.MAX_MODE)
            {
                _modeIndex.Value = 0;
            }
            
            _moveRight = true;
        }
        
        public void ChangeLeftMode()
        {
            _modeIndex.Value--;

            if (_modeIndex.Value <=  -1)
            {
                _modeIndex.Value = RouletteConst.MAX_MODE - 1;
            }

            _moveRight = false;
        }
    }
}
