using System.Threading.Tasks;
namespace Fumbbl.Ffb
{
    interface IWebsocket
    {
        Task Connect(string url);
        Task Send(string data);
        void Stop();
        Task Start();
    }
}