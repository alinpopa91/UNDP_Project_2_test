function isNumberKey(evt) {
    //var e = evt || window.event;
	var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

var baseUrl = 'https://localhost:44360/';

function updateSuccess() {
    alert('added');
}

function updateSuccess() {
    alert('error');
}

function SubmitAddMembers() {

    var model = {
        Name: $("#Name").val(),
        Gender: $('#Gender').val(),
        DateOfBirth: $("#DateOfBirth").val(),
        ContactNo: $("#ContactNo").val()
    };

     $.ajax({
         type: "get",
         url: baseUrl + 'Home/AddNewTeamMember',
         data: model,
         contenttype: "application/json",
         success: function (data) {
             $("#teamMemberDIV").html(data);
         },
         error: function (xhr, status, error) {
             alert(xhr.responseText);
         }
     });
}