
$(document).ready(function () {

    function showMessage(type, message) {
        var box = $('#message-box');
        box.removeClass("alert-success alert-danger").addClass("alert-" + type);
        box.text(message).fadeIn();

        setTimeout(function () {
            box.fadeOut()
        }, 3000);
    }

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

    $(".editable").on("blur", function () {
        var linha = $(this).closest('tr');
        var idHistorico = linha.attr('data-id');
        var campo = $(this).attr('data-field');
        var valor = $(this).text();

        if (valor == null || valor == "") {
            return null;
        }

        $.post("/Historico/AtualizarNota", { idHistorico: idHistorico, campo: campo, valor: valor }, function (response) {
            if (response.resultado) {
                linha.find('.media').text(response.media);
                showMessage("success", "Alteração salva com sucesso!");
            } else {
                showMessage("danger", "Erro na alteração!");
            }
        }).fail(function () {
            showMessage("danger", "Erro na comunicação com o servidor!");
        })

    })

})