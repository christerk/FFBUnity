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
            MainScene,
            SettingsScene,
            LoginScene,
            GameBrowserScene
        }

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Debug.Log("MainHandler Initialized");
            FFB.Instance.Initialize();
            FFB.Instance.RefreshState();
        }

        public void AddReport(Report text)
        {
            FFB.Instance.AddReport(text);
        }

        public void AddChatEntry(string text)
        {
            FFB.Instance.AddChatEntry(FFB.Instance.CoachName, text);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void OnApplicationQuit()
        {
            FFB.Instance.Stop();
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
