using Roulette.Utility.UI.Interface;
using UnityEngine;

namespace Roulette.OutGame
{
    public class GameSettingPresenter : MonoBehaviour, IOutGameWindowUI
    {
        [SerializeField]
        private bool _isAnimation;
        
        public bool IsAnimation => _isAnimation;

        private bool _isSoloPlay;
        
        private GameSettingModel _model;
        
        [SerializeField]
        private GameSettingView _view;

        public void Initialize(OutGameWindowInfo outGameWindowInfo)
        {
            _isSoloPlay = outGameWindowInfo.IsSoloPlay;
            
            _view.Initialize(_isSoloPlay);
            
        }

        public void Show()
        {
            
        }

        public void Hide()
        {
            
        }
    }
}
