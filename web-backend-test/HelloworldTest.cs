using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Newtonsoft.Json;
using Moq;
using Microsoft.Extensions.Logging;
using web_backend.Controllers;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace web_backend_test
{
    public class HelloworldTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Helloworld()
        {
            //Mock http request
            var httpContext = new DefaultHttpContext();

            var mockLogger = new Mock<ILogger<HelloworldController>>(MockBehavior.Strict);
            var controller = new HelloworldController(mockLogger.Object)
            {
                ControllerContext = new ControllerContext()
                { HttpContext = httpContext }
            };
            var result = controller.Get() as OkObjectResult;
            Assert.AreEqual("{\"code\":200,\"message\":\"Hellow\"}", JsonConvert.SerializeObject(result.Value));
        }

        [Test]
        public void postTestTest()
        {
            //Mock http request
            var form = new FormCollection(new Dictionary<string,Microsoft.Extensions.Primitives.StringValues>
            {
                {"username","114514" },
                { "password","1919810"}
            });
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "POST";
            httpContext.Request.Form = form;

            var mockLogger = new Mock<ILogger<HelloworldController>>(MockBehavior.Strict);
            var controller = new HelloworldController(mockLogger.Object)
            {
                ControllerContext = new ControllerContext()
                { HttpContext = httpContext }
            };

            var expectedObj = new
            {
                username = "114514",
                password = "1919810"
            };
            Assert.AreEqual(JsonConvert.SerializeObject(expectedObj), JsonConvert.SerializeObject((controller.postTest() as OkObjectResult).Value));
        }
    }
}