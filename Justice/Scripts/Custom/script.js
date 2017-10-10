$(document).ready(function(){

   // ================tab funksiyasi===================









  // $('#tab-head ul li:first').addClass('active');

  //   $('.content:first').show();

    

  //   $('#tab-head ul li a').click(function(){

  //       var id = $(this).attr('href');

  //       $('#tab-head ul li').removeClass('active');

  //       $(this).parent().addClass('active');

  //       $('.content').hide();

  //       $(id).fadeIn(2000);

  //   });





    // ==================dripdownmenu====================

    $('ul.nav li.dropdown').hover(function() {

$(this).find('.dropdown-menu').stop(true, true).delay(200).slideDown(500);

}, function() {

$(this).find('.dropdown-menu').stop(true, true).delay(200).slideUp(500);

});

})





    //=======================price=======================

    // $('.news').hover(function() {

    //   $(this).find(".cart").animate({top: '217px'});



    // }, function() {

    //   $(this).find(".cart").animate({top: '325px'});

      

    // });

    //     $('.price').hover(function() {

    //   $(this).find(".dollar").animate({top: '155px'});



    // }, function() {

    //   $(this).find(".dollar").animate({top: '240px'});

      

    // });

// =======================scroll menu=================== 

//   $(function () {

//   var nav = $('.nav-container');

//   var sekil = $('.navbar-brand ');

//   $(window).scroll(function () {

//     if ($(this).scrollTop() > 500) {

//       nav.addClass("fixed-nav");

//       $('.navbar-brand > img').remove();

//       sekil.append("<img src='assets/images/logo-inverted.png' />")

//     } else {

//       nav.removeClass("fixed-nav");

//       $('.navbar-brand > img').remove();

//       sekil.append("<img src='assets/images/logo.png' />")





//     }

//   });

// });



//======================= scroll animate =======================

   // $(window).scroll(function(event) {

   //    var Logos = $(window).scrollTop();

   //       if (Logos > 215) {

   //          $(".tek").css("transform","translateX(0px)");

   //          $(".cut").css("transform","translateX(0px)");

   //       }

   // });



   // $(window).scroll(function(event) {

   //    var ScrollAnimate = $(window).scrollTop();

   //       if (ScrollAnimate > 493) {

   //          $("#StartUp_left").css("transform","translateX(0px)");

   //          $("#StartUp_right").css("transform","translateX(0px)");

   //       };

   //       if (ScrollAnimate > 950) {

   //          $("#NewAge_left").css("transform","translateX(0px)");

   //          $("#NewAge_right").css("transform","translateX(0px)");

   //       };

   //       if (ScrollAnimate > 1556) {

   //          $("#Helmet_left").css("transform","translateX(0px)");

   //          $("#Helmet_right").css("transform","translateX(0px)");

   //       };

   // });





   // $(window).scroll(function(event) {

   //    var Ico_Animate = $(window).scrollTop();

   //       if (Ico_Animate > 2173) {

   //          $(".Second_Img img").css("transform","rotateX(0deg)")

   //       }

   //       if (Ico_Animate > 2600) {

   //          $(".row1").css("transform","translateX(0px)");

   //          $(".row2").css("transform","translateX(0px)");

   //       }

   //       if (Ico_Animate > 3000) {

   //          $(".parallax_texts").css("transform","translateX(0px)");

   //          $(".Inputs").css("transform","translateX(0px)");

   //       }

   // });

      // $(window).scroll(function(event) {

      // var Ico_Animate = $(window).scrollTop();

      //    if (Ico_Animate >80) {

      //       $(".fixed_menu").css({

      //         'position':'fixed',

      //         'width':100,

      //         'z-index':1;

      //       })

      //    }



      // });





   // $(window).scroll(function (event) {

   //  var enbasa = $(window).scrollTop();

   //  if (enbasa > 550) {

   //    $(".enbasa").show();

   //  }else{

   //    $(".enbasa").hide()

   //   // body...

   //  }

   // })





   // body...















// $(function(){

//         $(window).scroll(function(event) {

//       var Ico_Animate = $(window).scrollTop();

//          if (Ico_Animate >110) {



//             $(".fixed_menu").css({

//               'background':'white',

//               'position':'fixed',

//               'width':'100%',

//               'z-index':1,

//               'top':0,

//             })

//          }





//       });

// })

   // add phone and clear

      $(function(){

    

      $(document.body).on('click', '.changeType' ,function(){

        $(this).closest('.phone-input').find('.type-text').text($(this).text());

        $(this).closest('.phone-input').find('.type-input').val($(this).data('type-value'));

      });

      

      $(document.body).on('click', '.btn-remove-phone' ,function(){

        $(this).closest('.phone-input').remove();

      });

      

      

      $('.btn-add-phone').click(function(){



        var index = $('.phone-input').length + 1;

        

        $('.phone-list').append(''+

            '<div class="input-group phone-input">'+

              '<span class="input-group-btn">'+

                '<button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><span class="type-text">Tip</span> <span class="caret"></span></button>'+

                '<ul class="dropdown-menu" role="menu">'+

                  '<li><a class="changeType" href="javascript:;" data-type-value="phone">Ev Telefonu</a></li>'+

                  '<li><a class="changeType" href="javascript:;" data-type-value="fax">Fax</a></li>'+

                  '<li><a class="changeType" href="javascript:;" data-type-value="mobile">Mobil</a></li>'+

                '</ul>'+

              '</span>'+

              '<input type="text" name="phone['+index+'][number]" class="form-control" placeholder="Elaqə nömrənizi daxil edin" />'+

              '<input type="hidden" name="phone['+index+'][type]" class="type-input" value="" />'+

              '<span class="input-group-btn">'+

                '<button class="btn btn-danger btn-remove-phone" type="button"><span class="glyphicon glyphicon-remove"></span></button>'+

              '</span>'+

            '</div>'

        );



      });

      

    });

// =========================== addtobasket



$(function(){

  $('.addtobasket').click(function(){

      var id = $(this).data('id'),price = $(this).data('price'),img = $(this).data('img'),name = $(this).data('name'),code = $(this).data('code');

      var data = [];

      data.push({'id': id}),data.push({'name': name}),data.push({'price': price}),data.push({'img': img}),data.push({'code': code}),data.push({'action': 'add'});

      if(id > 0){

          $.post('basket-action.php',{data: data}).done(function(data){
              console.log(data.cart_item);
             $('.basketcount').html(data.cart_item);

          });

      }

  });



  $('.removebasketproduct').click(function(){

     var id = $(this).data('id');

     var data = [];

      data.push({'id': id}),data.push({'action': 'remove'});

     $.post('basket-action.php',{data: data}).done(function(data){

        if(data.success == true){ 

            $('#product-'+data.id).remove(),$('#product_count').html(data.product_count),$('#product_sum').html(data.product_sum), $('.basketcount').html(data.cart_item);

        }

     });

  });



  $(document).on('change', '.count_update', function(){

      var id = $(this).data('id'), count = $(this).val(),data = [];

       data.push({'id': id}),data.push({'count': count}),data.push({'action': 'count_update'});

      $.post('basket-action.php',{data:data}).done(function(data){

          if(data.success == true){

             $('#product_count').html(data.product_count),$('#product_sum').html(data.product_sum);

          }

      }); 
  });


  $(document).on('click', '.delfromfavorite', function(){

      var id = $(this).data('id'),data = [];

       data.push({'id': id}),data.push({'action': 'delfromfavorite'});

      $.post('basket-action.php',{data:data}).done(function(data){

          if(data.status == true){ 
             $('#favorite-'+id).remove();

          }

      });
      //delfromfavorite
  });

});









// ************************navbar fixed**************

$(function(){

$(window).bind('scroll', function () {

    if ($(window).scrollTop() > 100) {

        $('.top-header').addClass('fixed');

    } else {

        $('.top-header').removeClass('fixed');

    }

});





})







// *******************favorite button**********************

$(".addShopp  button  i ").hover(function(){

    $(this).removeClass('fa-star-o');

    $(this).addClass('fa-star');



},function(){

    $(this).removeClass('fa-star');

    $(this).addClass('fa-star-o');

    



})






// **********************slider**********
  jQuery(document).ready(function($) {
 
        $('#myCarousel').carousel({
                interval: 5000
        });
 
        $('#carousel-text').html($('#slide-content-0').html());
 
        //Handles the carousel thumbnails
       $('[id^=carousel-selector-]').click( function(){
            var id = this.id.substr(this.id.lastIndexOf("-") + 1);
            var id = parseInt(id);
            $('#myCarousel').carousel(id);
        });
 
 
        // When the carousel slides, auto update the text
        $('#myCarousel').on('slid.bs.carousel', function (e) {
                 var id = $('.item.active').data('slide-number');
                $('#carousel-text').html($('#slide-content-'+id).html());
        });
});