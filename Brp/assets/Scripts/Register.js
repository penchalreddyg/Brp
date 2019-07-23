/*------------------------------------------------------------------
[SignIn Javascript]
Project:	SVCE
Author: Connex Info Systems
Version:	1.0
Designed by: Chanikya Uppalapati
Author URI: http://connexinfo.com
-------------------------------------------------------------------*/

$(document).ready(function () {
    //Start SignIn
    $("#btnRegister").click(function () {
        $("#Form-Register").validate({
            errorClass: "help-block animation-fadeInQuickInv",
            errorElement: "div",
            errorPlacement: function (e, r) {
                r.parents(".form-group").append(e)
            }, highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success has-error").addClass("has-error"), $(e).closest(".help-block").remove()
            }, success: function (e) {
                e.closest(".form-group").removeClass("has-success has-error"), e.closest(".help-block").remove()
            }, rules: {
                "txtName": { required: !0 }, "txtEmail": { required: !0, email: !0 }, "txtPhone": { required: !0}, "txtPassword": { required: !0, minlength: 5 }
            }, messages: {
                //"txtEmail": "Please enter username",
                "txtName": { required: "Please enter name"},
                "txtEmail": { required: "Please enter username/email", email: "Please enter valid username/email" },
                "txtPhone": { required: "Please enter phone"},
                "txtPassword": { required: "Please enter password", minlength: "Your password must be at least 5 characters" }
            }
        })
        var form = $("#Form-Register");
        var name = $("#txtName").val();
        var email = $("#txtEmail").val();
        var phone = $("#txtPhone").val();
        var password = $("#txtPassword").val();
        if (form.valid()) {
            var loginRequest = { Name: name, EmailId: email, PhoneNO: phone, Password: password };
            $.ajax({
                type: "POST",
                url: service + "UserRegister",
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