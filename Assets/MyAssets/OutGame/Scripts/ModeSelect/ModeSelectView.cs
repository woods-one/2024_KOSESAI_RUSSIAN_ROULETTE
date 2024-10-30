using System.Collections.Generic;
using Roulette.Utility;
using Roulette.Utility.UI;
using UnityEngine;

namespace Roulette.OutGame
{
    public class ModeSelectView : MonoBehaviour
    {
        [SerializeField]
        private List<RouletteButton> _buttons = new ();

        public void Initialize()
        {
            foreach (var _button in _buttons)
            {
                _button.Initialize();
            }

            if (Settings.CAN_SOLO_MODE == false)
            {
                _buttons[0].SetDisabled(true);
            }
            
            foreach (var _button in _buttons)
            {
                if (_button.IsDisabled == false && _button.IsSelected == false)
                {
                    _button.SetSelected(true);
                }
            }
        }

        public bool SelectButton(int index)
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].SetSelected(i == index);
            }
            
            return _buttons[index].IsDisabled;
        }
    }
}
