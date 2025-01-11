using ShoppingPlace.Core.General;
using ShoppingPlace.Providers.GeneralProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddViewLocalization() // برای Views
    .AddDataAnnotationsLocalization(); // برای Validation Messages
;
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLocalization(options => options.ResourcesPath = "Messages.fa-IR");
builder.Services.AddSingleton<ILocalizationService, LocalizationService>();
var app = builder.Build();
var supportedCultures = new[] { "en-US", "fr-FR", "es-ES", "fa-IR" }; // زبان‌های پشتیبانی‌شده
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[3]) // زبان پیش‌فرض
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
