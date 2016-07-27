$(document).ready(function () {
    var filterSection = $("div.filter-section");

    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    var descriptionPicker = $(".description-picker", filterSection);
    var allFieldsPicker = $(".allFields-picker", filterSection);

    var releaseYearRangeSlider = $(".releaseyear-range-slider", filterSection);
    var volumeRangeSlider = $(".volume-range-slider", filterSection);
    var priceRangeSlider = $(".price-range-slider", filterSection);



    releaseYearRangeSlider.slider({
        range: true,
        min: 1900,
        max: (new Date().getFullYear()),
        values: [$("#releaseYearMin", releaseYearRangeSlider).val(), $("#releaseYearMax", releaseYearRangeSlider).val()],
        slide: function (event, ui) {
            $("#releaseYearMin", releaseYearRangeSlider).val(ui.values[0]);
            $("#releaseYearMax", releaseYearRangeSlider).val(ui.values[1]);
        }
    });

    volumeRangeSlider.slider({
        range: true,
        min: 1,
        max: 200000,
        values: [$("#volumeMin", volumeRangeSlider).val(), $("#volumeMax", volumeRangeSlider).val()],
        slide: function (event, ui) {
            $("#volumeMin", volumeRangeSlider).val(ui.values[0]);
            $("#volumeMax", volumeRangeSlider).val(ui.values[1]);
        }
    });
    priceRangeSlider.slider({
        range: true,
        min: 0,
        max: Number.MAX_VALUE,
        values: [$("#priceMin", priceRangeSlider).val(), $("#priceMax", priceRangeSlider).val()],
        slide: function (event, ui) {
            $("#priceMin", priceRangeSlider).val(ui.values[0]);
            $("#priceMax", priceRangeSlider).val(ui.values[1]);
        }
    });


    var func = function () {
        carsGridView.Refresh();
    }

    countryPicker.change(func);
    manufacturerPicker.change(func);
    carmodelPicker.change(func);
    carbodytypePicker.change(func);
    carOptionsPicker.change(func);
    releaseYearRangeSlider.change(func);
    volumeRangeSlider.change(func);
    priceRangeSlider.change(func);
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
        $.each(carFilterForm, function (i, v) {
            e.customArgs[v.name] = v.value;
        });
    }
}