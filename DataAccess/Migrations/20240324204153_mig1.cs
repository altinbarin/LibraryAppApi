using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalStock = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    InStock = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TCKNO = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "Status", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(3818), null, null, "Cemal", true, "Süreya" },
                    { 2, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(3821), null, null, "Orhan", true, "Kemal" },
                    { 3, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(3823), null, null, "Sabahattin", true, "Ali" },
                    { 4, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(3825), null, null, "Rick", true, "Riordan" },
                    { 5, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(3827), null, null, "J.K.", true, "Rowling" },
                    { 6, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(3828), null, null, "Anonim", true, "Anonim" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "DeletedDate", "GenreId", "InStock", "ModifiedDate", "Name", "PublisherId", "Section", "Status", "TotalStock" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5726), null, 1, 5, null, "Kürk Mantolu Madonna", 1, "113", true, 5 },
                    { 2, 1, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5731), null, 3, 2, null, "Güz Bitiği", 2, "113", true, 2 },
                    { 3, 1, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5734), null, 3, 1, null, "On Üç Günün Mektupları", 1, "113", true, 1 },
                    { 4, 1, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5736), null, 3, 1, null, "Günübirlik", 2, "113", true, 1 },
                    { 5, 1, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5739), null, 3, 1, null, "Üvercinka", 2, "113", true, 1 },
                    { 6, 2, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5741), null, 1, 3, null, "72. Koğuş", 5, "113", true, 3 },
                    { 7, 2, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5743), null, 1, 1, null, "Tersine Dünya", 5, "113", true, 1 },
                    { 8, 2, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5746), null, 1, 12, null, "Percy Jackson", 3, "110", true, 12 },
                    { 9, 6, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5748), null, 7, 19, null, "1919'dan Günümüze Türkiye", 6, "110", true, 19 },
                    { 10, 5, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5751), null, 1, 1, null, "Yüzüklerin Efendisi", 4, "110", true, 1 },
                    { 11, 6, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(5753), null, 4, 1, null, "La Fontaine Masalları", 3, "109", true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8467), null, null, "Roman", true },
                    { 2, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8469), null, null, "Hikaye", true },
                    { 3, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8471), null, null, "Şiir", true },
                    { 4, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8473), null, null, "Fabl", true },
                    { 5, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8474), null, null, "Masal", true },
                    { 6, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8476), null, null, "Tiyatro", true },
                    { 7, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8478), null, null, "Deneme", true },
                    { 8, new DateTime(2024, 3, 24, 23, 41, 53, 507, DateTimeKind.Local).AddTicks(8486), null, null, "Ansiklopedi", true }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "ModifiedDate", "Name", "Phone", "Status", "Surname", "TCKNO" },
                values: new object[,]
                {
                    { 1, "İstanbul, Kadıköy", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(304), null, "furkanaltinbarin@gmail.com", null, "Furkan", "05431768274", true, "Altınbarın", "20890834938" },
                    { 2, "İstanbul, Cevizlibağ", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(308), null, "mehmetcatmakasli@mail.com", null, "Mehmet", "05363235378", true, "Çatmakaşlı", "55871434614" },
                    { 3, "İstanbul, Üsküdar", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(310), null, "ahmetyilmaz@gmail.com", null, "Ahmet", "05363235375", true, "Yılmaz", "70726402020" },
                    { 4, "İstanbul, Kartal", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(313), null, "ayseyilmaz@gmail.com", null, "Ayşe", "05361031245", true, "Yılmaz", "20697468440" },
                    { 5, "İstanbul, Avcılar", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(315), null, "fatmakartal@gmail.com", null, "Fatma", "05361031245", true, "Kartal", "41354126398" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "ModifiedDate", "Name", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "İstanbul", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(1780), null, "everest@mail.com", null, "Everest", "02121234567", true },
                    { 2, "İstanbul", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(1783), null, "dogan@gmail.com", null, "Doğan Kitap", "02121234567", true },
                    { 3, "İstanbul", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(1785), null, "isbankasi@mail.com", null, "İş Bankası", "02121234567", true },
                    { 4, "İstanbul", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(1788), null, "yapikredi@mail.com", null, "Yapı Kredi", "02121234567", true },
                    { 5, "İstanbul", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(1790), null, "timas@mail.com", null, "Timaş", "02121234567", true },
                    { 6, "Ankara", new DateTime(2024, 3, 24, 23, 41, 53, 508, DateTimeKind.Local).AddTicks(1792), null, "tubitak@mail.com", null, "Tubitak", "03121234567", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
