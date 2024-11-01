using Roulette.Utility;
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
        
        public void Initialize(bool isSoloPlay)
        {
            SetMode(isSoloPlay);
        }

        private void SetMode(bool isSoloPlay)
        {
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
    }
}
