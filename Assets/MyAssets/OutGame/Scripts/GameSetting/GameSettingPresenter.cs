using UnityEngine;

namespace Roulette.OutGame
{
    public class GameSettingPresenter : MonoBehaviour, IOutGameWindowUI
    {
        [SerializeField]
        private bool _isAnimation;
        
        public bool IsAnimation => _isAnimation;

        private bool _isSoloPlay;

        public void Initialize(OutGameWindowInfo outGameWindowInfo)
        {
            _isSoloPlay = outGameWindowInfo.IsSoloPlay;
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}
