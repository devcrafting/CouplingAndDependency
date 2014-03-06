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
        public void RegisterThrowsExceptionWhenAlreadyRegistered()
        {
            // 1. Actors
            var registrationRepository = MockRepository.GenerateMock<IRegistrationRepository>();
            registrationRepository.Expect(x => x.GetItemByEmail(null)).IgnoreArguments().Return(new Registration());
            var newsletterService = new NewsletterService(registrationRepository, null, null);
            var data = new RegisterData();

            // 2. Action
           Assert.Throws<Exception>(() => newsletterService.Register(data));

            // 3. asserts : throw exception
        }
    }
}
