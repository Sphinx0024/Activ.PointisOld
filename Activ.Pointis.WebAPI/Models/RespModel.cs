﻿using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class RespModel
    {
        public string Responsable { get; set; }
        public List<Employes> Employes { get; set; }
    }
}