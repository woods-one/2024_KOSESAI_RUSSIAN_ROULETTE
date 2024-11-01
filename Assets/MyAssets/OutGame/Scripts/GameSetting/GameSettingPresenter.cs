using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using Roulette.Utility.Inputs;
using Roulette.Utility.UI;
using Roulette.Utility.UI.Interface;
using UnityEngine;

namespace Roulette.OutGame
{
    public class GameSettingPresenter : MonoBehaviour, IOutGameWindowUI
    {
        [SerializeField]
        private GameSettingView _view;
        
        [SerializeField]
        private bool _isAnimation;
        
        public bool IsAnimation => _isAnimation;

        private bool _isSoloPlay;
        
        private bool _canMove;
        
        private GameSettingModel _model;
        
        OutGameWindowType _windowType = OutGameWindowType.GameSetting;

        public void Initialize(OutGameWindowInfo outGameWindowInfo)
        {
            _isSoloPlay = outGameWindowInfo.IsSoloPlay;
            _canMove = true;

            _model = new GameSettingModel();
            _view.Initialize(_isSoloPlay);
            
            Bind();
        }
        
        void Bind()
        {
            _model.Index
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(x =>
                {
                    if (_view.SelectButton(x))
                    {
                        if (_model.MoveDown)
                        {
                            _model.SelectDown();
                        }
                        else
                        {
                            _model.SelectUp();
                        }
                    }
                }).AddTo(this);
            
            OutGameInput.Instance.DownButton
                .Skip(1)
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(_ =>
                {
                    if (_canMove)
                    {
                        _model.SelectDown();
                        CanChangeMode().Forget();
                    }
                }).AddTo(this);
            
            OutGameInput.Instance.UpButton
                .Skip(1)
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(_ =>
                {
                    if (_canMove)
                    {
                        _model.SelectUp();
                        CanChangeMode().Forget();
                    }
                }).AddTo(this);
            
            OutGameInput.Instance.RightButton
                .Skip(1)
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(_ =>
                {
                    if (_view.Parts[_model.Index.CurrentValue].GetType() == typeof(RouletteStepper))
                    {
                        if (_model.Index.CurrentValue == 0)
                        {
                            _model.AddLifeNum();
                        }
                        else if(_model.Index.CurrentValue == 1)
                        {
                            _model.AddPlayNum();
                        }
                    }
                }).AddTo(this);
            
            OutGameInput.Instance.LeftButton
                .Skip(1)
                .Where(_ => WindowManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(_ =>
                {
                    if (_view.Parts[_model.Index.CurrentValue].GetType() == typeof(RouletteStepper))
                    {
                        if (_model.Index.CurrentValue == 0)
                        {
                            _model.SubtractLifeNum();
                        }
                        else if(_model.Index.CurrentValue == 1)
                        {
                            _model.SubtractPlayNum();
                        }
                    }
                }).AddTo(this);
        }
        
        async UniTask CanChangeMode()
        {
            _canMove = false;
            await UniTask.Delay(100 , cancellationToken: new CancellationToken());
            _canMove = true;
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
