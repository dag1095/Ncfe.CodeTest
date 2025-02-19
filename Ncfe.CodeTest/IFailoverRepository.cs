﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    public interface IFailoverRepository
    {
        List<FailoverEntry> GetFailOverEntries();
        void InsertFailOverEntry(FailoverEntry failOverEntry);
        void Save();
    }
}
