using System.Threading.Tasks;
using Application.TextAnalyzer.Dtos;
using Core.TextAnalyzer.Entities;

namespace Application.TextAnalyzer
{
    public class TextAnalyzerAppService : ITextAnalyzerAppService
    {
        public async Task<TextAnalyzerResultDto> AnalyzeTextAsync(TextAnalyzerInputDto input)
        {
            if (input == null
                || string.IsNullOrEmpty(input.Text)
                || string.IsNullOrWhiteSpace(input.Text)
                || string.IsNullOrEmpty(input.Word)
                || string.IsNullOrWhiteSpace(input.Word))
                return null;

            var text = new TextComplete(input.Text, input.Word);

            return new TextAnalyzerResultDto()
            {
                Word = input.Word,
                NumberTimes = text.GetNumberTimesWordInText()
            };
        }
    }
}