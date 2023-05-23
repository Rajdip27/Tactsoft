showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#PurchaseItem .modal-body').html(res);
            $('#PurchaseItem .modal-title').html(title);
            $('#PurchaseItem').modal('show');
        }
    })
}
jQueryAjaxPost = form => {
    debugger;
    try {
       
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contenttype: false,
            processData: false,
            success: function (res) {
                debugger;
                if (res.isVaild) {
                    debugger;
                    $('#show-all').html(res.html);
                    
                    $('#PurchaseItem .modal-body').html('');
                    $('#PurchaseItem .modal-title').html('');
                    $('#PurchaseItem').modal('hide');
                    
                } else
                    debugger;
                    $('#PurchaseItem .modal-body').html(res.html);

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
                    $('#show-all').html(res.html)
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

