using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPPayment.PaymentServiceTest
{
    [TestClass]
    public class IsValidPaymentAmountTest
    {
        PaymentService.PaymentService paymentService = new PaymentService.PaymentService();

        [TestMethod]
        public void ValidAmountTest()
        {
            // Assert
            Assert.AreEqual(true, paymentService.IsValidPaymentAmount(100));
        }

        [TestMethod]
        public void InvalidAmountTest()
        {
            // Assert
            Assert.AreEqual(false, paymentService.IsValidPaymentAmount(-200));
        }

        [TestMethod]
        public void WhatsYourIdTestMethod()
        {
            // Assert
            Assert.AreEqual("2a8dec5a-5f70-45a2-9e0b-b14064850de0", paymentService.WhatsYourId());
        }
    }
}
