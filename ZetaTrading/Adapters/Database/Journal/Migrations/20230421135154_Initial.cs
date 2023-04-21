using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ZetaTrading.Adapters.Database.Common;

#nullable disable

namespace ZetaTrading.Adapters.Database.Journal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "journal");

            migrationBuilder.CreateTable(
                name: "ExceptionRecords",
                schema: "journal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    StackTrace = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionRecords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionRecords_Timestamp",
                schema: "journal",
                table: "ExceptionRecords",
                column: "Timestamp");

            migrationBuilder.Sql(EntityIdSequence.GenerateSqlCreate(
                JournalContext.SchemaName,
                SequenceBasedExceptionRecordIdGenerator.SequenceName));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(EntityIdSequence.GenerateSqlDrop(
                JournalContext.SchemaName,
                SequenceBasedExceptionRecordIdGenerator.SequenceName));

            migrationBuilder.DropTable(
                name: "ExceptionRecords",
                schema: "journal");
        }
    }
}
