using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPPayment.PaymentServiceTest
{
    [TestClass]
    public class CanMakePayementWithCardTest
    {
        PaymentService.PaymentService paymentService = new PaymentService.PaymentService();

        [TestMethod]
        public void InvalidCardTest()
        {
            // Assert
            Assert.AreEqual(false, paymentService.CanMakePaymentWithCard("1234abcd12341234", 12, 2022));
        }

        [TestMethod]
        public void InvalidMonthTest()
        {
            // Assert
            Assert.AreEqual(false, paymentService.CanMakePaymentWithCard("1234abcd12341234", 123, 2022));
        }

        [TestMethod]
        public void InvalidYearTest()
        {
            // Assert
            Assert.AreEqual(false, paymentService.CanMakePaymentWithCard("1234abcd12341234", 123, 19966));
        }

        [TestMethod]
        public void ValidCardDetailsTest()
        {
            // Assert
            Assert.AreEqual(true, paymentService.CanMakePaymentWithCard("1234567890123456", 12, 2016));
        }
    }
}
