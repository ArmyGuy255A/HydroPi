﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.ViewModels
{
    public class ProductViewModel
    {
        public string Description { get; set; }
        public bool ShouldCommit { get; set; } = true;
    }
}
