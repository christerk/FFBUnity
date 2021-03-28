using Fumbbl;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ConnectionHandler : MonoBehaviour
{
    public GameObject Progress;

    private RectTransform ProgressRect;
    private bool connected;
    private int IconsToLoad = 0;
    private int progress = 0;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private void Start()
    {
        FFB.Instance.Initialize();
        connected = false;
        IconsToLoad = 0;
        ProgressRect = Progress.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private async void Update()
    {
        if (!connected)
        {
            var players = FFB.Instance.Model.Players;
            if (players.Count > 0)
            {
                // Load player icon sprites.
                connected = true;
                List<Task> tasks = new List<Task>();
                progress = 0;
                HashSet<string> urls = new HashSet<string>();
                foreach (var player in players)
                {
                    string icon = player.Position.IconURL;
                    string portrait = player.PortraitURL ?? player.Position.PortraitURL;

                    urls.Add(icon);
                    urls.Add(portrait);
                }
                
                foreach (var pos in FFB.Instance.Model.Positions)
                {
                    string icon = pos.Value.IconURL;
                    string portrait = pos.Value.PortraitURL;

                    urls.Add(icon);
                    urls.Add(portrait);
                }

                IconsToLoad = urls.Count;
                foreach (var url in urls)
                {
                    tasks.Add(FFB.Instance.SpriteCache.GetAsync(url, s => { Interlocked.Increment(ref progress); }));
                }

                await Task.WhenAll(tasks);
                LogManager.Debug("Loaded Player Icons");
                MainHandler.Instance.SetScene(MainHandler.SceneType.MainScene);
            }
        }

        if (IconsToLoad != 0)
        {
            ProgressRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1665 * progress / IconsToLoad);
            Progress.SetActive(true);
        }
        else
        {
            Progress.SetActive(false);
        }
    }

    #endregion
}
