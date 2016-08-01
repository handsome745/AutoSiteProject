$(document).ready(function () {
    var filterSection = $("div.filter-section");

    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    var descriptionPicker = $(".description-picker", filterSection);
    var fuelTypePicker = $(".carfueltype-picker", filterSection);
    var transmitionTypePicker = $(".cartransmitiontype-picker", filterSection);
    var allFieldsPicker = $(".allFields-picker", filterSection);

    var releaseYearRangeSlider = $(".releaseyear-range-slider", filterSection);
    var volumeRangeSlider = $(".volume-range-slider", filterSection);
    var priceRangeSlider = $(".price-range-slider", filterSection);

    var func = function () {
        carsGridView.Refresh();
    }

    releaseYearRangeSlider.slider({
        range: true,
        min: 1900,
        max: (new Date().getFullYear()),
        values: [$("input#ReleaseYearMin", filterSection).val(), $("input#ReleaseYearMax", filterSection).val()],
        slide: function (event, ui) {
            $("input#ReleaseYearMin", filterSection).val(ui.values[0]);
            $("input#ReleaseYearMax", filterSection).val(ui.values[1]);
            $("label.releaseyear-label", filterSection).text("Release year:" + ui.values[0] + "-" + ui.values[1]);
        },
        stop: function () {
            func();
        }
    });
    volumeRangeSlider.slider({
        range: true,
        min: 0,
        max: 10000,
        values: [$("input#VolumeMin").val(), $("input#VolumeMax").val()],
        slide: function (event, ui) {
            $("input#VolumeMin").val(ui.values[0]);
            $("input#VolumeMax").val(ui.values[1]);
            $("label.volume-label", filterSection).text("Engine volume:" + ui.values[0] + "-" + ui.values[1]);
        },
        stop: function () {
            func();
        }
    });
    priceRangeSlider.slider({
        range: true,
        min: 0,
        max: 200000,
        values: [$("input#PriceMin").val(), $("input#PriceMax").val()],
        slide: function (event, ui) {
            $("input#PriceMin").val(ui.values[0]);
            $("input#PriceMax").val(ui.values[1]);
            $("label.price-label", filterSection).text("Price:" + ui.values[0] + "-" + ui.values[1]);
        },
        stop: function () {
            func();
        }
    });

    countryPicker.change(func);
    manufacturerPicker.change(func);
    carmodelPicker.change(func);
    carbodytypePicker.change(func);
    carOptionsPicker.change(func);
    releaseYearRangeSlider.change(func);
    volumeRangeSlider.change(func);
    priceRangeSlider.change(func);
    fuelTypePicker.change(func);
    transmitionTypePicker.change(func);
    descriptionPicker.keyup(function () {
        setTimeout(func, 300);
    });
    allFieldsPicker.keyup(function () {
        setTimeout(func, 300);
    });
    func();
});

carFilter = {
    onBeginCallback: function (s, e) {
        var carFilterForm = $("form").serializeArray();
        for (var i = 0; i < carFilterForm.length; i++) {
            if (carFilterForm[i].name.toString() === '__RequestVerificationToken' ||
                carFilterForm[i].name.toString() === 'DXScript' ||
                carFilterForm[i].name.toString() === 'DXCss') {
                carFilterForm.splice(i, 1);
                i--;
            }
        }

        $.each(carFilterForm, function (i, v) {
            e.customArgs[v.name] = v.value;
        });
        window.history.pushState(carFilterForm, "Car search", "?" + $.param(carFilterForm));

    }
}