@ECHO OFF
dotnet ef dbcontext scaffold "server =(local); database = SWD;uid=sa;pwd=sa;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer --output-dir
PAUSE