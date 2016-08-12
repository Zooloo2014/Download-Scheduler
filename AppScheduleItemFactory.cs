using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDM
{
    class AppScheduleItemFactory : ScheduleItemFactory
    {
        public override ScheduleItem GetScheduleItem(ResourceType rt)
        {
            ScheduleItem si = null;

            switch (rt)
            {
                case ResourceType.WEB:
                    si = new WebScheduleItem();
                    break;

                case ResourceType.FTP:
                    si = new FtpScheduleItem();
                    break;

                default:
                    break;
            }

            si.ResourceType = rt;

            return si;
        }


        public AppScheduleItemFactory() : base()
        {
        }
    }
}
