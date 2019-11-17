using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Text;
using System;
using Newtonsoft.Json.Linq;
using FUMBBL;
using Fumbbl.Dto;
using Newtonsoft.Json;

public class Networking
{
    static UTF8Encoding encoder = new UTF8Encoding();
    private static readonly TimeSpan delay = TimeSpan.FromMilliseconds(30000);
    private IWebsocket socket;
    private string apiToken;
    private Protocol Protocol;

    // Start is called before the first frame update
    public async Task Connect()
    {
        Protocol = new Protocol(true);
        Debug.Log("Starting Networking");

        socket = new FUMBBL.Websocket(Receive);

        FumbblApi api = new FumbblApi();
        api.Auth();
        apiToken = api.GetToken();

        try
        {
            string uri = "ws://fumbbl.com:22223/command";
            //string uri = "ws://localhost:22227/command";

            await Task.Delay(100);
            Debug.Log($"Connecting to {uri}");
            MainHandler.Instance.AddLogEntry($"Connecting to {uri}");
            await socket.Connect(uri);
            Debug.Log("Connected");
        }
        catch (Exception e)
        {
            Debug.Log($"<style=\"Error\">Error connecting: {e.Message}</style>");
            MainHandler.Instance.AddLogEntry($"<style=\"Error\">Error connecting: {e.Message}</style>");
        }

        RequestVersion();

        await socket.Start();

        Debug.Log("Networking ended");
    }

    private void Receive(string data)
    {
        string message = Protocol.Decompress(data);
        Debug.Log($"Received {message}");
        dynamic obj = JObject.Parse(message);
        if (string.Equals(obj.netCommandId.ToString(), "serverVersion"))
        {
            Spectate(apiToken, 1199282);
        }
        if (string.Equals(obj.netCommandId.ToString(), "serverTalk"))
        {
            FFB.Instance.AddChatEntry(obj.coach.ToString(), obj.talks[0].ToString());
        }
        if (obj?.reportList?.reports != null)
        {
            foreach (var x in obj.reportList.reports)
            {
                FFB.Instance.AddLogEntry(x.ToString());
            }
        }
    }

    public void Disconnect()
    {
        Debug.Log("Destroying Networking");
        socket.Stop();
    }

    private async void RequestVersion()
    {
        var command = new ClientRequestVersion();
        await Send(command);
    }

    private async void Spectate(string token, int game)
    {
        var command = new ClientJoin()
        {
            clientMode = "spectator",
            coach = FFB.Instance.CoachName,
            password = token,
            gameId = game,
            gameName = "",
            teamId = "",
            teamName = "",
        };
        await Send(command);
    }

    async Task Send(AbstractCommand command)
    {
        string serializedCommand = JsonConvert.SerializeObject(command);
        Debug.Log($"Sending {serializedCommand}");

        string data = Protocol.Compress(serializedCommand);

        await socket.Send(data);
    }
}
