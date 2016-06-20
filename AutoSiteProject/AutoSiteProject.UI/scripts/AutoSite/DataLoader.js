$(document).ready(function () {
    var filterSection = $("div.filter-section");
    var manufUrl = filterSection.data("countries-url");
    var carModelsfUrl = filterSection.data("carmodels-url");
    var modelTypessfUrl = filterSection.data("carbodytype-url");
    $(".country-picker", filterSection).change(function () {
        var id = $(".country-picker", filterSection).val();
        if (id == "" || id == null) {
            DataLoader.clearSelectorsandHide([$(".manufacturer-picker", filterSection),$(".carmodel-picker", filterSection) ,$(".carbodytype-picker", filterSection)]);
        }
        else {
            $(".manufacturer-picker", filterSection).show();
            DataLoader.loadManufacturers(manufUrl + "/" + id);
            DataLoader.clearSelectorsandHide([ $(".carmodel-picker", filterSection), $(".carbodytype-picker", filterSection)]);
        }
    });
    $(".manufacturer-picker", filterSection).change(function () {
        var id = $(".manufacturer-picker", filterSection).val();
        if (id == "" || id == null) {
            DataLoader.clearSelectorsandHide([$(".carmodel-picker", filterSection), $(".carbodytype-picker", filterSection)]);
        }
        else {
            $(".carmodel-picker", filterSection).show();
            DataLoader.loadCarModels(carModelsfUrl + "/" + id);
            DataLoader.clearSelectorsandHide([$(".carbodytype-picker", filterSection)]);
        }
    });
    $(".carmodel-picker", filterSection).change(function () {
        var id = $(".carmodel-picker", filterSection).val();
        if (id == "" || id == null) {
            DataLoader.clearSelectorsandHide([$(".carbodytype-picker", filterSection)]);
        }
        else {
            $(".carbodytype-picker", filterSection).show();
            DataLoader.loadModelBodyTypes(modelTypessfUrl + "/" + id);
        }
    });
    $(".country-picker", filterSection).change();
});

DataLoader = {

    clearSelectorsandHide(selectorsArray)
    {
        for (var i = 0; i < selectorsArray.length; i++) {
            selectorsArray[i].empty();
            selectorsArray[i].hide();
        }
    },
    loadManufacturers: function(url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataLoader.renderManufacturersList(output);
            },
            error: function (err, a, c) {
                alert("Error loading manufacturers");
            }
        });
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
    loadCarModels: function (url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataLoader.renderCarModelsList(output);
            },
            error: function (err, a, c) {
                alert("Error loading car models");
            }
        });
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
    loadModelBodyTypes: function (url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataLoader.renderModelBodyTypesList(output);
            },
            error: function (err, a, c) {
                alert("Error loading car model types");
            }
        });
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
    }

}