using BusinessObjects.Models;
using Net.payOS;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Tool
{
    public class PayOSPayment
    {
        private static PayOSPayment instance = default!;
        private readonly string clientId = "f0628d48-fda9-4a50-a9e4-763af3bc6b30";
        private readonly string apiKey = "dc7699b6-ecf0-4ed7-9d23-7c996e8586c5";
        private readonly string checkSumKey = "ac73f5daa87c20a85d230fca135709f6a969aeb813d28078ab14029634f0ae81";

        public static PayOSPayment Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PayOSPayment();
                }
                return instance;
            }
        }
        public async Task<CreatePaymentResult> CreatePayment(Account account, int money,int totalPayment)
        {
            try
            {
                PayOS payOS = new PayOS(clientId, apiKey, checkSumKey);
                
                List<ItemData> items = new List<ItemData>();
                items.Add(new ItemData($"Đơn hàng khách {account.Username}", 1, money * 10));
                PaymentData paymentData = new PaymentData(totalPayment + 100, money*10, "",
                    items, "bancantoi.site",
                    "bancantoi.site",
                    account.Username
                    );
                CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
                
                return createPayment;
            }
            catch (Exception ex)
            {
                throw new("Error with payOS: " + ex.Message);
            }
            
        }

    }
}
