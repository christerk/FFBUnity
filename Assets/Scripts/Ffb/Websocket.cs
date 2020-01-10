﻿using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Fumbbl.Ffb.Dto.Reports;

namespace Fumbbl.Ffb
{
    class Websocket : IWebsocket
    {
        public bool IsConnected => Socket != null && Socket.State == WebSocketState.Open;

        private const int receiveChunkSize = 100;
        private readonly Action<string> ReceiveAction;
        private readonly ClientWebSocket Socket;
        private readonly CancellationTokenSource CancellationSource;
        private CancellationToken CancellationToken;


        public Websocket(Action<string> receiveDelegate)
        {
            this.ReceiveAction = receiveDelegate;
            Socket = new ClientWebSocket();
            CancellationSource = new CancellationTokenSource();
            this.CancellationToken = CancellationSource.Token;
        }

        public async Task Connect(string url)
        {
            await Socket.ConnectAsync(new Uri(url), CancellationToken);
        }

        public async Task Send(string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);

            try
            {
                await Socket.SendAsync(new System.ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken);
            }
            catch (Exception e)
            {
                LogManager.Warn($"Unhandled exception in Send: {e.Message}");
            }
        }

        public async Task Start()
        {
            await Receive();
        }

        public void Stop()
        {
            CancellationSource.Cancel();
        }

        private async Task Receive()
        {
            var buffer = new ArraySegment<byte>(new byte[receiveChunkSize]);
            try
            {
                WebSocketReceiveResult result = null;
                while (Socket.State == WebSocketState.Open)
                {
                    using (var ms = new MemoryStream())
                    {
                        do
                        {
                            try
                            {
                                result = await Socket.ReceiveAsync(buffer, CancellationToken);
                            }
                            catch (Exception e)
                            {
                                LogManager.Error(e.Message);
                                Exception c = e;
                                while (c.InnerException != null)
                                {
                                    LogManager.Error(c.InnerException.ToString());
                                    c = c.InnerException;
                                }
                                throw e;
                            }
                            if (result.Count > 0)
                            {
                                ms.Write(buffer.Array, buffer.Offset, result.Count);
                            }
                        } while (!result.EndOfMessage);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            LogManager.Info("Server Closed Connection");
                            LogManager.Info(result.CloseStatusDescription);
                            //await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken);
                        }
                        else
                        {
                            if (result.Count > 0)
                            {
                                ms.Seek(0, SeekOrigin.Begin);

                                ReceiveData(Encoding.UTF8.GetString(ms.GetBuffer()));
                            }
                        }
                    }
                }
                LogManager.Info("Receive Loop ended normally");
            }
            catch (TaskCanceledException e)
            {
                LogManager.Info($"Receive Task Cancelled: {e.Message}");
            }
            catch (Exception e)
            {
                LogManager.Error($"Unhandled Exception in Receive: {e.Message}");
                LogManager.Error(e.StackTrace);
            }

            LogManager.Info("Websocket Receive terminated");
        }

        private void ReceiveData(string data)
        {
            ReceiveAction?.Invoke(data);
        }
    }
}
