/*------------------------------------------------------------------
[Logout Javascript]
Project:	SVCE
Author: i2speed.in, i2speed.com, I2Speed Technologies LLP
Version:	1.0
Design and Developed by: i2speed.in, i2speed.com
Author URI: http://i2speed.in , http://i2speed.com
-------------------------------------------------------------------*/

$(document).ready(function () {

    $.session.clear();
    window.location = "Login.html";
});