using System.Collections.Generic;
using Roulette.Utility;
using Roulette.Utility.UI;
using Roulette.Utility.UI.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Roulette.OutGame
{
    public class GameSettingView : MonoBehaviour
    {
        [SerializeField]
        private Image _modeBackgroundImage;
        
        [SerializeField]
        private Text _modeText;
        
        private List<IOutGameWindowParts> _parts = new ();
        public List<IOutGameWindowParts> Parts => _parts;
        
        [SerializeField]
        private List<RouletteButton> _buttons = new ();
        [SerializeField]
        private List<RouletteStepper> _steppers = new ();
        [SerializeField]
        private List<RouletteCheckBox> _checkBoxes = new();
        
        public void Initialize(bool isSoloPlay)
        {
            foreach (var _stepper in _steppers)
            {
                _parts.Add(_stepper);
            }
            foreach (var _checkBox in _checkBoxes)
            {
                _parts.Add(_checkBox);
            }
            foreach (var _button in _buttons)
            {
                _parts.Add(_button);
            }

            foreach (var part in _parts)
            {
                part.Initialize();
            }
            
            SetMode(isSoloPlay);
            
            foreach (var part in _parts)
            {
                if (part.IsDisabled == false && part.IsSelected == false)
                {
                    part.SetSelected(true);
                    break;
                }
            }
        }
        
        public bool SelectButton(int index)
        {
            for (int i = 0; i < _parts.Count; i++)
            {
                _parts[i].SetSelected(i == index);
            }
            
            return _parts[index].IsDisabled;
        }

        private void SetMode(bool isSoloPlay)
        {
            _steppers[1].SetDisabled(isSoloPlay);
            
            if (isSoloPlay)
            {
                _modeBackgroundImage.color = RouletteConst.SoloModeColor;
                _modeText.text = RouletteText.SoloMode;
            }
            else
            {
                _modeBackgroundImage.color = RouletteConst.MultiModeColor;
                _modeText.text = RouletteText.MultiMode;
            }
        }

        public void SetStepperText(int num,bool isLife)
        {
            
            if (isLife)
            {
                _steppers[0].SetCanMoveColor();
                
                _steppers[0].SetText(num.ToString());
                if (num == Settings.MaxLife)
                {
                    _steppers[0].SetCantMoveColor(true);
                }
                else if (num == Settings.MinLife)
                {
                    _steppers[0].SetCantMoveColor(false);
                }
            }
            else
            {
                _steppers[1].SetCanMoveColor();
                
                _steppers[1].SetText(num.ToString());
                if (num == Settings.MaxMultiPlayers)
                {
                    _steppers[1].SetCantMoveColor(true);
                }
                else if (num == Settings.MinMultiPlayers)
                {
                    _steppers[1].SetCantMoveColor(false);
                }
            }
        }

        public void SetCheckUseItem(bool useItem)
        {
            _checkBoxes[0].SetChecked(useItem);
        }
        
        public void Show()
        {
            foreach (var _part in _parts)
            {
                _part.Show();
            }
        }
        
        public void Hide()
        {
            foreach (var _part in _parts)
            {
                _part.Hide();
            }
        }
    }
}
