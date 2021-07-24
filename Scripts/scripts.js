function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
            
        }
        reader.readAsDataURL(imageUploader.files[0]);
     
    }
}

function ShowImagePreview_2(imageUploader2, previewImage2) {
    if (imageUploader2.files && imageUploader2.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage2).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader2.files[0]);
    }
}

function ShowImagePreview_3(imageUploader3, previewImage3) {
    if (imageUploader3.files && imageUploader3.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage3).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader3.files[0]);
    }
}

