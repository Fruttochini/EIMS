$(document).ready(function() {
    $("#subjectID").kendoComboBox({
        filter: "contains",
        placeholder: "Select Subject...",
        dataTextField: "Text",
        dataValueField: "Value",
        dataSource: {
            type: "odata",
            serverFiltering: true,
            transport: {
                read: "CourseFill/GetSubjectSelectList"
            }
        }
    });
});