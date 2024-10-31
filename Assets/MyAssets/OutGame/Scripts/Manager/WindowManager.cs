using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Roulette.OutGame
{
    public enum OutGameWindowType
    {
        ModeSelect,
        GameSetting,
        HowToPlay,
        ItemSwitch
    }
    
    public class WindowManager : MonoBehaviour
    {
        private List<IWindowUI> _openWindows = new ();
        public List<IWindowUI> OpenWindows => _openWindows;
        
        private List<OutGameWindowType> _openWindowTypes = new ();
        public List<OutGameWindowType> OpenWindowTypes => _openWindowTypes;
        
        public OutGameWindowType CurrentWindowType => _openWindowTypes[_openWindows.Count - 1];

        [SerializeField]
        private GameObject _modeSelectPrefab;
        
        private static WindowManager instance;
        public static WindowManager Instance
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

        private async UniTaskVoid Start()
        {
            OpenWindow(OutGameWindowType.ModeSelect);
        }

        public void OpenWindow(OutGameWindowType windowType, bool isSolo = false)
        {
            switch (windowType)
            {
                case OutGameWindowType.ModeSelect:
                    _openWindows.Add(Instantiate(_modeSelectPrefab).GetComponent<IWindowUI>());
                    OpenWindowTypes.Add(OutGameWindowType.ModeSelect);
                    break;
                case OutGameWindowType.GameSetting:
                    OpenWindowTypes.Add(OutGameWindowType.GameSetting);
                    break;
                case OutGameWindowType.ItemSwitch:
                    OpenWindowTypes.Add(OutGameWindowType.ItemSwitch);
                    break;
                case OutGameWindowType.HowToPlay:
                    OpenWindowTypes.Add(OutGameWindowType.HowToPlay);
                    break;
                default:
                    break;
            }
        }
        
        private static void SetupInstance()
        {
            instance = FindObjectOfType<WindowManager>();
	
            if (instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = "WindowManager";
                instance = gameObj.AddComponent<WindowManager>();
                DontDestroyOnLoad(gameObj);
            }
        }
    }
}
