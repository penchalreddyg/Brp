/*------------------------------------------------------------------
[SignIn Javascript]
Project:	SVCE
Author: i2speed.in, i2speed.com, I2Speed Technologies LLP
Version:	1.0
Design and Developed by: i2speed.in, i2speed.com
Author URI: http://i2speed.in , http://i2speed.com
-------------------------------------------------------------------*/

$(document).ready(function () {
    //Start Forgot Password
    $("#btnForgotPassword").click(function () {
        $("#Form-ForgotPassword").validate({
            errorClass: "help-block animation-fadeInQuickInv", errorElement: "div", errorPlacement: function (e, r) {
                r.parents(".form-group").append(e)
            }, highlight: function (e) {
                $(e).closest(".form-group").removeClass("has-success has-error").addClass("has-error"), $(e).closest(".help-block").remove()
            }, success: function (e) {
                e.closest(".form-group").removeClass("has-success has-error"), e.closest(".help-block").remove()
            }, rules: {
                "txtfgEmail": { required: !0, email: !0 }
            }, messages: {
                "txtfgEmail":
                    {
                        required: "Please enter email address",
                        email: "Please enter a valid email address"
                    }
            }
        })
        var form = $("#Form-ForgotPassword");
        var fgemail = $("#txtfgEmail").val();
        if (form.valid()) {
            var forgotRequest = { EmailId: fgemail };
            $.ajax({
                type: "POST",
                url: service + "ForgotPassword",
                data: JSON.stringify({ request: forgotRequest }),
                contentType: "application/json",
                dataType: "json",
                success: function (data) {
                    var response = data.ForgotPasswordResult;
                    if (response.StatusCode == "-555") {
                        $("#error").show();
                        $("#error").addClass("alert-danger");
                        $("#errormessage").text('Invalid Email Id');
                        setTimeout(function () {
                            $("#error").fadeOut('slow');
                            $("#error").removeClass("alert-danger");
                        }, 5000);
                    }

                },
                error: function (xhr) {
                }
            });
        }
    });
    //End Forgot Password
});