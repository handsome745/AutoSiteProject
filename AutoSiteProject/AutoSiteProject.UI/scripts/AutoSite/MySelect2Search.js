$(document).ready(function () {
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
                // parse the results into the format expected by Select2
                // since we are using custom formatting functions we do not need to
                // alter the remote JSON data, except to indicate that infinite
                // scrolling can be used
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
            var $carItem = $(
              '<span><img src="' + $("select.select2Search").data("img-url") + '/' + carItem.MainImageId + '" class="img-search" /> ' + carItem.Manufacturer + ' ' + carItem.Model + '</span>'
            );
            $carItem.on("click", function () {
                window.location.href = ''+ $("select.select2Search").data("caritem-url") + '/' + carItem.CarId;
            });
            return $carItem;
        }
    });
});