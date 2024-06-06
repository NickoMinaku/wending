using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using intratest.Server.models;
using System.Linq;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace intratest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly AppContext dbContext;
        private readonly IDistributedCache cache;
        public DrinkController(AppContext dbContext, IDistributedCache distributedCache) 
        {
             this.dbContext = dbContext;
             cache = distributedCache;
        }

        [HttpGet(Name = "GetDrinks")]
        public IEnumerable<Drink> Get() 
        {
            return dbContext.Drinks.ToArray();
        }

        [HttpPatch(Name = "ChangeDrinks")]
        public async Task<IEnumerable<Drink>> Patch(int[]? ids) 
        {
            if (ids!=null)
            {
                int bankUp = 0;
                foreach (int id in ids) {
                    Drink? drink = dbContext.Drinks.FirstOrDefault(x => x.Id == id);
                    if (drink !=null)
                    {
                        bankUp += drink.Cost;
                        drink.Quantity -= 1; 
                        dbContext.Drinks.Update(drink);
                    }
                }
                /*var userString = await cache.GetStringAsync("bank");
                int bank;
                if (userString != null) {
                    bank = int.Parse(userString);
                    bankUp += bank;
                    await cache.SetStringAsync("bank", bank.ToString());
                };*/
                await dbContext.SaveChangesAsync();
                return dbContext.Drinks.ToArray();
            }
            return dbContext.Drinks.ToArray();
        }
    }
}
