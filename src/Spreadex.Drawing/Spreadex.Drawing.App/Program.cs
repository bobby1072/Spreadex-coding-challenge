using Microsoft.Extensions.DependencyInjection;
using Spreadex.Drawing.App.Abstract;
using Spreadex.Drawing.App.Extensions;

var services = new ServiceCollection();

services
        .AddSpreadexDrawing();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<IApp>();


app.Run();
