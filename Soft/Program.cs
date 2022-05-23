using eSportSchool.Data;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using eSportSchool.Infra.Initializers;
using eSportSchool.Infra.Party;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Soft.Authorization.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<eSportSchoolDB>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages(o => {
    o.Conventions.AuthorizePage("/Trainers/Delete");
    //o.Conventions.AuthorizePage("/Trainers/Create");
    //o.Conventions.AuthorizePage("/Trainers/Edit");
    //o.Conventions.AuthorizePage("/KindOfSports/Create");
    //o.Conventions.AuthorizePage("/KindOfSports/Edit");
    //o.Conventions.AuthorizePage("/KindOfSports/Delete");
    //o.Conventions.AuthorizePage("/SportTeams/Create");
    //o.Conventions.AuthorizePage("/SportTeams/Edit");
    //o.Conventions.AuthorizePage("/SportTeams/Delete");
});
builder.Services.AddTransient<ISportTeamsRepo, SportTeamsRepo>();
builder.Services.AddTransient<ITrainersRepo, TrainersRepo>();
builder.Services.AddTransient<IKindOfSportRepo, KindOfSportRepo>();
builder.Services.AddTransient<ITrainerSportTeamsRepo, TrainerSportTeamsRepo>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<eSportSchoolDB>();
    _ = (db?.Database?.EnsureCreated());
    eSportSchoolDBInitializer.Init(db);
    var services = scope.ServiceProvider;
    await SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<eSportSchoolDB>();
    db?.Database?.EnsureCreated();
    eSportSchoolDBInitializer.Init(db);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
