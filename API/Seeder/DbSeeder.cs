using API.Models;
using API.Data;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace API.Seeder;

public class DbSeeder
{
    
    public static void Seed(BackendDbContext context)
    {
        var movies = new List<Movie>
            {
                new Movie
                {
                    name = "Inception",
                    posterUrl = "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
                    genre = "Science Fiction, Action, Thriller",
                    director = "Christopher Nolan",
                    duration = 148,
                    fsk = 12,
                    description = "Dom Cobb ist ein geschickter Dieb mit der seltenen Fähigkeit der 'Extraktion': Er kann im Traumzustand das Unterbewusstsein seiner Zielpersonen anzapfen und deren Geheimnisse stehlen.",
                    isFeatured = false
                },
                new Movie
                {
                    name = "Der Herr der Ringe: Die Gefährten",
                    posterUrl = "https://image.tmdb.org/t/p/w500/5VTN0pR8gcqV3EPUHHfMGnJYN9L.jpg",
                    genre = "Fantasy, Abenteuer",
                    director = "Peter Jackson",
                    duration = 178,
                    fsk = 12,
                    description = "Der junge Hobbit Frodo Beutlin erbt einen Ring, der sich als mächtigster und gefährlichster Ring aller Zeiten entpuppt. Er muss sich auf eine epische Quest begeben, um ihn zu zerstören.",
                    isFeatured = true
                },
                new Movie
                {
                    name = "The Dark Knight",
                    posterUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
                    genre = "Action, Drama, Krimi",
                    director = "Christopher Nolan",
                    duration = 152,
                    fsk = 16,
                    description = "Batman muss sich seinem größten psychologischen und physischen Test stellen, als ein brillanter anarchistischer Verbrecher namens Joker Chaos und Zerstörung in Gotham City verbreitet.",
                    isFeatured = false
                },
                new Movie
                {
                    name = "Interstellar",
                    posterUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg",
                    genre = "Science Fiction, Drama, Abenteuer",
                    director = "Christopher Nolan",
                    duration = 169,
                    fsk = 12,
                    description = "In einer Zukunft, in der die Erde unbewohnbar wird, versucht eine Gruppe von Astronauten durch ein Wurmloch zu reisen, um die Menschheit zu retten.",
                    isFeatured = true
                },
                new Movie
                {
                    name = "Matrix",
                    posterUrl = "https://image.tmdb.org/t/p/w500/7u3pxc0K1wx32IleAkLv78MKgrw.jpg",
                    genre = "Science Fiction, Action",
                    director = "Lana und Lilly Wachowski",
                    duration = 136,
                    fsk = 16,
                    description = "Ein Computerprogrammierer erfährt, dass die Realität, wie er sie kennt, in Wirklichkeit eine komplexe Computersimulation ist, und schließt sich einem Widerstand an, um die Menschheit zu befreien.",
                    isFeatured = false
                }
            };
        
        if (!context.Movies.Any())
        {
            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
        
        var rooms = new List<CinemaRoom>();
        
        if (!context.CinemaRooms.Any())
        {
            for (int i = 0; i < 5; i++)
            {
                var room = new CinemaRoom
                {
                    name = $"Saal {i+1}",
                    totalRows = 5,
                    seatsPerRow = 10
                };
                rooms.Add(room);
            }
        
            context.CinemaRooms.AddRange(rooms);
            context.SaveChanges();   
        }
        
        var todayShowings = new List<Showing>();
        var tomorrowShowings = new List<Showing>();
        var afterTomorrowShowings = new List<Showing>();
        
        if (!context.Showings.Any())
        {
            var moviesFromDb = context.Movies.ToList();
            var roomsFromDb = context.CinemaRooms.ToList();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var timeToday = DateTime.Today.AddHours(12 + j * 4);

                    var show = new Showing
                    {
                        is3D = j % 2 == 0,
                        basePrice = (j % 2 == 0) ? 13.2 : 11.9,
                        date = timeToday,
                        Movie = moviesFromDb[i],
                        CinemaRoom = roomsFromDb[i],
                        Seats = new List<ShowingSeat>()
                    };

                    for (char row = 'A'; row <= 'E'; row++)
                    {
                        for (int place = 1; place <= 10; place++)
                        {
                            string type = row == 'A' ? "Ermäßigt" :
                                row == 'E' ? "Premium" : "Regulär";

                            double price = row == 'A' ? -1.7 :
                                row == 'E' ? 1.8 : 0;

                            show.Seats.Add(new ShowingSeat()
                            {
                                seatRow = row,
                                seatNumber = place,
                                type = type,
                                additionalPrice = price,
                                isAvailable = true,
                                Showing = show
                            });
                        }
                    }
                    todayShowings.Add(show);
                }
            }
            
            context.Showings.AddRange(todayShowings);
            
            context.SaveChanges();
        }
        
    }
}