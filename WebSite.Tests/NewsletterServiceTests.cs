namespace WebSite.Tests
{
    using System;

    using NUnit.Framework;

    using Rhino.Mocks;

    using WebSite.Models;

    [TestFixture]
    public class NewsletterServiceTests
    {
        [Test]
        public void IfARegistrationExistsForEmailThrowAnException()
        {
            // 1. Actors
            var registerData = new RegisterData();
            var registrationRepository = MockRepository.GenerateMock<IRepository<Registration>>();
            registrationRepository.Expect(x => x.GetItem(null)).IgnoreArguments().Return(new Registration());
            var newsletterService = new NewsletterService(registrationRepository, null, null);

            // 2. Action
            Assert.Throws<Exception>(() => newsletterService.Register(registerData), "You are already registered...");

            // 3. Asserts : exception thrown
        }
    }
}
