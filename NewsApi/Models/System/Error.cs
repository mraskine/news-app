﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.Models.System
{
    public class Error
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public Error(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
