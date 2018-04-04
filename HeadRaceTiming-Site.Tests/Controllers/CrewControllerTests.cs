using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadRaceTimingSite.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Tests.Controllers
{
    [TestClass]
    public class CrewControllerTests
    {
        private static TimingSiteContext GetTimingSiteContext()
        {
            var options = new DbContextOptionsBuilder<TimingSiteContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TimingSiteContext(options);

            return context;
        }
    }
}
