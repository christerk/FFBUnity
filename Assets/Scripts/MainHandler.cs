using Fumbbl.Ffb.Dto;
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
            Application.targetFrameRate = 60;
            FFB.Instance.Initialize();
            FFB.Instance.RefreshState();
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
