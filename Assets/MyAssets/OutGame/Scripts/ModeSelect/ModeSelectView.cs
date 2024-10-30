using System.Collections.Generic;
using Roulette.Utility;
using Roulette.Utility.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Roulette.OutGame
{
    public class ModeSelectView : MonoBehaviour
    {
        [SerializeField]
        private List<RouletteButton> _buttons = new ();

        //TODO:そのうちInitializeにする
        private void Start()
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
    }
}
