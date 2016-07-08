$(document).ready(function () {
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

CarFilter = {
    queryStringToJSON: function (qs) {
        qs = qs || location.search.slice(1);

        var pairs = qs.split('&');
        var result = {};
        pairs.forEach(function (pair) {
            var pair = pair.split('=');
            var key = pair[0];
            var value = decodeURIComponent(pair[1] || '');

            if (result[key]) {
                if (Object.prototype.toString.call(result[key]) === '[object Array]') {
                    result[key].push(value);
                } else {
                    result[key] = [result[key], value];
                }
            } else {
                result[key] = value;
            }
        });

        return JSON.parse(JSON.stringify(result));
    }
    ,
    OnBeginCallback: function (s, e) {
        var carFilter = $("form").serializeArray();
        $.each(carFilter, function (i, v) {
            e.customArgs[v.name] = v.value;
        });

        //var jsonObj = CarFilter.queryStringToJSON(carFilter);
        //if (jsonObj.OptionsIds != null && jsonObj.OptionsIds.length <= 1) jsonObj.OptionsIds = [jsonObj.OptionsIds];
        //e.customArgs["filter"] = JSON.stringify(jsonObj);
    },
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