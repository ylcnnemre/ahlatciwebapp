using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ahlatciapp.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboneBilgi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoyAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meslek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uyruk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoyTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KmlFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneKizlik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SağlıkDurum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboneBilgi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrSoyAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrTcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboneAdres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İlce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mahalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaddeSok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Daire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboneKsBilgiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboneAdres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboneAdres_AboneBilgi_AboneKsBilgiId",
                        column: x => x.AboneKsBilgiId,
                        principalTable: "AboneBilgi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faturalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    M3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FaturaKesimTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AboneKsBilgiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faturalar_AboneBilgi_AboneKsBilgiId",
                        column: x => x.AboneKsBilgiId,
                        principalTable: "AboneBilgi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboneAdres_AboneKsBilgiId",
                table: "AboneAdres",
                column: "AboneKsBilgiId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faturalar_AboneKsBilgiId",
                table: "Faturalar",
                column: "AboneKsBilgiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboneAdres");

            migrationBuilder.DropTable(
                name: "Faturalar");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "AboneBilgi");
        }
    }
}
