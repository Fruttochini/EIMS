function OnSubjectChange(subject) {
    var dayid = $("#dayid").val();
    var loid = $("#lesOrid").val();
    var stdcount = $("#stdCount").val();
    
    $.ajax({
        type: "GET",
        url: "/Schedule/GetTeachersJSON?subjectID=" + subject + "&loid=" + loid + "&dayofweek=" + dayid,
        success: function (data) {
            $("#SelectedTeacher").empty();
            $.each(data, function (item) {
                var optionhtml = '<option value="' + data[item].ID + '">' + data[item].FullName + '</option>';
                
                $("#SelectedTeacher").append(optionhtml);
            });
        }
    });
    $.ajax({
        type: "GET",
        url: "/Schedule/GetRoomsJSON?subjectID=" + subject + "&loid=" + loid + "&dayofweek=" + dayid + "&stCount=" + stdcount,
        success:function(data)
        {
            $("#SelectedRoom").empty();
            $.each(data, function (item) {
                var optionhtml = '<option value="' + data[item].ID + '">' + data[item].RoomNo + '</option>';
                
                $("#SelectedRoom").append(optionhtml);
            })
        }
    });
        
        


}