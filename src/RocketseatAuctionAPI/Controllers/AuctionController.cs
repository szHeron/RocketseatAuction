﻿using Microsoft.AspNetCore.Mvc;
using RocketseatAuctionAPI.Entities;
using RocketseatAuctionAPI.UseCase.Auctions.GetCurrent;

namespace RocketseatAuctionAPI.Controllers;

public class AuctionController : RocketseatAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var UseCase = new GetCurrentAuctionUseCase();
        var result = UseCase.Execute();

        if(result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }
}
