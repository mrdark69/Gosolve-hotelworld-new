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


    //init shopping bag
    getBasketView();
    store.set('qty_defaul', 1);
    var Baskets = {};
    var option = $('#priceOption_qty option');
    var Cart = [];
    var RateTier = [];
    var Items = [];
    var QuantitySel = 1;
    $.each(option, function () {

        var poid = $(this).html();
        var val = $(this).attr('value');

        var arr = val.split('|');
       
        var UnitFrom = arr[0];
        var UnitTo = arr[1];
        var PriceOptionID = arr[2];
        var PriceOption = arr[3];

        RateTier.push({
            UnitFrom: UnitFrom,
            UnitTo: UnitTo,
            PriceOptionID: PriceOptionID,
            PriceOption: PriceOption
        });

    });
    
    Baskets = {
        RateTier: RateTier,
        Items: Items,
        QuantitySel: QuantitySel
    }
    store.set('Baskets', Baskets);

    $('.quantity').on('click', 'button', function () {

        var qty_defaul = store.get('qty_defaul');

        var data = $(this).data('direction'),
            i = $(this).parent().children('input[type="text"]'),
            val = i.val();
        store.set('qty_sel', val);
        if (data == "up") {
            val++;
            i.val(val);
            store.set('qty_sel', val);
        } else if (data == "down") {
            if (val == 1 ) return false;
            val--;
            i.val(val);
            store.set('qty_sel', val);
        }


       

        return false;


    });

    var mySelect = $('.priceOption');
    mySelect.fancySelect().on('change.fs', function () {
        $(this).trigger('change.$');
        var opv = $(this).val();
        store.set('qty_defaul', 1);

        store.set('optionSel', opv);
       
        var option = $('#priceOption_qty option');
       

        var Table = "";

        if (option.length > 0) {

            Table += '<table class="tbl_rate_tier table table-striped">';
            Table += '<tr>';
            Table += '<td><strong>Qty</strong></td>';

            $.each(option, function () {

                var poid = $(this).html();
                var val = $(this).attr('value');
                var arr = val.split('|');
                //this.UnitFrom + "|" + this.UnitTo + "|" + this.PriceOptionID + "|" + this.PriceOption.ToString("#,##0.00");
                var UnitFrom = arr[0];
                var UnitTo = arr[1];
                var PriceOptionID = arr[2];
                var PriceOption = arr[3];


                var index = 0;
                if (opv == PriceOptionID) {

                    Table += '<td>' + UnitFrom + (UnitTo > 0 ? '-' + UnitTo : '+')+ '<td>';
                  


                    index++;
                }
                
            });
            Table += '</tr>';
            Table += '<tr>';
            Table += '<td><strong>Price</strong></td>';
            $.each(option, function () {

                var poid = $(this).html();
                var val = $(this).attr('value');
                var arr = val.split('|');
                //this.UnitFrom + "|" + this.UnitTo + "|" + this.PriceOptionID + "|" + this.PriceOption.ToString("#,##0.00");
                var UnitFrom = arr[0];
                var UnitTo = arr[1];
                var PriceOptionID = arr[2];
                var PriceOption = arr[3];


                var index = 0;
                if (opv == PriceOptionID) {

                    Table += '<td style="font-weigth:bold;color:#e5a647">' + PriceOption + ' Baht<td>';



                    index++;
                }

            });


            


            Table += '</tr>';
            Table += '</table>';
        }

        $("#rate-tier").html(Table);

        if (opv == 0) {
            $("#rate-tier").remove();
        }
   


    }); // trigger the DOM's change event when changing FancySelect
  
    $('.tovar_view_btn .add_bag ').on('click', function () {

       // var priceOption = $(".priceOption").val();
       
        
       var cB = store.set('Baskets', Baskets);
       
        var qs = store.get('qty_sel');
        var ops = store.get('optionSel');  

        var title = $('.tovar_view_title').html();
        var img = $('.slick-active a img').attr('src');
        cB["optionSel"] = ops;
        cB["ProductTitle"] = title;
        cB["Productimage"] = img;
        cB["hd_postID"] = $('#hd_postID').val();
        



        store.set('Baskets', cB);
        // var qty = $(".tovar_view_btn #quantity");
        Cart.push(cB);
        var finalbasket = store.get('Baskets');
        console.log(finalbasket);
        store.set('BCarts', Cart);

        getBasketView();
        toastr.info('Thank You!', "Your Bag is updated!!");
    })

    //$('.sidepanel').hover(function () {

    //    $('body').css('position', 'fixed');

    //});


});


function getBasketView() {

   var cart = store.get('BCarts');
   if (cart) {
       var numitem = cart.length;
       $('#bag_num_item').html(numitem);

       var ret = '';
       var subtotal = 0;

       if (numitem > 0) {
           for (var i in cart) {
               var sel = cart[i].optionSel;
               var tier = cart[i].RateTier;
               var quan = cart[i].QuantitySel;
               var tier_s = $.grep(tier, function (d) { return d.PriceOptionID == sel && quan >= d.UnitFrom && quan < (d.UnitTo == 0 ? 9999 : d.UnitTo) });

               if (!tier_s) return;

               if (tier_s.length > 1) return;
               subtotal += tier_s[0].PriceOption * cart[i].QuantitySel;


               ret += '<li class="clearfix">';
               ret += '<img class="cart_item_product" src="' + cart[i].Productimage+'" alt="" />';
               ret += '<a href="product-page.html" class="cart_item_title">' + cart[i].ProductTitle + '</a>';
               ret += '<span class="cart_item_price">' + cart[i].QuantitySel + ' × ' + numeral(tier_s[0].PriceOption).format('0,0.00');+' Baht</span>';
               ret += '</li>';
           }
       }

       $('#bag_total').html(numeral(subtotal).format('0,0.00'))
       $('#bag_item_view').html(ret);
       
   }
  
}