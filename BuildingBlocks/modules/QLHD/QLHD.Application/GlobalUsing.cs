global using MediatR;

global using System.Data;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.Extensions.DependencyInjection;

global using BuildingBlocks.Domain.DTOs;
global using BuildingBlocks.Domain.Entities;
global using BuildingBlocks.Domain.Interfaces;
global using BuildingBlocks.Domain.ValueTypes;

global using BuildingBlocks.Application.Common;
global using BuildingBlocks.Application.Common.DTOs;
global using BuildingBlocks.Application.Common.Mapping;
global using BuildingBlocks.Application.Attachments.DTOs;
global using BuildingBlocks.Application.ExtensionMethods;

global using BuildingBlocks.CrossCutting.Exceptions;
global using BuildingBlocks.CrossCutting.ExtensionMethods;

global using QLHD.Domain.Entities;
global using QLHD.Domain.Entities.DanhMuc;
global using QLHD.Domain.Constants;
global using QLHD.Application.DuAns.DTOs;