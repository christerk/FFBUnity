using System.Threading.Tasks;

interface IWebsocket
{
    Task Connect(string url);
    Task Send(string data);
    void Stop();
    Task Start();
}