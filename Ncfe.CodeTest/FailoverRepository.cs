using System;
using System.Collections.Generic;

namespace Ncfe.CodeTest
{
    public class FailoverRepository
    {
        public List<FailoverEntry> GetFailOverEntries()
        {
            // return entries from the past 10 minutes
            Random random = new Random();
            int min = 0;
            int max = 20;

            int amount = random.Next(min, max);

            var entries = new List<FailoverEntry>();

            for (int i = 0; i < amount; i++)
            {
                entries.Add(new FailoverEntry());
            }

            return entries;
        }
    }
}
