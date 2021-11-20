﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShardingCore.Test6x.Domain.Entities
{
    public class LogDay
    {
        public Guid Id { get; set; }
        public string LogLevel { get; set; }
        public string LogBody { get; set; }
        public DateTime LogTime { get; set; }
    }
}
