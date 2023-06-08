using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace B_Rock.Data
{
    public class ApplicationDbContext : IdentityDbContext<B_RockUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Instrument>().HasData(
                new Instrument() { Id = 1, Name = "Bassoon" },
                new Instrument() { Id = 2, Name = "Cello" },
                new Instrument() { Id = 3, Name = "Clarinet" },
                new Instrument() { Id = 4, Name = "Concertmaster" },
                new Instrument() { Id = 5, Name = "Double bass" },
                new Instrument() { Id = 6, Name = "Guitar" },
                new Instrument() { Id = 7, Name = "Oboe" },
                new Instrument() { Id = 8, Name = "Horn" },
                new Instrument() { Id = 9, Name = "Piano" },
                new Instrument() { Id = 10, Name = "Timpani" },
                new Instrument() { Id = 11, Name = "Traverso" },
                new Instrument() { Id = 12, Name = "Viola" },
                new Instrument() { Id = 13, Name = "Violin" }
                );
            builder.Entity<Artist>().HasData(
                new Artist() { Id = 1, FirstName = "Benny", LastName = "Aghassi", InstrumentId = 1, Role = "Shared principal", UniqueURL = "Benny-Aghassi.jpg" },
                new Artist() { Id = 2, FirstName = "Tomasz", LastName = "Wesolowski", InstrumentId = 1, Role = "Shared principal", UniqueURL = "Tomasz-Aghassi.jpg" },
                new Artist() { Id = 3, FirstName = "Julien", LastName = "Barre", InstrumentId = 2, Role = "Shared principal", UniqueURL = "Julien-Barre.jpg" },
                new Artist() { Id = 4, FirstName = "Rebecca", LastName = "Rosen", InstrumentId = 2, Role = "Shared principal", UniqueURL = "Rebecca-Rosen.jpg" },
                new Artist() { Id = 5, FirstName = "Vincenzo", LastName = "Casale", InstrumentId = 3, Role = "Shared principal", UniqueURL = "Vincenzo-Casale.jpg" },
                new Artist() { Id = 6, FirstName = "Jean-Philippe", LastName = "Ponchin", InstrumentId = 3, UniqueURL = "Jean-Philippe-Ponchin.jpg" },
                new Artist() { Id = 7, FirstName = "Cecilia", LastName = "Bernardini", InstrumentId = 4, Role = "Acting concertmaster" },
                new Artist() { Id = 8, FirstName = "Evgeny", LastName = "Sviridov", InstrumentId = 4, Role = "Acting concertmaster", UniqueURL = "Evgeny-Sviridov.jpg" },
                new Artist() { Id = 9, FirstName = "Tom", LastName = "Devaere", InstrumentId = 5, Role = "Principal", UniqueURL = "Tom-Devaere.jpg" },
                new Artist() { Id = 10, FirstName = "Elise", LastName = "Christiaens", InstrumentId = 5, UniqueURL = "Elise-Christiaens.jpg" },
                new Artist() { Id = 11, FirstName = "Karl", LastName = "Nyhlin", InstrumentId = 6, UniqueURL = "Karl-Nyhlin.jpg" },
                new Artist() { Id = 12, FirstName = "Jean-Marc", LastName = "Philippe", InstrumentId = 7, Role = "Acting principal", UniqueURL = "Jean-Marc-Philippe.jpg" },
                new Artist() { Id = 13, FirstName = "Stefaan", LastName = "Verdegem", InstrumentId = 7, UniqueURL = "Stefaan-Verdegem.jpg" },
                new Artist() { Id = 14, FirstName = "Bart", LastName = "Aerbeydt", InstrumentId = 8, Role = "Shared principal", UniqueURL = "Bart-Aerbeydt.jpg" },
                new Artist() { Id = 15, FirstName = "Jeroen", LastName = "Billiet", InstrumentId = 8, Role = "Shared principal" },
                new Artist() { Id = 16, FirstName = "Mark", LastName = "De Merlier", InstrumentId = 8, UniqueURL = "Mark-De-Merlier.jpg" },
                new Artist() { Id = 17, FirstName = "Andreas", LastName = "Küppers", InstrumentId = 9, UniqueURL = "Andres-Küppers.jpg" },
                new Artist() { Id = 18, FirstName = "Jan", LastName = "Huylebroeck", InstrumentId = 10, Role = "Shared principal", UniqueURL = "Jan-Huylebroeck.jpg" },
                new Artist() { Id = 19, FirstName = "Koen", LastName = "Plaetinck", InstrumentId = 10, Role = "Shared principal" },
                new Artist() { Id = 20, FirstName = "Tami", LastName = "Krausz", InstrumentId = 11, Role = "Principal", UniqueURL = "Tami-Krausz.jpg" },
                new Artist() { Id = 21, FirstName = "Sien", LastName = "Huybrechts", InstrumentId = 11, UniqueURL = "Sien-Huybrechts.jpg" },
                new Artist() { Id = 22, FirstName = "Raquel", LastName = "Massadas", InstrumentId = 12, Role = "Principal", UniqueURL = "Raquel-Massadas.jpg" },
                new Artist() { Id = 23, FirstName = "Luc", LastName = "Gysbregts", InstrumentId = 12, UniqueURL = "Luc-Gysbregts.jpg" },
                new Artist() { Id = 24, FirstName = "Manuela", LastName = "Bucher", InstrumentId = 12,  UniqueURL = "Manuela-Bucher.jpg" },
                new Artist() { Id = 25, FirstName = "David", LastName = "Wish", InstrumentId = 13, UniqueURL = "David-Wish.jpg" },
                new Artist() { Id = 26, FirstName = "Sara", LastName = "Decorso", InstrumentId = 13, UniqueURL = "Sara-Decorso.jpg" },
                new Artist() { Id = 27, FirstName = "Ellie", LastName = "Nimeroski", InstrumentId = 13, UniqueURL = "Ellie-Nimeroski.jpg" },
                new Artist() { Id = 28, FirstName = "Jivka", LastName = "Kaltcheva", InstrumentId = 13, UniqueURL = "Jivka-Kaltcheva.jpg" },
                new Artist() { Id = 29, FirstName = "Liesbeth", LastName = "Nijs", InstrumentId = 13, UniqueURL = "Liesbeth-Nijs.jpg" },
                new Artist() { Id = 30, FirstName = "Madoka", LastName = "Nakamaru", InstrumentId = 13, UniqueURL = "Madoka-Nakamaru.jpg" },
                new Artist() { Id = 31, FirstName = "Ortwin", LastName = "Lowyck", InstrumentId = 13, UniqueURL = "Ortwin-Lowyck.jpg" },
                new Artist() { Id = 32, FirstName = "Shiho", LastName = "Ono", InstrumentId = 13, UniqueURL = "Shiho-Ono.jpg" },
                new Artist() { Id = 33, FirstName = "Rebecca", LastName = "Huber", InstrumentId = 13, UniqueURL = "Rebecca-Huber.jpg" },
                new Artist() { Id = 34, FirstName = "Yukie", LastName = "Yamaguchi", InstrumentId = 13, UniqueURL = "Yukie-Yamaguchi.jpg" }
                );
            builder.Entity<Staff>().HasData(
                new Staff() { Id = 1, FirstName = "Aglaja", LastName = "Thiesen", Role = "General Direction", Email = "aglaja@b-rock.org", PhoneNumber = "+32 471 69 52 19", UniqueURL = "Aglaja-Thiesen.jpg" },
                new Staff() { Id = 2, FirstName = "Albert", LastName = "Edelman", Role = "Artistic Direction", Email = "albert@b-rock.org", PhoneNumber = "+32 499 93 48 23", UniqueURL = "Albert-Edelman.jpg" },
                new Staff() { Id = 3, FirstName = "Davina", LastName = "Van Belle", Role = "Business Direction", Email = "davina@b-rock.org", PhoneNumber = "+32 477 98 04 28", UniqueURL = "Davina-VanBelle.jpg" },
                new Staff() { Id = 4, FirstName = "Claire", LastName = "Desmedt", Role = "Administration & Participation", Email = "claire@b-rock.org", PhoneNumber = "+32 494 48 79 62", UniqueURL = "Claire-Desmedt.jpg" },
                new Staff() { Id = 5, FirstName = "Tom", LastName = "Devaere", Role = "Casting Coordination & Music Libary", Email = "tom@b-rock.org", UniqueURL = "Tom-Devaere.jpg" },
                new Staff() { Id = 6, FirstName = "Sharon", LastName = "Buffel", Role = "Communication, Planning & Production", Email = "sharon@b-rock.org", PhoneNumber = "+32 491 25 22 33", UniqueURL = "Sharon-Buffel.jpg" },
                new Staff() { Id = 7, FirstName = "Toon", LastName = "Vannieuwenhuyse", Role = "Production & Libary", Email = "toon@b-rock.org", PhoneNumber = "+32 476 41 79 05", UniqueURL = "Toon-Vannieuwenhuyse.jpg" },
                new Staff() { Id = 8, FirstName = "Laurent", LastName = "Langlois", Role = "International Relations", Email = "laurent@b-rock.org", PhoneNumber = "+33 610 27 11 38", UniqueURL = "Laurent-Langlois.jpg" }
                );
            builder.Entity<Concert>().HasData(
                new Concert() { Id = 1, Title = "Mozart Mass", PerformedBy = "Haydn & Mozart with Vox Luminis XL", Location = "De Singel", City = "Antwerp", Country = "BE", DateAndTime = new DateTime(2023, 5, 25, 20, 00, 00), UniqueURL = "Mozart-Mass.jpg", ExternLink = "https://b-rock.org/project/mozart-mass-3/", Price = 15 },
                new Concert() { Id = 2, Title = "Tears Of Melancholy", PerformedBy = "Antoine Tamestit & B'Rock", Location = "Chapelle Corneille", City = "Rouen", Country = "FR", DateAndTime = new DateTime(2023, 6, 1, 20, 00, 00), UniqueURL = "Tears-Of-Melancholy.jpg", ExternLink = "https://b-rock.org/project/tears-of-melancholy-2/", Price = 25 },
                new Concert() { Id = 3, Title = "The Travels Of Monteverdi", PerformedBy = "B’Rock Orchestra & Vocal Consort", Location = "The German Church", City = "Stockholm", Country = "SE", DateAndTime = new DateTime(2023, 6, 2, 20, 00, 00), UniqueURL = "The-Travels-Of-Monteverdi.jpg", ExternLink = "https://b-rock.org/project/monteverdis-journey/", Price = 35 },
                new Concert() { Id = 4, Title = "Un Nouveau Vent", PerformedBy = "Fin de siècle à Paris", Location = "Opéra de Raims", City = "Reims", Country = "FR", DateAndTime = new DateTime(2023, 6, 24, 20, 00, 00), UniqueURL = "Un-Nouveau-Vent.jpg", ExternLink = "https://b-rock.org/project/un-nouveau-vent/" , Price = 45 }
                );
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Staff> Staff { get; set;}
        public DbSet<Ticket> Tickets { get; set; }
    }
}