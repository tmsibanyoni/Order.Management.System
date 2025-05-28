using Microsoft.Extensions.Logging;
using Order.Management.Repository.Interfaces;
using StackExchange.Redis;

namespace Order.Management.Repository.Helpers
{
    public class RedisRepositoryHelper(string connectionString) : IRedisRepositoryHelper
    {
        private readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect(connectionString);
        public string GetAllOrderA(string key)
        {
            var db = _redis.GetDatabase();
            return db.StringGet(key);
        }

        public string GetValue(string key)
        {
            var db = _redis.GetDatabase();
            return db.StringGet(key);
        }

        public bool KeyExists(string key)
        {
            var db = _redis.GetDatabase();
            return db.KeyExists(key);
        }

        public void SetValue(string key, string value)
        {
            var db = _redis.GetDatabase();
            db.StringSet(key, value, TimeSpan.FromMinutes(15), true);
        }
    }
}
