global using System.Collections.Generic;
global using System.Threading.Tasks;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.OpenApi.Models;
global using Tiko_Business.Abstract.Dapper;
global using Tiko_Business.Abstract.EntityFramework;
global using Tiko_Business.Concrete.Dapper;
global using Tiko_Business.Concrete.EntityFramework;
global using Tiko_DataAccess.Abstract.Dapper;
global using Tiko_DataAccess.Abstract.EntityFramework;
global using Tiko_DataAccess.Concrete.Dapper;
global using Tiko_DataAccess.Concrete.EntityFramework;
global using Tiko_Entities.Concrete;
global using Tiko_Entities.DTOs;
global using Tiko_WebAPI.Extensions;