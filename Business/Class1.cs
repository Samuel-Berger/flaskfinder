/*
namespace Business
{
    public class Class1
    {
        public async Task Connect()
        {
            await using var scope = app.Services.CreateAsyncScope();
            var db = scope.ServiceProvider.GetRequiredService<Db>();
            var canConnect = await db.Database.CanConnectAsync();
            app.Logger.LogInformation("Can connect to database: {CanConnect}", canConnect);
        }
    }
}
*/