﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    public sealed class CoreConnectionCredentials
    {
        public string Hostname { get; set; }

        public int Port { get; set; }

        public string  Username { get; set; }

        public string Password { get; set; }
    }
}
