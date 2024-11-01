using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Cysharp.Threading.Tasks;
using Roulette.Utility.UI.Interface;
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
        private List<IOutGameWindowUI> _openedWindows = new ();
        public List<IOutGameWindowUI> OpenedWindows => _openedWindows;
        
        private List<GameObject> _openedObjects = new ();
        public List<GameObject> OpenedObjects => _openedObjects;
        
        private List<OutGameWindowType> _openedWindowTypes = new ();
        public List<OutGameWindowType> OpenedWindowTypes => _openedWindowTypes;
        
        public OutGameWindowType CurrentWindowType => _openedWindowTypes[_openedWindows.Count - 1];

        [SerializeField]
        private GameObject _modeSelectPrefab;
        [SerializeField]
        private GameObject _gameSettingPrefab;
        
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
            OpenWindow(OutGameWindowType.GameSetting,new OutGameWindowInfo(false));
        }

        public void OpenWindow(OutGameWindowType windowType, OutGameWindowInfo outGameWindowInfo = null)
        {
            GameObject inst = null;
            IOutGameWindowUI instWin = null;
            switch (windowType)
            { 
                case OutGameWindowType.ModeSelect:
                    inst = Instantiate(_modeSelectPrefab);
                    _openedObjects.Add(inst);
                    
                    instWin = inst.GetComponent<IOutGameWindowUI>();
                    _openedWindows.Add(instWin);
                    
                    OpenedWindowTypes.Add(OutGameWindowType.ModeSelect);
                    HidePreviousWindow();
                    
                    instWin.Initialize(outGameWindowInfo);
                    break;
                case OutGameWindowType.GameSetting:
                    inst = Instantiate(_gameSettingPrefab);
                    _openedObjects.Add(inst);
                    
                    instWin = inst.GetComponent<IOutGameWindowUI>();
                    _openedWindows.Add(instWin);
                    
                    OpenedWindowTypes.Add(OutGameWindowType.GameSetting);
                    HidePreviousWindow();
                    
                    instWin.Initialize(outGameWindowInfo);
                    break;
                case OutGameWindowType.ItemSwitch:
                    OpenedWindowTypes.Add(OutGameWindowType.ItemSwitch);
                    HidePreviousWindow();
                    break;
                case OutGameWindowType.HowToPlay:
                    OpenedWindowTypes.Add(OutGameWindowType.HowToPlay);
                    HidePreviousWindow();
                    break;
                default:
                    break;
            }
        }

        private void HidePreviousWindow()
        {
            if (_openedWindows.Count - 2 >= 0)
            {
                _openedWindows[_openedWindows.Count - 2].Hide();
            }
        }

        public void BackPreviousWindow()
        {
            if (_openedWindows.Count - 2 < 0)
            {
                //タイトルに戻る
            }
            else
            {
                _openedWindows.RemoveAt(_openedWindows.Count - 1);
                
                _openedWindowTypes.RemoveAt(_openedWindowTypes.Count - 1);
                
                Destroy(_openedObjects[_openedObjects.Count - 1]);
                
                Debug.Log(_openedObjects[_openedWindows.Count - 1].name);
                
                _openedWindows[_openedWindows.Count - 1].Show();
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
