using System.Threading.Tasks;
using Application.TextAnalyzer.Dtos;

namespace Application.TextAnalyzer
{
    public interface ITextAnalyzerAppService
    {
        Task<TextAnalyzerResultDto> AnalyzeTextAsync(TextAnalyzerInputDto input);
    }
}