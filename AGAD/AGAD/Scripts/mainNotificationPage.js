$(document).ready(function () {

    // configration datetime picker
    $.datepicker.regional['tr'] = {
        closeText: 'kapat',
        prevText: '&#x3c;geri',
        nextText: 'ileri&#x3e',
        currentText: 'bugün',
        monthNames: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran',
        'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'],
        monthNamesShort: ['Oca', 'Şub', 'Mar', 'Nis', 'May', 'Haz',
            'Tem', 'Ağu', 'Eyl', 'Eki', 'Kas', 'Ara'],
        dayNames: ['Pazar', 'Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi'],
        dayNamesShort: ['Pz', 'Pt', 'Sa', 'Ça', 'Pe', 'Cu', 'Ct'],
        dayNamesMin: ['Pz', 'Pt', 'Sa', 'Ça', 'Pe', 'Cu', 'Ct'],
        weekHeader: 'Hf',
        dateFormat: 'dd.mm.yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['tr']);
    $("#endDate").datepicker({ dateFormat: 'dd MM yy', minDate: 0 }, "gotoCurrent", true);
    $("#endDate").val($.datepicker.formatDate('dd MM yy', new Date()))
    $("#uploader").plupload({
        runtimes: 'html5,flash,silverlight,html4',
        url: "/saveImage",

        multipart_params: {
            "__RequestVerificationToken": $('#imageInfo [name=__RequestVerificationToken]').val()
        },
        max_file_size: '2mb',
        chunk_size: '1mb',
        resize: {
            width: 200,
            height: 200,
            quality: 90,
            crop: true
        },


        filters: [
            { title: "Image files", extensions: "jpg,gif,png" },
        ],

        // Rename files by clicking on their titles
        rename: true,

        // Sort files
        sortable: true,

        // Enable ability to drag'n'drop files onto the widget (currently only HTML5 supports that)
        dragdrop: true,

        // Views to activate
        views: {
            list: true,
            thumbs: true, // Show thumbs
            active: 'thumbs'
        },

        // Flash settings
        flash_swf_url: '@Url.Content("~/Content/plupload-2.1.7/js/Moxie.swf")',

        // Silverlight settings
        silverlight_xap_url: '@Url.Content("~/Content/plupload-2.1.7/js/Moxie.axp")'
    });
    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg != value;
    }, "");
    $("#generalInfo").validate({
        rules: {
            AGADTYPE: {
                valueNotEquals: "0"
            }
        },
        messages: {
            AGADTYPE: {
                valueNotEquals: "Doğal Afet Çeşidi ve Acil Durum Seçeneğini Seçiniz"
            }
        }

    });
    $("#adressInfo").validate({
        rules: {

            CITY: {
                valueNotEquals: "0"
            },
            TOWN: {
                valueNotEquals: "0"
            },
            VILLAGE: {
                required: true,
                minlength: 3
            },
            DISTINCT_REGION: {
                required: true,
                minlength: 3
            }
        },
        messages: {

            CITY: {
                valueNotEquals: "Şehir Şeçiniz"
            },
            TOWN: {
                valueNotEquals: "Semt veya İlçe Seçiniz"
            },
            VILLAGE: {
                required: "Köy veya Kasaba İsmini Giriniz",
                minlength: "En Az 3 Karakter Giriniz"
            },
            DISTINCT_REGION: {
                required: "Mahalle İsmini Giriniz",
                minlength: "En Az 3 Karakter Giriniz"
            }
        }

    });


    $('.next').on('click', function () {
        var item = $('#msform').children('form:visible');
        var index = $('#msform > form').index(item);
        if (index == 0 && $("#generalInfo").valid() == false) {
            return;
        }
        else if (index == 1 && $("#adressInfo").valid() == false) {
            return;
        }
        index++;
        item.slideToggle("slow");
        $($('#msform').children('form')[index]).show();
        $($('#progressbar').children()[index]).addClass("active");
        $('html,body').animate({ scrollTop: $('#services').offset().top }, 'slow');

    });
    $('.previous').on('click', function () {
        var item = $('#msform').children('form:visible');
        var index = $('#msform > form').index(item);
        index--;

        item.slideUp("slow");
        $($('#msform').children('form')[index]).show();
        $($('#progressbar').children()[index + 1]).removeClass("active");
        $('html,body').animate({ scrollTop: $('#services').offset().top }, 'slow');
    });
    $('.submit').on('click', function () {
        if ($("#generalInfo").valid() && $("#adressInfo").valid()) {
            var data = $('#generalInfo, #adressInfo,  #imageInfo').serialize();
            debugger;
            var token = $('#generalInfo [name=__RequestVerificationToken]').val();

            data["__RequestVerificationToken"] = token;


            post("/save", data, function (data) {
                debugger;
                var item = $('#msform').children('form:visible');
                var index = $('#msform > form').index(item);
                item.slideToggle("slow");
                if (data.success) {
                    $('#success').show();
                }
                else {
                    $('#failed').show();
                }


                setTimeout(function () {
                    window.location.reload();
                }, 3000);

            }, function () {
                var item = $('#msform').children('form:visible');
                var index = $('#msform > form').index(item);
                item.slideToggle("slow");
                $('#failed').show();
                setTimeout(function () {
                    window.location.reload();
                }, 3000);
            });
        }
    });
    $('#CITY').change(function () {

        var token = $('#adressInfo [name=__RequestVerificationToken]').val();
        var data = {};
        data["__RequestVerificationToken"] = token;
        data["cityID"] = $('#CITY').val();
        post("/getList", data, function (data) {
            if ($.isArray(data)) {

                $('#TOWN').empty();
                $.each(data, function (i, value) {
                    $('#TOWN').append("<option value='" + value.Id + "'>" + value.NAME + "</option>");
                });
            }
        }, function () {
            var item = $('#msform').children('form:visible');
            var index = $('#msform > form').index(item);
            item.slideToggle("slow");
            $('#failed').show();
            setTimeout(function () {
                window.location.reload();
            }, 3000);
        });

    });

    function post(url, data, succes, failed) {
        $.ajax({
            type: 'POST',
            url: url,
            cache: true,
            data: data,
            success: succes,
            error: failed
        });
    }
});