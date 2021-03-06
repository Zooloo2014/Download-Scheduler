﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDM
{
    public class WebScheduleItem : ScheduleItem
    {
        public string Link { get; set; }


        public WebScheduleItem() : base()
        {
        }


        public override Runner GetRunner()
        {
            return new HttpRunner(this);
        }


        public override string ToString()
        {
            string ss;

            ss = Id.ToString() + "|";
            ss += TargetDate.ToString() + "|";
            ss += Link + "|";
            ss += GetStatusString() + "|";

            return ss;
        }
    }
}
