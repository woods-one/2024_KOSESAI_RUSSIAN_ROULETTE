using UnityEngine;

namespace Roulette.OutGame
{
    public class GameSettingPresenter : MonoBehaviour, IWindowUI
    {
        [SerializeField]
        private bool _isAnimation;
        
        public bool IsAnimation => _isAnimation;

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}
