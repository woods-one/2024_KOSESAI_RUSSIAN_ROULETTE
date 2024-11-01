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

            _model = new GameSettingModel(_isSoloPlay);
            _view.Initialize(_isSoloPlay);
            
            Bind();
        }
        
        void Bind()
        {
            _model.Index
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType)
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

            _model.SelectLifeNum
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(x =>
                {
                    _view.SetStepperText(x,true);
                    CanChangeMode().Forget();
                }).AddTo(this);
            
            _model.SelectPlayNum
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(x =>
                {
                    _view.SetStepperText(x,false);
                    CanChangeMode().Forget();
                }).AddTo(this);
            
            _model.UseItem
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType)
                .Subscribe(x =>
                {
                    _view.SetCheckUseItem(x);
                    CanChangeMode().Forget();
                }).AddTo(this);
            
            GameInput.Instance.DownButton
                .Skip(1)
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType && _canMove)
                .Subscribe(_ =>
                {
                    _model.SelectDown();
                    CanChangeMode().Forget();
                }).AddTo(this);
            
            GameInput.Instance.UpButton
                .Skip(1)
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType && _canMove)
                .Subscribe(_ =>
                {
                    _model.SelectUp();
                    CanChangeMode().Forget();
                }).AddTo(this);
            
            GameInput.Instance.RightButton
                .Skip(1)
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType && _canMove)
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
                        
                        CanChangeMode().Forget();
                    }
                }).AddTo(this);
            
            GameInput.Instance.LeftButton
                .Skip(1)
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType && _canMove)
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
                        
                        CanChangeMode().Forget();
                    }
                }).AddTo(this);
            
            GameInput.Instance.DecideButton
                .Skip(1)
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType && _canMove)
                .Subscribe(_ =>
                {
                    if (_view.Parts[_model.Index.CurrentValue].GetType() == typeof(RouletteCheckBox))
                    {
                        _model.SetUseItem();
                        
                        CanChangeMode().Forget();
                    }
                }).AddTo(this);
            
            GameInput.Instance.CancelButton
                .Skip(1)
                .Where(_ => OutGameManager.Instance.CurrentWindowType == _windowType && _canMove)
                .Subscribe(_ =>
                {
                    OutGameManager.Instance.BackPreviousWindow();
                    CanChangeMode().Forget();
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
