﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSide.API.Models.ORM
{
    public class Report
    {
        public int ID { get; set; }
        public int personcount { get; set; }
        public int phonecount { get; set; }

        public string Location { get; set; }

        public DateTime requesttime { get; set; }

        private bool _status = false;
        public bool Status

        {
            get
            { return _status; }
            set
            { Status = value; }

        }

        

    }
}
