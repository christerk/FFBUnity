using Cinemachine;
using Fumbbl.Ffb.Dto;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fumbbl
{
    public class MainHandler : MonoBehaviour
    {
        public static MainHandler Instance;

        public enum SceneType
        {
            None,
            ConnectScene,
            MainScene,
            SettingsScene,
            LoginScene,
            GameBrowserScene
        }

        #region MonoBehaviour Methods

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            LogManager.Debug("MainHandler Initialized");
            Application.targetFrameRate = 75;
            FFB.Instance.Initialize();
            FFB.Instance.RefreshState();

            if (FFB.Instance.ActionInjector is null)
            {
                var obj = new GameObject("ActionInjector");
                obj.AddComponent(Type.GetType("ActionInjectorHandler"));
            }

            // Disable GUI Layout for cinemachine. Gets rid of 368B of GC alloc per frame
            var cinemachine = Camera.main.GetComponent<CinemachineBrain>();
            if (cinemachine != null) {
                cinemachine.useGUILayout = false;
            }
        }

        private void OnApplicationQuit()
        {
            FFB.Instance.Stop();
        }

        #endregion

        public void AddChatEntry(string text)
        {
            _ = FFB.Instance.Network.Send(new ClientTalk() { talk = text });
        }

        public void AddReport(Report text)
        {
            FFB.Instance.AddReport(text);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void SetScene(SceneType scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }

        internal void SetScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
