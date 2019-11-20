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
        static readonly UTF8Encoding encoder = new UTF8Encoding();
        private static readonly TimeSpan delay = TimeSpan.FromMilliseconds(30000);
        private IWebsocket socket;
        private string apiToken;
        private Protocol Protocol;

        private readonly ReflectedFactory<Report, string> ReportFactory;
        private readonly ReflectedFactory<ModelChange, string> ModelChangeFactory;

        public Networking()
        {
            ReportFactory = new ReflectedFactory<Report, string>();
            ModelChangeFactory = new ReflectedFactory<ModelChange, string>();
        }

        // Start is called before the first frame update
        public async Task Connect()
        {
            Protocol = new Protocol(true);
            Debug.Log("Starting Networking");

            socket = new Websocket(Receive);

            FumbblApi api = new FumbblApi();
            api.Auth();
            apiToken = api.GetToken();

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
        }

        private void Receive(string data)
        {
            string message = Protocol.Decompress(data);
            Debug.Log($"Received {message}");
            dynamic obj = JObject.Parse(message);
            if (string.Equals(obj.netCommandId.ToString(), "serverVersion"))
            {
                Spectate(apiToken, 1199709);
            }
            if (string.Equals(obj.netCommandId.ToString(), "serverTalk"))
            {
                FFB.Instance.AddChatEntry(obj.coach.ToString(), obj.talks[0].ToString());
            }
            if (obj?.modelChangeList?.modelChangeArray != null)
            {
                foreach (var x in obj.modelChangeList.modelChangeArray)
                {
                    ModelChange change = ModelChangeFactory.DeserializeJson(x, x?.modelChangeId?.ToString());

                    if (change != null)
                    {
                        FFB.Instance.Model.ApplyChange(change);
                    }
                }
            }
            if (obj?.reportList?.reports != null)
            {
                foreach (var x in obj.reportList.reports)
                {
                    Report report = ReportFactory.DeserializeJson(x, x?.reportId?.ToString());
                    if (report != null)
                    {
                        FFB.Instance.AddReport(report);
                    }
                    else
                    {
                        FFB.Instance.AddReport(RawString.Create(x.ToString()));
                    }
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
}