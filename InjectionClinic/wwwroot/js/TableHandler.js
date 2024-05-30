$(document).ready(function () {
    $('#loginForm').submit(function (event) {
        event.preventDefault(); // Evita o envio do formulário tradicional

        var username = $('#username').val();
        var password = $('#password').val();

        $.ajax({
            url: '@Url.Action("Login", "SeuController")',
            type: 'GET',
            data: { username: username, password: password },
            success: function (data) {
                var tableHtml = '<table>'; // Constrói a tabela HTML
                tableHtml += '<thead><tr>';
                $.each(data.columns, function (index, value) {
                    tableHtml += '<th>' + value + '</th>';
                });
                tableHtml += '</tr></thead>';
                tableHtml += '<tbody>';
                $.each(data.rows, function (index, row) {
                    tableHtml += '<tr>';
                    $.each(row, function (index, cell) {
                        tableHtml += '<td>' + cell + '</td>';
                    });
                    tableHtml += '</tr>';
                });
                tableHtml += '</tbody></table>';

                $('#queryResults').html(tableHtml); // Exibe a tabela na div #queryResults
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});

document.getElementById('Injection01').addEventListener('click', function () {
    document.getElementsByName('username')[0].value = "' OR 1=1; --";
});

document.getElementById('Injection02').addEventListener('click', function () {
    document.getElementsByName('username')[0].value = "'; DROP TABLE users; --";
});