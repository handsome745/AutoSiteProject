$(document).ready(function () {
    $("#country").change(function () {
        var id = $("#country option:selected").val();
        DataLoader.loadManufacturers(id);
    });
});

DataLoader = {
    loadManufacturers: function(id) {
        $.ajax({
            type: "GET",
            asynch: true,
            url: "home/getmanufacturersofcountry/" + id,
            success: function (output) {
                DataLoader.renderManufacturersList(output);
            },
            error: function (err) {
                alert("Error");
            }
        });
    },
    renderManufacturersList: function(data) {
        var result = "";
        for (var i = 0; i < data.length; i++) {
            result += "<option value='" + data[i].Id + "'>";
            result += data[i].Name;
            result += "</option>";
        }
        document.getElementById("SelectedManufacturer").innerHTML = result;
    }

}