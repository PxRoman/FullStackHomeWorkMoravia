using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationManagement.Infrastructure.Migrations
{
    public partial class AddedJobSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TranslationJobs",
                columns: new[] { "Id", "CustomerName", "OriginalContent", "Price", "Status", "TranslatedContent" },
                values: new object[] { 1, "Roman", "OriginalContent", 0.5, 0, "TranslatedContent" });

            migrationBuilder.InsertData(
                table: "TranslationJobs",
                columns: new[] { "Id", "CustomerName", "OriginalContent", "Price", "Status", "TranslatedContent" },
                values: new object[] { 2, "Michal", "OriginalContent", 0.29999999999999999, 1, "TranslatedContent" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TranslationJobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TranslationJobs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
