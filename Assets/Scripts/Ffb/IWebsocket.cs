using System.Threading.Tasks;
namespace Fumbbl
{
    interface IWebsocket
    {
        Task Connect(string url);
        Task Send(string data);
        void Stop();
        Task Start();
    }
}