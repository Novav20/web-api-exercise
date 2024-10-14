using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiRouteResponses.Controllers;
using Xunit;

namespace WebApiTest
{
    public class UserTest
    {
        [Fact]
        public void UserGet()
        {
            //AAA
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);

            var result = userController.Get();

            Assert.NotEmpty(result);

        }
        [Fact]
        public void UserGetByIdBadRequest()
        {
            //AAA
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);

            var firstId = userController.Get().ToList()[0].Id;

            var result = userController.Get(firstId.ToString());

            Assert.IsType<OkObjectResult>(result.Result);

        }
                [Fact]
        public void UserGetById()
        {
            //AAA
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);

            var result = userController.Get("");

            Assert.IsType<BadRequestResult>(result.Result);

        }
    }
}