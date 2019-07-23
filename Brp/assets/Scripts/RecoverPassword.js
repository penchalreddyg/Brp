/*------------------------------------------------------------------
[SignIn Javascript]
Project: BIM Insights
Author: Connex Info Systems
Version:	1.0
Designed by: Chanikya Uppalapati
Author URI: http://connexinfo.com
------------------------------------------------------------------*/

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