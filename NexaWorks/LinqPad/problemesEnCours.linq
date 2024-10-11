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
  <RuntimeVersion>8.0</RuntimeVersion>
</Query>

string status;
bool statusBool;

while (true)
{
    status = Util.ReadLine("Saisissez le statut du produit :true pour resolu ou false pour non résolu ?");

    if (bool.TryParse(status, out statusBool))
    {
        break; // Sortir de la boucle si la valeur est correcte
    }
    else
    {
        Console.WriteLine("La valeur entrée est incorrecte. Seuls 'true' et 'false' sont acceptés.");
    }
}

var problemesEnCours = from ticket in Tickets
                       where ticket.Status == statusBool
                       select new
                       {
                           ticket.CreationDate,
                           ticket.ProblemDescription,
                       };

problemesEnCours.Dump();
Console.WriteLine("appuyez sur f5 pour une autre recherche");
