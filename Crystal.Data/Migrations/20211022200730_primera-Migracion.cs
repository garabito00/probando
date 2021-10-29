using Microsoft.EntityFrameworkCore.Migrations;

namespace Crystal.Data.Migrations
{
    public partial class primeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "crystal");

            migrationBuilder.CreateTable(
                name: "departamento",
                schema: "crystal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "puesto",
                schema: "crystal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Sueldo = table.Column<double>(type: "decimal", nullable: false),
                    DepartamentoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puesto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_puesto_departamento_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalSchema: "crystal",
                        principalTable: "departamento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                schema: "crystal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "[Nombre] + '.' + [Apellido]"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "[Nombre] + '.' + [Apellido] + '@crystal.com.do'"),
                    PuestoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.ID);
                    table.ForeignKey(
                        name: "FK_empleados_puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalSchema: "crystal",
                        principalTable: "puesto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "direccion",
                schema: "crystal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    Ciudad = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Pais = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_direccion_empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalSchema: "crystal",
                        principalTable: "empleados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_direccion_EmpleadoID",
                schema: "crystal",
                table: "direccion",
                column: "EmpleadoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_empleados_PuestoId",
                schema: "crystal",
                table: "empleados",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_puesto_DepartamentoID",
                schema: "crystal",
                table: "puesto",
                column: "DepartamentoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "direccion",
                schema: "crystal");

            migrationBuilder.DropTable(
                name: "empleados",
                schema: "crystal");

            migrationBuilder.DropTable(
                name: "puesto",
                schema: "crystal");

            migrationBuilder.DropTable(
                name: "departamento",
                schema: "crystal");
        }
    }
}
