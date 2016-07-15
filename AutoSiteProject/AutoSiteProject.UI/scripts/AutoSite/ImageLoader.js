$(document).ready(function () {
    $("input.add-image").change(function () {
        ImageLoader.AddImagePreview(this);
        this.replaceWith(this.clone(true));
    });
});

ImageLoader = {
    AddImagePreview: function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            var imageContainer = $("div.images-container");

            reader.onload = function (e) {
                var timestamp = new Date().getUTCMilliseconds();//uniq number
                var fileInput = input.clone(true, true);//deep copy with data and events
                fileInput.attr("visibility", "hidden");//hide file input
                var imageBlock = "<div class='image-block' id = '" + timestamp + "'>";
                imageBlock += fileInput.html();
                imageBlock += "<img src='" + e.target.result + "' width = '150'/>";
                imageBlock += "<input type='button' value='Delete' id='" + timestamp + "' class='deleteImageBlockButton'/>";
                imageBlock += "</div>";
                imageContainer.html(imageContainer.html().append(imageBlock));
                $("input.deleteImageBlockButton").on("click", function() {
                     ImageLoader.DeleteImageBlock(this);
                });
            }
            reader.readAsDataURL(input.files[0]);
        }
    },
    DeleteImageBlock: function(button) {
        var id = button.attr("id");
        $("div.image-block#" + id).remove();
    }

}