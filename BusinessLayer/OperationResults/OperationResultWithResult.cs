using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Rd.JadeRest.BusinessLayer.OperationResults
{
    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }
    }
}
