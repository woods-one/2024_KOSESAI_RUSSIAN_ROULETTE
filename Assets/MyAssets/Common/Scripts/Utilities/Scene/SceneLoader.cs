using Roulette.InGame;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Roulette.Utility.Scenes
{
    public enum Scenes
    {
        Title,
        OutGame,
        InGame
    }
    public class SceneLoader : MonoBehaviour
    {
        private InGameData _inGameData = new InGameData(Settings.MinLife, Settings.SoloPlayer, Settings.UseItemDefault);
        public InGameData InGameData => _inGameData;
        
        private static SceneLoader _instance;

        public static SceneLoader Instance
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

        private static void SetupInstance()
        {
            _instance = FindObjectOfType<SceneLoader>();

            if (_instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = "Singleton";
                _instance = gameObj.AddComponent<SceneLoader>();
                DontDestroyOnLoad(gameObj);
            }
        }

        public void LoadScene(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }

        public void SetInGameData(InGameData inGameData)
        {
            _inGameData = inGameData;
        }
    }
}
