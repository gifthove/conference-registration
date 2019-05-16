using Microsoft.EntityFrameworkCore.Migrations;

namespace conference_registration.data.Migrations
{
    public partial class AddedMoreColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conferences",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Attendees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Attendees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Attendees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Attendees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IndividualBooking",
                table: "Attendees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Attendees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Attendees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TermsAndConditions",
                table: "Attendees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "IndividualBooking",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "TermsAndConditions",
                table: "Attendees");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Conferences",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400);
        }
    }
}
