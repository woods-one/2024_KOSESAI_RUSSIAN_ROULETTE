using Roulette.Utility.UI.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Roulette.Utility.UI
{
    public class RouletteStepper : MonoBehaviour, IOutGameWindowParts
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
        private bool _useSelectedAnimation;
        public bool UseSelectedAnimation => _useSelectedAnimation;
        
        [SerializeField]
        private Image _rightImage;
        
        [SerializeField]
        private Image _leftImage;
        
        [SerializeField]
        private Text _infoText;
        
        private bool _isSelected;
        public bool IsSelected => _isSelected;
        
        private bool _isDisabled;
        public bool IsDisabled => _isDisabled;

        public void Initialize()
        {
            _isSelected = false;

            _isDisabled = false;
            
            _disabledImage.gameObject.SetActive(false);

            SetSelected(false);
        }

        public void SetText(string text)
        {
            _infoText.text = text;
        }

        public void SetCantMoveColor(bool isRight)
        {
            if (isRight)
            {
                _rightImage.color = RouletteConst.CantMoveColor;
            }
            else
            {
                _leftImage.color = RouletteConst.CantMoveColor;
            }
        }

        public void SetCanMoveColor()
        {
            _rightImage.color = RouletteConst.CanMoveColor;
            _leftImage.color = RouletteConst.CanMoveColor;
        }

        public void Show()
        {
            _mainImage.gameObject.SetActive(true);
            _rightImage.gameObject.SetActive(true);
            _leftImage.gameObject.SetActive(true);
            _infoText.gameObject.SetActive(true);
            _selectImage.gameObject.SetActive(_isSelected);
            _disabledImage.gameObject.SetActive(_isDisabled);
        }

        public void Hide()
        {
            _mainImage.gameObject.SetActive(false);
            _rightImage.gameObject.SetActive(false);
            _leftImage.gameObject.SetActive(false);
            _infoText.gameObject.SetActive(false);
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