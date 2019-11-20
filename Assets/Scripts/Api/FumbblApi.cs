﻿using Fumbbl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using UnityEngine;


public class FumbblApi
{
    private string accessToken;
    public void Auth()
    {
        string clientId = PlayerPrefs.GetString("OAuth.ClientId");
        string clientSecret = PlayerPrefs.GetString("OAuth.ClientSecret");

        string result = Post("oauth", "token", new Dictionary<string, string>()
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = clientId,
            ["client_secret"] = clientSecret
        });

        Api.Dto.Auth.Token token = JsonConvert.DeserializeObject<Api.Dto.Auth.Token>(result);
       
        accessToken = token.access_token;

        result = Get("oauth", "identity");
        int coachId = int.Parse(result);

        result = Get("coach", $"get/{coachId}");
        Api.Dto.Coach.Get coach = JsonConvert.DeserializeObject<Api.Dto.Coach.Get>(result);
        FFB.Instance.SetCoachName(coach.name);
    }

    public string GetToken()
    {
        string token = JsonConvert.DeserializeObject<string>(Post("auth", "getToken"));
        return token;
    }

    public List<Api.Dto.Match.Current> GetCurrentMatches()
    {
        return JsonConvert.DeserializeObject<List<Api.Dto.Match.Current>>(Get("match", "current"));
    }

    private string Get(string component, string endpoint)
    {
        WebClient client = new WebClient();
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
        return null;
    }

    private string Post(string component, string endpoint, Dictionary<string, string> data = null)
    {
        WebClient client = new WebClient();
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
        return null;
    }

}