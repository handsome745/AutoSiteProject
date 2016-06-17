$(document).ready(function () {
    var filterSection = $("div.filter-section");
    var manufUrl = filterSection.data("countries-url");
    var carModelsfUrl = filterSection.data("carmodels-url");
    $(".country-picker", filterSection).change(function () {
        var id = $(this).val();
        $(".manufacturer-picker", filterSection).show();
        DataLoader.loadManufacturers(manufUrl + "/" + id);
    });
    $(".manufacturer-picker", filterSection).change(function () {
        var id = $(this).val();
        $(".carmodel-picker", filterSection).show();
        DataLoader.loadCarModels(carModelsfUrl + "/" + id);
    });
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