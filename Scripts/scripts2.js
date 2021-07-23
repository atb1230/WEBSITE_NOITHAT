function ShowImagePreview_2(imageUploader2, previewImage2) {
    if (imageUploader2.files && imageUploader2.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage2).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader2.files[0]);
    }
}