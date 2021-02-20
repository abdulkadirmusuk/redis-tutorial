using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Collections.Generic;

namespace Redis.Demo.Controllers
{
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;
        public CacheController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public string Get([FromQuery]string key)
        {
            try
            {
                return _database.StringGet(key);
            }
            catch (System.Exception e)
            {

                return $"Aranan key bulunamadı: {e}";
            }
           
        }

        // POST: CacheController/Create
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string,string> keyValue)
        {
            _database.StringSet(keyValue.Key, keyValue.Value);
        }
    }
}
