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
    var carbodytypeId = modelData.CarBodyTypeId;

    DataLoader.loadCountries(countryUrl, countryPicker, countryId);
    DataLoader.loadCarBodyTypes(carBodyTypesfUrl, carbodytypePicker, carbodytypeId);
    DataLoader.loadCarOptions(carOptionsUrl, carOptionsPicker);


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
    countryPicker.change();
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
    loadCarOptions: function (url, picker) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                DataRender.renderCarOptionsList(output,picker);
            },
            error: function (err, a, c) {
                alert("Error loading car model types");
            }
        });
    }

}
DataRender = {
    clearSelectorsAndDisable(selectorsArray) {
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
    renderCarOptionsList: function (output, picker) {
        var result = "";
        for (var i = 0; i < output.length; i++) {
            result += "<input type='checkbox' name='carOption' class='carOption' value=" + output[i].Id + ">" + output[i].Name + "<br>";
        }
        picker.html(result);
    }
}