empoup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#big-modal .modal-body').html(res);
            $('#big-modal .modal-title').html(title);
            $('#big-modal').modal('show');
        }
    })
}



empost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html);
                    $('#big-modal .modal-body').html('');
                    $('#big-modal .modal-title').html('');
                    $('#big-modal').modal('hide');
                }
                else
                    $('#big-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}
emdelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({

                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                }, error: function (err) {
                    console.log(ex);
                }
            })
        } catch (ex) {
            console.log(ex);
        }
    }
    return false;
}
