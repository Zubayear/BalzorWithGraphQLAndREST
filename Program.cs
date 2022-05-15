using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using BlazorExp.Data;
using BlazorExp.GraphQL;
using BlazorExp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRepository, TicketRepository>();
builder.Services.AddScoped<TicketsService>();

// DynamoDB
var aWsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(aWsOptions);
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();

builder.Services
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapControllers();
app.MapGraphQL();
app.Run();