$(document).ready(function () {
    $.get('http://localhost:30881/api/CourseAPI/GetAllCourse', function (response) {
        $.each(response, function (index, value) {
            $('#courseInAllCourses').append(" <div class='col-md-4'> <div class='card card-product'> <div class='card-image' data-header-animation='true'> <a href='#pablo'> <img class='img' src='" + value.coursePicture + "'> </a> </div> <div class='card-content'> <div class='card-actions'> <button type='button' class='btn btn-danger btn-simple fix-broken-card'> <i class='material-icons'>build</i> Fix Header! </button> <button type='button' class='btn btn-default btn-simple' rel='tooltip' data-placement='bottom' title='View'> <i class='material-icons'>art_track</i> </button> <button type='button' class='btn btn-success btn-simple' rel='tooltip' data-placement='bottom' title='Edit'> <i class='material-icons'>edit</i> </button> <button type='button' class='btn btn-danger btn-simple' rel='tooltip' data-placement='bottom' title='Remove'> <i class='material-icons'>close</i> </button> </div> <h4 class='card-title'> <a href='#pablo'>" + value.courseName + "</a> </h4> <div class='card-descrip    tion'>" + value.courseDiscription + "</div> </div> <div class='card-footer'> <div class='price'> <h4>" + value.courseFee + "</h4> </div> <div class='stats pull-right'> <p class='category'><i class='material-icons'>startDate</i>" + value.courseStartDate+"</p> </div> </div> </div> </div>");
        });
    });
    $('#CourseAdd').click(function () {
        courseName = $('#courseName').val();
        courseFee = $('#courseFee').val();
        courseteacherName = $('#courseTeacherName').val();
        courseStartDate = $('#courseStartDate').val();
        fileCourseImage = $('#fileCourseImage').attr('src');
        textCourseDiscription = $('#textCourseDiscription').val();
        var jsonObject = { 'CourseName': courseName, 'CourseFee': courseFee, 'TeacherName': courseteacherName, 'courseDiscription': textCourseDiscription, 'courseStartDate': courseStartDate, 'coursePicture': fileCourseImage };
        if (courseName.length == 0 || courseFee.length == 0 || courseteacherName == 0 || courseStartDate.length == 0 || textCourseDiscription.length == 0) {
            alert("please fill the form completely");
        }
        else {
            $.ajax({
                type: "POST",
                data: JSON.stringify(jsonObject),
                url: "http://localhost:30881/api/CourseAPI/CourseRegister",
                contentType: "application/json",
                success: function (response) {
                    $.each(response, function (index, value) {
                        alert(response.status);
                        var NewCourseId = response.id
                        var totalFiles = document.getElementById('fileCourseImage').files.length;
                        if (totalFiles > 0) {
                            var newform = new FormData();
                            newform.append('CourseId', NewCourseId);
                            for (var i = 0; i < totalFiles; i++) {
                                newform.append("image", document.getElementById('fileCourseImage').files[i]);
                            }
                            $.ajax({
                                type: 'POST',
                                url: '/Home/fileUploadingCourses',
                                data: newform,
                                dataType: 'json',
                                contentType: false,
                                processData: false,
                                success: function (response) {
                                    $('#courseName').val('');
                                    $('#courseFee').val('');
                                    $('#courseTeacherName').val('');
                                    $('#courseStartDate').val('');
                                    $('#fileCourseImage').val('');
                                    $('#textCourseDiscription').val('');
                                    window.location.href = '/Home/AllCourses';
                                },
                                error: function (errormsg) { prompt("", JSON.stringify      (errormsg)) }
                            });
                        }
                    });
                }
            });
        }
    });
});