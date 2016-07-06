$(document).ready(function () {
    var filterSection = $("div.filter-section");

    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    var descriptionPicker = $(".description-picker", filterSection);

    var carsResult = $("table.cars-result");
    var carsUrl = filterSection.data("cars-url");

    var func = function () {
        var carFilter = $("form").serialize();
        CarFilter.loadCarsList(
            carsUrl,
            carsResult,
            carFilter
        );
    }

    countryPicker.change(func);
    manufacturerPicker.change(func);
    carmodelPicker.change(func);
    carbodytypePicker.change(func);
    carOptionsPicker.change(func);
    descriptionPicker.keyup(function () {
        setTimeout(func, 300);
    });
    func();
});

CarFilter = {
    loadCarsList: function (url, carsResult, carFilter) {

        $.ajax({
            type: "POST",
            asynch: true,
            url: url,
            dataType: "json",
            data: carFilter,
            success: function (output) {
                CarFilter.renderCarList(output, carsResult);
            },
            error: function (err, a, c) {
                alert(err + a + c);
            }
        });
    },
    renderCarList: function (output, carsResult) {
        $("td", carsResult).remove();
        var result = "";
        for (var i = 0; i < output.length; i++) {
            result += "<tr>";
            result += "<td>" + output[i].CarId + "</td>";
            result += "<td>" + output[i].Country + "</td>";
            result += "<td>" + output[i].Manufacturer + "</td>";
            result += "<td>" + output[i].Model + "</td>";
            result += "<td>" + output[i].BodyType + "</td>";
            result += "<td>" + output[i].OptionsNames + "</td>";
            result += "<td>" + output[i].Description + "</td>";
            result += "</tr>";
        }
        $('tr:last', carsResult).after(result);
    }

}