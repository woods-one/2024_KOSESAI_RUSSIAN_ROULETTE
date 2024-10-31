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
    public class ModeSelectPresenter : MonoBehaviour, IWindowUI
    {
        private ModeSelectModel _model;
        
        [SerializeField]
        private ModeSelectView _view;
        
        private bool _canChangeMode;

        private bool _isAnimation;
        
        public bool IsAnimation => _isAnimation;
        
        void Start()
        {
            _model = new ModeSelectModel();
            _view.Initialize();
            _canChangeMode = true;
            Bind();
            _model.SetIndex(0);
        }

        void Bind()
        {
            _model.ModeIndex.Subscribe(x =>
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
            });
            
            OutGameInput.Instance.RightButton
                .Skip(1)
                .Subscribe(_ =>
                {
                    if (_canChangeMode)
                    {
                        _model.ChangeRightMode();
                        CanChangeMode().Forget();
                    }
                });
            
            OutGameInput.Instance.LeftButton
                .Skip(1)
                .Subscribe(_ =>
                {
                    if (_canChangeMode)
                    {
                        _model.ChangeLeftMode();
                        CanChangeMode().Forget();
                    }
                });
        }

        async UniTask CanChangeMode()
        {
            _canChangeMode = false;
            await UniTask.Delay(100 , cancellationToken: new CancellationToken());
            _canChangeMode = true;
        }
    }
}
