﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Dtos.Base
{
    public abstract class DtoBase
    {
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
