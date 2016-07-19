$(document).ready(function () {
    var filterSection = $("div.filter-section");
    //urls
    var countryUrl = filterSection.data("countries-url");
    var manufUrl = filterSection.data("manufacturers-url");
    var carModelsfUrl = filterSection.data("carmodels-url");
    var carBodyTypesfUrl = filterSection.data("carbodytype-url");
    //Pickers
    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    
    carOptionsPicker.chosen({ allow_single_deselect: true , width:"280px"});

    //initial ids
    var countryId = countryPicker.data("initid");
    var manufacturerId = manufacturerPicker.data("initid");
    var carmodelId = carmodelPicker.data("initid");
    var carbodytypeId = carbodytypePicker.data("initid");

    dataLoader.loadCountries(countryUrl, countryPicker, countryId);
    dataLoader.loadCarBodyTypes(carBodyTypesfUrl, carbodytypePicker, carbodytypeId);

    countryPicker.change(function () {
        var id = countryPicker.val();
        if (id == "" || id == null) {
            dataRender.clearSelectorsAndDisable([manufacturerPicker, carmodelPicker]);
        }
        else {
            manufacturerPicker.prop('disabled', false);
            dataLoader.loadManufacturers(manufUrl + "/" + id, manufacturerPicker, manufacturerId);
            dataRender.clearSelectorsAndDisable([carmodelPicker]);
        }
    });
    manufacturerPicker.change(function () {
        var id = manufacturerPicker.val();
        if (id == "" || id == null) {
            dataRender.clearSelectorsAndDisable([carmodelPicker]);
        }
        else {
            carmodelPicker.prop('disabled', false);
            dataLoader.loadCarModels(carModelsfUrl + "/" + id, carmodelPicker, carmodelId);
        }
    });
    countryPicker.change();
});

dataLoader = {
    loadCountries: function (url,picker,id) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                dataRender.renderList(output,picker,id);
            },
            error: function (err, a, c) {
                alert("Error loading manufacturers");
            }
        });
    },
    loadManufacturers: function (url, picker, id) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                dataRender.renderList(output, picker, id);
            },
            error: function (err, a, c) {
                alert("Error loading manufacturers");
            }
        });
    },
    loadCarModels: function (url,picker,id) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                dataRender.renderList(output, picker, id);
            },
            error: function (err, a, c) {
                alert("Error loading car models");
            }
        });
    },
    loadCarBodyTypes: function (url,picker,id) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                dataRender.renderList(output, picker, id);
            },
            error: function (err, a, c) {
                alert("Error loading car model types");
            }
        });
    }
}
dataRender = {
    clearSelectorsAndDisable: function(selectorsArray) {
        for (var i = 0; i < selectorsArray.length; i++) {
            selectorsArray[i].empty();
            selectorsArray[i].prop('disabled', 'disabled');
        }
    },
    renderList: function (output,picker,id) {
        picker.empty(); //remove all child nodes
        var newOption = $('<option selected value>Select value</option>');
        picker.append(newOption);
        for (var i = 0; i < output.length; i++) {
            newOption = $('<option value="' + output[i].Id + '">' + output[i].Name + '</option>');
            picker.append(newOption);
        }
        picker.val(id);
        if (id > 0) picker.change();
        picker.trigger("chosen:updated");
    }
}