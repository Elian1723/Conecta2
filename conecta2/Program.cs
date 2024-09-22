using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Configurar la autenticaci�n con cookies.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Ruta de inicio de sesi�n.
    });

var app = builder.Build();

// Configurar el middleware de autenticaci�n y autorizaci�n.
app.UseAuthentication(); // Habilita la autenticaci�n
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Ruta por defecto que redirige a Login
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}");

    // Ruta para Dispositivos
    endpoints.MapControllerRoute(
        name: "dispositivos",
        pattern: "Dispositivos/{action=Dispositivos}/{id?}",
        defaults: new { controller = "Dispositivos" });
});
app.Run();
