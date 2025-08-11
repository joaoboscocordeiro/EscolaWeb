
$(document).ready(function () {

    $(document).on('blur', '.matricula', function () {
        var matricula = $(this).val();
        var row = $(this).closest('tr');

        if (matricula) {

            $.ajax({
                url: '/Aluno/BuscarAlunoPorMatricula',
                method: 'GET',
                data: { matricula: matricula },
                success: function (response) {
                    if (response.dados) {
                        row.find('.nome-aluno').text(response.dados.nome)
                    } else {
                        row.find('.nome-aluno').text('Aluno não encontrado!')
                    }
                }
            })

        }
        else {
            row.find('.nome-aluno').text('');
        }
    })

})