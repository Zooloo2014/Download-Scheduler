using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDM
{
    abstract public class ScheduleItemFactory
    {
        public abstract ScheduleItem GetScheduleItem(ResourceType rt);
    }
}
