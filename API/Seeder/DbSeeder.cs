using System.Security.Cryptography;
using System.Text;
using API.Models;
using API.Data;
using API.Services;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace API.Seeder;

public class DbSeeder
{
    public static void Seed(BackendDbContext context)
    {
        if (!context.users.Any(u => u.role == 2))
        {
            CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);

            var adminUser = new User
            {
                email = "admin",
                firstName = "Admin",
                lastName = "User",
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                role = 2
            };

            context.users.Add(adminUser);
            context.SaveChanges();
        }

        
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
                    name = "Der Herr der Ringe: Die zwei Türme",
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
                    name = "Pulp Fiction",
                    posterUrl = "https://image.tmdb.org/t/p/w500/d5iIlFn5s0ImszYzBPb8JPIfbXD.jpg",
                    genre = "Krimi, Drama",
                    director = "Quentin Tarantino",
                    duration = 154,
                    fsk = 16,
                    description = "Die Leben von zwei Auftragskillern, einem Boxer, der Frau eines Gangsterbosses und zwei Kleinganoven verflechten sich in vier Geschichten von Gewalt und Erlösung im kriminellen Untergrund von Los Angeles.",
                    isFeatured = false
                }
            };
        
        if (!context.movies.Any())
        {
            context.movies.AddRange(movies);
            context.SaveChanges();
        }
        
        var rooms = new List<CinemaRoom>();
        
        if (!context.cinemaRooms.Any())
        {
            for (int i = 0; i < 5; i++)
            {
                var room = new CinemaRoom
                {
                    name = $"Saal {i+1}",
                    totalRows = 10,
                    seatsPerRow = 16
                };
                rooms.Add(room);
            }
        
            context.cinemaRooms.AddRange(rooms);
            context.SaveChanges();   
        }
        
        var todayShowings = new List<Showing>();
        var tomorrowShowings = new List<Showing>();
        var afterTomorrowShowings = new List<Showing>();
        
        if (!context.showings.Any())
        {
            var moviesFromDb = context.movies.ToList();
            var roomsFromDb = context.cinemaRooms.ToList();

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
                        movie = moviesFromDb[i],
                        cinemaRoom = roomsFromDb[i],
                        seats = new List<ShowingSeat>()
                    };

                    Console.WriteLine(moviesFromDb[i].name);
                    
                    // left block
                    for (char row = 'A'; row <= 'J'; row++)
                    {
                        for (int place = 1; place <= 3; place++)
                        {
                            string type = row == 'A' ? "Ermäßigt" :
                                row == 'E' ? "Premium" : "Regulär";

                            double price = row == 'A' ? -1.7 :
                                row == 'E' ? 1.8 : 0;

                            show.seats.Add(new ShowingSeat()
                            {
                                seatRow = row,
                                seatNumber = place,
                                type = type,
                                additionalPrice = price,
                                isAvailable = true,
                                showing = show
                            });
                        }
                    }
                    
                    // middle block
                    for (char row = 'A'; row <= 'J'; row++)
                    {
                        for (int place = 4; place <= 13; place++)
                        {
                            string type = row == 'A' ? "Ermäßigt" :
                                row == 'E' ? "Premium" : "Regulär";

                            double price = row == 'A' ? -1.7 :
                                row == 'E' ? 1.8 : 0;

                            show.seats.Add(new ShowingSeat()
                            {
                                seatRow = row,
                                seatNumber = place,
                                type = type,
                                additionalPrice = price,
                                isAvailable = true,
                                showing = show
                            });
                        }
                    }
                    
                    // right block
                    for (char row = 'A'; row <= 'J'; row++)
                    {
                        for (int place = 14; place <= 16; place++)
                        {
                            string type = row == 'A' ? "Ermäßigt" :
                                row == 'E' ? "Premium" : "Regulär";

                            double price = row == 'A' ? -1.7 :
                                row == 'E' ? 1.8 : 0;

                            show.seats.Add(new ShowingSeat()
                            {
                                seatRow = row,
                                seatNumber = place,
                                type = type,
                                additionalPrice = price,
                                isAvailable = true,
                                showing = show
                            });
                        }
                    }
                    
                    todayShowings.Add(show);
                }
                
                for (int j = 0; j < 3; j++)
                {
                    var timeTomorrow = DateTime.Today.AddDays(1).AddHours(12 + j * 4);

                    var show = new Showing
                    {
                        is3D = j % 2 == 0,
                        basePrice = (j % 2 == 0) ? 13.2 : 11.9,
                        date = timeTomorrow,
                        movie = moviesFromDb[i],
                        cinemaRoom = roomsFromDb[i],
                        seats = new List<ShowingSeat>()
                    };

                    for (char row = 'A'; row <= 'E'; row++)
                    {
                        for (int place = 1; place <= 10; place++)
                        {
                            string type = row == 'A' ? "Ermäßigt" :
                                row == 'E' ? "Premium" : "Regulär";

                            double price = row == 'A' ? -1.7 :
                                row == 'E' ? 1.8 : 0;

                            show.seats.Add(new ShowingSeat()
                            {
                                seatRow = row,
                                seatNumber = place,
                                type = type,
                                additionalPrice = price,
                                isAvailable = true,
                                showing = show
                            });
                        }
                    }
                    tomorrowShowings.Add(show);
                }
                
                for (int j = 0; j < 3; j++)
                {
                    var timeAfterTomorrow = DateTime.Today.AddDays(2).AddHours(12 + j * 4);

                    var show = new Showing
                    {
                        is3D = j % 2 == 0,
                        basePrice = (j % 2 == 0) ? 13.2 : 11.9,
                        date = timeAfterTomorrow,
                        movie = moviesFromDb[i],
                        cinemaRoom = roomsFromDb[i],
                        seats = new List<ShowingSeat>()
                    };

                    for (char row = 'A'; row <= 'E'; row++)
                    {
                        for (int place = 1; place <= 10; place++)
                        {
                            string type = row == 'A' ? "Ermäßigt" :
                                row == 'E' ? "Premium" : "Regulär";

                            double price = row == 'A' ? -1.7 :
                                row == 'E' ? 1.8 : 0;

                            show.seats.Add(new ShowingSeat()
                            {
                                seatRow = row,
                                seatNumber = place,
                                type = type,
                                additionalPrice = price,
                                isAvailable = true,
                                showing = show
                            });
                        }
                    }
                    afterTomorrowShowings.Add(show);
                }
            }
            
            
            context.showings.AddRange(todayShowings);
            context.showings.AddRange(tomorrowShowings);
            context.showings.AddRange(afterTomorrowShowings);
            context.SaveChanges();
        }
        else
        {
            var allShows = context.showings.OrderBy(s => s.id).ToList();

            int index = 0;
            foreach (var show in allShows)
            {
                int groupIndex = index % 3;
                int dayOffset = index / 15;

                var date = DateTime.Today.AddDays(dayOffset);

                if (groupIndex == 0)
                    show.date = date.AddHours(12);
                else if (groupIndex == 1)
                    show.date = date.AddHours(15).AddMinutes(30);
                else if (groupIndex == 2)
                    show.date = date.AddHours(19);

                index++;
            }

            context.SaveChanges();
        }
    }
    
    private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

}