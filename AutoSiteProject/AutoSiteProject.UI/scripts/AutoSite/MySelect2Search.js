select2SearchControl = {
    init: function () {
        $("select.select2Search").select2({
            ajax: {
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
            minimumInputLength: 1,
            templateResult: function (carItem) {
                if (carItem.CarId == null) return null;
                var imageSrc = $("select.select2Search").data("img-url") + '/' + carItem.MainImageId;
                if (carItem.MainImageId === "") imageSrc = "http://www.designofsignage.com/application/symbol/building/image/600x600/no-photo.jpg";
                var $carItem = $(
                  '<span><img src="' + imageSrc + '" class="img-search" alt="car image" /> '
                  + carItem.Country + ' ' + carItem.Manufacturer + ' ' + carItem.Model + ' '
                  + carItem.BodyType + ' ' + '</span>'
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

