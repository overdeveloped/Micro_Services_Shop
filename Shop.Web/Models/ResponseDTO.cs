﻿namespace Shop.Web.Models
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool IsGreatSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
