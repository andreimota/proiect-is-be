using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Common.Models
{
    public class CompilerRequestModel
    {
        public CompilerRequestModel(string clientId, string clientSecret, string language, string script, string versionIndex)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.language = language;
            this.script = script;
            this.versionIndex = versionIndex;
        }

        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string language { get; set; }
        public string script { get; set; }
        public string versionIndex { get; set; }
    }
}
