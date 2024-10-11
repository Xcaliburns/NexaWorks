<Query Kind="Statements">
  <Connection>
    <ID>a31347ad-1d53-4cc3-a755-03784cc40d71</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>NexaWorks_CodeFirst</Database>
    <Server>localhost</Server>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <Reference Relative="..\bin\Debug\net8.0\NexaWorks.dll">&lt;UserProfile&gt;\source\repos\NexaWorks\NexaWorks\bin\Debug\net8.0\NexaWorks.dll</Reference>
</Query>

void RechercherProblemesParProduit()
{
    string productId = Util.ReadLine("Saisissez l'Id du produit ");
    if (int.TryParse(productId, out int productIdInt))
    {
        var result = from t in Tickets
                     where t.Status == false && t.ProductVersionOperatingSystem.ProductId == productIdInt
                     select new
                     {
                         t.ProblemDescription,
                         t.ProductVersionOperatingSystemId,
                         t.Status,
                         t.ProductVersionOperatingSystem.ProductId
                     };
        result.Dump();
    }
    else
    {
        Console.WriteLine("L'ID du produit doit être un nombre valide.");
    }
}

RechercherTicketsParProduit();
Console.WriteLine("Appuyez sur F5 pour une autre recherche");