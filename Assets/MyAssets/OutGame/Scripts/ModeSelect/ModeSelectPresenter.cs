using System.Threading;
using Cysharp.Threading.Tasks;
using Roulette.Utility.Inputs;
using R3;
using UnityEngine;

namespace Roulette.OutGame
{
    /// <summary>
    /// ModeSelectのプレゼンター
    /// </summary>
    public class ModeSelectPresenter : MonoBehaviour, IOutGameWindowUI
    {
        private ModeSelectModel _model;
        
        [SerializeField]
        private ModeSelectView _view;
        
        private bool _canChangeMode;

        [SerializeField]
        private bool _isAnimation;
        
        public bool IsAnimation => _isAnimation;
        
        OutGameWindowType _windowType = OutGameWindowType.ModeSelect;
        
        public void Initialize(OutGameWindowInfo outGameWindowInfo = null)
        {
            _model = new ModeSelectModel();
            _view.Initialize();
            _canChangeMode = true;
            Bind();
            _model.SetIndex(0);
        }

        void Bind()
        {
            _model.ModeIndex
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(x =>
                {
                    if (_view.SelectButton(x))
                    {
                        if (_model.MoveRight)
                        {
                            _model.ChangeRightMode();
                        }
                        else
                        {
                            _model.ChangeLeftMode();
                        }
                    }
                }).AddTo(this);
            
            OutGameInput.Instance.RightButton
                .Skip(1)
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(_ =>
                {
                    if (_canChangeMode)
                    {
                        _model.ChangeRightMode();
                        CanChangeMode().Forget();
                    }
                }).AddTo(this);
            
            OutGameInput.Instance.LeftButton
                .Skip(1)
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(_ =>
                {
                    if (_canChangeMode)
                    {
                        _model.ChangeLeftMode();
                        CanChangeMode().Forget();
                    }
                }).AddTo(this);
        }

        async UniTask CanChangeMode()
        {
            _canChangeMode = false;
            await UniTask.Delay(100 , cancellationToken: new CancellationToken());
            _canChangeMode = true;
        }

        public void Show()
        { 
            _view.Show();
        }
        
        public void Hide()
        {
            _view.Hide();
        }
    }
}
