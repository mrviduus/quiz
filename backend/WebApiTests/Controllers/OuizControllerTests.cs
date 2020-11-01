using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading;
using WebApi.testResponse;

namespace WebApi.Controllers.Tests
{
    [TestClass()]
    public class OuizControllerTests
    {
        public Int32? questionId = 25;

        [TestMethod]
        public void NextQuestionTest()
        {
            string result;
            HttpClient httpClient = new HttpClient();
            string baseUrl = "http://localhost:5000/";
            int questionId = 1;

            var client = new Client(baseUrl, httpClient);
            try
            {
                result = client.ApiQuizNext(questionId);
            }
            catch (Exception ex)
            {

                result = null;
            }

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async void GetAnswerTest()
        {
            HttpClient httpClient = new HttpClient();
            await httpClient.GetAsync("http://localhost:5000/");
            string baseUrl = "http://localhost:5000/";

            var client = new Client(baseUrl, httpClient);

            Int32? questionId = 1;
            var source = new CancellationTokenSource();
            var ct = source.Token; //token     .  source.Cancel();
            await client.ApiQuizAnswerAsync("{'Question':'2+2?','Answer':'4'}");

            Assert.Fail();
        }
    }
}