using Microsoft.EntityFrameworkCore.Migrations;

namespace DataKendaraan.Migrations
{
    public partial class ConnectDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kendaraan",
                columns: table => new
                {
                    NoRegistrasi = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaPemilik = table.Column<string>(type: "text", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    Merk = table.Column<string>(type: "text", nullable: false),
                    TahunPembuatan = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Kapasitas = table.Column<int>(type: "int", nullable: false),
                    Warna = table.Column<string>(type: "text", nullable: false),
                    BahanBakar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kendaraan", x => x.NoRegistrasi);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kendaraan");
        }
    }
}
