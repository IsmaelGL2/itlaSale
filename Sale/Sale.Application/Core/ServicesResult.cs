using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Core
{
    public class ServicesResult
    {
        public ServicesResult() 
        {
            this.Success = true;
        }
        public bool Success { get; set; }   
        public string? Message { get; set; }
        public dynamic? Data { get; set; }

    }
}
