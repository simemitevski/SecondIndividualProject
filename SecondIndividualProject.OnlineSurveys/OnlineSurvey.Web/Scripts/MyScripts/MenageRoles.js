$(document).ready(function () {

    getallroles($("#tbl_listofroles > tbody"));

    $("#createNewRole").click(function() {
        $("#addrole_part").show();
        $("#listofroles_part").hide();
    });

    $("#btn_addrole").click(function () {
        var role = {
            RoleName: $('#txt_rolename').val().trim()
        };

        $.ajax({
            type: "POST",
            url: "Home/AddNewRole",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: role,
            success: function (d) {
                if (d == "OK")
                    getallroles($("#tbl_listofroles > tbody"));
            },
            error: function (xhr, textStatus, errorThrown) {
                // TODO: Show error
            }
        });

        $("#addrole_part").hide();
        $("#listofroles_part").show();
    });
});

function getallroles(wheretoappent) {
    var strtoappend;
    wheretoappent.empty();
    $.ajax({
        type: "GET",
        url: "Home/GetAllRoles",
        content: "application/json; charset=utf-8",
        dataType: "json",
        success: function (d) {
            if (d.success == true)
                for (var i = 0; i < d.length; i++) {
                    strtoappend += "<tr>" + "<td>" + d[i].RoleName + "</td>" + "<td>" + "</td>" + "</tr>";
                }
            wheretoappent.html(strtoappend);
        },
        error: function (xhr, textStatus, errorThrown) {
            // TODO: Show error
        }
    });
}