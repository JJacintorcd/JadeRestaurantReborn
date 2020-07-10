using System;

namespace Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
