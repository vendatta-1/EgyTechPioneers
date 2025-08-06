using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "RefreshTokens",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "RefreshTokens",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "RefreshTokens",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "RefreshTokens",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "RefreshTokens",
                newName: "DeletedBy");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "RefreshTokens",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "RefreshTokens",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "RefreshTokens",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "RefreshTokens",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "RefreshTokens",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "RefreshTokens",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "RefreshTokens",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "RefreshTokens",
                newName: "Deletedby");

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "RefreshTokens",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "RefreshTokens",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
