select2SearchControl = {
    init: function () {
        $("select.select2Search").select2({
            ajax: {
                placeholder: function () {
                    $(this).data('placeholder');
                },
                url: $("select.select2Search").data("search-url"),
                type: 'POST',
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    return {
                        AllFieldsSearch: params.term // search term
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    return {
                        results: data,
                        pagination: {
                            more: (params.page * 30) < data.total_count
                        }
                    };
                },
                cache: true
            },
            escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
            minimumInputLength: 0,
            templateResult: function (carItem) {
                if (carItem.CarId == null) return null;
                var imageSrc = $("select.select2Search").data("img-url") + '/' + carItem.MainImageId;
                if (carItem.MainImageId === "") imageSrc = "http://www.designofsignage.com/application/symbol/building/image/600x600/no-photo.jpg";
                var $carItem = $(
                  '<span class="searchCursor"><img src="' + imageSrc + '" class="img-search" alt="car image" /> '
                  + '<label class="select2label">' + carItem.Country + '</label>'
                  + '<label class="select2label">' + carItem.Manufacturer + '</label>'
                  + '<label class="select2label">' + carItem.Model + '</label>'
                  + '<label class="select2label">' + carItem.BodyType + '</label>'
                  + '<label class="select2label">' + carItem.FuelType + '</label>'
                  + '<label class="select2label">' + carItem.TransmitionType + '</label>'
                  + '<label class="select2label">' + carItem.ReleaseYear + 'r.e.</label>'
                  + '<label class="select2label">' + carItem.Price + '$</label>'
                  + '<label class="select2label">' + carItem.Volume + 'cm3 ' + '</span>'
                );
                $carItem.on("click", function () {
                    window.location.href = '' + $("select.select2Search").data("caritem-url") + '/' + carItem.CarId;
                });
                return $carItem;
            }
        });
    }
};
$(document).ready(function () {
    var searchControls = $(".js-need-init");
    $.each(searchControls, function (index, value) {
        var initScripts = $(value).data("init-script");
        if (initScripts) {
            //TODO: applyScripts
            var parts = initScripts.split(".");
            window[parts[0]][parts[1]]();
        }
    });
});

