using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiloDash.Infra.Data.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "EntityAuditRelation",
                columns: table => new
                {
                    EntityAuditRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ChildEntityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAuditRelation", x => x.EntityAuditRelationId);
                });

            migrationBuilder.CreateTable(
                name: "EntityAuditUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAuditUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityAudit",
                columns: table => new
                {
                    EntityAuditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    EntityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KeyValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoggedUserJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAudit", x => x.EntityAuditId);
                    table.ForeignKey(
                        name: "FK_EntityAudit_EntityAuditUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EntityAuditUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HardwareAddress = table.Column<int>(type: "int", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EntityAuditRelation",
                columns: new[] { "EntityAuditRelationId", "ChildEntityName", "EntityName" },
                values: new object[,]
                {
                    { 1, null, "Building" },
                    { 2, null, "Device" },
                    { 3, null, "Room" },
                    { 4, null, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RoomId",
                table: "Devices",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAudit_TransactionId",
                table: "EntityAudit",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAudit_UserId",
                table: "EntityAudit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                column: "BuildingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "EntityAudit");

            migrationBuilder.DropTable(
                name: "EntityAuditRelation");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "EntityAuditUser");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
