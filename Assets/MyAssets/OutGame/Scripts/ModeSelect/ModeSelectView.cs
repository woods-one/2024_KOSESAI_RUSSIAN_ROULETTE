using System.Collections.Generic;
using Roulette.Utility;
using Roulette.Utility.UI;
using UnityEngine;

namespace Roulette.OutGame
{
    /// <summary>
    /// ModeSelectのビュー
    /// </summary>
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

            if (Settings.CanSoloMode == false)
            {
                _buttons[0].SetDisabled(true);
            }
            // _buttons[0].SetDisabled(Settings.CanSoloMode == false); 視認性的にどうだろう
            
            foreach (var _button in _buttons)
            {
                if (_button.IsDisabled == false && _button.IsSelected == false)
                {
                    _button.SetSelected(true);
                    break;
                }
                // _button.SetSelected(_button.IsDisabled == false && _button.IsSelected == false); こっちも
            }
        }

        public void Show()
        {
            foreach (var _button in _buttons)
            {
                _button.Show();
            }
        }
        
        public void Hide()
        {
            foreach (var _button in _buttons)
            {
                _button.Hide();
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
