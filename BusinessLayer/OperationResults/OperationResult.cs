using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Rd.JadeRest.BusinessLayer.OperationResults
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public Exception Exception { get; set; }
    }
}
