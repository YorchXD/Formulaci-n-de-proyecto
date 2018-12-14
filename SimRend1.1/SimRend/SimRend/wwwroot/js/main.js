$(function(){
	$("#wizard").steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "fade",
        enableAllSteps: true,
        transitionEffectSpeed: 300,
        labels: {
            next: "Siguiente",
            previous: "Atras",
            finish: 'Proceed to checkout'
        },
        onStepChanging: function (event, currentIndex, newIndex) { 
            if ( newIndex >= 1 ) {
                $('.steps ul li:first-child a img').attr('src','/images/Solicitud/evento.png');
            } else {
                $('.steps ul li:first-child a img').attr('src','/images/Solicitud/evento.png');
            }

            if ( newIndex === 1 ) {
                $('.steps ul li:nth-child(2) a img').attr('src','/images/Solicitud/categoria.png');
            } else {
                $('.steps ul li:nth-child(2) a img').attr('src','/images/Solicitud/categoria.png');
            }

            if ( newIndex === 2 ) {
                $('.steps ul li:nth-child(3) a img').attr('src','/images/Solicitud/agregarPersonas.png');
            } else {
                $('.steps ul li:nth-child(3) a img').attr('src','/images/Solicitud/agregarPersonas.png');
            }

            if ( newIndex === 3 ) {
                $('.steps ul li:nth-child(4) a img').attr('src','images/step-4-active.png');
                $('.actions ul').addClass('step-4');
            } else {
                $('.steps ul li:nth-child(4) a img').attr('src','images/step-4.png');
                $('.actions ul').removeClass('step-4');
            }
            return true; 
        }
    });
    // Custom Button Jquery Steps
    $('.forward').click(function(){
    	$("#wizard").steps('next');
    })
    $('.backward').click(function(){
        $("#wizard").steps('previous');
    })
    // Click to see password 
    $('.password i').click(function(){
        if ( $('.password input').attr('type') === 'password' ) {
            $(this).next().attr('type', 'text');
        } else {
            $('.password input').attr('type', 'password');
        }
    }) 
    // Create Steps Image
    $('.steps ul li:first-child').append('<img src="/images/Solicitud/step-arrow.png" alt="" class="step-arrow">').find('a').append('<img src="/images/Solicitud/evento.png" alt=""> ').append('<span class="step-order">Datos del evento</span>');
    $('.steps ul li:nth-child(2').append('<img src="/images/Solicitud/step-arrow.png" alt="" class="step-arrow">').find('a').append('<img src="/images/Solicitud/categoria.png" alt="">').append('<span class="step-order">Agregar categorias</span>');
    $('.steps ul li:nth-child(3)').append('<img src="/images/Solicitud/step-arrow.png" alt="" class="step-arrow">').find('a').append('<img src="/images/Solicitud/agregarPersonas.png" alt="">').append('<span class="step-order">Agregar personas</span>');
    $('.steps ul li:last-child a').append('<img src="/images/Solicitud/step-4.png" alt="">').append('<span class="step-order">Step 04</span>');
    // Count input 
    $(".quantity span").on("click", function() {

        var $button = $(this);
        var oldValue = $button.parent().find("input").val();

        if ($button.hasClass('plus')) {
          var newVal = parseFloat(oldValue) + 1;
        } else {
           // Don't allow decrementing below zero
          if (oldValue > 0) {
            var newVal = parseFloat(oldValue) - 1;
            } else {
            newVal = 0;
          }
        }
        $button.parent().find("input").val(newVal);
    });
})
