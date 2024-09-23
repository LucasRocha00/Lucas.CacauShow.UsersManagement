using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lucas.CacauShow.UsersManagement.Persistence.Migrations
{
    public partial class CriacaoUsuarioAdm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [USER] ([NAME],[LOGIN],CPF,EMAIL,[PASSWORD],CREATIONDATE) VALUES " +
                "('ADM','ADM','00000000000','','n0vPSogfs3KBy+DvQDSDw8/AEPZHdgRMNpL0TsN/3GlxmUvA',GETDATE())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
