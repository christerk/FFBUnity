using Fumbbl.Ffb.Dto;
using Fumbbl.Ffb.Dto.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Fumbbl.Ffb
{
    public class Networking
    {
        public bool IsReceiving { get; private set; }

        private IWebsocket socket;
        private string ApiToken { get; set; }
        private Protocol Protocol;

        private readonly ReflectedFactory<NetCommand, string> NetCommandFactory;

        public Networking()
        {
            NetCommandFactory = new ReflectedFactory<NetCommand, string>();
        }

        public async Task Connect()
        {
            Protocol = new Protocol(true);

            socket = new Websocket(Receive);

            ApiToken = await FFB.Instance.Api.GetToken();

            try
            {
                string uri = "ws://fumbbl.com:22223/command";
                //string uri = "ws://localhost:22227/command";

                await Task.Delay(100);
                LogManager.Info($"Networking Connecting to {uri}");
                MainHandler.Instance.AddReport(RawString.Create($"Connecting to {uri}"));
                await socket.Connect(uri);
                LogManager.Debug("Networking Connected");

                RequestVersion();
            }
            catch (Exception e)
            {
                LogManager.Error($"<style=\"Error\">Error connecting: {e.Message}</style>");
                MainHandler.Instance.AddReport(RawString.Create($"<style=\"Error\">Error connecting: {e.Message}</style>"));
            }
        }

        public void Disconnect()
        {
            LogManager.Info("Destroying Networking");
            IsReceiving = false;
            if (socket != null)
            {
                socket.Stop();
            }
        }

        public async Task Send(AbstractCommand command)
        {
            string serializedCommand = JsonConvert.SerializeObject(command);

            string data = Protocol.Compress(serializedCommand);

            await socket.Send(data);
        }

        public async void SendPing()
        {
            var command = new ClientPing()
            {
                timestamp = DateTime.Now.Ticks
            };
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

        public async Task StartReceive()
        {
            IsReceiving = true;
            LogManager.Debug("Networking Receive Loop Started");

            _ = socket.Start();

            while (socket.IsConnected)
            {
                FFB.Instance.Network.SendPing();
                await Task.Delay(2000);
            }

            LogManager.Debug("Networking Receive Loop Ended");
            IsReceiving = false;
        }

        private void Receive(string data)
        {
            string message = Protocol.Decompress(data);
            JObject obj = JObject.Parse(message);

            if (obj?["netCommandId"].ToString() == "serverModelSync")
            {

            }

            NetCommand netCommand = NetCommandFactory.DeserializeJson(obj, obj?["netCommandId"]?.ToString());
            if (netCommand != null)
            {
                FFB.Instance.HandleNetCommand(netCommand);
            }
            else
            {
                FFB.Instance.AddReport(RawString.Create($"<b>* * * Missing DTO for NetCommand {obj?["netCommandId"]} * * *</b>"));
            }
        }

        private async void RequestVersion()
        {
            var command = new ClientRequestVersion();
            await Send(command);
        }
    }
}
