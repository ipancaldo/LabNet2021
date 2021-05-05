$('#enviar').click(function(){
    var nombre = $('#name').val();
    if(nombre == ""){
        $('#validacion1').fadeIn();
        return false;
    }else{
        $('#validacion1').fadeOut();
    }
});

$('#enviar').click(function(){
    var apellido = $('#lastname').val();
    if(apellido == ""){
        $('#validacion2').fadeIn();
        return false;
    }else{
        $('#validacion2').fadeOut();
    }
});

$('#enviar').click(function(){
    var edad = $('#age').val();
    if(edad == ""){
        $('#validacion3').fadeIn();
        return false;
    }else{
        $('#validacion3').fadeOut();
    }

    if(edad < 1){
        $('#validacion3-edad').fadeIn();
        return false;
    }else{
        $('#validacion3-edad').fadeOut();
    }
});

$('#enviar').click(function(){
    var empresa = $('#company').val();
    if(empresa == ""){
        $('#validacion4').fadeIn();
        return false;
    }else{
        $('#validacion4').fadeOut();
    }
});



$('#limpiarCampos').click(function(){
    $('#name').val("");
    $('#lastname').val("");
    $('#age').val("");
    $('#company').val("");
});