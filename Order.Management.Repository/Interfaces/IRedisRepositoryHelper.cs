using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.Repository.Interfaces
{
    public interface IRedisRepositoryHelper
    {
        public string GetValue(string key);
        public void SetValue(string key, string value);
        public bool KeyExists(string key);
    }
}
