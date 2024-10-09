using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Configurar la autenticaci�n con cookies.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Ruta de inicio de sesi�n.
        options.AccessDeniedPath = "/Account/Login";
    });



var app = builder.Build();

 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); 

// Configurar el middleware de autenticaci�n y autorizaci�n.
app.UseAuthentication(); // Habilita la autenticaci�n
app.UseAuthorization(); // Habilita la autorizaci�n

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
