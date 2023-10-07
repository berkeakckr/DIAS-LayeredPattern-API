var builder = WebApplication.CreateBuilder(args);

// Add services to the container.                     //
builder.Services.AddRazorPages();                     //This is where the configuring happens inbetween builder dec. and the build
builder.Services.AddControllers();//for controllers   //
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");                    //Middleware
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();//This needs to be between routing and endpoints for the auth. to be proper

app.UseEndpoints(endpoints => //Needed for endpoint routes like localhost/api/users
{
    endpoints.MapControllers();
});



app.MapRazorPages();

app.Run();
