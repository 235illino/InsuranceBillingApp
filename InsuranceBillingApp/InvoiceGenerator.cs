using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBillingApp
{
    public static class InvoiceGenerator
    {
        public static decimal CalculateTotal(Client client)
        {
            decimal total = 0;

            foreach (var policy in client.Policies)
            {
                // Модифікатор ціни залежно від ризику
                decimal modifier = 1 + (policy.RiskFactor * 0.05m);
                total += policy.BasePrice * modifier;
            }

            // Знижка, якщо клієнт має 3 або більше полісів
            if (client.Policies.Count >= 3)
            {
                total *= 0.9m; // 10% знижка
            }

            return total;
        }

        public static string GenerateInvoice(Client client)
        {
            decimal total = CalculateTotal(client);

            var invoice = $"📄 Рахунок для клієнта: {client.Name}\n";
            invoice += "-----------------------------\n";

            foreach (var policy in client.Policies)
            {
                decimal modifier = 1 + (policy.RiskFactor * 0.05m);
                decimal price = policy.BasePrice * modifier;

                invoice += $"- {policy.Type} страхування: {price:C} (ризик: {policy.RiskFactor})\n";
            }

            invoice += "-----------------------------\n";
            invoice += $"Загальна сума до сплати: {total:C}\n";

            return invoice;
        }
    }

}
