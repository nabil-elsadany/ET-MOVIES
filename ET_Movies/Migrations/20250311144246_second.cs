using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ET_Movies.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actor_ActorsId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movie_MoviesId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Cinema_CinemaId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Movie_MoviesId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinema",
                table: "Cinema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "Cinema",
                newName: "Cinemas");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "ActorMovie",
                newName: "ActorMovies");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actors");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_MoviesId",
                table: "OrderItems",
                newName: "IX_OrderItems_MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_CinemaId",
                table: "Movies",
                newName: "IX_Movies_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_CategoryId",
                table: "Movies",
                newName: "IX_Movies_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovies",
                newName: "IX_ActorMovies_MoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies",
                columns: new[] { "ActorsId", "MoviesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Actors_ActorsId",
                table: "ActorMovies",
                column: "ActorsId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Movies_MoviesId",
                table: "ActorMovies",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_MoviesId",
                table: "OrderItems",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Actors_ActorsId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Movies_MoviesId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_MoviesId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameTable(
                name: "Cinemas",
                newName: "Cinema");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actor");

            migrationBuilder.RenameTable(
                name: "ActorMovies",
                newName: "ActorMovie");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_MoviesId",
                table: "OrderItem",
                newName: "IX_OrderItem_MoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CinemaId",
                table: "Movie",
                newName: "IX_Movie_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoryId",
                table: "Movie",
                newName: "IX_Movie_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovies_MoviesId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinema",
                table: "Cinema",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actor_ActorsId",
                table: "ActorMovie",
                column: "ActorsId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movie_MoviesId",
                table: "ActorMovie",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cinema_CinemaId",
                table: "Movie",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Movie_MoviesId",
                table: "OrderItem",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id");
        }
    }
}
