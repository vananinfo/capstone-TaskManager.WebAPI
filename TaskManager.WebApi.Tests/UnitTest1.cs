using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.WebApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Moq;
using TaskManager.Entities;
using System.Diagnostics;
using Newtonsoft.Json;
using TaskManager.DataModel;

namespace TaskManager.WebApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllTasks()
        {
            TaskManagerController controller = new TaskManagerController();            
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/getalltasks";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            var response = controller.GetAllTasks();
            Trace.Write(((System.Web.Http.Results.OkNegotiatedContentResult<string>)response).Content);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);
            
        }
        [TestMethod]
        public void GetAllTaskDetails()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/GetAllTaskDetails";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            var response = controller.GetAllTaskDetails();
            Trace.Write("Records returned = " + ((System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<TaskManager.Entities.Tasks>>)response).Content.Count);
            //Trace.Write(((System.Web.Http.Results.OkNegotiatedContentResult<string>)response).Content);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
        [TestMethod]
        public void GetTaskByID()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/GetTaskByID";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            var response = controller.GetTaskByID(1);
            Trace.Write("Records returned = "+ ((System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<TaskManager.Entities.Tasks>>)response).Content.Count);
            //Trace.Write(((System.Web.Http.Results.OkNegotiatedContentResult<string>)response).Content);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
        [TestMethod]
        public void AddTaskDetails()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/AddTaskDetails";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            TaskDetailsDTO t = new TaskDetailsDTO();
            t.Task = "Task" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            t.Priority = 10;
            t.Parent_Id = 1;
            t.Start_Date = DateTime.Now;
            t.End_Date = DateTime.Now;
            var response = controller.AddTaskDetails(t);
            Trace.Write(response);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
        [TestMethod]
        public void EndTask()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/EndTask";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act                        
            var response = controller.EndTask(20004);
            Trace.Write(response);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
    }

}
