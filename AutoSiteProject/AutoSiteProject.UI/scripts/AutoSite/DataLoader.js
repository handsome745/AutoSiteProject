$(document).ready(function () {
    var filterSection = $("div.filter-section");
    //urls
    var countryUrl = filterSection.data("countries-url");
    var manufUrl = filterSection.data("manufacturers-url");
    var carModelsfUrl = filterSection.data("carmodels-url");
    var carBodyTypesfUrl = filterSection.data("carbodytype-url");
    var fuelTypesUrl = filterSection.data("carfueltype-url");
    var transmitionTypesUrl = filterSection.data("cartransmitiontype-url");
    //Pickers
    var countryPicker = $(".country-picker", filterSection);
    var manufacturerPicker = $(".manufacturer-picker", filterSection);
    var carmodelPicker = $(".carmodel-picker", filterSection);
    var carbodytypePicker = $(".carbodytype-picker", filterSection);
    var carOptionsPicker = $(".caroptions-picker", filterSection);
    var fuelTypePicher = $(".carfueltype-picker", filterSection);
    var transmitionTypePicker = $(".cartransmitiontype-picker", filterSection);
    
    carOptionsPicker.chosen({ allow_single_deselect: true , width:"100%"});

    //initial ids
    var countryId = countryPicker.data("initid");
    var manufacturerId = manufacturerPicker.data("initid");
    var carmodelId = carmodelPicker.data("initid");
    var carbodytypeId = carbodytypePicker.data("initid");
    var fuelTypeId = fuelTypePicher.data("initid");
    var transmitionTypeId = transmitionTypePicker.data("initid");

    dataLoader.loadItems(countryUrl, countryPicker, countryId, "Can't load countries");
    dataLoader.loadItems(carBodyTypesfUrl, carbodytypePicker, carbodytypeId,"Can't load body types");
    dataLoader.loadItems(fuelTypesUrl, fuelTypePicher, fuelTypeId, "Can't load fuel types");
    dataLoader.loadItems(transmitionTypesUrl, transmitionTypePicker, transmitionTypeId, "Can't load transmition types");

    countryPicker.change(function () {
        var id = countryPicker.val();
        if (id == "" || id == null) {
            dataRender.clearSelectorsAndDisable([manufacturerPicker, carmodelPicker]);
        }
        else {
            manufacturerPicker.prop('disabled', false);
            dataLoader.loadItems(manufUrl + "/" + id, manufacturerPicker, manufacturerId,"Can't load manufacturers");
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
            dataLoader.loadItems(carModelsfUrl + "/" + id, carmodelPicker, carmodelId, "Can't load car models");
        }
    });
    countryPicker.change();
});

dataLoader = {
    loadItems: function (url, picker, id, errorMessage) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: url,
            success: function (output) {
                dataRender.renderList(output, picker, id);
            },
            error: function (err, a, c) {
                alert(errorMessage);
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