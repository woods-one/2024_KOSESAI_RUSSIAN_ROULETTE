using UnityEngine;

namespace Roulette.OutGame
{
    public class GameSettingPresenter : MonoBehaviour, IOutGameWindowUI
    {
        [SerializeField]
        private bool _isAnimation;
        
        public bool IsAnimation => _isAnimation;

        public void Initialize(OutGameWindowInfo outGameWindowInfo)
        {
            
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}
