using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fumbbl.Ffb
{
    public class Networking
    {
        private IWebsocket socket;
        private string ApiToken { get; set; }
        private Protocol Protocol;

        private readonly ReflectedFactory<Report, string> ReportFactory;
        private readonly ReflectedFactory<ModelChange, string> ModelChangeFactory;
        private readonly ReflectedFactory<NetCommand, string> NetCommandFactory;

        public bool IsConnected { get; private set; }

        public Networking()
        {
            ReportFactory = new ReflectedFactory<Report, string>();
            ModelChangeFactory = new ReflectedFactory<ModelChange, string>();
            NetCommandFactory = new ReflectedFactory<NetCommand, string>();
            IsConnected = true;
        }

        // Start is called before the first frame update
        public async Task Connect()
        {
            Protocol = new Protocol(true);
            Debug.Log("Starting Networking");

            socket = new Websocket(Receive);

            ApiToken = FFB.Instance.Api.GetToken();

            try
            {
                string uri = "ws://fumbbl.com:22223/command";
                //string uri = "ws://localhost:22227/command";

                await Task.Delay(100);
                Debug.Log($"Connecting to {uri}");
                MainHandler.Instance.AddReport(RawString.Create($"Connecting to {uri}"));
                await socket.Connect(uri);
                Debug.Log("Connected");
            }
            catch (Exception e)
            {
                Debug.Log($"<style=\"Error\">Error connecting: {e.Message}</style>");
                MainHandler.Instance.AddReport(RawString.Create($"<style=\"Error\">Error connecting: {e.Message}</style>"));
            }

            RequestVersion();

            await socket.Start();

            Debug.Log("Networking ended");
            IsConnected = false;
        }

        private void Receive(string data)
        {
            string message = Protocol.Decompress(data);
            JObject obj = JObject.Parse(message);

            NetCommand netCommand = NetCommandFactory.DeserializeJson(obj, obj?["netCommandId"]?.ToString());
            if (netCommand != null)
            {
                FFB.Instance.HandleNetCommand(netCommand);
            }
            else
            {
                Debug.Log($"Unhandled message: {message}");
            }

            if (obj?["modelChangeList"]?["modelChangeArray"] != null)
            {
                foreach (var x in obj["modelChangeList"]["modelChangeArray"])
                {
                    ModelChange change = ModelChangeFactory.DeserializeJson(x, x?["modelChangeId"]?.ToString());

                    if (change != null)
                    {
                        FFB.Instance.Model.ApplyChange(change);
                    }
                }
            }
            if (obj?["reportList"]?["reports"] != null)
            {
                foreach (var x in obj["reportList"]["reports"])
                {
                    Report report = ReportFactory.DeserializeJson(x, x?["reportId"]?.ToString());
                    if (report != null)
                    {
                        FFB.Instance.AddReport(report);
                    }
                    else
                    {
                        FFB.Instance.AddReport(RawString.Create($"Missing DTO for {x?["reportId"]}"));
                        //FFB.Instance.AddReport(RawString.Create(x.ToString()));
                    }
                }
            }
        }

        public void Disconnect()
        {
            IsConnected = false;
            Debug.Log("Destroying Networking");
            socket.Stop();
        }

        private async void RequestVersion()
        {
            var command = new ClientRequestVersion();
            await Send(command);
        }

        public async void Spectate(int game)
        {
            var command = new ClientJoin()
            {
                clientMode = "spectator",
                coach = FFB.Instance.CoachName,
                password = ApiToken,
                gameId = game,
                gameName = "",
                teamId = "",
                teamName = "",
            };
            await Send(command);
        }

        public async void SendPing()
        {
            var command = new ClientPing()
            {
                timestamp = DateTime.Now.Ticks
            };
            await Send(command);
        }

        async Task Send(AbstractCommand command)
        {
            string serializedCommand = JsonConvert.SerializeObject(command);

            string data = Protocol.Compress(serializedCommand);

            await socket.Send(data);
        }
    }
}