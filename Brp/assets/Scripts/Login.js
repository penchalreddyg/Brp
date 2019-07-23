/*------------------------------------------------------------------
[SignIn Javascript]
Project:	SVCE
Author: i2speed.in, i2speed.com, I2Speed Technologies LLP
Version:	1.0
Design and Developed by: i2speed.in, i2speed.com
Author URI: http://i2speed.in , http://i2speed.com
-------------------------------------------------------------------*/

$(document).ready(function () {
    //Start SignIn
    $("#btnSignin").click(function () {
        $("#Form-Login").validate({
            errorClass: "help-block animation-fadeInQuickInv",
            errorElement: "div",
            errorPlacement: function (e, r) {
                r.parents(".form-group").append(e)
            }, highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success has-error").addClass("has-error"), $(e).closest(".help-block").remove()
            }, success: function (e) {
                e.closest(".form-group").removeClass("has-success has-error"), e.closest(".help-block").remove()
            }, rules: {
                "txtEmail": { required: !0, email: !0 }, "txtPassword": { required: !0, minlength: 5 }
            }, messages: {
                //"txtEmail": "Please enter username",
                "txtEmail": { required: "Please enter username/email", email: "Please enter valid username/email" },
                "txtPassword": { required: "Please enter password", minlength: "Your password must be at least 5 characters" }
            }
        })
        var form = $("#Form-Login");
        var email = $("#txtEmail").val();
        var password = $("#txtPassword").val();
        if (form.valid()) {
            var loginRequest = { EmailId: email, Password: password };
            $.ajax({
                type: "POST",
                url: service + "UserLogin",
                data: JSON.stringify({ request: loginRequest }),
                contentType: "application/json",
                dataType: "json",
                success: function (data) {
                    var response = data.UserLoginResult;
                    if (response.StatusCode == "-555") {
                        $("#error").show();
                        $("#error").addClass("alert-danger");
                        $("#errormessage").text("Enter Credentials correctly");
                        setTimeout(function () {
                            $("#error").fadeOut('slow');
                            $("#error").removeClass("alert-danger");
                        }, 5000);
                    }
                    else {
                        $.session.set("MName", response.FullName);
                        $.session.set("MUserId", response.UserID);
                        $.session.set("MEmailId", response.EmailId);
                        $.session.set("PhoneNo", response.PhoneNumber);
                        $.session.set("IsResetPassword", response.IsResetPassword);
                        $.session.set("UserType", response.UserType);
                        $.session.set("RegisteredID", response.RegisteredID);
                        $.session.set("Department", response.Department);
                        if (response.IsResetPassword == "1")
                            window.location.href = "ChangePassword.html";
                        else if (response.UserType == "1")
                            window.location.href = "Pages/MyProfile.html";
                        else if (response.UserType == "2")
                            window.location.href = "Pages/MyProfile.html";
                        else
                            window.location.href = "Pages/Home.html";
                    }
                },
                error: function (xhr) {
                }
            });
        }
    });
    //End SignIn
});