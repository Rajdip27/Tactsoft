﻿showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}
jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contenttype: false,
            processData: false,
            success: function (res) {
                if (res.isVaild) {
                    $('#view-all').html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                } else
                    $('#form-modal .modal-body').html(res.html);

            }, error: function (err) {
                console.log(err);
            }
        })
        return false;

    } catch (ex) {
        console.log(ex);
    }
}
jQueryAjaxDelete = form => {
    
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                contenttype: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html)
                }, error: function (err) {
                    console.log(err);
                }
            })
        } catch (ex) {
            console.log(ex);
        }
    }
    return false;

    
}