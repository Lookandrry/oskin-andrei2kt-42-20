using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OskinAndreiKt_42_20.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_kafedra",
                columns: table => new
                {
                    Идентификаторзаписикафедры = table.Column<int>(name: "Идентификатор записи кафедры", type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Названиекафедры = table.Column<string>(name: "Название кафедры", type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_kafedra_kafedra_id", x => x.Идентификаторзаписикафедры);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_name_degree = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_degree_degree_id", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_prepod",
                columns: table => new
                {
                    prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_prepod_firstname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_prepod_lastname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_prepod_middlename = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    c_prepod_telephone = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Номер телефона преподавателя"),
                    c_prepod_mail = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Эл. почта преподавателя"),
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор кафедры"),
                    degree_id = table.Column<int>(type: "int", nullable: false, comment: "Индетификатор ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_prepod_prepod_id", x => x.prepod_id);
                    table.ForeignKey(
                        name: "fk_c_degree_id",
                        column: x => x.degree_id,
                        principalTable: "Degree",
                        principalColumn: "degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_c_kafedra_id",
                        column: x => x.kafedra_id,
                        principalTable: "cd_kafedra",
                        principalColumn: "Идентификатор записи кафедры",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_prepod_fk_c_degree_id",
                table: "cd_prepod",
                column: "degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_prepod_fk_c_kafedra_id",
                table: "cd_prepod",
                column: "kafedra_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_prepod");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "cd_kafedra");
        }
    }
}
