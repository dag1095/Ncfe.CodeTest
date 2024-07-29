using System;

namespace Ncfe.CodeTest
{
    public class FailoverEntry
    {
        public FailoverEntry()
        {
            Random random = new Random();
            int min = -20;
            int max = 0;

            DateTime = DateTime.Now.AddMinutes(random.Next(min, max));
        }

        public DateTime DateTime { get; set; }
    }
}
