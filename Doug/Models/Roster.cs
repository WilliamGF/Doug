﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doug.Models
{
    public class Roster
    {
        public string Id { get; set; }
        public bool IsReady { get; set; }
        public bool IsSkipping { get; set; }
    }
}