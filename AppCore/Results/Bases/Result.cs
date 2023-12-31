﻿namespace AppCore.Results.Bases
{
    public abstract class Result // abstract classların constructorlarını protected yapmak daha doğru
    {
        

        public bool IsSuccessful { get; set; }

        public string? Message { get; set; }

        protected Result(bool isSuccessful, string? message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
