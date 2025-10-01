using InsuranceBillingApp;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using var db = new InsuranceDbContext();
        db.Database.EnsureCreated(); // Створює базу, якщо її ще нема

        // ➕ Додавання клієнта з полісами
        var client = new Client { Name = "Олена Ковальчук" };
        client.Policies.Add(new InsurancePolicy { Type = "Health", BasePrice = 4000, RiskFactor = 2 });
        client.Policies.Add(new InsurancePolicy { Type = "Auto", BasePrice = 6000, RiskFactor = 3 });

        db.Clients.Add(client);
        db.SaveChanges();

        // 📤 Отримання клієнта з бази
        var loadedClient = db.Clients
            .Include(c => c.Policies)
            .FirstOrDefault(c => c.Name == "Олена Ковальчук");

        if (loadedClient != null)
        {
            string invoice = InvoiceGenerator.GenerateInvoice(loadedClient);
            Console.WriteLine(invoice);
        }
    }
}

