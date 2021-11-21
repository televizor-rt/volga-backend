using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Televizor.VolgaIronHack.Entities;
using Televizor.VolgaIronHack.Users;

namespace Televizor.VolgaIronHack;


[ApiController]
[Route("api/[controller]")]
public abstract class AbstractController : ControllerBase
{
    protected readonly ICurrentUserProvider CurrentUserProvider;
    protected readonly VolgaIronHackDbContext DbContext;
    protected readonly IMapper Mapper;
    protected readonly ILogger Logger;


    protected AbstractController(
        VolgaIronHackDbContext dbContext,
        IMapper mapper,
        ILoggerFactory loggerFactory,
        ICurrentUserProvider currentUserProvider)
    {
        DbContext = dbContext;
        Mapper = mapper;
        CurrentUserProvider = currentUserProvider;
        Logger = loggerFactory.CreateLogger(GetType());
    }


    protected IActionResult GetListResult<TItem>(ListView<TItem> list)=>
        list.Items.Count is 0
            ? NoContent()
            : Ok(list);
}