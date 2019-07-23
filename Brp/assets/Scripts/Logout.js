/*------------------------------------------------------------------
[Logout Javascript]
Project: BIM Insights
Author: Connex Info Systems
Version:	1.0
Designed by: Chanikya Uppalapati
Author URI: http://connexinfo.com
------------------------------------------------------------------*/

$(document).ready(function () {

    $.session.clear();
    window.location = "Login";
});