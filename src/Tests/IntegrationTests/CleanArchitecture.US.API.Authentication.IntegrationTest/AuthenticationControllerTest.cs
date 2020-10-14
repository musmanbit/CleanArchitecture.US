using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.US.API.Authentication.IntegrationTest.Fixtures;
using NUnit.Framework;


namespace CleanArchitecture.US.API.Authentication.IntegrationTest
{

    [TestFixture]
    public class AuthenticationControllerTest : Fixtures.IntegrationTest
    {
       
        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
           
        }

      /*  [Test]
        [TestCase(7)]
        [TestCase(6)]
        */
        public async Task WhenSomeTextIsPosted_ThenTheResultIsOk(int id)
        {
            var textContent = new ByteArrayContent(Encoding.UTF8.GetBytes("Backpack for his applesauce"));
            textContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            try
            {
                var result = await base.Client.GetAsync("/api/admin/" + id.ToString());
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        //[Test]
        public async Task WhenNoTextIsPosted_ThenTheResultIsBadRequest()
        {
            var result = await base.Client.PostAsync("/sample", new StringContent(string.Empty));
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        //[OneTimeTearDown]
        public void TearDown()
        {
            Client.Dispose();
          
        }
    }
}