using Radzen;
using ServerTest.Components;


//ColdShine.Blazor.Models.ConditionCollection conditions = new ColdShine.Blazor.Models.ConditionCollection();
//conditions.Add(new ColdShine.Blazor.Models.Condition { Property = "Name", Operator = ColdShine.Blazor.Models.Operators.ContainsOperator,Value="b" });
//var items = new[] { new { Name = "abc", Value = 1 }, new { Name = "bcd", Value = 2 } };
//var result = conditions.Where(items).ToArray();
//var result = items.Where(item => item.Name.Contains("a"));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
