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

    var func = function() {
        CarFilter.loadCarsList(
            carsUrl,
            carsResult,
            countryPicker.val(),
            manufacturerPicker.val(),
            carmodelPicker.val(),
            carbodytypePicker.val(),
            carOptionsPicker.chosen().val(),
            descriptionPicker.val()
        );
    }

    countryPicker.change(func);
    manufacturerPicker.change(func);
    carmodelPicker.change(func);
    carbodytypePicker.change(func);
    carOptionsPicker.change(func);
    descriptionPicker.keyup(func);
    func();
});

CarFilter = {
    loadCarsList: function (url, carsResult, countryId, manufacturerId, carModelId, carBodyTypeId, carOptionsIds, description) {
        var data = {
            CountryId: countryId,
            ManufacturerId: manufacturerId,
            ModelId: carModelId,
            BodyTypeId: carBodyTypeId,
            OptionsIds: carOptionsIds.map(Number),
            Description: description
        };
        $.ajax({
            type: "POST",
            asynch: true,
            url: url,
            dataType: "json",
            data: data,
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
            result += "<td>"+output[i].CarId +"</td>";
            result += "<td>"+output[i].Country +"</td>";
            result += "<td>"+output[i].Manufacturer +"</td>";
            result += "<td>"+output[i].Model +"</td>";
            result += "<td>"+output[i].BodyType +"</td>";
            result += "<td>"+output[i].OptionsNames +"</td>";
            result += "<td>" + output[i].Description + "</td>";
            result += "</tr>";
        }
        $('tr:last', carsResult).after(result);
    }

}