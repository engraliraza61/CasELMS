$(document).ready(function () {
    $('#studentRegisterButton').click(function () {
        firstName = $('#studentFirstName').val();
        lastName = $('#studentLastName').val();
        userName = $('#studentUserName').val();
        email = $('#studnetEmail').val();
        password = $('#studentPassword').val();
        phoneNo = $('#studnetPhoneNo').val();
        address = $('#studentAddress').val();
        postalCode = $('#studentPostalCode').val();
        var jsinObject = { 'FirstName': firstName, 'LastName': lastName, 'UserName': userName, 'StudentPhoneNumber': StudentPhoneNumber, 'Email': email, 'Password': password, 'Adress': address, 'PostalCode': postalCode };
        if (firstName.length == 0 || lastName.length == 0 || userName.length == 0 || email.length == 0 || password.length == 0 || phoneNo.length == 0 || address.length == 0 || postalCode.length == 0) {
            alert("please fill the form completely");
        }
        else
        {
            $.ajax({
                type: "POST",
                data: JSON.stringify(jsinObject),
                url: "",
                contentType: "application/json",
                success: function (response) {
                    $.each(response, function (index, value) {
                        alert(response.status);
                    });

                }
            });
        }
    });
});
