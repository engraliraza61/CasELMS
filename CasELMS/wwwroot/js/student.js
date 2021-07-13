$(document).ready(function () {
    function StudentFirstNameVerify() {
        if ($('#studentFirstName').val().length<=2) {
            $('#firstNameMassage').html('length must be greater than 3');
            $('#firstNameMassage').css('color', 'red');
        }
        else {
            $('#firstNameMassage').html('length is in best form');
            $('#firstNameMassage').css('color', 'green');
        }
    }
    $('#studentFirstName').blur(function () {
        StudentFirstNameVerify();
    });
    function StudentLastNameVerify() {
        if ($('#studentLastName').val().length <= 2) {
            $('#LastNameMassage').html('length must be greater than 3');
            $('#LastNameMassage').css('color', 'red');
        }
        else {
            $('#LastNameMassage').html('length is in best form');
            $('#LastNameMassage').css('color', 'green');
        }
    }
    $('#studentLastName').blur(function () {
        StudentLastNameVerify();
    });
    function StudentUserNameVerify() {
        if ($('#studentUserName').val().length <= 2) {
            $('#UserNameMassage').html('length must be greater than 3');
            $('#UserNameMassage').css('color', 'red');
        }
        else {
            $('#UserNameMassage').html('length is in best form');
            $('#UserNameMassage').css('color', 'green');
        }
    }
    $('#studentUserName').blur(function () {
        StudentUserNameVerify();
    });
    function StudentPasswordVerify() {
        if ($('#studentPassword').val().length <= 4) {
            $('#PasswordMassage').html('length must be greater than 3');
            $('#PasswordMassage').css('color', 'red');
        }
        else {
            $('#PasswordMassage').html('length is in best form');
            $('#PasswordMassage').css('color', 'green');
        }
    }
    $('#studentPassword').blur(function () {
        StudentPasswordVerify();
    });
    function StudentPhoneVerify() {
        if ($('#studnetPhoneNo').val().length == 0) {
            $('#PhoneNoMassage').html('please fill this field');
            $('#PhoneNoMassage').css('color', 'red');
        }
        else {
            $('#PhoneNoMassage').html('length is in best form');
            $('#PhoneNoMassage').css('color', 'green');
        }
    }
    $('#studnetPhoneNo').blur(function () {
        StudentPhoneVerify();
    });
    function StudentAddressVerify() {
        if ($('#studentAddress').val().length == 0) {
            $('#AddressMassage').html('please fill this field');
            $('#AddressMassage').css('color', 'red');
        }
        else {
            $('#AddressMassage').html('');
        }
    }
    $('#studentAddress').blur(function () {
        StudentAddressVerify();
    });
    function StudentpostalCodeVerify() {
        if ($('#studentPostalCode').val().length == 0) {
            $('#postalCodeMassage').html('please fill this field');
            $('#postalCodeMassage').css('color', 'red');
        }
        else {
            $('#postalCodeMassage').html('');
        }
    }
    $('#studentPostalCode').blur(function () {
        StudentpostalCodeVerify();
    });
    function StudentClassVerify() {
        if ($('#optionstudentClass').val().length == 0) {
            $('#ClassMassage').html('please fill this field');
            $('#ClassMassage').css('color', 'red');
        }
        else {
            $('#ClassMassage').html('');
        }
    }
    $('#optionstudentClass').blur(function () {
        StudentClassVerify();
    });
    $('#studnetEmail').blur(function () {
        email = $('#studnetEmail').val();
        jsonObject = { 'email': email };
        $.ajax({
            type: "POST",
            url: "http://localhost:30881/api/StudentAPI/EmailCheck",
            data: JSON.stringify(jsonObject),
            contentType: 'application/json',
            success: function (response) {
                if (response.status == 'Email Verified') {
                    $('#EmailMassage').html('Email Verified');
                    $('#EmailMassage').css('color', 'green');
                }
                else {
                    $('#EmailMassage').html('Email already exist');
                    $('#EmailMassage').css('color', 'red');
                    $('#studnetEmail').focus();
                }
            },
            error: function (errormsg) { prompt("", JSON.stringify(errormsg)) }
        });
    });
        $.get("http://localhost:30881/api/StudentAPI/GetAllStudent", function (response) {
            $.each(response, function (index, value) {
                $('#tblStudent').append("<tr><td>" + value.firstName + "</td><td>" + value.lastName + "</td><td>" + value.email + "</td><td>" + value.studentPhoneNumber + "</td><td>" + value.status + "</td><td align='left'> <a href='#' id='RemoveStudent" + value.studentId + "'  class='btn btn-simple btn-danger btn-icon remove'><i class='material-icons'>close</i></a><a href='/Home/UpdateStudent/" + value.studentId + "' class='btn btn-simple btn-success btn-icon edit'><i class='material-icons'>edit</i></a></td></tr>");
            });
        });
        $('#showDeAciveStudent').click(function () {
            $.get("http://localhost:30881/api/StudentAPI/ShowDeactiveStudent", function (response) {
                $.each(response, function (index, value) {
                    $('#tblStudent').append("<tr><td>" + value.firstName + "</td><td>" + value.lastName + "</td><td>" + value.email + "</td><td>" + value.studentPhoneNumber + "</td><td>" + value.status + "</td><td align='left'> <a href='#' id='RemoveStudent" + value.studentId + "'  class='btn btn-simple btn-danger btn-icon remove'><i class='material-icons'>close</i></a><a href='/Home/UpdateStudent/" + value.studentId + "' class='btn btn-simple btn-success btn-icon edit'><i class='material-icons'>edit</i></a></td></tr>");
                });
            });
        });
        $('#showAciveStudent').click(function () {
            $.get("http://localhost:30881/api/StudentAPI/ShowActiveStudent", function (response) {
                $.each(response, function (index, value) {
                    $('#tblStudent').append("<tr><td>" + value.firstName + "</td><td>" + value.lastName + "</td><td>" + value.email + "</td><td>" + value.studentPhoneNumber + "</td><td>" + value.status + "</td><td align='left'> <a href='#' id='RemoveStudent" + value.studentId + "'  class='btn btn-simple btn-danger btn-icon remove'><i class='material-icons'>close</i></a><a href='/Home/UpdateStudent/" + value.studentId + "' class='btn btn-simple btn-success btn-icon edit'><i class='material-icons'>edit</i></a></td></tr>");
                });
            });
        });
    $.get("http://localhost:30881/api/CourseAPI/GetAllCourse", function (response) {
        $.each(response, function (index, value) {
            $('#optionstudentClass').append("<option CourseId=" + value.courseId + ">" + value.courseName + "</option");
        });
    });
    $(document).on('click', '.remove', function () {
        Id = $(this).attr('id');
        Id = Id.replace("RemoveStudent", "");
        jsonObject = { 'studentId': Id };
        $.ajax({
            type: "PUT",
            data: JSON.stringify(jsonObject),
            url: "http://localhost:30881/api/StudentAPI/RemoveStudent",
            contentType: "application/json",
            success: function (response) {
                $.each(response, function (index, value) {
                    alert(response.status);
                });
            }
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
        studentClass = $('#optionstudentClass').val();
        var jsonObject = { 'FirstName': firstName, 'LastName': lastName, 'UserName': userName, 'StudentPhoneNumber': phoneNo, 'Email': email, 'Password': password, 'Adress': address, 'PostalCode': postalCode, 'class': studentClass };
        if (firstName.length == 0 || lastName.length == 0 || userName.length == 0 || email.length == 0 || password.length == 0 || phoneNo.length == 0 || address.length == 0 || postalCode.length == 0 || studentClass.length==0) {
            alert("please fill the form carefully");
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
                            alert(response.status);
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
