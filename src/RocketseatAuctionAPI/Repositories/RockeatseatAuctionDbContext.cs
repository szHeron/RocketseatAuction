using Microsoft.EntityFrameworkCore;
using RocketseatAuctionAPI.Entities;

namespace RocketseatAuctionAPI.Repositories;

public class RockeatseatAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { set; get; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=D:\\Downloads\\leilaoDbNLW.db");
    }
}
