$(document).ready(function () {
    var filterSection = $("div.filter-section");

    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    var descriptionPicker = $(".description-picker", filterSection);
    var allFieldsPicker = $(".allFields-picker", filterSection);

    var func = function () {
        carsGridView.Refresh();
    }

    countryPicker.change(func);
    manufacturerPicker.change(func);
    carmodelPicker.change(func);
    carbodytypePicker.change(func);
    carOptionsPicker.change(func);
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