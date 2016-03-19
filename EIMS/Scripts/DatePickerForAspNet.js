$(function () {
    if (!Modernizr.inputtypes.date) {
        $(function () {
            $("input[type='date']")
                        .datepicker({ dateFormat: 'dd/mm/yy' })
                        .get(0).setAttribute("type", "text");
        })
    }
});