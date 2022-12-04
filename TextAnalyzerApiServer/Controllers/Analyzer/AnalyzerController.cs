using Microsoft.AspNetCore.Mvc;
using Shared.Services.Interfaces;
using TextAnalyzerApiServer.Controllers.Analyzer.Models;

namespace TextAnalyzerApiServer.Controllers.Analyzer
{
    [ApiController]
    [Route("analyzer")]
    public class AnalyzerController : ControllerBase
    {
        private readonly ITextAnalyzerService _textAnalyzerService;
		public AnalyzerController(
			ITextAnalyzerService textAnalyzerService)
        {
            _textAnalyzerService = textAnalyzerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnalyzeRequestModel model)
        {
            if(model == null)
            {
                return BadRequest(ModelState);
            }
            var result = await _textAnalyzerService.AnalyzeTextsFromUrls(model.Urls);
            if(result != null && !model.IncludeTexts)
            {
                foreach (var resultItem in result.ResultItems)
                {
                    resultItem.Text = null;
                }
            }
            return Ok(result);
        }
    }
}