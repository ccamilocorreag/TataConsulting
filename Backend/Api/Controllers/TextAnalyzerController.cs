using System.Threading.Tasks;
using Application.TextAnalyzer;
using Application.TextAnalyzer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class TextAnalyzerController : ControllerBase
    {
        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        private static readonly string[] scopeRequiredByApi = {"access_as_user"};
        private readonly ILogger<TextAnalyzerController> _logger;

        private readonly ITextAnalyzerAppService _textAnalyzerAppService;

        public TextAnalyzerController(ILogger<TextAnalyzerController> logger,
            ITextAnalyzerAppService textAnalyzerAppService)
        {
            _logger = logger;
            _textAnalyzerAppService = textAnalyzerAppService;
        }

        [HttpPost("AnalyzeText")]
        public async Task<IActionResult> AnalyzeText([FromBody] TextAnalyzerInputDto text)
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            var result = await _textAnalyzerAppService.AnalyzeTextAsync(text);
            if (result != null)
                return Ok(result);

            return BadRequest("Text couldn't be analyze");
        }
    }
}