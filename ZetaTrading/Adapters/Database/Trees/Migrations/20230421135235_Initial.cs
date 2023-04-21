using Microsoft.EntityFrameworkCore.Migrations;
using ZetaTrading.Adapters.Database.Common;

#nullable disable

namespace ZetaTrading.Adapters.Database.Trees.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "trees");

            migrationBuilder.CreateTable(
                name: "TreeNodes",
                schema: "trees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    RootId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeNodes_TreeNodes_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "trees",
                        principalTable: "TreeNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreeNodes_TreeNodes_RootId",
                        column: x => x.RootId,
                        principalSchema: "trees",
                        principalTable: "TreeNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeNodes_Name",
                schema: "trees",
                table: "TreeNodes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TreeNodes_ParentId",
                schema: "trees",
                table: "TreeNodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeNodes_RootId",
                schema: "trees",
                table: "TreeNodes",
                column: "RootId");

            migrationBuilder.Sql(EntityIdSequence.GenerateSqlCreate(
                TreeContext.SchemaName,
                SequenceBasedTreeNodeIdGenerator.SequenceName));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(EntityIdSequence.GenerateSqlDrop(
                TreeContext.SchemaName,
                SequenceBasedTreeNodeIdGenerator.SequenceName));

            migrationBuilder.DropTable(
                name: "TreeNodes",
                schema: "trees");
        }
    }
}
