<Query Kind="Statements">
  <Connection>
    <ID>a31347ad-1d53-4cc3-a755-03784cc40d71</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
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
  <Reference Relative="..\..\..\source\repos\NexaWorks\NexaWorks\bin\Debug\net8.0\NexaWorks.dll">&lt;UserProfile&gt;\source\repos\NexaWorks\NexaWorks\bin\Debug\net8.0\NexaWorks.dll</Reference>
</Query>

string productId = Util.ReadLine("Saisissez l'Id du produit ?");
int productIdInt = int.Parse(productId);


var result = from t in Tickets
where t.Status==false && t.ProductVersionOperatingSystem.ProductId==productIdInt
select new { 
			t.ProblemDescription,
			t.ProductVersionOperatingSystemId,
			t.Status,
			t.ProductVersionOperatingSystem.ProductId};
result.Dump();