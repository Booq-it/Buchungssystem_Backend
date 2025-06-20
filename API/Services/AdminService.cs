﻿using API.Data;
using API.InputDto;
using API.Models;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IAdminService
    {
        bool AddMovie(MovieInputDto inputDto);
        bool EditMovie(MovieInputDto inputDto);
        bool DeleteMovie(int id);
        bool AddShowing(ShowingInputDto dto);
        bool EditShowing(ShowingInputDto dto, int id);
        bool DeleteShowing(int id);
        Task<bool> AddBookingByUserId(BookingInputDto dto);
        Task<bool> AddGuestBooking(GuestBookingInput dto);
    }
    
    public class AdminService : IAdminService
    {
        private readonly BackendDbContext _db;
        private readonly IBookingService _bookingService;
        
        public AdminService(BackendDbContext db, IBookingService bookingService)
        {
            _db = db;
            _bookingService = bookingService;
        }
        
        public bool AddMovie(MovieInputDto inputDto)
        {
            var movie = new Movie
            {
                name = inputDto.name,
                posterUrl = inputDto.posterUrl,
                genre = inputDto.genre,
                director = inputDto.director,
                duration = inputDto.duration,
                fsk = inputDto.fsk,
                description = inputDto.description,
                isFeatured = inputDto.isFeatured
            };
            
            _db.Add(movie);
            _db.SaveChanges();
            
            return true;
        }

        public bool EditMovie(MovieInputDto dto)
        {
            var movie = _db.movies.FirstOrDefault(m => m.id == dto.id);
            
            if(movie == null)
                return false;
            
            movie.name = dto.name;
            movie.posterUrl = dto.posterUrl;
            movie.genre = dto.genre;
            movie.director = dto.director;
            movie.duration = dto.duration;
            movie.fsk = dto.fsk;
            movie.description = dto.description;
            movie.isFeatured = dto.isFeatured;
            
            _db.Update(movie);
            _db.SaveChanges();
            
            return true;
        }
        
        public bool DeleteMovie(int id)
        {
            var movie = _db.movies.FirstOrDefault(m => m.id == id);
            
            if (movie == null)
                return false;
            
            _db.movies.Remove(movie);
            _db.SaveChanges();
            
            return true;
        }

        public bool AddShowing(ShowingInputDto dto)
        {
            var movieFromDb = _db.movies.FirstOrDefault(m => m.id == dto.movieId);
            
            var cinemaRoomFromDb = _db.cinemaRooms.FirstOrDefault(m => m.id == dto.cinemaRoomId);
            
            var show = new Showing
            {
                is3D = dto.is3D,
                basePrice = dto.basePrice,
                date = dto.date,
                movie = movieFromDb,
                cinemaRoom = cinemaRoomFromDb,
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

            _db.Add(show);
            _db.SaveChanges();
            
            return true;
        }

        public bool EditShowing(ShowingInputDto dto, int id)
        {
            var showing = _db.showings
                .FirstOrDefault(s => s.id == id);
            
            if (showing == null)
                return false;
            
            showing.is3D = dto.is3D;
            showing.basePrice = dto.basePrice;
            showing.date = dto.date;
            showing.movie = _db.movies.FirstOrDefault(m => m.id == dto.movieId);
            showing.cinemaRoom = _db.cinemaRooms.FirstOrDefault(m => m.id == dto.cinemaRoomId);
            
            _db.Update(showing);
            _db.SaveChanges();
            
            return true;
        }
        
        public bool DeleteShowing(int id)
        {
            var showing = _db.showings.FirstOrDefault(s => s.id == id);
            
            if (showing == null)
                return false;
            
            _db.showings.Remove(showing);
            _db.SaveChanges();
            
            return true;
        }

        public async Task<bool> AddBookingByUserId(BookingInputDto dto)
        {
            if( await _bookingService.MakeBooking(dto))
                return true;
            
            return false;
        }

        public async Task<bool> AddGuestBooking(GuestBookingInput dto)
        {
            if (await _bookingService.MakeGuestBooking(dto))
                return true;

            return false;
        }
    }
}
