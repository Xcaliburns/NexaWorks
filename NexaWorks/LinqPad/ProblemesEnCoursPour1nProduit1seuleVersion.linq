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

void ProblemesEnCoursPour1nProduit1seuleVersion()
{
    string versionId = Util.ReadLine("Saisissez l'Id de la version produit ");
    if (int.TryParse(versionId, out int versionIdInt))
    {
        var result = from t in Tickets
                     where t.Status == false && t.ProductVersionOperatingSystem.VersionId == versionIdInt
                     select new
                     {
                         t.ProblemDescription,
                         t.ProductVersionOperatingSystemId,
                         t.Status,                        
						 t.ProductVersionOperatingSystem.Version.Product.Name,
						 t.ProductVersionOperatingSystem.Version.Id // CS0833 An anonymous type cannot have multiple properties with the same name Ihave to change the name "Name" in context
                     };
        result.Dump();
    }
    else
    {
        Console.WriteLine("L'Id de la version doit être un nombre valide.");
    }
}


ProblemesEnCoursPour1nProduit1seuleVersion();
Console.WriteLine("Appuyez sur F5 pour une autre recherche");