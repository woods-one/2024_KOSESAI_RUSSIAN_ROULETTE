using R3;
using R3.Triggers;
using UnityEngine;

namespace Roulette.Utility.Inputs
{
    /// <summary>
    /// アウトゲームの入力検知
    /// </summary>
    public class GameInput : MonoBehaviour,IGameInputEventProvider
    {
        private ReactiveProperty<bool> _rightButton = new ();
        private ReactiveProperty<bool> _leftButton = new ();
        private ReactiveProperty<bool> _upButton = new ();
        private ReactiveProperty<bool> _downButton = new ();
        private ReactiveProperty<bool> _cancelButton = new ();
        private ReactiveProperty<bool> _decideButton = new ();
        private ReactiveProperty<bool> _anyButton = new ();
        

        public ReadOnlyReactiveProperty<bool> RightButton
        {
            get { return _rightButton; }
        }

        public ReadOnlyReactiveProperty<bool> UpButton
        {
            get { return _upButton; }
        }
        
        public ReadOnlyReactiveProperty<bool> DownButton
        {
            get { return _downButton; }
        }
        
        public ReadOnlyReactiveProperty<bool> LeftButton
        {
            get { return _leftButton; }
        }

        public ReadOnlyReactiveProperty<bool> CancelButton
        {
            get { return _cancelButton; }
        }

        public ReadOnlyReactiveProperty<bool> DecideButton
        {
            get { return _decideButton; }
        }

        public ReadOnlyReactiveProperty<bool> AnyButton
        {
            get { return _anyButton; }
        }
        
        private static GameInput _instance;

        public static GameInput Instance
        {
            get
            {
                if (_instance == null)
                {
                    SetupInstance();
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start()
        {
            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.RightArrow))
                .DistinctUntilChanged()
                .Subscribe(x => _rightButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.LeftArrow))
                .DistinctUntilChanged()
                .Subscribe(x => _leftButton.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.UpArrow))
                .DistinctUntilChanged()
                .Subscribe(x => _upButton.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.DownArrow))
                .DistinctUntilChanged()
                .Subscribe(x => _downButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.D))
                .DistinctUntilChanged()
                .Subscribe(x => _decideButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.S))
                .DistinctUntilChanged()
                .Subscribe(x => _cancelButton.Value = x);
            
            this.UpdateAsObservable()
                .Select(_ => Input.anyKeyDown)
                .DistinctUntilChanged()
                .Subscribe(x => _anyButton.Value = x);
        }
        
        private static void SetupInstance()
        {
            _instance = FindObjectOfType<GameInput>();
	
            if (_instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = "GameInput";
                _instance = gameObj.AddComponent<GameInput>();
                DontDestroyOnLoad(gameObj);
            }
        }
    }
}
