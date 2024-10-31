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
    public class ModeSelectPresenter : MonoBehaviour
    {
        private ModeSelectModel _model;
        
        [SerializeField]
        private ModeSelectView _view;
        
        private bool _canChangeMode;
        
        void Start()
        {
            _model = new ModeSelectModel();
            _view.Initialize();
            _canChangeMode = true;
            Bind();
        }

        void Bind()
        {
            _model.ModeIndex.Subscribe(x =>
            {
                Debug.Log(x);
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
                .Subscribe(x =>
                {
                    if (_canChangeMode)
                    {
                        _model.ChangeRightMode();
                        CanChangeMode().Forget();
                    }
                });
            
            OutGameInput.Instance.LeftButton
                .Skip(1)
                .Subscribe(x =>
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
