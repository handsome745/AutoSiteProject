$(document).ready(function () {
    var addImageDiv = $("div.add-image");
    $("input", addImageDiv).change(function () {
        ImageLoader.AddImagePreview(this);
    });
});

ImageLoader = {
    AddImagePreview: function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            var imageContainer = $("div.images-container");



            reader.onload = function (e) {

                function guid() {
                    function s4() {
                        return Math.floor((1 + Math.random()) * 0x10000)
                          .toString(16)
                          .substring(1);
                    }
                    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
                      s4() + '-' + s4() + s4() + s4();
                }

                var addImageDiv = $("div.add-image");
                var inputImage = $("input", addImageDiv);

                var uniqueId = guid();

                var newInput = $('<input>').attr({
                    type: 'file',
                    id: uniqueId,
                    name: 'files'
                });



                newInput.files = inputImage.files;//deep copy with data and events
                newInput.attr("visibility", "hidden");//hide file input
                var imageBlock = "<div class='image-block' id = '" + uniqueId + "'>";
                imageBlock += fileInput.html();
                imageBlock += "<img src='" + e.target.result + "' width = '150'/>";
                imageBlock += "<input type='button' value='Delete' id='" + uniqueId + "' class='deleteImageBlockButton'/>";
                imageBlock += "</div>";
                imageContainer.html(imageContainer.html() + imageBlock);
                $("input.deleteImageBlockButton").on("click", function () {
                    ImageLoader.DeleteImageBlock(this);
                });
                inputImage.replaceWith(inputImage.clone(true));

                newInput.append("form");
            }
            reader.readAsDataURL(input.files[0]);

        }
    },
    DeleteImageBlock: function (button) {
        $("div.image-block#" + button.id).remove();
    }

}