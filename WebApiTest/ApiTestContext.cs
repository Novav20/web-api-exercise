using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRouteResponses.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApiTest
{
    public class ApiTestContext
    {
        public static ApiDbContext GetApiAppContext()
        {
            var optiones = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(databaseName: "AppDb").Options;

            var dbContext = new ApiDbContext(optiones);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}