using R3;
using UnityEngine;

namespace Roulette.OutGame
{
    public class ModeSelectModel
    {
        private readonly ReactiveProperty<int> _modeIndex = new ();
        public ReadOnlyReactiveProperty<int> ModeIndex => _modeIndex;
        
        public const int MAX_MODE = 2;

        public void ChangeRightMode()
        {
            _modeIndex.Value++;

            if (_modeIndex.Value >= MAX_MODE)
            {
                _modeIndex.Value = 0;
            }
        }
        
        public void ChangeLeftMode()
        {
            _modeIndex.Value--;

            if (_modeIndex.Value <=  -1)
            {
                _modeIndex.Value = MAX_MODE;
            }
        }
    }
}
