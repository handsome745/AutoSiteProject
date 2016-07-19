$(document).ready(function () {
    var addImageDiv = $("div.add-image");
    $("input", addImageDiv).change(function () {
        myImageLoader.addImagePreview(this);
    });
    $("input.existImageDeleteButton").on("click",function () {
        myImageLoader.disableExistImageBlock(this);
    });
});

myImageLoader = {
    addImagePreview: function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            Array.from(input.files).forEach(function (file) {
                reader.onload = function (e) {
                    myImageLoader.onImageLoad(e, input);
                }
                reader.readAsDataURL(file);
            });
        }
    },
    deleteImageBlock: function (button) {
        $("div.image-block#" + button.id).remove();
    },
    disableExistImageBlock: function(button) {
        Array.from($("div.image-block#" + button.id).children()).forEach(function(item) { item.style.display = "none"; });
        $("input.existImageIdField#" + button.id, $("div.image-block#" + button.id)).val(0);
    },
    onImageLoad: function (e, input) {
        var addImageDiv = $("div.add-image");
        var imageContainer = $("div.images-container");

        var uniqueId = myImageLoader.guid();
        
        var img = $("<img>").attr({
            src: e.target.result,
            width: "150"
        });
        input.style.display = "none";
        var deleteButton = $("<input>").attr({
            type: "button",
            id: uniqueId,
            'class': "deleteImageBlockButton",
            value: "Delete"
        });

        var imageBlock = $("<div>").attr({
            'class': "image-block",
            id: uniqueId
        });
        imageBlock.append(input);
        imageBlock.append(img);
        imageBlock.append(deleteButton);

        imageContainer.append(imageBlock);
        $("input.deleteImageBlockButton").on("click", function () {
            myImageLoader.deleteImageBlock(this);
        });

        var newAddInput = $($("<input>").attr({ type: "file", name: "files" }));
        newAddInput.change(function () {
            myImageLoader.addImagePreview(this);
        });
        addImageDiv.append(newAddInput);
    },
    guid: function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
          s4() + '-' + s4() + s4() + s4();
    }
}