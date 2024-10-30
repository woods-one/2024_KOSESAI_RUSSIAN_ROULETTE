using R3;
using R3.Triggers;
using UnityEngine;

namespace Roulette.Utility.Inputs
{
    public class OutGameInput : MonoBehaviour,IOutGameInputEventProvider
    {
        private ReactiveProperty<bool> _rightButton = new ();
        private ReactiveProperty<bool> _leftButton = new ();
        private ReactiveProperty<bool> _cancelButton = new ();
        private ReactiveProperty<bool> _decideButton = new ();

        public ReadOnlyReactiveProperty<bool> RightButton
        {
            get { return _rightButton; }
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
        
        private static OutGameInput instance;
        public static OutGameInput Instance
        {
            get
            {
                if (instance == null)
                {
                    SetupInstance();
                }
                return instance;
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
                .Select(_ => Input.GetKeyDown(KeyCode.D))
                .DistinctUntilChanged()
                .Subscribe(x => _decideButton.Value = x);

            this.UpdateAsObservable()
                .Select(_ => Input.GetKeyDown(KeyCode.S))
                .DistinctUntilChanged()
                .Subscribe(x => _cancelButton.Value = x);
        }
        
        private static void SetupInstance()
        {
            instance = FindObjectOfType<OutGameInput>();
	
            if (instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = "OutGameInput";
                instance = gameObj.AddComponent<OutGameInput>();
                DontDestroyOnLoad(gameObj);
            }
        }
    }
}