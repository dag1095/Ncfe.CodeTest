using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ncfe.CodeTest
{
    public class FailoverRepository : IFailoverRepository
    {
        //todo: put in a config file
        private readonly string _connectionString = "Data Source=:memory:;Version=3;New=True;";
        private readonly CodeTestDbContext _context;

        public FailoverRepository(CodeTestDbContext context) 
        {
            _context = context;
        }

        public List<FailoverEntry> GetFailOverEntries()
        {
            // return entries from the past 10 minutes
            return _context.FailoverEntries.Where(x => x.DateTime > DateTime.Now.AddMinutes(-10)).ToList();
        }

        public void InsertFailOverEntry(FailoverEntry failOverEntry)
        {
            _context.FailoverEntries.Add(failOverEntry);
            _context.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
