using DevFreela.Api.ManipuladorExcecoes;
using DevFreela.Api.Modelos;
using DevFreela.Api.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// IOptions
builder.Services.Configure<FreelanceCustoTotal>
    (builder.Configuration.GetSection("FreelanceCustoTotalConfig"));

// IOptions
builder.Services.AddProblemDetails();

// Excecao
builder.Services.AddExceptionHandler<ApiManipuladorExcecao>();

// Contexto Entity
builder.Services.AddDbContext<DevFreelaDBContexto>(o => o.UseInMemoryDatabase("DevFreelaDb"));

// Singleton - Vai manter sempre o mesmo objeto (Configuração, coisas fixas)
// Scoped    - Mantém o mesmo objeto mas apenas dentro da mesma requisição
// Transaint - A cada uso é uma nova instancia
builder.Services.AddSingleton<IConfigServico, ConfigServico>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
