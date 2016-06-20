$(document).ready(function () {
    var filterSection = $("div.filter-section");
    var manufUrl = filterSection.data("countries-url");
    var carModelsfUrl = filterSection.data("carmodels-url");
    $(".country-picker", filterSection).change(function () {
        var id = $(this).val();
        if (id == -1) {
            $(".manufacturer-picker", filterSection).hide();
            $(".manufacturer-picker", filterSection).val(-1);
            $(".manufacturer-picker", filterSection).change();
        }
        else {
            $(".manufacturer-picker", filterSection).show();
            DataLoader.loadManufacturers(manufUrl + "/" + id);
        }
       

    });
    $(".manufacturer-picker", filterSection).change(function () {
        var id = $(this).val();
        if (id == -1) {
            $(".carmodel-picker", filterSection).hide();
            $(".carmodel-picker", filterSection).val(-1);
        }
        else {
            $(".carmodel-picker", filterSection).show();
            DataLoader.loadCarModels(carModelsfUrl + "/" + id);
        }
    });
    $(".country-picker", filterSection).change();
});

DataLoader = {
    loadManufacturers: function(url) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataLoader.renderManufacturersList(output);
            },
            error: function (err, a, c) {
                alert("Error");
            }
        });
    },
    renderManufacturersList: function (output) {
        var result = "";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        var filterSection = $("div.filter-section");
        $(".manufacturer-picker", filterSection).html(result);
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
                alert("Error");
            }
        });
    },
    renderCarModelsList: function (output) {
        var result = "";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        var filterSection = $("div.filter-section");
        $(".carmodel-picker", filterSection).html(result);
    }

}