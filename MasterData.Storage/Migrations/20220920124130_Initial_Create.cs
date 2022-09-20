using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterData.Storage.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUnit",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    nKey = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    szName = table.Column<string>(nullable: false),
                    nType = table.Column<short>(nullable: false),
                    dtCreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUnit", x => x.gId);
                    table.UniqueConstraint("AK_tblUnit_nKey", x => x.nKey);
                });

            migrationBuilder.CreateTable(
                name: "tbEquipment",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    nKey = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    szName = table.Column<string>(nullable: false),
                    bIsUsed = table.Column<bool>(nullable: false),
                    gUnitId = table.Column<Guid>(nullable: false),
                    dtCreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEquipment", x => x.gId);
                    table.UniqueConstraint("AK_tbEquipment_nKey", x => x.nKey);
                    table.ForeignKey(
                        name: "FK_tbEquipment_tblUnit_gUnitId",
                        column: x => x.gUnitId,
                        principalTable: "tblUnit",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTrend",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    nKey = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    szName = table.Column<string>(maxLength: 150, nullable: false),
                    dtCreatedAt = table.Column<DateTime>(nullable: false),
                    gUnitId = table.Column<Guid>(nullable: true),
                    gEquipmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTrend", x => x.gId);
                    table.UniqueConstraint("AK_tblTrend_nKey", x => x.nKey);
                    table.ForeignKey(
                        name: "FK_tblTrend_tbEquipment_gEquipmentId",
                        column: x => x.gEquipmentId,
                        principalTable: "tbEquipment",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTrend_tblUnit_gUnitId",
                        column: x => x.gUnitId,
                        principalTable: "tblUnit",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCounterTrend",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    nKey = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    szName = table.Column<string>(maxLength: 150, nullable: false),
                    dtCreatedAt = table.Column<DateTime>(nullable: false),
                    gTrendId = table.Column<Guid>(nullable: false),
                    nRecordMode = table.Column<int>(nullable: false),
                    nType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCounterTrend", x => x.gId);
                    table.UniqueConstraint("AK_tblCounterTrend_nKey", x => x.nKey);
                    table.ForeignKey(
                        name: "FK_tblCounterTrend_tblTrend_gTrendId",
                        column: x => x.gTrendId,
                        principalTable: "tblTrend",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblParameterTrend",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    nKey = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    szName = table.Column<string>(maxLength: 150, nullable: false),
                    dtCreatedAt = table.Column<DateTime>(nullable: false),
                    gTrendId = table.Column<Guid>(nullable: false),
                    nRecordMode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblParameterTrend", x => x.gId);
                    table.UniqueConstraint("AK_tblParameterTrend_nKey", x => x.nKey);
                    table.ForeignKey(
                        name: "FK_tblParameterTrend_tblTrend_gTrendId",
                        column: x => x.gTrendId,
                        principalTable: "tblTrend",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbEquipment_gUnitId",
                table: "tbEquipment",
                column: "gUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCounterTrend_gTrendId",
                table: "tblCounterTrend",
                column: "gTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_tblParameterTrend_gTrendId",
                table: "tblParameterTrend",
                column: "gTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrend_gEquipmentId",
                table: "tblTrend",
                column: "gEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTrend_gUnitId",
                table: "tblTrend",
                column: "gUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCounterTrend");

            migrationBuilder.DropTable(
                name: "tblParameterTrend");

            migrationBuilder.DropTable(
                name: "tblTrend");

            migrationBuilder.DropTable(
                name: "tbEquipment");

            migrationBuilder.DropTable(
                name: "tblUnit");
        }
    }
}
