using R3;
using UnityEngine;
using Roulette.Utility;

namespace Roulette.OutGame
{
    public class ModeSelectModel
    {
        private readonly ReactiveProperty<int> _modeIndex = new ();
        public ReadOnlyReactiveProperty<int> ModeIndex => _modeIndex;

        public void ChangeRightMode()
        {
            _modeIndex.Value++;

            if (_modeIndex.Value >= RouletteConst.MAX_MODE)
            {
                _modeIndex.Value = 0;
            }
        }
        
        public void ChangeLeftMode()
        {
            _modeIndex.Value--;

            if (_modeIndex.Value <=  -1)
            {
                _modeIndex.Value = RouletteConst.MAX_MODE;
            }
        }
    }
}
