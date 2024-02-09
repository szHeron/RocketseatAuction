using RocketseatAuctionAPI.Communication.Request;
using RocketseatAuctionAPI.Entities;
using RocketseatAuctionAPI.Repositories;
using RocketseatAuctionAPI.Services;

namespace RocketseatAuctionAPI.UseCase.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

    public int Execute(int itemId, RequestCreationOfferJson request)
    {
        var repository = new RockeatseatAuctionDbContext();
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };
        repository.Offers.Add(offer);
        repository.SaveChanges();
        return offer.Id;
    }
}
