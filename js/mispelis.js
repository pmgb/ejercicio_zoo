$(document).ready(function () {
 
 
 function buscaDatos (numeroDePagina) {
 
    //console.log('jqueryOK');
    var urlAPI = 'https://api.themoviedb.org/3/discover/movie?api_key=e8c6d35a6bd555573d4b93aff5b6743b';
    urlAPI += '&page=' + numeroDePagina;
    console.log(urlAPI);

    $.get(urlAPI, function (respuesta, estado) {
    
  
     $('.fa fa-star').click(function () {
        var siguientePagina = parseInt$('#pagina-actual').html() +1;
        buscaDatos(siguientePagina);
   //   console.log('yeahhhhhh');
  });
     
     
        // COMPRUEBO EL ESTADO DE LA LLAMADA
        if (estado === 'success') {
            // SI LLEGO HASTA AQUÍ QUIERE DECIR
            // QUE EN 'RESPUESTA' TENGO LA INFO
          

           
           $('pagina-actual').html(respuesta.page);
           $('total-paginas').html(respuesta.total_pages);
            
            
            var relleno = '';
            var nItems = 0;
            $.each(respuesta.results, function (indice, elemento) {
                // if (nItems === 3) {
                //     return;
                // }
                var rutaPoster = 'https://image.tmdb.org/t/p/w500' + elemento.poster_path;
                //console.log(rutaPoster);
                relleno = ' <div class="item-pelicula">';
                relleno += '    <div class="contenido-pelicula">';
                relleno += '        <img class="imagen-pelicula" src="' + rutaPoster + '" alt="" />';
                relleno += '    </div>';
                relleno += '    <div class="datos-pelicula">';
                relleno += '        <div class="cabecera">';
                relleno += '            <span>' + elemento.title + '</span>';
                relleno += '        </div>';
                relleno += '        <div class="votos">' + elemento.vote_average + '</div>';
                relleno += '        <div class="clear">' + elemento.overview.substring(0, 400) + '</div>';
                relleno += '        <div class="contenido">';
                relleno += '        </div>';
                relleno += '    </div>';
                relleno += '</div>';
                // console.log('relleno -> ', relleno);
                $('#resultados').append(relleno);
              
                 nItems++;
                //yo
                // if (nItems === 5 ){
                //     console.log('5 páginas')
                //     return;

                
            }
        });
 

            // var rutaPoster = 'https://image.tmdb.org/t/p/w500'
            //                     + respuesta.results[0].poster_path;
            // $('.imagen-pelicula').attr('src', rutaPoster);
            // $('div.cabecera span').html(respuesta.results[0].title);
            // $('.votos').html(respuesta.results[0].vote_average);
            // $('.contenido').html(respuesta.results[0].overview);
        }


    });


});
