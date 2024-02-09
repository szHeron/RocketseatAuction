using Microsoft.AspNetCore.Mvc;
using RocketseatAuctionAPI.Communication.Request;
using RocketseatAuctionAPI.Filters;
using RocketseatAuctionAPI.UseCase.Offers.CreateOffer;

namespace RocketseatAuctionAPI.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttributes))]
public class OfferController : RocketseatAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreationOfferJson request, [FromServices] CreateOfferUseCase useCase)
    {
        var offerId = useCase.Execute(itemId, request);
        return Created(string.Empty, offerId);
    }
}
