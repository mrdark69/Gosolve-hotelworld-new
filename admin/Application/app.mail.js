﻿"use strict";
var confs = {
    storage: {
        get: function () {
            return new Promise(function (t, e) {
                try {
                    var i = JSON.parse(localStorage.getItem("jqueryEmail")) ||
                        {
                        elements: [],
                        html: "",
                        emailSettings: {
                                options: {
                                    paddingTop: "50px",
                                    paddingLeft: "5px",
                                    paddingBottom: "50px",
                                    paddingRight: "5px", backgroundColor: "#cccccc"
                                }
                            , type: "emailSettings"
                        }
                    }
                        ;
                    setTimeout(function () {
                        t(i)
                    }
                        , 1e3)
                }
                catch (t) {
                    utils.notify(t).error(), e(t)
                }
            }
            )
        }
        ,
        put: function (t) {
            return new Promise(function (e, i) {
                try {
                    t.html = utils.removeLineBreaks(t.html), localStorage.setItem("jqueryEmail", JSON.stringify(t)), e()
                }
                catch (t) {
                    utils.notify(t).error(), i(t)
                }
            }
            )
        }
    }
    ,
    options: {
        urlToUploadImage: "//uploads.im/api", trackEvents: !1
    }
}

    ,
    utils = {
        snakeToCamel: function (t) {
            return "string" != typeof t ? t : t.replace(/_([a-z])/gi, function (t, e) {
                return "" + e.toUpperCase()
            }
            )
        }
        ,
        camelToSnake: function (t) {
            return "string" != typeof t ? t : t.replace(/([A-Z])/g, function (t, e) {
                return "_" + e.toLowerCase()
            }
            )
        }
        ,
        uid: function (t) {
            return (t || "id") + (new Date).getTime() + "RAND" + Math.ceil(1e5 * Math.random())
        }
        ,
        stripTags: function (t, e) {
            var i = document.createElement("html");
            if ($(i).append($("<head/>")), $(i).append($("<body/>")), $(i).find('head meta[http-equiv="Content-Type"]').length || $(i).find("head").append($("<meta/>", {
                "http-equiv": "Content-Type", content: "text/html; charset=UTF-8"
            }
            )), $(i).find('head meta[name="viewport"]').length || $(i).find("head").append($("<meta/>", {
                name: "viewport", content: "width=device-width", "initial-scale": "1.0", "user-scalable": "yes"
            }
            )), !$(i).find("head style#builder-styles").length) {
                var n = $(document).find("head style#builder-styles").clone();

                //custom by darkman 
                //$(i).find('head style').remove();
                $(i).find("head").append(n)
            }
            return $(i).find("body").css({
                background: e.options.backgroundColor, padding: e.options.paddingTop + " " + e.options.paddingRight + " " + e.options.paddingBottom + " " + e.options.paddingLeft
            }
            ).html(t),
                $(i).find("i.actions, textarea").remove(),
                $(i).find("[contenteditable]").removeAttr("contenteditable spellcheck id").find("[data-mce-style]").removeAttr("data-mce-style"),
                $(i).find(".builder-element").each(function () {
                    $(this).replaceWith($(this).contents())
                }
                ),
                $(i).contents().contents().addBack().filter(function () {
                    return this.nodeType == Node.COMMENT_NODE
                }
                ).remove(),
                $(i)[0].outerHTML
        }
        ,
        notify: function (t, e) {
            return {
                log: function () {
                    return alertify.log(t, e)
                }
                ,
                success: function () {
                    alertify.success(t, e)
                }
                ,
                error: function () {
                    alertify.error(t, e)
                }
            }
        }
        ,
        confirm: function (t, e, i, n, o) {
            return alertify.okBtn(n).cancelBtn(o).confirm(t, e, i)
        }
        ,
        alert: function (t) {
            return alertify.okBtn("Accept").alert(t)
        }
        ,
        prompt: function (t, e, i, n) {
            return alertify.defaultValue(t).prompt(e, i, n)
        }
        ,
        validateEmail: function (t) {
            return Vue.util.isObject(t) && $.isArray(t.elements) && "string" == typeof t.html && Vue.util.isObject(t.emailSettings) && "emailSettings" == t.emailSettings.type && Vue.util.isObject(t.emailSettings.options)
        }
        ,
        trackEvent: function (t, e, i) {
            if (confs.trackEvents) {
                if (!ga) throw new Error("To track events, include Google analytics code in index.html");
                return ga("send", "event", t, e, i)
            }
        }
        ,
        equals: function (t, e) {
            function i(t, e) {
                var i = $.extend(!0, {}
                    , t),
                    n = JSON.stringify(i);
                return n === JSON.stringify($.extend(!0, i, e))
            }
            return i(t, e) && i(e, t)
        }
        ,
        removeLineBreaks: function (t) {
            return t.replace(/\n\s*\n/gi, "\n")
        }
        ,
        initTooltips: function () {
            setTimeout(function () {
                $("i[title]").powerTip({
                    placement: "sw-alt"
                }
                )
            }
                , 100)
        }
    }

    ;

var components =  {
    "email-builder-component": function (t, e) {
        Promise.all([$.get("builder/builder_campaign.html"), confs.storage.get()]).then(function (e) {
            t({
                data: function () {
                    return {
                        preview: !1, currentElement: {}
                        , elements: [{
                            type: "title", icon: "&#xE165;", primary_head: "Title", second_head: "And subtitle"
                        }
                            , {
                            type: "divider", icon: "&#xE8E9;", primary_head: "Divider", second_head: "1px separation line"
                        }
                            , {
                            type: "text", icon: "&#xE8EE;", primary_head: "Text", second_head: "Editable text box"
                        }
                            , {
                            type: "html", icon: "code", primary_head: "HTML", second_head: "Editable HTML box"
                        }
                            , {
                            type: "image", icon: "&#xE40B;", primary_head: "Image", second_head: "Image without text"
                        }
                            , {
                            type: "button", icon: "&#xE913;", primary_head: "Button", second_head: 'Clickable URL button"'
                        }
                            , {
                            type: "imageTextInside", icon: "&#xE060;", primary_head: "Image/Text", second_head: "Image inside text"
                        }
                            , {
                            type: "imageTextLeft", icon: "format_textdirection_r_to_l", primary_head: "Image/Text", second_head: "Text on the left"
                        }
                            , {
                            type: "imageTextRight", icon: "format_textdirection_l_to_r", primary_head: "Image/Text", second_head: "Text on the right"
                        }
                            , {
                            type: "imageText2x2", icon: "text_fields", primary_head: "Image/Text", second_head: "2 columns"
                        }
                            , {
                            type: "imageText3x2", icon: "wrap_text", primary_head: "Image/Text", second_head: "3 columns"
                        }
                            , {
                            type: "video", icon: "video_library", primary_head: "Video", second_head: "Embed video source"
                        }
                            , {
                            type: "social", icon: "share", primary_head: "Social Icons", second_head: "4 social icons"
                        }
                            , {
                            type: "unsubscribe", icon: "markunread_mailbox", primary_head: "Unscubscribe", second_head: "Block with unsubscription text"
                        }
                        ], defaultOptions: {
                            title: {
                                type: "title", options: {
                                    align: "center", title: "Enter your title here", subTitle: "Subtitle", padding: ["30px", "50px", "30px", "50px"], backgroundColor: "#ffffff", color: "#444444"
                                }
                            }
                            , divider: {
                                type: "divider", options: {
                                    padding: ["15px", "50px", "0px", "50px"], backgroundColor: "#ffffff"
                                }
                            }
                            , text: {
                                type: "text", options: {
                                    padding: ["10px", "50px", "10px", "50px"], backgroundColor: "#ffffff", text: '<p style="margin:0 0 10px 0;line-height:22px;font-size:13px;" data-block-id="text-area">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>'
                                }
                            }
                            , html: {
                                type: "html", options: {
                                    html: "<p>Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>"
                                }
                            }
                            , button: {
                                type: "button", options: {
                                    align: "center", padding: ["15px", "50px", "15px", "50px"], buttonText: "Click me", url: "#", buttonBackgroundColor: "#3498DB", backgroundColor: "#ffffff"
                                }
                            }
                            , image: {
                                type: "image", options: {
                                    align: "center", padding: ["15px", "50px", "15px", "50px"], image: location.origin + "/assets/350x150.jpg", backgroundColor: "#ffffff"
                                }
                            }
                            , video: {
                                type: "video", options: {
                                    padding: ["0px", "0px", "0px", "0px"], iframeVideo: '<iframe width="560" height="315" src="https://www.youtube.com/embed/cbk8mXPyCcc" frameborder="0" allowfullscreen></iframe>', fullWidth: !1, backgroundColor: "#ffffff"
                                }
                            }
                            , imageTextInside: {
                                type: "imageTextInside", options: {
                                    padding: ["15px", "50px", "15px", "50px"], image: location.origin + "/assets/370x160.jpg", width: "370", backgroundColor: "#ffffff", text: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>'
                                }
                            }
                            , imageTextRight: {
                                type: "imageTextRight", options: {
                                    padding: ["15px", "50px", "15px", "50px"], image: location.origin + "/assets/340x145.jpg", width: "340", backgroundColor: "#ffffff", text: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam.</p>'
                                }
                            }
                            , imageTextLeft: {
                                type: "imageTextLeft", options: {
                                    padding: ["15px", "50px", "15px", "50px"], image: location.origin + "/assets/340x145.jpg", width: "340", backgroundColor: "#ffffff", text: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam.</p>'
                                }
                            }
                            , imageText2x2: {
                                type: "imageText2x2", options: {
                                    padding: ["15px", "50px", "15px", "50px"], image1Hide: !1, image1: location.origin + "/assets/255x154.jpg", image2Hide: !1, image2: location.origin + "/assets/255x154.jpg", width1: "255", width2: "255", backgroundColor: "#ffffff", text1: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>', text2: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>'
                                }
                            }
                            , imageText3x2: {
                                type: "imageText3x2", options: {
                                    padding: ["15px", "50px", "15px", "50px"], image1Hide: !1, image1: location.origin + "/assets/154x160.jpg", image2Hide: !1, image2: location.origin + "/assets/154x160.jpg", image3Hide: !1, image3: location.origin + "/assets/154x160.jpg", width1: "154", width2: "154", width3: "154", backgroundColor: "#ffffff", text1: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>', text2: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>', text3: '<p style="line-height: 22px;">Lorem ipsum dolor sit amet, consectetur adipisci elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>'
                                }
                            }
                            , unsubscribe: {
                                type: "unsubscribe", options: {
                                    padding: ["10px", "50px", "10px", "50px"], backgroundColor: "#eeeeee", text: '<p style="text-align: center; margin: 0px 0px 10px 0px; line-height: 22px; font-size: 13px;" data-block-id="text-area"><span style="font-size: 8pt; color: #333333;">If you\'d like to unsubscribe and stop receiving these emails<span style="color: #0000ff;"> <a style="color: #0000ff;" href="#">click here</a></span>.</span></p>'
                                }
                            }
                            , social: {
                                type: "social", options: {
                                    align: "center", padding: ["10px", "50px", "10px", "50px"], backgroundColor: "#eeeeee", facebookLink: "https://www.facebook.com/envato", twitterLink: "https://twitter.com/envatomarket", linkedinLink: "", youtubeLink: "https://www.youtube.com/user/Envato"
                                }
                            }
                        }
                        , Email: e[1], clonedEmail: JSON.parse(JSON.stringify(e[1]))
                    }
                }
                , mounted: function () {
                    this.$root._data.loading = !1, utils.initTooltips()
                }
                , watch: {
                    Email: {
                        handler: function () {
                            utils.initTooltips()
                        }
                        , deep: !0
                    }


                }
                , computed: {
                    loading: function () {
                        return this.$root._data.loading
                    }
                }

                , created: function () {
                    var t = this;
                   
                    //GetTemplatelist((function () {
                       
                    //    //t.BindingEdit();
                    //    //t.BindingDelete();
                    //    //t.BindingAddNew();

                    //    console.log(t);
                    //})(t));
                    GetSubscriberGroup();
                    GetTemplatelist(function () {
                           t.BindingEdit();
                            t.BindingDelete();
                            t.BindingAddNew();
                            t.BindingEvent();
                    },t);

                   
                  

                    return false;
                }
                , beforeDestroy: function () {
                   // alert('before destroy');
                }
                ,
                destroyed: function () { }
                , methods: {
                    hasChanges: function () {
                        return !utils.equals(this.Email, this.clonedEmail)
                    }
                    , editElement: function (t) {
                        if (!t) return this.currentElement = {}
                            ;
                        var e = this, i = "emailSettings" !== t ? e.Email.elements.find(function (e) {
                            return e.id == t
                        }
                        ) : e.Email[t];
                        e.preview || e.currentElement == i || (e.currentElement = {}
                            , setTimeout(function () {
                                e.currentElement = i
                            }
                                , 10))
                    }
                    , removeElement: function (t) {
                        var e = this;
                        return utils.confirm("Are you sure?", function () {
                            e.Email.elements = e.Email.elements.filter(function (e) {
                                return e != t
                            }
                            ), utils.equals(e.currentElement, t) && (e.currentElement = {}
                            )
                        }
                            , null, "Delete element", "Don't delete")
                    }

                    , LoadFromTemplate: function () {

                        $('#modal_media_campaign').show(function () {
                            getTemplateall();
                            $('#btn-custom-add-template').show();
                            $('#email-builder-header-actions_custom').show();
                           
                        });
                        $('#btn-close-template').show();
                        $('#btn-close-media').hide();
                        $('.email-builder-header-actions').hide();

                    }
                    , PublishCampaign: function () {
                      
                       

                        var t = this;
                        this.Email.html = utils.stripTags($(t.$refs.emailElements.$el).html(), this.Email.emailSettings), confs.storage.put(t.Email).then(function () {

                            AddnewCampaign(function () {


                                t.BindingEdit();
                                t.BindingDelete();
                                t.BindingAddNew();


                            }

                                , t), t.clonedEmail = JSON.parse(JSON.stringify(t.Email)), t.currentElement = {}
                        })




                    }
                    , campaignOPtionClick: function () {
                        $('#campaign-option-pan').toggle();
                      
                    }
                    , SelectFile: function () {
                        console.log('click');
                        var data = store.get("key_onSel");


                        var fileat = (store.get('fileat') == null ? [] : store.get('fileat'))
                        fileat.push({
                            Path: data.Path,
                            FileName: data.FileName
                        });

                        var f = "[" + data.FileName + "] ";
                        $('#file_list_m').append(f);



                        store.set('fileat', fileat);


                        $('.email-builder-header-actions').show();
                        $('#email-builder-header-actions_custom').hide();
                        $('#modal_media').hide(function () {
                            $('.btn-custom-add-medias').hide();
                            $('#campaign-option-pan').show();
                        });
                    }
                    , AddFileCustome: function () {
                        $('#campaign-option-pan').toggle();
                        $('#modal_media').show(function () {


                            $('button[id^="btn-custom-add-medias"]').hide();

                            $('#btn-custom-add-medias-f').show();


                            //$('#btn-custom-add-medias-f').on('click', function (e) {

                                
                            //});


                            $('#email-builder-header-actions_custom').show();
                            getmediall();

                            BindingCat();
                            $('#sel_type,#sel_cat').on('change', function () {

                                console.log('sss');
                                getmediall();
                            });
                        });

                        $('.email-builder-header-actions').hide();
                    }
                    , AddmediaCustom: function (event, u, k, opt, i) {
                        var o = $(event.target).parent().find('input');

                        store.set('key', k);
                        store.set('option', opt);
                        store.set('index', i);
                        store.set('origin', u);
                        store.set('input-url', o)

                        $('#modal_media').show(function () {
                            $('button[id^="btn-custom-add-medias"]').hide();

                            $('#btn-custom-add-medias-' + i).show();
                            $('#email-builder-header-actions_custom').show();
                            getmediall();

                            BindingCat();
                            $('#sel_type,#sel_cat').on('change', function () {

                                console.log('sss');
                                getmediall();
                            });
                        });

                        $('.email-builder-header-actions').hide();


                    }
                    , CloseImageAddPanel: function () {
                        $('#campaign-option-pan').toggle();
                        $('.email-builder-header-actions').show();
                        $('#email-builder-header-actions_custom').hide();
                        $('#modal_media').hide(function () {


                        });


                    }
                    , CloseTemplateAddPanel: function () {
                        $('#campaign-option-pan').toggle();
                        $('.email-builder-header-actions').show();
                        $('#email-builder-header-actions_custom').hide();
                        $('#modal_media_campaign').hide(function () {

                            $('#btn-close-template').hide();
                            $('#btn-close-media').show();
                        });


                    }
                    , AddImagefrompanel: function () {
                        var iu = store.get('input-url');
                        var origin = store.get('origin');

                        var k = store.get('key');
                        var opt = store.get('option');
                        var i = store.get('index');





                        var data = store.get("key_onSel");
                        var url = origin + data.Path + "/" + data.FileName;

                        $(iu).val(url);

                        $('.email-builder-header-actions').show();
                        $('#email-builder-header-actions_custom').hide();
                        $('#modal_media').hide(function () {


                        });
                    }


                    , saveEmailTemplate: function () {
                        var t = this;
                        this.Email.html = utils.stripTags($(t.$refs.emailElements.$el).html(), this.Email.emailSettings), confs.storage.put(t.Email).then(function () {

                            utils.notify("Email has been saved.").success(), t.clonedEmail = JSON.parse(JSON.stringify(t.Email)), t.currentElement = {}
                        })

                       // this.$destroy();
                    },
                    SelectTemplate: function () {
                        var t = this;
                        var i = store.get('jqueryEmail');
                        (utils.validateEmail(i) ? confs.storage.put(i).then(function () {
                            t.currentElement = {}
                                , t.Email = $.extend(!0, {}
                                    , i), t.clonedEmail = $.extend(!0, {}
                                        , i), utils.notify("Email has been imported").success()


                        }
                        ) : utils.notify("Imported data isn't valid.").error())

                        $('.email-builder-header-actions').show();
                        $('#email-builder-header-actions_custom').hide();
                        $('#modal_media_campaign').hide(function () {

                            $('#btn-close-template').hide();
                            $('#btn-close-media').show();
                        });
                    }

                    , BindingEvent: function () {
                        var t = this;
                        $('#c_next').on('click', function () {
                            var raw = store.get('rawdata');
                            var p = raw.Start;

                            raw['Start'] = p + raw.Size;

                            store.set("rawdata", raw);

                            GetTemplatelist(function () {


                                t.BindingEdit();
                                t.BindingDelete();
                                t.BindingAddNew();


                            });
                        });

                        $('#c_pre').on('click', function () {
                            var raw = store.get('rawdata');
                            var p = raw.Start;

                            var pp = p - raw.Size;
                            raw['Start'] = (pp < 0 ? 0 : pp);

                            store.set("rawdata", raw);

                            GetTemplatelist(function () {


                                t.BindingEdit();
                                t.BindingDelete();
                                t.BindingAddNew();


                            });
                        });


                        $('.c_status').on('click', function () {
                            var s = $(this).data('sid');
                            var raw = store.get('rawdata');

                            $('#c-status').html($(this).html());
                            raw['CSID'] = s;
                            store.set("rawdata", raw);
                            GetTemplatelist(function () {


                                t.BindingEdit();
                                t.BindingDelete();
                                t.BindingAddNew();


                            });

                            return false;
                        })


                        $('#c_refresh').on('click', function () {
                            GetTemplatelist(function () {


                                t.BindingEdit();
                                t.BindingDelete();
                                t.BindingAddNew();


                            });
                        });

                        $('#c_cancel').on('click', function () {

                            var ch = [];
                            if ($('.i-checks:checked').length) {
                                $.each($('.i-checks:checked'), function () {

                                    ch.push($(this).val());
                                });
                            }

                            console.log(ch);

                            if (ch.length > 0) {

                                swal({
                                    title: "Are you sure?",
                                    text: "คุณต้องการยกเลิก การใช้งาน รายการที่ท่านเลือกใช่หรือไม่",
                                    type: "warning",
                                    showCancelButton: true,
                                    confirmButtonColor: "#DD6B55",
                                    confirmButtonText: "Yes, Cancel it!",
                                    closeOnConfirm: false
                                }, function () {




                                    var url ='/Application/ajax/campaign/ajax_webmethod_campaign.aspx/Cancel'
                                    var param = JSON.stringify({ parameters: ch });
                                    AjaxPost(url, param, null, function (data) {
                                        if (data.success) {

                                            toastr.success('Notification', data.msg);

                                            GetTemplatelist(function () {


                                                t.BindingEdit();
                                                t.BindingDelete();
                                                t.BindingAddNew();


                                            });

                                        }

                                    });

                                    swal.close();

                                });


                            } else {
                                swal({
                                    title: "Please Check less one",
                                    text: "กรุณาเลือก รายการอย่างน้อย 1 รายการ"
                                });

                            }



                        });


                        $('#c_bin').on('click', function () {
                            var ch = [];
                            if ($('.i-checks:checked').length) {
                                $.each($('.i-checks:checked'), function () {

                                    ch.push($(this).val());
                                });
                            }

                            if (ch.length > 0) {

                                swal({
                                    title: "Are you sure?",
                                    text: "คุณต้องการที่จะ ย้ายรายการที่เลือกลงสู่ Trash ใช่หรือไม่",
                                    type: "warning",
                                    showCancelButton: true,
                                    confirmButtonColor: "#DD6B55",
                                    confirmButtonText: "Yes, Trash it!",
                                    closeOnConfirm: false
                                }, function () {




                                    var url = '/Application/ajax/campaign/ajax_webmethod_campaign.aspx/Trash';
                                    var param = JSON.stringify({ parameters: ch });
                                    AjaxPost(url, param, null, function (data) {
                                        if (data.success) {

                                            toastr.success('Notification', data.msg);

                                            GetTemplatelist();

                                        }

                                    });

                                    swal.close();

                                });


                            } else {
                                swal({
                                    title: "Please Check less one",
                                    text: "กรุณาเลือก รายการอย่างน้อย 1 รายการ"
                                });

                            }
                        });
                    }
                    , BindingEdit: function () {
                        var t = this;
                        //var dd = $(document).find('#editor-content-display').children('div.tab-pane').find('button.btn-edit-template-content')
                        //    .on('click', function () {

                        //        $('#btn-b-update-template').show();
                        //        $('#btn-b-add-template').hide();
                        //        var i = store.get('jqueryEmail');
                        //        (utils.validateEmail(i) ? confs.storage.put(i).then(function () {
                        //            t.currentElement = {}
                        //                , t.Email = $.extend(!0, {}
                        //                    , i), t.clonedEmail = $.extend(!0, {}
                        //                        , i), utils.notify("Email has been imported").success()


                        //        }
                        //        ) : utils.notify("Imported data isn't valid.").error())
                        //        $('#modal_html_builder').modal({
                        //            backdrop: 'static',
                        //            keyboard: false
                        //        });
                        //    });


                        var dd = $(document).find('.item-edit')
                            .on('click', function () {
                                $('#btn-b-update-template').show();
                                $('.btn-b-add-template').hide();

                                var csid = $(this).data('ssid');
                                var id = $(this).data('cid');

                                if (csid == "1" || csid == "2" || csid == "4" || csid == "5" || csid == "6") {

                                   
                                    var url = "/Application/ajax/campaign/ajax_webmethod_campaign.aspx/GetItemById";
                                    var data = { CID: id };

                                    var param = JSON.stringify({ parameters: data });

                                    AjaxPost(url, param, function () {
                                        $('#main-campaign-list').addClass('sk-loading');
                                    }, function (data) {

                                        if (data.CID) {

                                           
                                            store.set('ItemSel', data);

                                            store.set('jqueryEmail', data.EL);

                                           




                                            setTimeout(function () {
                                               
                                                $('#main-campaign-list').removeClass('sk-loading');

                                              
                                                //$('#btn-b-add-template')

                                                var i = store.get('jqueryEmail');
                                                (utils.validateEmail(i) ? confs.storage.put(i).then(function () {
                                                    t.currentElement = {}
                                                        , t.Email = $.extend(!0, {}
                                                            , i), t.clonedEmail = $.extend(!0, {}
                                                                , i), utils.notify("Email has been imported").success()


                                                }
                                                ) : utils.notify("Imported data isn't valid.").error())


                                                $('#modal_html_builder').modal({
                                                    backdrop: 'static',
                                                    keyboard: false
                                                });

                                            }, 1000);
                                        }
                                    });

                                   


                                } else {

                                    swal({
                                        title: "Cannot Edit ",
                                        text: "ไม่สามารถทำรายการได้ กรุณาตราวจสอบ สถานะของ รายการอีกครั้ง"
                                    });
                                }
                                console.log(csid);



                                return false;
                            });
                    }
                    , BindingDelete: function () {
                        var t = this;
                        var de = $(document).find('#editor-content-display').children('div.tab-pane').find('button.btn-del-template-content')
                            .on('click', function () {


                                swal({
                                    title: "Are you sure?",
                                    text: "You will not be able to recover this record!",
                                    type: "warning",
                                    showCancelButton: true,
                                    confirmButtonColor: "#DD6B55",
                                    confirmButtonText: "Yes, delete it!",
                                    closeOnConfirm: false
                                }, function () {

                                    var el = store.get('jqueryEmail');
                                    var tm = store.get('TemplateSel');

                                    var tid = 0;
                                    var eid = "";
                                    if (tm) {
                                        eid = tm.EID;
                                        tid = tm.TID;
                                    }
                                    var data = { TID: tid, EID: eid, Title: $("#t-title").val(), EL: el };

                                    var url = "/Application/ajax/template/ajax_webmethod_template.aspx/DeleteTemplate";
                                    var param = JSON.stringify({ parameters: data });
                                    AjaxPost(url, param, null, function (data) {
                                        if (data.success) {

                                            toastr.success('Notification', data.msg);

                                            GetTemplatelist(function () {

                                                
                                                t.BindingEdit();
                                                t.BindingDelete();
                                                t.BindingAddNew();
                                            },t);

                                        }

                                    });

                                    swal.close();

                                });



                            });
                    }
                    , BindingAddNew: function () {
                        var t = this;

                      


                        var ee = $(document).find('button#btn_add_new_campaign')
                            .on('click', function (e) {

                                e.preventDefault;
                              

                                $('#t-title').val('');




                             
                                $('#btn-b-update-template').hide();
                                $('#btn-b-add-template').show();

                                store.remove('jqueryEmail');
                                var i = store.get('jqueryEmail');
                                // t.Email.elements = "", t.clonedEmail.element = ""

                               

                                var updatedata = {
                                    elements: [],
                                    html: "",
                                    emailSettings: {
                                        options: {
                                            paddingTop: "50px",
                                            paddingLeft: "5px",
                                            paddingBottom: "50px",
                                            paddingRight: "5px", backgroundColor: "#cccccc"
                                        }
                                        , type: "emailSettings"
                                    }
                                }

                               
                                t.Email = updatedata
                                    //,t.clonedEmail = updatedata

                             
                               

                                $('#modal_html_builder').modal({
                                    backdrop: 'static',
                                    keyboard: false
                                });

                               
                               
                            });

                        var i = new Event("input", {
                            bubbles: !0
                        }
                        );

                        //t.dispatchEvent(i);

                        e.preventDefault;

                    }
               
                    , saveNewEmailTemplate: function () {

                        var t = this;
                        this.Email.html = utils.stripTags($(t.$refs.emailElements.$el).html(), this.Email.emailSettings), confs.storage.put(t.Email).then(function () {

                            AddnewTemplate(function () {
                                

                                t.BindingEdit();
                                t.BindingDelete();
                                t.BindingAddNew();
                            
                                
                            }

                            ,t), t.clonedEmail = JSON.parse(JSON.stringify(t.Email)), t.currentElement = {}
                        })
                       // this.$destroy();
                    }
                    , UpdateTemplate: function () {

                        var t = this;
                        this.Email.html = utils.stripTags($(t.$refs.emailElements.$el).html(), this.Email.emailSettings), confs.storage.put(t.Email).then(function () {

                            UpdateTemplate(function () {
                                t.BindingEdit();
                                t.BindingDelete();
                                t.BindingAddNew();
                            }

                            ,t), t.clonedEmail = JSON.parse(JSON.stringify(t.Email)), t.currentElement = {}
                        })
                        // this.$destroy();
                    }
                    , previewEmail: function () {

                        return this.Email.elements.length ? (this.preview = !0, void (this.currentElement = {}
                        )) : utils.notify("Nothing to preview, please add some elements.").log()


                    }
                    , exportEmail: function () {
                        if (!this.Email.elements.length) return utils.notify("Nothing to export, please add some elements.").log();
                        var t = document.createElement("a");
                        t.href = "data:attachment/html," + encodeURI(this.Email.html), t.target = "_blank", t.download = utils.uid("export") + ".html", document.body.appendChild(t), t.click(), document.body.removeChild(t)
                    }
                    , cloneElement: function (t) {
                        var e = JSON.parse(JSON.stringify(t));
                        e.id = utils.uid(), this.Email.elements.splice(this.Email.elements.indexOf(t) + 1, 0, e)
                    }
                    , clone: function (t) {
                        var e = $.extend(!0, {}
                            , this.defaultOptions[t.type]);
                        return e.id = utils.uid(), e.component = t.type + "Template", e
                    }
                    , getDataReal: function () {
                        var t = this;

                        var i = store.get('jqueryEmail');
                        return utils.validateEmail(i) ? confs.storage.put(i).then(function () {
                            t.currentElement = {}
                                , t.Email = $.extend(!0, {}
                                    , i), t.clonedEmail = $.extend(!0, {}
                                    , i), utils.notify("Email has been imported").success()

                         
                        }
                        ) : utils.notify("Imported data isn't valid.").error()

                       
                        //this.bubbles
                       
                    }
                    , importJson: function () {
                        var t = this, e = $("<input />", {
                            type: "file", name: "import-file"
                        }
                        ).on("change", function () {
                            var e = new FileReader;
                            e.onload = function () {
                                var i = JSON.parse(e.result);
                                utils.validateEmail(i) ? confs.storage.put(i).then(function () {
                                    t.currentElement = {}
                                        , t.Email = $.extend(!0, {}
                                            , i), t.clonedEmail = $.extend(!0, {}
                                                , i), utils.notify("Email has been imported").success()
                                }
                                ) : utils.notify("Imported data isn't valid.").error()
                            }
                                ;
                            var i = this.files[0];
                            return "application/json" !== i.type ? utils.notify("Invalid format file").log() : void e.readAsText(i)
                        }
                            );


                        return t.Email.elements.length ? utils.confirm("On import all current details will be deleted!", function () {
                            return e.click()
                        }
                            , function () {
                                return utils.notify("Import canceled").log()
                            }
                            , "accept", "deny") : e.click()
                    }
                    , exportJson: function () {
                        var t = document.createElement("a");
                        t.target = "_blank", t.href = "data:attachment/json," + encodeURI(JSON.stringify(this.Email)), t.download = utils.uid("export") + ".json", document.body.appendChild(t), t.click(), document.body.removeChild(t)
                    }
                }
                , template: e[0], directives: {
                    mdInput: {
                        bind: function (t, e, i) {
                            var n = $(t), o = function () {
                                n.closest(".md-input-wrapper").removeClass("md-input-wrapper-danger md-input-wrapper-success md-input-wrapper-disabled"), n.hasClass("md-input-danger") && n.closest(".md-input-wrapper").addClass("md-input-wrapper-danger"), n.hasClass("md-input-success") && n.closest(".md-input-wrapper").addClass("md-input-wrapper-success"), n.prop("disabled") && n.closest(".md-input-wrapper").addClass("md-input-wrapper-disabled"), n.hasClass("label-fixed") && n.closest(".md-input-wrapper").addClass("md-input-filled"), "" != n.val() && n.closest(".md-input-wrapper").addClass("md-input-filled")
                            }
                                ;
                            setTimeout(function () {
                                n.hasClass("md-input-processed") || (n.prev("label").length ? n.prev("label").addBack().wrapAll('<div class="md-input-wrapper"/>') : n.wrap('<div class="md-input-wrapper"/>'), n.addClass("md-input-processed").closest(".md-input-wrapper").append('<span class="md-input-bar"/>')), o()
                            }
                                , 100), n.on("focus", function () {
                                    n.closest(".md-input-wrapper").addClass("md-input-focus")
                                }
                                ).on("blur", function () {
                                    setTimeout(function () {
                                        n.closest(".md-input-wrapper").removeClass("md-input-focus"), "" == n.val() ? n.closest(".md-input-wrapper").removeClass("md-input-filled") : n.closest(".md-input-wrapper").addClass("md-input-filled")
                                    }
                                        , 100)
                                }
                                    )
                        }
                    }
                    , inputFileUpload: {
                        twoWay: !0, bind: function (t, e, i) {
                            var n, o;
                            setTimeout(function () {
                                n = $(t).closest(".md-input-wrapper"), o = n.children("input:text"), o.css("paddingRight", "35px"), n.append('<button type="button" class="md-icon upload-icon">\n    <i class="material-icons">file_upload</i>\n    <input type="file" name="file">\n</button>'), n.find("input[type=file]").bind("change", function (e) {
                                    if (!confs.options.urlToUploadImage) throw Error("You don't set the 'urlToUploadImage' in variables.");
                                    var i = $(this), n = i.prev("i.material-icons"), o = n.text();
                                    n.text("hdr_strong").addClass("icon-spin").css("opacity", ".7"), i.prop("disabled", !0);
                                    var a = new FormData;
                                    return a.append("upload", e.target.files[0]), $.ajax({
                                        url: confs.options.urlToUploadImage, data: a, processData: !1, contentType: !1, type: "POST", success: function (e) {
                                            if (200 == e.status_code) {
                                                var i = new Event("input", {
                                                    bubbles: !0
                                                }
                                                );
                                                $(t).val(e.data.img_url), t.dispatchEvent(i), utils.notify("Your image has been uploaded").log()
                                            }
                                            else utils.notify(e.status_txt).error()
                                        }
                                        , error: function (t) {
                                            utils.notify(t.statusText).error()
                                        }
                                        , complete: function () {
                                            i.prop("disabled", !1), n.text(o).removeClass("icon-spin").removeAttr("style")
                                        }
                                    }
                                    )
                                }
                                )
                            }
                                , 100)
                        }
                        , unbind: function (t) {
                            $(t).unbind("change")
                        }
                    },
                    customSelMedia: {
                        twoWay: !0, bind: function (t, e, i) {
                            var n, o, p;
                            setTimeout(function () {
                                p = $(t).attr('index'),
                                    n = $(t).closest("#email-builder"),
                                    o = n.find('#btn-custom-add-media'),

                                    o.prepend('<button style="display:none" id="btn-custom-add-medias-' + p + '" class="btn-custom-add-medias btn btn-success"><i class="fa fa-plus"></i> Add Image</button>'),
                                    // o.find('button').removeAttr('style');
                                    o.find('button#btn-custom-add-medias-' + p).bind('click', function (e) {

                                        var iu = store.get('input-url');
                                        var origin = store.get('origin');


                                        var data = store.get("key_onSel");

                                        var url = origin + data.Path + "/" + data.FileName;

                                        var i = new Event("input", {
                                            bubbles: !0
                                        });

                                        $(t).val(url), t.dispatchEvent(i), utils.notify("Your image has been uploaded").log();



                                        $('.email-builder-header-actions').show();
                                        $('#email-builder-header-actions_custom').hide();
                                        $('#modal_media').hide(function () {

                                            $('.btn-custom-add-medias').hide();

                                        });

                                        console.log(e);
                                    });
                            }
                                , 100)
                        }
                        , unbind: function (t) {
                            $(t).unbind("change")
                        }
                    }
                }
                , filters: {
                    makeTitle: function (t) {
                        return t ? (t = utils.camelToSnake(t), t = t.charAt(0).toUpperCase() + t.slice(1), t.replace(/_/g, " ")) : ""
                    }
                }
                , components: {
                    titleTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" align="center" :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" data-type="title">\n    <tbody>\n    <tr>\n        <td :align="element.options.align" class="title" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" style="color: #757575;" data-block-id="background">\n            <h1 v-if="element.options.title.length" :style="{color: element.options.color}" style="font-family: Arial, sans-serif; margin: 0; font-weight: 800; line-height: 42px; font-size: 36px;" data-block-id="main-title">{{ element.options.title }}</h1>\n            <h4 v-if="element.options.subTitle.length" :style="{color: element.options.color}" style="font-family: Arial, sans-serif; font-weight: 500; margin-bottom: 0; line-height: 22px; font-size: 16px;" data-block-id="sub-title">{{ element.options.subTitle }}</h4>\n        </td>\n    </tr>\n    </tbody>\n</table>'
                    }
                    , buttonTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFFF" align="center" style="display: table;" :style="{backgroundColor: element.options.backgroundColor}" data-type="button">    <tbody>    <tr>        <td :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" class="buttons-full-width"><table cellspacing="0" cellpadding="0" border="0" :align="element.options.align" class="button"><tbody>    <tr>        <td style="margin: 10px 10px 10px 10px;" class="button">            <a :style="{backgroundColor: element.options.buttonBackgroundColor}" style="color: #FFFFFF;font-family: Arial,serif;font-size: 15px;line-height:21px;border-radius: 6px;text-align: center;text-decoration: none;font-weight: bold;display: block;margin: 0 0; padding: 12px 20px;" class="button-1" :href="element.options.url" data-default="1">{{ element.options.buttonText }}</a>                   <!--[if mso]>             </center>           </v:roundrect>         <![endif]-->        </td>    </tr>    </tbody></table>        </td>    </tr>    </tbody></table>'
                    }
                    , textTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" align="center" data-type="text-block">    <tbody>    <tr>        <td class="block-text" data-block-id="background" align="left" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" style="font-size: 13px; color: #000000; line-height: 22px;" v-tinymce-editor="element.options.text"> </td> <textarea style="display:none;visibility:hidden" v-model="element.options.text"></textarea>    </tr>    </tbody></table>'
                    }
                    , htmlTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" align="center" data-type="html-block">    <tbody>    <tr>        <td class="block-text" data-block-id="background" align="left" v-tinymce-editor="element.options.html"> </td> <textarea style="display:none;visibility:hidden" v-model="element.options.html"></textarea>    </tr>    </tbody></table>'
                    }
                    , socialTemplate: {
                        props: ["element"], template: '<table class="main" align="center" width="640" cellspacing="0" cellpadding="0" border="0" :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" data-type="social-links">\n    <tbody>\n    <tr>\n        <td class="social" :align="element.options.align" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}">\n            <a :href="element.options.facebookLink" target="_blank" style="border: none;text-decoration: none;" class="facebook">\n                <img border="0" v-if="element.options.facebookLink.length" src="' + location.origin + '/assets/social/facebook.png">\n            </a>\n            <a :href="element.options.twitterLink" target="_blank" style="border: none;text-decoration: none;" class="twitter">\n                <img border="0" v-if="element.options.twitterLink.length" src="' + location.origin + '/assets/social/twitter.png">\n            </a>\n            <a :href="element.options.linkedinLink" target="_blank" style="border: none;text-decoration: none;" class="linkedin">\n                <img border="0" v-if="element.options.linkedinLink.length" src="' + location.origin + '/assets/social/linkedin.png">\n            </a>\n            <a :href="element.options.youtubeLink" target="_blank" style="border: none;text-decoration: none;" class="youtube">\n                <img border="0" v-if="element.options.youtubeLink.length" src="' + location.origin + '/assets/social/youtube.png">\n            </a>\n        </td>\n    </tr>\n    </tbody>\n</table>'
                    }
                    , unsubscribeTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" align="center" data-type="text-block">    <tbody>    <tr>        <td data-block-id="background" align="left" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" style="font-family: Arial,serif; font-size: 13px; color: #000000; line-height: 22px;" v-tinymce-editor="element.options.text"></td> <textarea style="display:none;visibility:hidden" v-model="element.options.text"></textarea>    </tr>    </tbody></table>'
                    }
                    , dividerTemplate: {
                        props: ["element"], template: '<table class="main" width="640" :style="{backgroundColor: element.options.backgroundColor}" style="border: 0; display: table;" cellspacing="0" cellpadding="0" border="0" align="center" data-type="divider">    <tbody>    <tr>        <td class="divider-simple" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}"><table width="100%" cellspacing="0" cellpadding="0" border="0" style="border-top: 1px solid #DADFE1;">    <tbody>    <tr>        <td width="100%" height="15px"></td>    </tr>    </tbody></table>        </td>    </tr>    </tbody></table>'
                    }
                    , imageTemplate: {
                        props: ["element"], template: '<table width="640" class="main"  cellspacing="0" cellpadding="0" border="0" align="center" :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" data-type="image">    <tbody>    <tr>        <td :align="element.options.align" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" class="image"><img border="0" style="display:block;max-width:100%;" :src="element.options.image" tabindex="0">        </td>    </tr>    </tbody></table>'
                    }
                    , imageTextInsideTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFFF" align="center"   :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" data-type="imageTextInside">    <tbody>    <tr>        <td align="left"   class="image-text"    :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}"     style="font-family: Arial,serif; font-size: 13px; color: #000000; line-height: 22px;"><table class="image-in-table" width="190" align="left" style="padding:5px 5px 5px 0; margin: 11px 0;">    <tbody>    <tr>        <td width="160">            <img border="0" align="left"                 :src="element.options.image"                 :width="element.options.width"                 style="display: block;margin: 0px;max-width: 540px;padding:0 10px 10px 0;">        </td>    </tr>    <tr>    </tr>    </tbody></table><div v-tinymce-editor="element.options.text"></div> <textarea style="display:none;visibility:hidden" v-model="element.options.text"></textarea>        </td>    </tr>    </tbody></table>'
                    }
                    , imageTextRightTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFFF" align="center" :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" data-type="imageTextRight">    <tbody>    <tr>        <td class="image-text" align="left" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" style="font-family: Arial,serif; font-size: 13px; color: #000000; line-height: 22px;"><table class="image-in-table" width="190" align="left" style="margin: 11px 0;">    <tbody>    <tr>        <td class="gap" width="30"></td>        <td width="160">            <img border="0" align="left" :src="element.options.image" :width="element.options.width" style="display: block;margin: 0px;max-width: 340px;padding:5px 5px 0 0;">        </td>    </tr>    </tbody></table><table width="190">    <tbody>    <tr>        <td class="text-block" v-tinymce-editor="element.options.text"></td> <textarea style="display:none;visibility:hidden" v-model="element.options.text"></textarea>    </tr>    </tbody></table>        </td>    </tr>    </tbody></table>'
                    }
                    , imageTextLeftTemplate: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFFF" align="center"\n       :style="{backgroundColor: element.options.backgroundColor}"\n       style="display: table;" data-type="imageTextLeft">\n    <tbody>\n    <tr>\n        <td class="image-text" align="left"\n            :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}"\n            style="font-family: Arial,serif; font-size: 13px; color: #000000; line-height: 22px;">\n            <table width="190" align="left">\n                <tbody>\n                <tr>\n                    <td class="text-block" v-tinymce-editor="element.options.text"></td><textarea style="display:none;visibility:hidden" v-model="element.options.text"></textarea>\n                </tr>\n                </tbody>\n            </table>\n            <table class="image-in-table" width="190" align="right" style="margin: 11px 0;">\n                <tbody>\n                <tr>\n                    <td class="gap" width="30"></td>\n                    <td width="160">\n                        <img border="0" align="left"\n                             :src="element.options.image"\n                             :width="element.options.width"\n                             style="display: block;margin: 0px;max-width: 340px;padding:5px 5px 0 0;">\n                    </td>\n                </tr>\n                </tbody>\n            </table>\n        </td>\n    </tr>\n    </tbody>\n</table>'
                    }
                    , imageText2x2Template: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFFF" align="center"\n       :style="{backgroundColor: element.options.backgroundColor}"\n       style="display: table;" data-type="imageText2x2Template">\n    <tbody>\n    <tr>\n        <td>\n            <table class="main" align="center" border="0" cellpadding="0" cellspacing="0" width="640" style="display: table;">\n                <tbody>\n                <tr>\n                    <td class="image-caption" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" data-block-id="background">\n                        <table class="image-caption-column" align="left" border="0" cellpadding="0" cellspacing="0" width="255">\n                            <tbody>\n                            <tr v-if="!element.options.image1Hide">\n                                <td class="image-caption-content">\n                                    <img :src="element.options.image1"\n                                         :width="element.options.width1"\n                                         style="display: block;"\n                                         align="2" border="0">\n                                </td>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-content text" align="left" style="font-family: Arial,serif;font-size: 13px;color: #000000;line-height: 22px;" v-tinymce-editor="element.options.text1"></td><textarea style="display:none;visibility:hidden" v-model="element.options.text1"></textarea>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-bottom-gap" height="5" width="100%"></td>\n                            </tr>\n                            </tbody>\n                        </table>\n                        <table class="image-caption-column" align="right" border="0" cellpadding="0"\n                               cellspacing="0" width="255">\n                            <tbody>\n                            <tr v-if="!element.options.image2Hide">\n                                <td class="image-caption-content">\n                                    <img :src="element.options.image2"\n                                         :width="element.options.width2"\n                                         style="display: block;"\n                                         align="2" border="0">\n                                </td>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-content text" align="left" style="font-family: Arial,serif;font-size: 13px;color: #000000;line-height: 22px;" v-tinymce-editor="element.options.text2"></td><textarea style="display:none;visibility:hidden" v-model="element.options.text2"></textarea>\n                            </tr>\n                            <tr>\n                                <td height="5" width="100%"></td>\n                            </tr>\n                            </tbody>\n                        </table>\n                    </td>\n                </tr>\n                </tbody>\n            </table>\n        </td>\n    </tr>\n    </tbody>\n</table>'
                    }
                    , imageText3x2Template: {
                        props: ["element"], template: '<table width="640" class="main" cellspacing="0" cellpadding="0" border="0" bgcolor="#FFFFFF" align="center"\n       :style="{backgroundColor: element.options.backgroundColor}"\n       style="display: table;" data-type="imageText3x2">\n    <tbody>\n    <tr>\n        <td class="image-caption" :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}">\n            <table class="image-caption-container" align="left" border="0" cellpadding="0" cellspacing="0" width="350">\n                <tbody>\n                <tr>\n                    <td>\n                        <table class="image-caption-column" align="left" border="0" cellpadding="0" cellspacing="0" width="160">\n                            <tbody>\n                            <tr>\n                                <td height="15" width="100%"></td>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-content"\n                                    style="font-family: Arial,serif; font-size: 13px; color: #000000;">\n                                    <img :src="element.options.image1"\n                                         :width="element.options.width1"\n                                         style="display: block;" align="2" border="0">\n                                </td>\n                            </tr>\n                            <tr>\n                                <td height="15" width="100%"></td>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-content text"\n                                    style="font-family: Arial,serif; font-size: 13px; color: #000000; line-height: 22px;"\n                                    align="left"\n                                    v-tinymce-editor="element.options.text1"></td><textarea style="display:none;visibility:hidden" v-model="element.options.text1"></textarea>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-bottom-gap" height="5" width="100%"></td>\n                            </tr>\n                            </tbody>\n                        </table>\n                        <table class="image-caption-column" align="right" border="0" cellpadding="0" cellspacing="0" width="160">\n                            <tbody>\n                            <tr>\n                                <td class="image-caption-top-gap" height="15" width="100%"></td>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-content"\n                                    style="font-family: Arial,serif; font-size: 13px; color: #000000;">\n                                    <img :src="element.options.image2"\n                                         :width="element.options.width2"\n                                         style="display: block;" align="2" border="0">\n                                </td>\n                            </tr>\n                            <tr>\n                                <td height="15" width="100%"></td>\n                            </tr>\n                            <tr>\n                                <td class="image-caption-content text"\n                                    style="font-family: Arial,serif; font-size: 13px; color: #000000; line-height: 22px;"\n                                    align="left"\n                                    v-tinymce-editor="element.options.text2"></td><textarea style="display:none;visibility:hidden" v-model="element.options.text2"></textarea>                            </tr>\n                            <tr>\n                                <td class="image-caption-bottom-gap" height="5" width="100%"></td>\n                            </tr>\n                            </tbody>\n                        </table>\n                    </td>\n                </tr>\n                </tbody>\n            </table>\n            <table class="image-caption-column" align="right" border="0" cellpadding="0" cellspacing="0"\n                   width="160">\n                <tbody>\n                <tr>\n                    <td class="image-caption-top-gap" height="15" width="100%"></td>\n                </tr>\n                <tr>\n                    <td class="image-caption-content"\n                        style="font-family: Arial,serif; font-size: 13px; color: #000000;">\n                        <img :src="element.options.image3"\n                             :width="element.options.width3"\n                             style="display: block;" align="2" border="0">\n                    </td>\n                </tr>\n                <tr>\n                    <td height="15" width="100%"></td>\n                </tr>\n                <tr>\n                    <td class="image-caption-content text"\n                        style="font-family: Arial,serif; font-size: 13px; color: #000000; line-height: 22px;"\n                        align="left"\n                        v-tinymce-editor="element.options.text3"></td><textarea style="display:none;visibility:hidden" v-model="element.options.text3"></textarea>\n                </tr>\n                <tr>\n                    <td height="5" width="100%"></td>\n                </tr>\n                </tbody>\n            </table>\n        </td>\n    </tr>\n    </tbody>\n</table>'
                    }
                    , videoTemplate: {
                        props: ["element"], computed: {
                            iframeCode: function () {
                                var t = $(this.element.options.iframeVideo), e = $(this.element.options.iframeVideo).attr("width");
                                return t.attr("width", this.element.options.fullWidth ? 640 : e).get(0).outerHTML
                            }
                        }
                        , template: '<table width="640" class="main"  cellspacing="0" cellpadding="0" border="0" align="center" :style="{backgroundColor: element.options.backgroundColor}" style="display: table;" data-type="image">    <tbody>    <tr>        <td :style="{paddingTop: this.element.options.padding[0], paddingRight: this.element.options.padding[1], paddingBottom: this.element.options.padding[2], paddingLeft: this.element.options.padding[3]}" class="video" :class="{fullWidth: element.options.fullWidth}" v-html="iframeCode"></td>    </tr>    </tbody></table>'
                    }
                }
            }
            )
        }
            , e)
    }
    , loading: {
        template: '<transition name="fade"><h1 class="loading" v-if="loading">Loading ...</h1></transition>', computed: {
            loading: function () {
                return this.$root._data.loading
            }
        }
    }
}

 var vm = new Vue({
    data: function () {
        return {
            loading: !0
        }
    }
    , components: components
 }).$mount("#app")



    Vue.directive("tinymceEditor", {
        twoWay: !0, bind: function (t, e) {
            var i = t, n = [];
            tinymce.baseURL = "bower_components/tinymce/", setTimeout(function () {
              
                tinymce.init({
                    target: i,
                    inline: !0,
                    skin: "lightgray",
                    theme: "modern",
                    plugins: [
                        "advlist autolink lists link image charmap",
                        "searchreplace visualblocks code fullscreen",
                        "insertdatetime media table contextmenu paste",
                        "textcolor"
                    ],
                    toolbar: "undo redo | styleselect | bold italic fontsizeselect forecolor backcolor | alignleft aligncenter alignright alignjustify | bullist numlist | link mybutton",
                    fontsize_formats: "8pt 9pt 10pt 11pt 12pt 13pt 14pt 15pt 16pt 18pt 24pt 36pt",
                    setup: function (i) {
                        i.on("init", function () {
                            n = $(t).next("textarea"),
                                i.setContent(e.value);
                        }),
                        i.addButton('mybutton', {
                            text: "Add media",
                            onclick: function () {

                                $('#modal_media').show(function () {
                                    $('button[id^="btn-custom-add-medias"]').hide();
                                    $('#btn-custom-add-medias-m').show();

                                    $('#btn-custom-add-medias-m').bind('click', function () {
                                        var data = store.get("key_onSel");
                                        var url =  location.origin + data.Path + "/" + data.FileName;
                                        i.insertContent('<img style="width:50%" src="' + url + '" />');
                                        var t = new Event("input", {
                                            bubbles: !0
                                        });
                                        n.val(i.getContent({format: "raw"})), n.get(0).dispatchEvent(t)
                                        
                                        $('.email-builder-header-actions').show();
                                        $('#email-builder-header-actions_custom').hide();
                                        $('#modal_media').hide(function () {
                                        $('.btn-custom-add-medias').hide();
                                        });
                                        
                                        
                                    });
                                    $('#email-builder-header-actions_custom').show();
                                    getmediall();
                                    BindingCat();
                                    $('#sel_type,#sel_cat').on('change', function () {

                                        console.log('sss');
                                        getmediall();
                                    });
                                });

                                $('.email-builder-header-actions').hide();
                              
                            }
                        })
                            , i.on("change", function(ed, o) {
                            //comment the onkeyup  coz the cursor always jump to top   keyup
                                var t = new Event("input", {bubbles: !0});
                                n.val(i.getContent({ format: "raw" })), n.get(0).dispatchEvent(t)


                                //i.insertContent(12);
                               
                                i.preventDefault();
                                i.stopPropagation();
                             
                            }),
                            i.on('blur', function () {

                           // return false;
                            //const content = i.getContent();
                            //this.onEditorKeyup.emit(content);
                        })
                    }
                })
            }
            )
        }
        , update: function (t, e) {
            tinymce.get($(t).attr("id")).setContent(e.value)
        }
        , unbind: function (t) {
            tinymce.get($(t).attr("id")).destroy()
        }
    }

    ),
    Vue.filter("fullwidth", ["iframe", "fullWidth", function (t, e) { }

    ]),

    $(document).on("focusin", function (t) {
    $(t.target).closest(".mce-window, .moxman-window").length && t.stopImmediatePropagation()

   
    //$(".select2_demo_2").select2();
        //if ($(t.target).closest(".mce-window").length) {
        //    t.stopImmediatePropagation();
        //}
    }


    );

