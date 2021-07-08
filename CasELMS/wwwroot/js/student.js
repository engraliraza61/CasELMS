$(document).ready(function () {
    $.get("http://localhost:30881/api/StudentAPI/GetAllStudent", function (response) {
        $.each(response, function (index, value) {
            $('#tblStudent').append("<tr><td>" + value.firstName + "</td><td>" + value.lastName + "</td><td>" + value.email + "</td><td>" + value.studentPhoneNumber + "</td><td align='left'> <a href='#'  class='btn btn-simple btn-danger btn-icon remove'><i class='material-icons'>close</i></a><a href='/Home/UpdateStudent/" + value.studentId+"' class='btn btn-simple btn-success btn-icon edit'><i class='material-icons'>edit</i></a></td></tr>");
        });
    });
    $('.addStudent').click(function () {
        window.location.href = "/Home/RegisterPage";
    });
    $('#studentRegisterButton').click(function () {
        firstName = $('#studentFirstName').val();
        lastName = $('#studentLastName').val();
        userName = $('#studentUserName').val();
        email = $('#studnetEmail').val();
        password = $('#studentPassword').val();
        phoneNo = $('#studnetPhoneNo').val();
        address = $('#studentAddress').val();
        postalCode = $('#studentPostalCode').val();
        studentClass = $('#studentClass').val();
        var jsonObject = { 'FirstName': firstName, 'LastName': lastName, 'UserName': userName, 'StudentPhoneNumber': phoneNo, 'Email': email, 'Password': password, 'Adress': address, 'PostalCode': postalCode, 'studentClass': studentClass };
        if (firstName.length == 0 || lastName.length == 0 || userName.length == 0 || email.length == 0 || password.length == 0 || phoneNo.length == 0 || address.length == 0 || postalCode.length == 0 || studentClass.length==0) {
            alert("please fill the form completely");
        }
        else
        {
            $.ajax({
                type: "POST",
                data: JSON.stringify(jsonObject),
                url: "http://localhost:30881/api/StudentAPI/Registration",
                contentType: "application/json",
                success: function (response) {
                    $.each(response, function (index, value) {
                        alert(response.status);
                        $('#studentFirstName').val('');
                        $('#studentLastName').val('');
                        $('#studentUserName').val('');
                        $('#studnetEmail').val('');
                        $('#studnetPhoneNo').val('');
                        $('#studentAddress').val('');
                        $('#studentPostalCode').val('');
                        $('#studentClass').val('');
                        window.location.href = '/Home/LoginPage';
                    });
                }
            });
        }
    });
    $('#loginButton').click(function () {
        email=$('#loginEmail').val();
        password = $('#loginPassword').val();
        var jsonObject = { 'Email': email, 'Password': password };
            $.ajax({
                type: "POST",
                data: JSON.stringify(jsonObject),
                url: "http://localhost:30881/api/StudentAPI/Login",
                contentType: "application/json",
                success: function (response) {
                    $.each(response, function (index, value) {
                        if (response.status == "login successfully") {
                            alert(response.UserIdentity);
                            $('#loginEmail').val('');
                            $('#loginPassword').val('');
                            $.cookie("UserIdentity", Response.UserIdentity);
                            window.location.href = '/Home/Index';
                        }
                        else {
                            alert("login failed")
                        }
                    });
                },
                error: function (errormsg) { prompt("", JSON.stringify(errormsg)) }
            });
    });
});
