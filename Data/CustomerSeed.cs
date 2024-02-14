using CMS.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CMS.Data
{
    public class CustomerSeed
    {
        public static async Task SeedAsync(CustomerContext context)
        {
            try
            {
                if (!context.PaymentMethods.Any())
                {
                    var paymentMethodData =
                        File.ReadAllText("./Data/SeedData/Paymentmethod.json");
                    var payment = JsonSerializer.Deserialize<List<PaymentMethod>>(paymentMethodData);
                    foreach (var item in payment)
                    {
                        context.PaymentMethods.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.AddressTypes.Any())
                {
                    var addressTypeData =
                        File.ReadAllText("./Data/SeedData/AddressType.json");
                    var address = JsonSerializer.Deserialize<List<AddressTypes>>(addressTypeData);
                    foreach (var item in address)
                    {
                        context.AddressTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("seed data failure!", ex);
            }
        }



    }
}

