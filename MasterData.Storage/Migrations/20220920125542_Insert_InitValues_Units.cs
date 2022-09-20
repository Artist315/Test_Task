using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterData.Storage.Migrations
{
    public partial class Insert_InitValues_Units : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblUnit",
                columns: new[] { "gId", "dtCreatedAt", "nKey", "szName", "nType" },
                values: new object[,]
                {
                    { new Guid("f8a5032e-6995-4826-b128-41423b2930f7"), new DateTime(2022, 9, 20, 12, 55, 41, 15, DateTimeKind.Utc).AddTicks(7813), 1, "Test1", (short)23 },
                    { new Guid("2e0685bc-e6ac-4dda-9d67-8ce361e4e760"), new DateTime(2022, 9, 20, 12, 55, 41, 15, DateTimeKind.Utc).AddTicks(8296), 2, "Test2", (short)22 },
                    { new Guid("c89e11a1-34c5-4eaf-8084-956cc5e510bf"), new DateTime(2022, 9, 20, 12, 55, 41, 15, DateTimeKind.Utc).AddTicks(8336), 3, "Test3", (short)22 },
                    { new Guid("a2664588-f699-4fe2-ad24-696c679f68b6"), new DateTime(2022, 9, 20, 12, 55, 41, 15, DateTimeKind.Utc).AddTicks(8341), 4, "Test4", (short)22 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblUnit",
                keyColumn: "gId",
                keyValue: new Guid("2e0685bc-e6ac-4dda-9d67-8ce361e4e760"));

            migrationBuilder.DeleteData(
                table: "tblUnit",
                keyColumn: "gId",
                keyValue: new Guid("a2664588-f699-4fe2-ad24-696c679f68b6"));

            migrationBuilder.DeleteData(
                table: "tblUnit",
                keyColumn: "gId",
                keyValue: new Guid("c89e11a1-34c5-4eaf-8084-956cc5e510bf"));

            migrationBuilder.DeleteData(
                table: "tblUnit",
                keyColumn: "gId",
                keyValue: new Guid("f8a5032e-6995-4826-b128-41423b2930f7"));
        }
    }
}
