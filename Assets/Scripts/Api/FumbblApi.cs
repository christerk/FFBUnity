using Fumbbl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

using ApiDto = Fumbbl.Api.Dto;


public class FumbblApi
{
    private string accessToken;

    public bool Auth(string clientId, string clientSecret)
    {
        string result = Post("oauth", "token", new Dictionary<string, string>()
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = clientId,
            ["client_secret"] = clientSecret
        });

        ApiDto.Auth.Token token = JsonConvert.DeserializeObject<ApiDto.Auth.Token>(result);

        accessToken = token.access_token;

        try
        {
            result = Get("oauth", "identity");
            int coachId = int.Parse(result);

            result = Get("coach", $"get/{coachId}");
            ApiDto.Coach.Get coach = JsonConvert.DeserializeObject<ApiDto.Coach.Get>(result);
            FFB.Instance.SetCoachName(coach.name);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private string Get(string component, string endpoint)
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                if (accessToken != null)
                {
                    client.Headers.Add("authorization", $"Bearer {accessToken}");
                }

                string result = client.DownloadString($"https://fumbbl.com/api/{component}/{endpoint}");
                return result;
            }
            catch (Exception e)
            {
                Debug.Log($"Error during API access {e.Message}");
            }
        }
        return null;
    }

    public List<ApiDto.Match.Current> GetCurrentMatches()
    {
        return JsonConvert.DeserializeObject<List<ApiDto.Match.Current>>(Get("match", "current"));
    }

    public static async void GetImage(string url, Image target)
    {
        Sprite s = await FFB.Instance.SpriteCache.GetAsync(url);
        FFB.Instance.ExecuteOnMainThread(
            () =>
            {
                if(!target.IsDestroyed())
                {
                    target.sprite = s;
                }
            }
        );
    }

    public static async Task<Sprite> GetSpriteAsync(string url)
    {
        Texture2D img = new Texture2D(1,1);
        try
        {
            using (var client = new WebClient())
            {
                var data = await client.DownloadDataTaskAsync("https://fumbbl.com/" + url);
                img.LoadImage(data);
            }
        }
        catch (WebException ex)
        {
            HttpWebResponse resp = ex.Response as HttpWebResponse;
            if (resp == null)
            {
                Debug.LogWarning($"Failed to download: \"{url}\" Due to exception: {ex}");
                return null;
            }
            else
            {
                Debug.LogWarning($"Failed to download ({(int)resp.StatusCode}, {resp.StatusCode}): \"{url}\"");
                return null;
            }
        }
        Sprite s = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f), 1f, 0, SpriteMeshType.FullRect);
        s.name = url;
        return s;
    }

    public string GetToken()
    {
        string token = JsonConvert.DeserializeObject<string>(Post("auth", "getToken"));
        return token;
    }

    internal bool Login(string uid, string pwd)
    {
        string result = Post("oauth", "createApplication", new Dictionary<string, string>()
        {
            ["c"] = uid,
            ["p"] = pwd
        });

        JObject obj = JObject.Parse(result);
        if (obj["client_id"] != null && obj["client_secret"] != null)
        {
            PlayerPrefs.SetString("OAuth.ClientId", obj["client_id"].ToString());
            PlayerPrefs.SetString("OAuth.ClientSecret", obj["client_secret"].ToString());
            return true;
        }

        return false;
    }

    private string Post(string component, string endpoint, Dictionary<string, string> data = null)
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                if (accessToken != null)
                {
                    client.Headers.Add("authorization", $"Bearer {accessToken}");
                }

                NameValueCollection values = new NameValueCollection();
                if (data != null)
                {
                    foreach (var pair in data)
                    {
                        values.Add(pair.Key, pair.Value);
                    }
                }

                string url = $"https://fumbbl.com/api/{component}/{endpoint}";

                Debug.Log(url);

                byte[] result = client.UploadValues(url, "POST", values);

                return UTF8Encoding.UTF8.GetString(result);
            }
            catch (Exception e)
            {
                Debug.Log($"Error during API access {e.Message}");
            }
        }
        return null;
    }
}
