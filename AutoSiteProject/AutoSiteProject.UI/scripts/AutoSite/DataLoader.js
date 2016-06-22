$(document).ready(function () {
    var filterSection = $("div.filter-section");
    //urls
    var countryUrl = filterSection.data("countries-url");
    var manufUrl = filterSection.data("manufacturers-url");
    var carModelsfUrl = filterSection.data("carmodels-url");
    var carBodyTypesfUrl = filterSection.data("carbodytype-url");
    var carOptionsUrl = filterSection.data("caroptions-url");
    //Pickers
    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    //initial ids
    var countryId = modelData.CountryId;
    var manufacturerId = modelData.ManufacturerId;
    var carmodelId = modelData.ModelId;
    var carbodytypeId = modelData.BodyTypeId;

    //var carOptions = modelData.CarOptions;//List of checked car options

    DataLoader.loadCountries(countryUrl, countryPicker, countryId);
    DataLoader.loadCarBodyTypes(carBodyTypesfUrl, carbodytypePicker, carbodytypeId);
    //DataLoader.loadCarOptions(carOptionsUrl, carOptionsPicker, carOptions);


    countryPicker.change(function () {
        var id = countryPicker.val();
        if (id == "" || id == null) {
            DataRender.clearSelectorsAndDisable([manufacturerPicker, carmodelPicker]);
        }
        else {
            manufacturerPicker.prop('disabled', false);
            DataLoader.loadManufacturers(manufUrl + "/" + id, manufacturerPicker,manufacturerId);
            DataRender.clearSelectorsAndDisable([carmodelPicker]);
        }
    });
    manufacturerPicker.change(function () {
        var id = manufacturerPicker.val();
        if (id == "" || id == null) {
            DataRender.clearSelectorsAndDisable([carmodelPicker]);
        }
        else {
            carmodelPicker.prop('disabled', false);
            DataLoader.loadCarModels(carModelsfUrl + "/" + id,carmodelPicker,carmodelId);
        }
    });
    
});

DataLoader = {
    loadCountries: function (url,picker,id) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderCountriesList(output,picker,id);
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
                DataRender.renderManufacturersList(output,picker,id);
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
                DataRender.renderCarModelsList(output,picker,id);
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
                DataRender.renderCarBodyTypesList(output, picker, id);
            },
            error: function (err, a, c) {
                alert("Error loading car model types");
            }
        });
    },
    loadCarOptions: function (url, picker, checkedOptions) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderCarOptionsList(output, picker, checkedOptions);
            },
            error: function (err, a, c) {
                alert("Error loading car model types");
            }
        });
    }

}
DataRender = {
    clearSelectorsAndDisable: function(selectorsArray) {
        for (var i = 0; i < selectorsArray.length; i++) {
            selectorsArray[i].empty();
            selectorsArray[i].prop('disabled', 'disabled');
        }
    },
    renderCountriesList: function (output,picker,id) {
        var result = "<option value>Select country</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
       picker.html(result);
       picker.val(id);
       if (id > 0) picker.change();
    },
    renderManufacturersList: function (output, picker, id) {
        var result = "<option value>Select manufacturer</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        picker.html(result);
        picker.val(id);
        if (id > 0) picker.change();
    },
    renderCarModelsList: function (output,picker,id) {
        var result = "<option value>Select car model</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        picker.html(result);
        picker.val(id);
        if (id > 0) picker.change();
    },
    renderCarBodyTypesList: function (output,picker,id) {
        var result = "<option value>Select car model type</option>";
        for (var i = 0; i < output.length; i++) {
            result += "<option value='" + output[i].Id + "'>";
            result += output[i].Name;
            result += "</option>";
        }
        picker.html(result);
        picker.val(id);
    },
    renderCarOptionsList: function (output, picker, checkedOptions) {
        var result = "";
        for (var i = 0; i < output.length; i++) {
            result += "<input type='checkbox' name='CarOptions' class='carOption' value=";
            result += output[i].Id;
            if ($.inArray(output[i].id, checkedOptions) != -1) result += "checked";
            result += ">" + output[i].Name + "<br>";
        }
        picker.html(result);
    }
}