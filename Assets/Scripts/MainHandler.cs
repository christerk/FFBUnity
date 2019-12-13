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

        private void OnApplicationQuit()
        {
            FFB.Instance.Stop();
        }

        private void Start()
        {
            Debug.Log("MainHandler Initialized");
            FFB.Instance.Initialize();
            FFB.Instance.RefreshState();
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

        internal void SetScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void SetScene(SceneType scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}
