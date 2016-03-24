function SetPressense(incId)
{
    var pid = incId.substring(1);
    var pres = $("#" + pid).prop('checked');
    var mark = $("#" + incId).val();
    var ldid = $("#lessondateid").val();
    
    if (pres == false) {
        mark = null
    }
    else if (!$.isNumeric(mark)) {
        mark = null;
        var id = "#" + incID;
        $(id).val("");
    }
    $.ajax({
        type: "GET",
        url: "/LessonPrecense/SetPressense?studentID=" + pid + "&lessonDateID=" + ldid+ "&pressense="+pres+"&mark="+mark,
        success: function (data) {

        }
    })
    
}

function SetPressenseOnCheckbox(element) {
    var pres = false;
    var mark = null;
    var elid = $(element).attr('id');
    element.checked ? pres = true : pres = false;
    if (pres==false)
    {
        var id = "#m" + elid;
        $(id).val("");
    }

    mark = $("#m" + elid).val();
    var ldid = $("#lessondateid").val();
    $.ajax({
        type: "GET",
        url: "/LessonPrecense/SetPressense?studentID=" + elid + "&lessonDateID=" + ldid + "&pressense=" + pres + "&mark=" + mark,
        success: function (data) {

        }
    })
}