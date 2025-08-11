using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Api.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteAjustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_escola_turmaDisciplinasescola_turma",
                table: "TurmaDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FKescola_turmaDisciplinasescola_disciplina",
                table: "TurmaDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_DataMatricula",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Logradouro",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Contato_Celular",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_Nome",
                table: "Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_DataMatricula",
                table: "Matricula",
                column: "DataMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Logradouro",
                table: "Endereco",
                column: "Logradouro");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_Celular",
                table: "Contato",
                column: "Celular");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Nome",
                table: "Aluno",
                column: "Nome");

            migrationBuilder.AddForeignKey(
                name: "FK_escola_turmaDisciplinasescola_disciplina",
                table: "TurmaDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_escola_turmaDisciplinasescola_turma",
                table: "TurmaDisciplinas",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_escola_turmaDisciplinasescola_disciplina",
                table: "TurmaDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_escola_turmaDisciplinasescola_turma",
                table: "TurmaDisciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_DataMatricula",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Logradouro",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Contato_Celular",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_Nome",
                table: "Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_DataMatricula",
                table: "Matricula",
                column: "DataMatricula",
                unique: true,
                filter: "[DataMatricula] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Logradouro",
                table: "Endereco",
                column: "Logradouro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contato_Celular",
                table: "Contato",
                column: "Celular",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Nome",
                table: "Aluno",
                column: "Nome",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_escola_turmaDisciplinasescola_turma",
                table: "TurmaDisciplinas",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKescola_turmaDisciplinasescola_disciplina",
                table: "TurmaDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
