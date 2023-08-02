using ClienteCRUDLogica;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteLogica, ClienteLogica>();
builder.Services.AddScoped<IEnderecoLogica, EnderecoLogica>();
builder.Services.AddScoped<IEstadoCivilLogica, EstadoCivilLogica>();
builder.Services.AddScoped<IOrgaoExpedicaoLogica, OrgaoExpedicaoLogica>();

builder.Services.AddScoped<ISexoLogica, SexoLogica>();
builder.Services.AddScoped<IRequestLogica, RequestLogica>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
