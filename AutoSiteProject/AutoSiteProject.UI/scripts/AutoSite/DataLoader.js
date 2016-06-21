$(document).ready(function () {
    var filterSection = $("div.filter-section");
    //urls
    var countryUrl = filterSection.data("countries-url");
    var manufUrl = filterSection.data("manufacturers-url");
    var carModelsfUrl = filterSection.data("carmodels-url");
    var modelTypesfUrl = filterSection.data("carbodytype-url");
    var carOptionsUrl = filterSection.data("caroptions-url");

    DataLoader.loadCountries(countryUrl);
    DataLoader.loadCarOptions(carOptionsUrl);

    $(".country-picker", filterSection).change(function () {
        var id = $(".country-picker", filterSection).val();
        if (id == "" || id == null) {
            DataRender.clearSelectorsandHide([$(".manufacturer-picker", filterSection), $(".carmodel-picker", filterSection), $(".carbodytype-picker", filterSection)]);
        }
        else {
            $(".manufacturer-picker", filterSection).show();
            DataLoader.loadManufacturers(manufUrl + "/" + id);
            DataRender.clearSelectorsandHide([ $(".carmodel-picker", filterSection), $(".carbodytype-picker", filterSection)]);
        }
    });
    $(".manufacturer-picker", filterSection).change(function () {
        var id = $(".manufacturer-picker", filterSection).val();
        if (id == "" || id == null) {
            DataRender.clearSelectorsandHide([$(".carmodel-picker", filterSection), $(".carbodytype-picker", filterSection)]);
        }
        else {
            $(".carmodel-picker", filterSection).show();
            DataLoader.loadCarModels(carModelsfUrl + "/" + id);
            DataRender.clearSelectorsandHide([$(".carbodytype-picker", filterSection)]);
        }
    });
    $(".carmodel-picker", filterSection).change(function () {
        var id = $(".carmodel-picker", filterSection).val();
        if (id == "" || id == null) {
            DataRender.clearSelectorsandHide([$(".carbodytype-picker", filterSection)]);
        }
        else {
            $(".carbodytype-picker", filterSection).show();
            DataLoader.loadModelBodyTypes(modelTypesfUrl + "/" + id);
        }
    });
    $(".country-picker", filterSection).change();
});

DataLoader = {
    loadCountries: function (url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderCountriesList(output);
            },
            error: function (err, a, c) {
                alert("Error loading manufacturers");
            }
        });
    },
    loadManufacturers: function(url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderManufacturersList(output);
            },
            error: function (err, a, c) {
                alert("Error loading manufacturers");
            }
        });
    },
    loadCarModels: function (url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderCarModelsList(output);
            },
            error: function (err, a, c) {
                alert("Error loading car models");
            }
        });
    },
    loadModelBodyTypes: function (url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderModelBodyTypesList(output);
            },
            error: function (err, a, c) {
                alert("Error loading car model types");
            }
        });
    },
    loadCarOptions: function (url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderCarOptionsList(output);
            },
            error: function (err, a, c) {
                alert("Error loading car model types");
            }
        });
    }

}
DataRender = {
    clearSelectorsandHide(selectorsArray) {
        for (var i = 0; i < selectorsArray.length; i++) {
            selectorsArray[i].empty();
            selectorsArray[i].hide();
        }
    },
    renderCountriesList: function (output) {
        var result = "<option value>Select country</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        var filterSection = $("div.filter-section");
        $(".country-picker", filterSection).html(result);
        $(".country-picker", filterSection).val("");
    },
    renderManufacturersList: function (output) {
        var result = "<option value>Select manufacturer</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        var filterSection = $("div.filter-section");
        $(".manufacturer-picker", filterSection).html(result);
        $(".manufacturer-picker", filterSection).val("");
    },
    renderCarModelsList: function (output) {
        var result = "<option value>Select car model</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        var filterSection = $("div.filter-section");
        $(".carmodel-picker", filterSection).html(result);
        $(".carmodel-picker", filterSection).val("");
    },
    renderModelBodyTypesList: function (output) {
        var result = "<option value>Select car model type</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        var filterSection = $("div.filter-section");
        $(".carbodytype-picker", filterSection).html(result);
        $(".carbodytype-picker", filterSection).val("");
    },
    renderCarOptionsList: function (output) {
        var result = "";
        for (var i = 0; i < output.length; i++) {
            result += "<input type='checkbox' name='carOption' class='carOption' value=" + output[i].Id + ">" + output[i].Name + "<br>";
        }
        var filterSection = $("div.filter-section");
        $(".caroptions-picker", filterSection).html(result);
    }
}