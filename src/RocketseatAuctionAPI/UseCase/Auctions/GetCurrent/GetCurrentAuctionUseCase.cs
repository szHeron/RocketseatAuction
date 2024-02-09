using Microsoft.EntityFrameworkCore;
using RocketseatAuctionAPI.Entities;
using RocketseatAuctionAPI.Repositories;

namespace RocketseatAuctionAPI.UseCase.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new RockeatseatAuctionDbContext();

        var today = new DateTime(2024, 05, 01);

        return repository.Auctions.Include(auction => auction.Items).FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
