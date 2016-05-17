using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPPayment.PaymentServiceTest
{
    [TestClass]
    public class IsCardNumberValidTest
    {
        PaymentService.PaymentService paymentService = new PaymentService.PaymentService();

        [TestMethod]
        public void ValidNumberTest()
        {
            // Assert
            Assert.AreEqual(true, paymentService.IsCardNumberValid("1234567890123456"));
        }

        [TestMethod]
        public void InvalidNumberTest()
        {
            // Assert
            Assert.AreEqual(false, paymentService.IsCardNumberValid("123asdc123123"));
        }
    }
}
