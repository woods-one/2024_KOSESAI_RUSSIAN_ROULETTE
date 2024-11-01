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
    }
}
