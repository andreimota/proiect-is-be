using ProiectIS_BE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Common.Interfaces
{
    public interface ICompilerService
    {
        Task<CompilerResponseModel> GetCodeExecutionResponse(CompilerRequestModel model);
    }
}
