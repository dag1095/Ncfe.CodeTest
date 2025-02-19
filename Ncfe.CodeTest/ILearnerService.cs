﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    public interface ILearnerService
    {
        Task<Learner> GetLearner(int learnerId);
        Learner GetArchivedLearner(int learnerId);
    }
}
