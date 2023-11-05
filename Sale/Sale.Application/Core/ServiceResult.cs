﻿
namespace Sale.Application.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
