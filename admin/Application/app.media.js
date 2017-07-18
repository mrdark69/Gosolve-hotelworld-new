Dropzone.autoDiscover = false;
$(document).ready(function () {
    $('body').on('hidden.bs.modal', function () {
        if ($('.modal.in').length > 0) {
            $('body').addClass('modal-open');
        }
    });
    $.fn.modal.Constructor.prototype.enforceFocus = $.noop;
    store.clearAll();
    //$('form').bind('submit', function (e) {
    //    e.preventDefault();
    //    // etc
    //});

    $('.media_item_box:hidden').val();

    var mediablock = $('.media_item_box');
    $.each(mediablock, function () {



        var ele = $(this);
        var focus = ele.attr('id');
        var url = ele.find(':hidden').val();
        if (url != "") {
            var del = '<button data-idmediab="' + focus + '"  onclick="removeMedia(this);" class="btn btn-warning btn-circle btn-media-focus" type="button"><i class="fa fa-times"></i></button >';
            var lbl = ele.find('label');
            lbl.html('');
            lbl.css('background-image', 'url(' + url + ')');
            lbl.addClass('box_media_fucus_block');
            lbl.prepend(del);
            $('#modal_media_select').modal('hide');

            ele.find('button.addmedia').html('Edit');
        }





    });



    



    var myDropzone_media = new Dropzone("div#mydropzone_media", {
        url: "/admin/Application/ajax/media/ajax_upload_media.aspx",
        paramName: "file_media", // The name that will be used to transfer the file
        maxFilesize: 20, // MB
        dictDefaultMessage: "<strong>Drop files here or click to upload. </strong></br> สามารถลากรูปภาพที่ต้องการมาวาง หรือ click เพื่อเลือกภาพได้เลยครับ"

    });

    myDropzone_media.on("complete", function (file) {
        myDropzone_media.removeFile(file);

        getmediall();


    });


    var mainform = jQuery('form');
    mainform.validate();
    var ele = $(".required");
    $.each(ele, function (index) {
        $(this).rules('add', {
            required: true,
            messages: {
                required: 'required field'
            }
        }
        );
    });

    $('#sel_type,#sel_cat').on('change', function () {
        getmediall();
    });

    $('#add_new_cat').on('click', function (e) {
        $('#_add_cat_modal').modal('show');
    });

    $('.addmedia').on('click', function (e) {

        e.preventDefault;

        var dd = $(this).parent('.media_item_box');
        var id = dd.attr('id');

        store.set('box_media_focus', id);

        $('#t-title').val('');

        $('#btn-b-update-template').hide();
        $('#btn-b-add-template').show();

        $('#modal_media_select').modal({
            backdrop: 'static',
            keyboard: false
        });


    });

    $("#btn_update_media_category_close").on('click', function (e) {
        $('#btn_update_media_category_close').modal('hide');

        $('#modal_media_select').modal({focus:this});
    });
    $("#btn_add_category_close").on('click', function (e) {
        $('#_add_cat_modal').modal('hide');
        $('#modal_media_select').modal({ focus: this });
    });

    $('#btn_add_category').on('click', function (e) {

                    
                    e.preventDefault;


                    if (mainform.valid()) {
                        var url = "/admin/Application/ajax/media/ajax_webmethod_media.aspx/InsertCat";
                        var data = { CatVal: $("#Cat_title").val() };

                        var param = JSON.stringify({ parameters: data });

                        AjaxPost(url, param, null, function (data) {

                            if (data.success) {

                                toastr.success('Notification', data.msg);


                                BindingCat();
                                getmediall();


                                $('#_add_cat_modal').modal('hide');
                            }
                        });


                    }
                    return false;
    });
    $('#btn-add-tax-sel').on('click', function () {
        var sel = $('#select-form-detail-cat').val();
        var sd = store.get('key_onSel');
        var title = $("#select-form-detail-cat option:selected").text();
        var MID = sd.MID;
        var t = sd.MediaTax;
        //var newv = [];
        if (sel > 0) {

            var c = t.filter(function (el) {
                return el.TaxID == sel && el.MID == MID;
            });
            if (!c.length) {
                t.push({ TaxID: parseInt(sel), MID: MID, Title: title });
            }

            sd.MediaTax = t;
            store.set('key_onSel', sd);

            BindingTax(t);

        }
    });

    $('#btn_update_media_category').on('click', function (e) {
                    e.preventDefault;

                    var url = "/admin/Application/ajax/media/ajax_webmethod_media.aspx/BulkUpdateCat";
                    var data = [];
                    var _CatVals = $("#sel-update-media-bulk").val();
                    var _d = store.get('data_sel_list');
                    for (var i in _d) {
                        data.push({ TaxID: _CatVals, MID: _d[i].MID });
                    }

                    var param = JSON.stringify({ parameters: data });

                    AjaxPost(url, param, null, function (data) {

                        if (data.success) {

                            toastr.success('Notification', data.msg);


                            getmediall();
                            $('#_update_media_cat_modal').modal('hide');

                            
                        }
                    });


                    return false;
     });


    $('#modal_media_select').on('shown.bs.modal', function () {

        $('#mail-text-block').hide(function () {
            $('#btn-custom-add-medias-m').hide();
            $('#btn-custom-add-medias-f').show();
        });

        getmediall();

        BindingCat();
        $('#sel_type,#sel_cat').on('change', function () {

            console.log('sss');
            getmediall();
        });
    });

    
    $('#btn-custom-add-medias-m').on('click', function () {
        var data = store.get("key_onSel");
        var url = location.origin + data.Path + "/" + data.FileName;

        //i.insertContent('<img style="width:50%" src="' + url + '" />');


        var focus = store.get('box_media_focus');

        var ele = $('#' + focus);
        var del = '<button data-idmediab="' + focus + '"  onclick="removeMedia(this);" class="btn btn-warning btn-circle btn-media-focus" type="button"><i class="fa fa-times"></i></button >';
        var lbl = ele.find('label');
        lbl.html('');
        lbl.css('background-image', 'url(' + url + ')');
        lbl.addClass('box_media_fucus_block');
        lbl.prepend(del);
        $('#modal_media_select').modal('hide');

        ele.find('button.addmedia').html('Edit');


        ele.find(':hidden').val(url);
        //$('#modal_media').hide(function () {
        //    $('#mail-text-block').show();

        //});


    });

});


function removeMedia(e) {
    var focus = $(e).data('idmediab');

    var ele = $('#' + focus);
    var lbl = ele.find('label');
    lbl.html('No Media selected');
    var del = ele.find('button.btn-media-focus');
    del.remove();

    ele.find(':hidden').val('');

    lbl.removeClass('box_media_fucus_block');
    lbl.removeAttr('style');

    ele.find('button.addmedia').html('Add Media');
}


function getmediall() {

    var url = "/admin/Application/ajax/media/ajax_webmethod_media.aspx/GetMedia";

    var data = { Tax: $("#sel_cat").val(), Type: $("#sel_type").val() };
    var param = JSON.stringify({ parameters: data });
    AjaxPost(url, param, function () {
        $('#media-list').addClass('sk-loading');
    }, function (data) {

        $('#lightBoxGallery').html(generateMediaData(data));

        $('.media-block').on('click', Click_BindingToRightDetail);

        store.remove('key_onSel');
        $("#media_detail_block").hide();

        setTimeout(function () {
            $('#media-list').removeClass('sk-loading');
        }, 1000);
    });

}
function CloseImageAddPanel_media() {


    $('#modal_media_select').modal('hide');
    //$('#modal_media').hide(function () {
    //    $('#mail-text-block').show();

    //});

}
function SelectFile() {
    console.log('click');
    var data = store.get("key_onSel");


    var fileat = (store.get('fileat') == null ? [] : store.get('fileat'));
    fileat.push({
        Path: data.Path,
        FileName: data.FileName
    });

    var f = "[" + data.FileName + "] ";
    $('#file_list_m').append(f);


    store.set('fileat', fileat);

    $('#modal_media').hide(function () {
        $('#mail-text-block').show(function () {

        });
    });
}
function BindingCat() {
    var url = "/admin/Application/ajax/media/ajax_webmethod_media.aspx/GetMediaCat";

    var data = {};
    var param = JSON.stringify({ parameters: data });
    AjaxPost(url, param, null, function (data) {
        store.set("Cat_data", data);


        HtmlBinding();

    });
}

function generateMediaData(data) {
    var ret = "";
    for (d in data) {
        var url = data[d].Path + "/" + data[d].FileName;
        store.set("key_" + data[d].MID, data[d]);
        //encodeURIComponent(JSON.stringify(data[d]))
        ret += '<div class="media-block" id="block_' + data[d].MID + '" style="background-image:url(' + url + ')">';
        ret += '<input type="checkbox" value="' + data[d].MID + '" name="media_checkbox" style = "display:none; id="media_checkbox" />';
        ret += '<a href= "javascript:void(0)" class="img_data" title="' + data[d].Title + '" >';
        //style = "display:none;
        var string = data[d].FileType,
            expr = /image/;  // no quotes here

        if (expr.test(string)) {
            // ret += '<img class="img-responsive" src="' + url + '">';
        } else {
            ret += '<div class="media-doc" ><i class="fa fa-file"></i>  <span style="font-size:11px;color:#cccccc;">' + data[d].FileName + '</span></div>';
        }


        ret += '</a><button class="icon-check btn btn-info btn-circle" type="button"  onclick="return false;" style="display:none;"><i class="fa fa-check"></i></button > </div >';
    }
    // style="display:none;" <i style="display:none;" class="icon-check fa fa-certificate"></i> 
    return ret;
}

function HtmlBinding() {
    //$('#sel_cat').html('');
    $('#sel_cat option').filter(function () { return this.value != 0; }).remove();
    var data = store.get("Cat_data");
    var ret = "";
    for (var i in data) {
        
        ret += '<option value="' + data[i].TaxID + '">' + data[i].Title + '</option>';
        
    }


    $('#sel_cat').append(ret);
    $('#select-form-detail-cat').append(ret);
    $('#sel-update-media-bulk').append(ret);
}
function BindingTax(MediaTax, append = false) {
    var taxlist = '';
    for (var i in MediaTax) {
        taxlist += '<li><a href="javascript:void(0);">' + MediaTax[i].Title + '</a></li>';
    }
    if (append) {
        $('#tax_media_list').append(taxlist);
    } else {
        $('#tax_media_list').html(taxlist);
    }


}
function Click_BindingToRightDetail() {



    var chek = $(this).find(':checkbox');
    var a = $(this).find('a.img_data');

    $(this).removeClass('media-block-selected');

    //Toggle Checkbox Select
    chek.prop("checked", function (i, val) {
        return !val;
    });

    if (chek.prop("checked")) {

        $(this).addClass('media-block-selected');
    }

    if (chek.prop("checked")) {
        // var data = JSON.parse(decodeURIComponent(a.data('gallery')));
        var getData = store.get("key_" + chek.val());

        //set select
        store.set("key_onSel", getData);
    }


    var data = store.get("key_onSel");


    $('.media-block .icon-check').hide();
    if (data) {
        $('#block_' + data.MID + ' .icon-check').show();
    }



    if (chek.prop("checked")) {
        $("#media_detail_block").show();
    } else {
        $(this).find('.icon-check').hide();
        $("#media_detail_block").hide();
        store.remove("key_onSel");
    }


    //$(this).find('.icon-check').show();

    if ($('.media-block').find(':checked').length == 0) {
        $('.media-block .icon-check').hide();
        store.remove("key_onSel");
    }




    if (data) {

        var string = data.FileType,
            expr = /image/;  // no quotes here

        if (expr.test(string)) {
            $('.media_img_big').show();
        } else {
            $('.media_img_big').hide();
        }


        var url = data.Path + "/" + data.FileName;
        $('#media_detail_block .media_img_big').find('img').prop('src', url);


        var fn = $('#media_detail_block').find('label.media_file_name');
        var fy = $('#media_detail_block').find('label.media_file_type');
        var fo = $('#media_detail_block').find('label.media_file_on');
        var fd = $('#media_detail_block').find('label.media_file_dimensions');
        var ft = $('#media_detail_block').find('input.media_file_title');

        var fs = $('#media_detail_block').find('label.media_file_size');

        fn.html(data.FileName);
        fy.html(data.FileType);
        fo.html(data.DateUpload);
        fd.html(data.Dimensions);
        ft.val(data.Title);
        fs.html(data.FileSizeFormat);




        var MediaTax = data.MediaTax;


        BindingTax(MediaTax);
    }







    var allcheck = $('#lightBoxGallery').find('input[name="media_checkbox"]:checked');

    if (allcheck.length == 0) {
        $("#media_detail_block").hide();
    }

    return false;
}
function Click_BindingToRightDetail_bak() {



    var chek = $(this).find(':checkbox');
    var a = $(this).find('a.img_data');

    $('.media-block').removeClass('media-block-selected');

    $('.media-block').find(':checked').removeAttr("checked");

    //Toggle Checkbox Select
    chek.prop("checked", function (i, val) {
        return !val;
    });

    if (chek.prop("checked")) {

        $(this).addClass('media-block-selected');
    }

    if (chek.prop("checked")) {
        // var data = JSON.parse(decodeURIComponent(a.data('gallery')));
        var getData = store.get("key_" + chek.val());

        //set select
        store.set("key_onSel", getData);
    }


    var data = store.get("key_onSel");


    $('.media-block .icon-check').hide();
    $('#block_' + data.MID + ' .icon-check').show();
    //$(this).find('.icon-check').show();

    //if ($('.media-block').find(':checked').length == 0) {
    //    $('.media-block .icon-check').hide();
    //}

    var string = data.FileType,
        expr = /image/;  // no quotes here

    if (expr.test(string)) {
        $('.media_img_big').show();
    } else {
        $('.media_img_big').hide();
    }

    var url = data.Path + "/" + data.FileName;
    $('#media_detail_block .media_img_big').find('img').prop('src', url);


    var fn = $('#media_detail_block').find('label.media_file_name');
    var fy = $('#media_detail_block').find('label.media_file_type');
    var fo = $('#media_detail_block').find('label.media_file_on');
    var fd = $('#media_detail_block').find('label.media_file_dimensions');
    var ft = $('#media_detail_block').find('input.media_file_title');

    var fs = $('#media_detail_block').find('label.media_file_size');

    fn.html(data.FileName);
    fy.html(data.FileType);
    fo.html(data.DateUpload);
    fd.html(data.Dimensions);
    // ft.val(data.Title);
    fs.html(data.FileSizeFormat);




    var MediaTax = data.MediaTax;


    BindingTax(MediaTax);


    $("#media_detail_block").show();


    var allcheck = $('#lightBoxGallery').find('input[name="media_checkbox"]:checked');
    console.log(allcheck.length);
    if (allcheck.length == 0) {
        $("#media_detail_block").hide();
    }

    return false;
}

function BulkUpdate(option) {
                //var option = $('#sel_bulk_update').val();



                
                var data = [];

                $.each($('.media-block').find(':checked'), function () {

                    data.push(store.get("key_" + $(this).val()));
                    
                });  


                if (data.length > 0) {
                    switch (option) {
                        case 1:
                            BulkDelete(data);
                            break;
                        case 2:
                            BulkUpdateCat(data);
                            break;
                    }
                } else {
                    swal({
                        title: "Alerts",
                        text: "ท่านยังไม่ได้ กดเลือก Media ที่จะทำรายการ"
                    });
                }

               

               
            }


            function BulkUpdateCat(data) {

                store.set("data_sel_list", data);

                $('#_update_media_cat_modal').modal('show');

                return false;
            }


            function CategoryTaxRemove(item) {
               

                var tax = $(item).data('taxid');
                    var newv = [];
                    var sd = store.get('key_onSel');
                    if (sd != null) {
                        var t = sd.MediaTax;
                        if (t.length > 0) {


                            newv = t.filter(function (el) {
                                return el.TaxID !== tax;
                            });

                            sd.MediaTax = newv;
                            store.set('key_onSel', sd);

                            BindingTax(newv);
                        }
                    }

                    return false;

                
            }

            function BulkDelete(data) {
                            swal({
                                title: "Are you sure?",
                                text: "You will not be able to recover this record!",
                                type: "warning",
                                showCancelButton: true,
                                confirmButtonColor: "#DD6B55",
                                confirmButtonText: "Yes, delete it!",
                                closeOnConfirm: false
                            }, function () {

                                
                                var url = "/admin/Application/ajax/media/ajax_webmethod_media.aspx/BulkDelete";
                                var param = JSON.stringify({ parameters: data });
                                AjaxPost(url, param, null, function (data) {
                                    if (data.success) {

                                        toastr.success('Notification', data.msg);

                                        getmediall();

                                        $(".my-input").val("");

                                    }

                                });

                                swal.close();

                                });


                            return false;
            }


            function DeleteMedia() {

                
               
                swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this record!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!",
                    closeOnConfirm: false
                }, function () {


                    var data = store.get("key_onSel");


                    var url = "/admin/Application/ajax/media/ajax_webmethod_media.aspx/Delete";
                    var param = JSON.stringify({ parameters: data });
                                AjaxPost(url, param, null, function (data) {
                                    if (data.success) {

                                        toastr.success('Notification', data.msg);
                                       
                                        getmediall();
                                       
                                    }

                                });

                                swal.close();

                     });
               
            }


            function save() {
                var data = store.get("key_onSel");



                var url = "/admin/Application/ajax/media/ajax_webmethod_media.aspx/UpdateMedia";
                var param = JSON.stringify({ parameters: data });
                AjaxPost(url, param, function () {
                    $('#media-detail').addClass('sk-loading');
                }, function (data) {
                    if (data.success) {

                        toastr.success('Notification', data.msg);

                        $('#media-detail').addClass('sk-loading');

                        //getmediall();
                        setTimeout(function () {
                            $('#media-detail').removeClass('sk-loading');
                        }, 1000);
                        return false;
                    }

                });

                

           
                
                return false;
            }