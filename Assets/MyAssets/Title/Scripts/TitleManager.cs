using R3;
using Roulette.Utility.Inputs;
using Roulette.Utility.Scenes;
using UnityEngine;

namespace Roulette.Title
{
    public class TitleManager : MonoBehaviour
    {
        private bool _pressAnyKey = false;
        
        private void Start()
        {
            _pressAnyKey = false;
            Bind();
        }

        private void Bind()
        {
            GameInput.Instance.AnyButton
                .Skip(1)
                .Where(_ => !_pressAnyKey)
                .Subscribe(_ =>
                {
                    _pressAnyKey = true;
                    
                    SceneLoader.Instance.LoadScene(Scenes.OutGame);
                });
        }
    }
}
