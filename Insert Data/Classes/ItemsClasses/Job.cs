using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insert_Data.Classes.ItemsClasses
{
    class Job
    {
        private
            //job common info
            string jobNumber;
            string client;
            //tool info
            string toolNumber;
            string gwdBullPlug;
            string modem;
            string modemVersion;
            float circHours;
            float maxToolTemp;
            //engineer's info
            string engineer1;
            string engineer2;
            string eng1Arrive;
            string eng2Arrive;
            string eng1Left;
            string eng2Left;
            //container info
            string container;
            string contArrive;
            string contLeft;
            //extra info
            string comment;
            string rig;

    }
}
