using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class BeginTransactionRequest
    {
        public List<string> offerIds { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
    }
}
