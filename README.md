# TIL
https://www.youtube.com/watch?v=Xtt6mS0p2_c


https://sqlitebrowser.org/

Sqlite - Nuget
- System.Data.SQLite.Core
- Dapper (Micro-ORM)
using(IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
{
    var output = conn.Query<PersonModel>("select * from Person", new DynamicParameters());
    return output.ToList();
}

- System.Configuration
<connectionStrings>
   <add name="Default" connectionString="Data Source=.\DemoDB.db;Version=3;" providerName="System.Data.SqlClient"/>
</connectionStrings>

ConfigurationManager.ConnectionStrings[id].ConnectionString;
