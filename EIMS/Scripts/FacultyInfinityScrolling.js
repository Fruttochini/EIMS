$(function () {

    var page = 0;
    var _inCallback = false;
    function loadItems() {
        if (page > -1 && !_inCallback) {
            _inCallback = true;
            page++;

            $.ajax({
                type: 'GET',
                url: '/Faculty/Faculties/' + page,
                success: function (data, textstatus) {
                    if (data != '') {
                        $(".table").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                }
            });
        }
    }

    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {

            loadItems();
        }
    });
})