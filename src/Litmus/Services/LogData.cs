using System.Collections.Generic;
using System.Linq;
using Litmus.Entities;

namespace Litmus.Services
{
    public interface ILogData
    {
        IEnumerable<Log> GetAll();
        Log Get(int id);
        void Add(Log newLog);

        // a Log record does not need update or delete methods 
    }

    public class SqlLogData : ILogData
    {
        private LitmusDbContext _context;

        public SqlLogData(LitmusDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Log> GetAll()
        {
            var logs = _context.Logs.ToList();

            return logs;
        }

        public Log Get(int id)
        {
            return _context.Logs.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Log newLog)
        {
            _context.Add(newLog);
            _context.SaveChanges();
        }

    }
}
