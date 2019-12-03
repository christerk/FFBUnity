using Fumbbl;
using Fumbbl.Lib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class ConnectionHandler : MonoBehaviour
{
    private bool connected;
    // Start is called before the first frame update
    void Start()
    {
        FFB.Instance.Initialize();
        connected = false;
    }

    // Update is called once per frame
    async void Update()
    {
        if (!connected)
        {
            var players = FFB.Instance.Model.GetPlayers().ToList();
            if (players.Count > 0)
            {
                // Load player icon sprites.
                connected = true;
                List<Task> tasks = new List<Task>();
                foreach (var player in players)
                {
                    string icon = player.Position.IconURL;

                    tasks.Add(FFB.Instance.SpriteCache.GetAsync(icon));
                }

                await Task.WhenAll(tasks);
                Debug.Log("Loaded Player Icons");
                MainHandler.Instance.SetScene(MainHandler.SceneType.MainScene);
            }
        }
    }
}
