﻿using B_Rock.Data;
using Microsoft.EntityFrameworkCore;

namespace B_Rock.Services
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _dbContext;
        public ArtistService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddArtist(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
        }

        public void DeleteArtist(Artist artist)
        {
            _dbContext.Artists.Update(artist);
            _dbContext.SaveChanges();
        }

        public Artist GetById(int id)
        {
            return _dbContext.Artists.Include(a => a.Instrument).Where(a => a.Id == id && a.IsDeleted == false).Select(a => new Artist
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Role = a.Role,
                Instrument = a.Instrument,
                InstrumentId = a.InstrumentId,
                UniqueURL = a.UniqueURL,
                IsDeleted = a.IsDeleted
            }).FirstOrDefault();
        }

        public IEnumerable<Artist> GetByInstrument(int instrumentId)
        {
            return _dbContext.Artists.Include(a => a.Instrument)
                .Where(a => a.InstrumentId == instrumentId && a.IsDeleted == false)
                .Select(a => new Artist
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Role = a.Role,
                    InstrumentId = a.InstrumentId,
                    Instrument = a.Instrument,
                    UniqueURL= a.UniqueURL,
                    IsDeleted = a.IsDeleted
                }).ToList();
        }

        public void UpdateArtist(Artist artist)
        {
            _dbContext.Artists.Update(artist);
            _dbContext.SaveChanges();
        }
    }
}
