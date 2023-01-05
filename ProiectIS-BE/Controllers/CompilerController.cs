using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectIS_BE.Common.Interfaces;
using ProiectIS_BE.Common.Models;
using ProiectIS_BE.Models.Compiler;

namespace ProiectIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompilerController : ControllerBase
    {
        private readonly ICompilerService _compilerService;
        private readonly IConfiguration _configuration;

        public CompilerController(ICompilerService compilerService, IConfiguration configuration)
        {
            _compilerService = compilerService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteCode(CodeExecutionRequestModel model)
        {
            var requestModel = new CompilerRequestModel(
                _configuration["JDoodle:ClientId"],
                _configuration["JDoodle:ClientSecret"],
                model.Language,
                model.Script,
                "0"
            );

            var executionResult = await _compilerService.GetCodeExecutionResponse(requestModel);

            return Ok(executionResult);
        }
    }
}
