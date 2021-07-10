using System.Threading.Tasks;
using Application.TextAnalyzer;
using Application.TextAnalyzer.Dtos;
using NUnit.Framework;

namespace Test
{

    [TestFixture]
    public class TestTata
    {
        private TextAnalyzerAppService _textAnalyzerAppService;

        [SetUp]
        public void SetUp()
        {
            _textAnalyzerAppService = new TextAnalyzerAppService();
        }

        [Test]
        public async Task InputNull_ReturnNull()
        {
            var result = await _textAnalyzerAppService.AnalyzeTextAsync(null);

            Assert.IsNull(result);
        }

        [Test]
        public async Task InputTextEmpty_ReturnNull()
        {
            var input = new TextAnalyzerInputDto()
            {
                Text = "",
                Word = "de"
            };
            var result = await _textAnalyzerAppService.AnalyzeTextAsync(input);

            Assert.IsNull(result);
        }

        [Test]
        public async Task InputWordEmpty_ReturnNull()
        {
            var input = new TextAnalyzerInputDto()
            {
                Text = "Este es un texto cualquiera",
                Word = ""
            };
            var result = await _textAnalyzerAppService.AnalyzeTextAsync(input);

            Assert.IsNull(result);
        }

        [Test]
        public async Task InputTextAndWord_ReturnWordOneTime()
        {
            var input = new TextAnalyzerInputDto()
            {
                Text = "Este es un texto cualquiera",
                Word = "es"
            };
            var result = await _textAnalyzerAppService.AnalyzeTextAsync(input);

            Assert.IsTrue(result.NumberTimes == 1);
        }

        [Test]
        public async Task InputTextAndWord_ReturnWordTenTimes()
        {
            var input = new TextAnalyzerInputDto()
            {
                Text = "Este es un texto cualquiera un un un un un un un un un",
                Word = "un"
            };
            var result = await _textAnalyzerAppService.AnalyzeTextAsync(input);

            Assert.IsTrue(result.NumberTimes == 10);
        }
    }
}