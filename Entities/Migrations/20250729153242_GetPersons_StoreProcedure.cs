using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class GetPersons_StoreProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPerons = @"
                CREATE PROCEDURE [dbo].[GetAllPerosns]
                AS BEGIN
                SELECT PersonID,PersonName,Email,DateOfBirth,Gender,CountryID,Address,ReceiveNewsLetters FROM [dbo].[Persons]
                END
            ";
            migrationBuilder.Sql(sp_GetAllPerons);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPerons = @"
                DROP PROCEDURE [dbo].[GetAllPerosns]
                AS BEGIN
                SELECT PersonID,PersonName,Email,DateOfBirth,Gender,CountryID,Address,ReceiveNewsLetters FROM [dbo].[Persons]
                END
            ";
            migrationBuilder.Sql(sp_GetAllPerons);


        }
    }
}
