ASP.NET Core
============

[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://www.dotnetfoundation.org/)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt) [![Help Wanted](https://img.shields.io/github/issues/dotnet/aspnetcore/help%20wanted?color=%232EA043&label=help%20wanted&style=flat-square)](https://github.com/dotnet/aspnetcore/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22) [![Good First Issues](https://img.shields.io/github/issues/dotnet/aspnetcore/good%20first%20issue?color=%23512BD4&label=good%20first%20issue&style=flat-square)](https://github.com/dotnet/aspnetcore/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22)
[![Discord](https://img.shields.io/discord/732297728826277939?style=flat-square&label=Discord&logo=discord&logoColor=white&color=7289DA)](https://aka.ms/dotnet-discord)

ASP.NET Core is an open-source and cross-platform framework for building modern cloud-based internet-connected applications, such as web apps, IoT apps, and mobile backends. ASP.NET Core apps run on [.NET](https://dot.net), a free, cross-platform, and open-source application runtime. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac, and Linux. [Learn more about ASP.NET Core](https://learn.microsoft.com/aspnet/core/).

## Getting start

1. Run ```docker compose up -d``` to deploy a database. You need to have docker installed on your machine. **Please change the password inside ```docker-compose.yml``` and database connection string
inside ```appsettings.json```**
2. Open solution with ```Visual Studio 2022``` Make sure that you have ```ASP.NET and web development``` installed.
3. Open NuGet Package Manager Console by going to ```Tools > NuGet Package Manager > Package Manager Console```
4. Run on that console ```add-migration Initial``` and ```update-database``` after.
5. Press debug or start up your application in ```Visual Studio 2022```
