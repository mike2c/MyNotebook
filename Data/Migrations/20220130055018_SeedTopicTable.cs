using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedTopicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 1, "Math" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 2, "Social Studies" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 3, "Geography" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 4, "English" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 5, "Art" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 6, "Algebra" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 7, "Geometry" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 8, "Health" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 9, "Spanish" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 10, "Speech" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { 11, "History" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "TopicId",
                keyValue: 11);
        }
    }
}
