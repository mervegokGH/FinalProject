using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class GetArrivalAutoCompleteRequest
    {
        public int ProductType { get; set; }
        public string Query { get; set; }
        public string Culture { get; set; }
    }
}
