using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final__test.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "Cloud",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    all = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloud", x => x.my_id);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    lat = table.Column<double>(type: "REAL", nullable: false),
                    lon = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.my_id);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    temp = table.Column<double>(type: "REAL", nullable: false),
                    feels_like = table.Column<double>(type: "REAL", nullable: false),
                    temp_min = table.Column<double>(type: "REAL", nullable: false),
                    temp_max = table.Column<double>(type: "REAL", nullable: false),
                    pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    sea_level = table.Column<int>(type: "INTEGER", nullable: false),
                    grnd_level = table.Column<int>(type: "INTEGER", nullable: false),
                    humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    temp_kf = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.my_id);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pod = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.my_id);
                });

            migrationBuilder.CreateTable(
                name: "weatherDatas",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cod = table.Column<string>(type: "TEXT", nullable: false),
                    message = table.Column<int>(type: "INTEGER", nullable: false),
                    cnt = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weatherDatas", x => x.my_id);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    speed = table.Column<double>(type: "REAL", nullable: false),
                    deg = table.Column<int>(type: "INTEGER", nullable: false),
                    gust = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.my_id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    coordmy_id = table.Column<int>(type: "INTEGER", nullable: false),
                    country = table.Column<string>(type: "TEXT", nullable: false),
                    population = table.Column<int>(type: "INTEGER", nullable: false),
                    timezone = table.Column<int>(type: "INTEGER", nullable: false),
                    sunrise = table.Column<int>(type: "INTEGER", nullable: false),
                    sunset = table.Column<int>(type: "INTEGER", nullable: false),
                    RootId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.my_id);
                    table.ForeignKey(
                        name: "FK_City_Coord_coordmy_id",
                        column: x => x.coordmy_id,
                        principalTable: "Coord",
                        principalColumn: "my_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_City_weatherDatas_RootId",
                        column: x => x.RootId,
                        principalTable: "weatherDatas",
                        principalColumn: "my_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dt = table.Column<int>(type: "INTEGER", nullable: false),
                    mainmy_id = table.Column<int>(type: "INTEGER", nullable: false),
                    cloudsmy_id = table.Column<int>(type: "INTEGER", nullable: false),
                    windmy_id = table.Column<int>(type: "INTEGER", nullable: false),
                    visibility = table.Column<int>(type: "INTEGER", nullable: false),
                    pop = table.Column<string>(type: "TEXT", nullable: false),
                    sysmy_id = table.Column<int>(type: "INTEGER", nullable: false),
                    dt_txt = table.Column<string>(type: "TEXT", nullable: false),
                    RootId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.my_id);
                    table.ForeignKey(
                        name: "FK_List_Cloud_cloudsmy_id",
                        column: x => x.cloudsmy_id,
                        principalTable: "Cloud",
                        principalColumn: "my_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_Main_mainmy_id",
                        column: x => x.mainmy_id,
                        principalTable: "Main",
                        principalColumn: "my_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_Sys_sysmy_id",
                        column: x => x.sysmy_id,
                        principalTable: "Sys",
                        principalColumn: "my_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_Wind_windmy_id",
                        column: x => x.windmy_id,
                        principalTable: "Wind",
                        principalColumn: "my_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_weatherDatas_RootId",
                        column: x => x.RootId,
                        principalTable: "weatherDatas",
                        principalColumn: "my_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    my_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    main = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    icon = table.Column<string>(type: "TEXT", nullable: false),
                    Listmy_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.my_id);
                    table.ForeignKey(
                        name: "FK_Weather_List_Listmy_id",
                        column: x => x.Listmy_id,
                        principalTable: "List",
                        principalColumn: "my_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_coordmy_id",
                table: "City",
                column: "coordmy_id");

            migrationBuilder.CreateIndex(
                name: "IX_City_RootId",
                table: "City",
                column: "RootId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_List_cloudsmy_id",
                table: "List",
                column: "cloudsmy_id");

            migrationBuilder.CreateIndex(
                name: "IX_List_mainmy_id",
                table: "List",
                column: "mainmy_id");

            migrationBuilder.CreateIndex(
                name: "IX_List_RootId",
                table: "List",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_List_sysmy_id",
                table: "List",
                column: "sysmy_id");

            migrationBuilder.CreateIndex(
                name: "IX_List_windmy_id",
                table: "List",
                column: "windmy_id");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_Listmy_id",
                table: "Weather",
                column: "Listmy_id");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Coord");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Cloud");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Wind");

            migrationBuilder.DropTable(
                name: "weatherDatas");
        }
    }
}
