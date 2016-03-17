$(function () {

    var page = 0;
    var _inCallback = false;
    function loadItems() {
        if (page > -1 && !_inCallback) {
            _inCallback = true;
            page++;

            $.ajax({
                type: 'GET',
                url: '/Subject/GetSubjectList/' + page,
                success: function (data, textstatus) {
                    if (data != '') {
                        $("#scrollTable").append(data);
                        
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                }
            });
            $("#scrollTable").removeClass("table");
            $("#scrollTable").addClass("table");
            
        }
    }

    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {

            loadItems();
        }
    });
})