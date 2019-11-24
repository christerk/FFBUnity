using Fumbbl.Ffb.Dto;
using System.Collections;
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
        }

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Debug.Log("MainHandler Initialized");
            StartCoroutine(DeferredInit());
        }

        private IEnumerator DeferredInit()
        {
            yield return null;
            yield return null;
            FFB.Instance.Initialize();
            yield return null;
            FFB.Instance.RefreshState();

            while (FFB.Instance.Network.IsConnected)
            {
                yield return new WaitForSeconds(2);
                FFB.Instance.Network.SendPing();
            }
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
    }
}