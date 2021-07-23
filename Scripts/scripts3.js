function ShowImagePreview_3(imageUploader3, previewImage3) {
    if (imageUploader3.files && imageUploader3.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage3).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader3.files[0]);
    }
}