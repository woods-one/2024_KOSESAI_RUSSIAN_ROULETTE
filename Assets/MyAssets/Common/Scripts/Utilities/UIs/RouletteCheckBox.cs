using System.Collections;
using System.Collections.Generic;
using Roulette.Utility.UI.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Roulette.Utility.UI
{
    public class RouletteCheckBox : MonoBehaviour,IOutGameWindowParts
    {
        [SerializeField]
        private Image _mainImage;
        public Image MainImage => _mainImage;

        [SerializeField]
        private Image _selectImage;
        public Image SelectImage => _selectImage;
        
        [SerializeField]
        private Image _disabledImage;
        
        [SerializeField]
        private Image _checkedImage;
        
        [SerializeField]
        private bool _useSelectedAnimation;
        public bool UseSelectedAnimation => _useSelectedAnimation;

        private bool _isChecked;
        public bool IsChecked => _isChecked;
        
        private bool _isSelected;
        public bool IsSelected => _isSelected;
        
        private bool _isDisabled;
        public bool IsDisabled => _isDisabled;

        public void Initialize()
        {
            _isSelected = false;

            _isDisabled = false;
            
            _isChecked = Settings.UseItemDefault;
            
            _disabledImage.gameObject.SetActive(false);

            SetSelected(false);
        }

        public void SetChecked(bool isChecked)
        {
            _isChecked = isChecked;
            
            _checkedImage.gameObject.SetActive(_isChecked);
        }

        public void Show()
        {
            _mainImage.gameObject.SetActive(true);
            _checkedImage.gameObject.SetActive(_isChecked);
            _selectImage.gameObject.SetActive(_isSelected);
            _disabledImage.gameObject.SetActive(_isDisabled);
        }

        public void Hide()
        {
            _mainImage.gameObject.SetActive(false);
            _checkedImage.gameObject.SetActive(false);
            _selectImage.gameObject.SetActive(false);
            _disabledImage.gameObject.SetActive(false);
        }

        public void SetSelected(bool isSelected)
        {
            if (isSelected)
            {
                _mainImage.color = RouletteConst.MainColor;
            }
            else
            {
                _mainImage.color = RouletteConst.UnSelectedColor;
            }
            
            _isSelected = isSelected;
            _selectImage.gameObject.SetActive(isSelected);
        }

        public void SetDisabled(bool isDisabled)
        {
            _isDisabled = isDisabled;
            _disabledImage.gameObject.SetActive(isDisabled);
        }
    }
}
