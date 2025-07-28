
$(document).on("click", "#professores", function () {

    var idTurma = $(this).attr("data-idturma");
    var nomeTurma = $(this).attr("data-nometurma");
    var tabelaProfessores = "";

    $.ajax({
        url: `/Professor/ProfessoresDaTurma/` + idTurma,
        type: `GET`,
        success: function (response) {
            if (response.dados.length == 0)
            {
                tabelaProfessores += `
                    <tr>
                        <td colspan="4" class="text-center">Nenhum professor vinculado!</td>
                    </tr>
                `;
            }
            else
            {
                response.dados.forEach(p => {
                    tabelaProfessores += `
                    <tr>
                        <td>${p.id}</td>
                        <td>${p.nome}</td>
                        <td>${p.materia.descricao}</td>
                        <td>${p.email}</td>
                    </tr>
                    `
                })
            }

            document.querySelector("#modalProfessores .modal-body table tbody").innerHTML = tabelaProfessores;

            document.getElementById("textModalProfessores").innerHTML = nomeTurma;

            var meuModal = new bootstrap.Modal(document.getElementById("modalProfessores"));

            meuModal.show();
        }
    })

})

$(document).on("click", "#alunos", function () {

    var idTurma = $(this).attr("data-idturma");
    var nomeTurma = $(this).attr("data-nometurma");
    var tabelaAlunos = "";

    $.ajax({
        url: `/Aluno/AlunosDaTurma/` + idTurma,
        type: `GET`,
        success: function (response) {
            if (response.dados.length == 0) {
                tabelaAlunos += `
                    <tr>
                        <td colspan="4" class="text-center">Nenhum aluno vinculado!</td>
                    </tr>
                `;
            }
            else {
                response.dados.forEach(a => {
                    tabelaAlunos += `
                    <tr>
                        <td>${a.id}</td>
                        <td>${a.matricula}</td>
                        <td>${a.nome}</td>
                        <td>${a.email}</td>
                    </tr>
                    `
                })
            }

            document.querySelector("#modalAlunos .modal-body table tbody").innerHTML = tabelaAlunos;

            document.getElementById("textModalAlunos").innerHTML = nomeTurma;

            var meuModal = new bootstrap.Modal(document.getElementById("modalAlunos"));

            meuModal.show();
        }
    })

})