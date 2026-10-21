var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MauiAppMeuCombustivel>("mauiappmeucombustivel");

builder.Build().Run();
