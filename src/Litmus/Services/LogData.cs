using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Litmus.Entities;

namespace Litmus.Services
{
    public interface ILogData
    {
        IEnumerable<Log> GetAll();
        Log Get(int id);
        void Add(Log newLog);
        int Commit();

        // a Log record does not need update or delete methods 
    }

    public class SqlLogData : ILogData
    {
        public IEnumerable<Log> GetAll()
        {
            throw new NotImplementedException();
        }

        public Log Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Log newLog)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
