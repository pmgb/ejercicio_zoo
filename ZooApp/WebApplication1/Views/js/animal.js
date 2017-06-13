$(document).ready(function () {

    function GetClasificaciones() {

        var urlAPI = 'http://localhost:52673/api/animal';

        $.get(urlAPI, function (respuesta, estado) {

            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                console.log("prueba");

                //Yo, probando


                Clase
                var relleno = '';

                relleno += '<table border="0">';
                relleno += '    <tr>';
                relleno += '        <td>Id.</td>'
                relleno += '        <td>Denominación</td>'
                relleno += '        <td>Acciones</td>'
                relleno += '    </tr>';
                $.each(respuesta.dataMarcas, function (indice, elemento) {

                    relleno += '    <tr>';
                    relleno += '        <td>' + elemento.id + '</td>';
                    relleno += '        <td>' + elemento.denominacion + '</td>';
                    relleno += '        <td>';
                    relleno += '            <button data-id="' + elemento.id + '" id="btnEliminar">X</button>';
                    relleno += '            <button data-id="' + elemento.id + '" id="btnEditar">Editar</button>';
                    relleno += '        </td>';
                    relleno += '    </tr>';

                });
                relleno += '</table>';
                $('#resultados').append(relleno);
            }
        });
    }

    $('#resultados').on('click', '#btnEliminar', function () {
        var idMarca = $(this).attr('data-id');
        var urlAPI = 'http://localhost:52673/api/animal';
        $.ajax({
            url: urlAPI + '/' + idMarca,
            type: "DELETE",
            success: function (respuesta) {
                GetClasificaciones();
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    $('#resultados').on('click', '#btnEditar', function () {
        var idMarca = $(this).attr('data-id');
        var urlAPI = 'http://localhost:52673/api/animal';
        var dataNuevaMarca = {
            denominacion: $('#txtNuevaMarca').val()
        };

        $.ajax({
            url: urlAPI + '/' + idMarca,
            type: "PUT",
            dataType: 'json',
            data: dataNuevaMarca,
            success: function (respuesta) {
                GetClasificaciones();
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    $('#btnAddMarca').click(function () {
        //debugger;
        var nuevaMarca = $('#txtMarcaDenominacion').val();
        var urlAPI = 'http://localhost:52673/api/animal';

        var dataNuevaMarca = {
            id: 0,
            denominacion: nuevaMarca
        };
        debugger;

        $('#imgLoading').className = '';

        $.ajax({
            url: urlAPI,
            type: "POST",
            dataType: 'json',
            data: dataNuevaMarca,
            success: function (respuesta) {
                GetMarcas();
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    GetClasificaciones();

});