using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakScope_Breaks_BreakId",
                table: "BreakScope");

            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityScope_Disability_DisabilityId",
                table: "DisabilityScope");

            migrationBuilder.DropForeignKey(
                name: "FK_OverTimeScopes_OverTime_OverTimeId",
                table: "OverTimeScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProbationScopes_Probations_ProbationId",
                table: "ProbationScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestScopes_Requests_RequestId",
                table: "RequestScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftScopes_Shifts_ShiftId",
                table: "ShiftScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationScopes_Vacations_VacationId",
                table: "VacationScopes");

            migrationBuilder.RenameColumn(
                name: "VacationId",
                table: "VacationScopes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_VacationScopes_VacationId",
                table: "VacationScopes",
                newName: "IX_VacationScopes_EntityId");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "ShiftScopes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ShiftScopes_ShiftId",
                table: "ShiftScopes",
                newName: "IX_ShiftScopes_EntityId");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "RequestScopes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestScopes_RequestId",
                table: "RequestScopes",
                newName: "IX_RequestScopes_EntityId");

            migrationBuilder.RenameColumn(
                name: "OverTimeId",
                table: "OverTimeScopes",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_OverTimeScopes_OverTimeId",
                table: "OverTimeScopes",
                newName: "IX_OverTimeScopes_EntityId");

            migrationBuilder.RenameColumn(
                name: "DisabilityId",
                table: "DisabilityScope",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_DisabilityScope_DisabilityId",
                table: "DisabilityScope",
                newName: "IX_DisabilityScope_EntityId");

            migrationBuilder.RenameColumn(
                name: "BreakId",
                table: "BreakScope",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BreakScope_BreakId",
                table: "BreakScope",
                newName: "IX_BreakScope_EntityId");

            migrationBuilder.AlterColumn<string>(
                name: "ProbationId",
                table: "ProbationScopes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EntityId",
                table: "ProbationScopes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProbationScopes_EntityId",
                table: "ProbationScopes",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakScope_Breaks_EntityId",
                table: "BreakScope",
                column: "EntityId",
                principalTable: "Breaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityScope_Disability_EntityId",
                table: "DisabilityScope",
                column: "EntityId",
                principalTable: "Disability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OverTimeScopes_OverTime_EntityId",
                table: "OverTimeScopes",
                column: "EntityId",
                principalTable: "OverTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProbationScopes_OverTime_EntityId",
                table: "ProbationScopes",
                column: "EntityId",
                principalTable: "OverTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProbationScopes_Probations_ProbationId",
                table: "ProbationScopes",
                column: "ProbationId",
                principalTable: "Probations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestScopes_Requests_EntityId",
                table: "RequestScopes",
                column: "EntityId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftScopes_Shifts_EntityId",
                table: "ShiftScopes",
                column: "EntityId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationScopes_Vacations_EntityId",
                table: "VacationScopes",
                column: "EntityId",
                principalTable: "Vacations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakScope_Breaks_EntityId",
                table: "BreakScope");

            migrationBuilder.DropForeignKey(
                name: "FK_DisabilityScope_Disability_EntityId",
                table: "DisabilityScope");

            migrationBuilder.DropForeignKey(
                name: "FK_OverTimeScopes_OverTime_EntityId",
                table: "OverTimeScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProbationScopes_OverTime_EntityId",
                table: "ProbationScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProbationScopes_Probations_ProbationId",
                table: "ProbationScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestScopes_Requests_EntityId",
                table: "RequestScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftScopes_Shifts_EntityId",
                table: "ShiftScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationScopes_Vacations_EntityId",
                table: "VacationScopes");

            migrationBuilder.DropIndex(
                name: "IX_ProbationScopes_EntityId",
                table: "ProbationScopes");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "ProbationScopes");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "VacationScopes",
                newName: "VacationId");

            migrationBuilder.RenameIndex(
                name: "IX_VacationScopes_EntityId",
                table: "VacationScopes",
                newName: "IX_VacationScopes_VacationId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "ShiftScopes",
                newName: "ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_ShiftScopes_EntityId",
                table: "ShiftScopes",
                newName: "IX_ShiftScopes_ShiftId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "RequestScopes",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestScopes_EntityId",
                table: "RequestScopes",
                newName: "IX_RequestScopes_RequestId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "OverTimeScopes",
                newName: "OverTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_OverTimeScopes_EntityId",
                table: "OverTimeScopes",
                newName: "IX_OverTimeScopes_OverTimeId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DisabilityScope",
                newName: "DisabilityId");

            migrationBuilder.RenameIndex(
                name: "IX_DisabilityScope_EntityId",
                table: "DisabilityScope",
                newName: "IX_DisabilityScope_DisabilityId");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "BreakScope",
                newName: "BreakId");

            migrationBuilder.RenameIndex(
                name: "IX_BreakScope_EntityId",
                table: "BreakScope",
                newName: "IX_BreakScope_BreakId");

            migrationBuilder.AlterColumn<string>(
                name: "ProbationId",
                table: "ProbationScopes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BreakScope_Breaks_BreakId",
                table: "BreakScope",
                column: "BreakId",
                principalTable: "Breaks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisabilityScope_Disability_DisabilityId",
                table: "DisabilityScope",
                column: "DisabilityId",
                principalTable: "Disability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OverTimeScopes_OverTime_OverTimeId",
                table: "OverTimeScopes",
                column: "OverTimeId",
                principalTable: "OverTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProbationScopes_Probations_ProbationId",
                table: "ProbationScopes",
                column: "ProbationId",
                principalTable: "Probations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestScopes_Requests_RequestId",
                table: "RequestScopes",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftScopes_Shifts_ShiftId",
                table: "ShiftScopes",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationScopes_Vacations_VacationId",
                table: "VacationScopes",
                column: "VacationId",
                principalTable: "Vacations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
