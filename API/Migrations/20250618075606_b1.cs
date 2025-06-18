using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class b1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Showings_ShowingId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Showings_ShowingId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_GuestBookings_GuestBookingId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Showings_ShowingId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showings_CinemaRooms_CinemaRoomId",
                table: "Showings");

            migrationBuilder.DropForeignKey(
                name: "FK_Showings_Movies_MovieId",
                table: "Showings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Showings",
                table: "Showings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestBookings",
                table: "GuestBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaRooms",
                table: "CinemaRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Showings",
                newName: "showings");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "seats");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "GuestBookings",
                newName: "guestBookings");

            migrationBuilder.RenameTable(
                name: "CinemaRooms",
                newName: "cinemaRooms");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "bookings");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "showings",
                newName: "movieId");

            migrationBuilder.RenameColumn(
                name: "CinemaRoomId",
                table: "showings",
                newName: "cinemaRoomId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "showings",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Showings_MovieId",
                table: "showings",
                newName: "IX_showings_movieId");

            migrationBuilder.RenameIndex(
                name: "IX_Showings_CinemaRoomId",
                table: "showings",
                newName: "IX_showings_cinemaRoomId");

            migrationBuilder.RenameColumn(
                name: "ShowingId",
                table: "seats",
                newName: "showingId");

            migrationBuilder.RenameColumn(
                name: "GuestBookingId",
                table: "seats",
                newName: "GuestBookingid");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "seats",
                newName: "Bookingid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "seats",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ShowingId",
                table: "seats",
                newName: "IX_seats_showingId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_GuestBookingId",
                table: "seats",
                newName: "IX_seats_GuestBookingid");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_BookingId",
                table: "seats",
                newName: "IX_seats_Bookingid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "movies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ShowingId",
                table: "guestBookings",
                newName: "showingId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "guestBookings",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "IsCancelled",
                table: "guestBookings",
                newName: "isCancelled");

            migrationBuilder.RenameColumn(
                name: "GuestLastName",
                table: "guestBookings",
                newName: "guestLastName");

            migrationBuilder.RenameColumn(
                name: "GuestFirstName",
                table: "guestBookings",
                newName: "guestFirstName");

            migrationBuilder.RenameColumn(
                name: "GuestEmail",
                table: "guestBookings",
                newName: "guestEmail");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "guestBookings",
                newName: "bookingDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "guestBookings",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_GuestBookings_ShowingId",
                table: "guestBookings",
                newName: "IX_guestBookings_showingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cinemaRooms",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bookings",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ShowingId",
                table: "bookings",
                newName: "showingId");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "bookings",
                newName: "bookingDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bookings",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserId",
                table: "bookings",
                newName: "IX_bookings_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ShowingId",
                table: "bookings",
                newName: "IX_bookings_showingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_showings",
                table: "showings",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_seats",
                table: "seats",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guestBookings",
                table: "guestBookings",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cinemaRooms",
                table: "cinemaRooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_showings_showingId",
                table: "bookings",
                column: "showingId",
                principalTable: "showings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_users_userId",
                table: "bookings",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_guestBookings_showings_showingId",
                table: "guestBookings",
                column: "showingId",
                principalTable: "showings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_seats_bookings_Bookingid",
                table: "seats",
                column: "Bookingid",
                principalTable: "bookings",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_guestBookings_GuestBookingid",
                table: "seats",
                column: "GuestBookingid",
                principalTable: "guestBookings",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_showings_showingId",
                table: "seats",
                column: "showingId",
                principalTable: "showings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_showings_cinemaRooms_cinemaRoomId",
                table: "showings",
                column: "cinemaRoomId",
                principalTable: "cinemaRooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_showings_movies_movieId",
                table: "showings",
                column: "movieId",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_showings_showingId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_users_userId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_guestBookings_showings_showingId",
                table: "guestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_seats_bookings_Bookingid",
                table: "seats");

            migrationBuilder.DropForeignKey(
                name: "FK_seats_guestBookings_GuestBookingid",
                table: "seats");

            migrationBuilder.DropForeignKey(
                name: "FK_seats_showings_showingId",
                table: "seats");

            migrationBuilder.DropForeignKey(
                name: "FK_showings_cinemaRooms_cinemaRoomId",
                table: "showings");

            migrationBuilder.DropForeignKey(
                name: "FK_showings_movies_movieId",
                table: "showings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_showings",
                table: "showings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_seats",
                table: "seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_guestBookings",
                table: "guestBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cinemaRooms",
                table: "cinemaRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookings",
                table: "bookings");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "showings",
                newName: "Showings");

            migrationBuilder.RenameTable(
                name: "seats",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "guestBookings",
                newName: "GuestBookings");

            migrationBuilder.RenameTable(
                name: "cinemaRooms",
                newName: "CinemaRooms");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "Showings",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "cinemaRoomId",
                table: "Showings",
                newName: "CinemaRoomId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Showings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_showings_movieId",
                table: "Showings",
                newName: "IX_Showings_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_showings_cinemaRoomId",
                table: "Showings",
                newName: "IX_Showings_CinemaRoomId");

            migrationBuilder.RenameColumn(
                name: "showingId",
                table: "Seats",
                newName: "ShowingId");

            migrationBuilder.RenameColumn(
                name: "GuestBookingid",
                table: "Seats",
                newName: "GuestBookingId");

            migrationBuilder.RenameColumn(
                name: "Bookingid",
                table: "Seats",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Seats",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_seats_showingId",
                table: "Seats",
                newName: "IX_Seats_ShowingId");

            migrationBuilder.RenameIndex(
                name: "IX_seats_GuestBookingid",
                table: "Seats",
                newName: "IX_Seats_GuestBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_seats_Bookingid",
                table: "Seats",
                newName: "IX_Seats_BookingId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "showingId",
                table: "GuestBookings",
                newName: "ShowingId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "GuestBookings",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "isCancelled",
                table: "GuestBookings",
                newName: "IsCancelled");

            migrationBuilder.RenameColumn(
                name: "guestLastName",
                table: "GuestBookings",
                newName: "GuestLastName");

            migrationBuilder.RenameColumn(
                name: "guestFirstName",
                table: "GuestBookings",
                newName: "GuestFirstName");

            migrationBuilder.RenameColumn(
                name: "guestEmail",
                table: "GuestBookings",
                newName: "GuestEmail");

            migrationBuilder.RenameColumn(
                name: "bookingDate",
                table: "GuestBookings",
                newName: "BookingDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "GuestBookings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_guestBookings_showingId",
                table: "GuestBookings",
                newName: "IX_GuestBookings_ShowingId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CinemaRooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "showingId",
                table: "Bookings",
                newName: "ShowingId");

            migrationBuilder.RenameColumn(
                name: "bookingDate",
                table: "Bookings",
                newName: "BookingDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_userId",
                table: "Bookings",
                newName: "IX_Bookings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_showingId",
                table: "Bookings",
                newName: "IX_Bookings_ShowingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Showings",
                table: "Showings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestBookings",
                table: "GuestBookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaRooms",
                table: "CinemaRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Showings_ShowingId",
                table: "Bookings",
                column: "ShowingId",
                principalTable: "Showings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Showings_ShowingId",
                table: "GuestBookings",
                column: "ShowingId",
                principalTable: "Showings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_GuestBookings_GuestBookingId",
                table: "Seats",
                column: "GuestBookingId",
                principalTable: "GuestBookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Showings_ShowingId",
                table: "Seats",
                column: "ShowingId",
                principalTable: "Showings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showings_CinemaRooms_CinemaRoomId",
                table: "Showings",
                column: "CinemaRoomId",
                principalTable: "CinemaRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showings_Movies_MovieId",
                table: "Showings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
