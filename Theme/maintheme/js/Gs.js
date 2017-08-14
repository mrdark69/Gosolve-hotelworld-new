$(document).ready(function () {
    $('.slider-for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.slider-nav'
    });
    $('.slider-nav').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.slider-for',
        dots: true,
        centerMode: true,
        focusOnSelect: true
    });


    store.set('qty_defaul', 1);
    $('.quantity').on('click', 'button', function () {

        var qty_defaul = store.get('qty_defaul');

        var data = $(this).data('direction'),
            i = $(this).parent().children('input[type="text"]'),
            val = i.val();
        if (data == "up") {
            val++;
            i.val(val);
        } else if (data == "down") {
            if (val == 1 || val ==  qty_defaul) return false;
            val--;
            i.val(val);
        }

        return false;


    });

    $(".priceOption").on('click', function () {
        var opv = $(this).val();

        var arr = opv.split('|');
        var max = arr[1];

        store.set('qty_defaul', 1);
    })
    $('.tovar_view_btn .add_bag ').on('click', function () {
        var qty = $(".tovar_view_btn #quantity");

        var priceOption = $(".priceOption").val();
        console.log(priceOption);
 
    })
});