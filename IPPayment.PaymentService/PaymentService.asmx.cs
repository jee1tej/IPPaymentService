using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IPPayment.PaymentService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PaymentService : WebService, IPaymentService
    {
        /// <summary>
        /// returns given client Id
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string WhatsYourId()
        {
            return "2a8dec5a-5f70-45a2-9e0b-b14064850de0";
        }

        /// <summary>
        /// Implements Luhn Algorithm to validate given cardNumber
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        [WebMethod]
        public bool IsCardNumberValid(string cardNumber)
        {
            try
            {
                long cardNo = 0;
                if (cardNumber.Length == 16 &&
                    long.TryParse(cardNumber, out cardNo))
                {
                    long sum = 0;
                    var dividend = cardNo;

                    //calculate sum of non-check digits using luhn algorithm
                    for (int i = 1; i <= cardNumber.Length; i++)
                    {
                        //double the number for every alternate digit
                        var remainder = i % 2 == 0 ? (dividend % 10) * 2 : dividend % 10;

                        if (remainder > 9)
                        {
                            //add both digits in the number
                            remainder = remainder % 10 + remainder / 10;
                        }

                        dividend = dividend / 10;

                        sum += remainder;
                    }

                    //compare actual checkdigit with calculated checkdigit
                    return 10 - sum % 10 == cardNo % 10;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// vadlidates payment amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [WebMethod]
        public bool IsValidPaymentAmount(long amount)
        {
            return amount > 99 && amount < 99999999;
        }

        /// <summary>
        /// Validates the card number, expiry motnh and year to ensure the details can be used to make a payment
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="expiryMonth"></param>
        /// <param name="expiryYear"></param>
        /// <returns></returns>
        [WebMethod]
        public bool CanMakePaymentWithCard(string cardNumber, int expiryMonth, int expiryYear)
        {
            try
            {
                return IsCardNumberValid(cardNumber) &&                                             //check if card number is valid
                       expiryMonth >= 1 && expiryMonth <= 12 &&                                     //check if expiry month is valid
                       expiryYear.ToString().Length == 4 && expiryYear >= DateTime.Today.Year &&    //check if expiry year is valid
                       new DateTime(expiryYear, expiryMonth, DateTime.Today.Day) >= DateTime.Today; //check if card is still valid
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}