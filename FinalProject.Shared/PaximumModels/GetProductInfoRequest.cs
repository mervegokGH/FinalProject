using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class GetProductInfoRequest
    {
        public int productType { get; set; }
        public int ownerProvider { get; set; }
        public string product { get; set; }
        public string culture { get; set; }
    }
}
