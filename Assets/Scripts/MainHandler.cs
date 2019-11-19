using Fumbbl.Dto;
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
        }

        private void Awake()
        {
            //GameObject[] objs = GameObject.FindGameObjectsWithTag("MainHandler");

            //if (objs.Length > 1)
            //{
            //    Destroy(this.gameObject);
            //} else
            //{
            Instance = this;
            //}
            //DontDestroyOnLoad(this.gameObject);
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
        }

        public void AddReport(IReport text)
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