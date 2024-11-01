using R3;
using Roulette.Utility.Inputs;
using Roulette.Utility.Scenes;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Roulette.Title
{
    public class TitleManager : MonoBehaviour
    {
        private bool _pressAnyKey = false;
        
        private async UniTaskVoid Start()
        {
            _pressAnyKey = false;
            
            await UniTask.Delay(2000);
            
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
