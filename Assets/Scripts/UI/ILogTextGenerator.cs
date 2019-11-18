using Fumbbl.Dto;

namespace Fumbbl.UI
{
    public interface ILogTextGenerator
    {
        string Convert(IReport report);
    }
}