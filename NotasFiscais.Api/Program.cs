using NotasFiscais.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//desafio pede armazenamento em memoria, entao ideal é manter tudo no mesmo objeto
//scoped e transi nao seriam muito ideais.
builder.Services.AddSingleton<INotaFiscalService, NotaFiscalService>();


//permitir requests pro bck
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazorFrontend", policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
              .AllowAnyHeader()
              .AllowAnyMethod();//get, post, put e delete.
    });
});

var app = builder.Build();

app.UseCors("PermitirBlazorFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
