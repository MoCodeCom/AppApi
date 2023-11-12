using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using appapi.Data;
using appapi.Entity;

namespace appapi.Seed
{
    public class DataSeed
    {
        public static async Task SeedAsync(DbContextApi context)
        {
            if(!context.User.Any())
            {
                var data = File.ReadAllText("Seed/userjson.json");
                var desdata = JsonSerializer.Deserialize<List<UserEntity>>(data);
                context.User.AddRange(desdata);
            }

            if(!context.Address.Any())
            {
                var data = File.ReadAllText("Seed/addressjson.json");
                var desdata = JsonSerializer.Deserialize<List<AddressEntity>>(data);
                context.Address.AddRange(desdata);
            }

            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }

        }
        
    }
}