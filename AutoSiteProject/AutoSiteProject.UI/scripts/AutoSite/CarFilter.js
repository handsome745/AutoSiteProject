﻿$(document).ready(function () {
    var filterSection = $("div.filter-section");

    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    var descriptionPicker = $(".description-picker", filterSection);

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
    func();
});

carFilter = {
    onBeginCallback: function (s, e) {
        var carFilterForm = $("form").serializeArray();
        $.each(carFilterForm, function (i, v) {
            e.customArgs[v.name] = v.value;
        });
    },
    loadCarsList: function (url, carsResult, carFilterData) {

        $.ajax({
            type: "POST",
            asynch: true,
            url: url,
            dataType: "json",
            data: carFilterData,
            success: function (output) {
                carFilter.renderCarList(output, carsResult);
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