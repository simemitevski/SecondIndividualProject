$(document).ready(function () {
    var path = window.location.host;
    getallroles($("#tbl_listofroles > tbody"));

    $("#createNewRole").click(function () {
        $("#addrole_part").show();
        $("#listofroles_part").hide();
    });

    $("#btn_canceladding").click(function () {
        $("#addrole_part").hide();
        $("#listofroles_part").show();
    });

    $("#btn_addrole").click(function () {
        if ($('#txt_rolename').val().trim() === "") {
            alert('Enter role name before submitting!!');
        } else {
            var role = {
                RoleName: $('#txt_rolename').val().trim()
            };

            $.ajax({
                type: "POST",
                url: "/Home/AddNewRole",
                content: "application/json; charset=utf-8",
                dataType: "json",
                data: role,
                success: function(d) {
                    if (d == "OK")
                        getallroles($("#tbl_listofroles > tbody"));
                },
                error: function(xhr, textStatus, errorThrown) {
                    // TODO: Show error
                }
            });

            $("#addrole_part").hide();
            $("#listofroles_part").show();
        }
    });
});

function getallroles(wheretoappent) {
    var strtoappend;
    var path = window.location.host;
    wheretoappent.empty();
    $.ajax({
        type: "GET",
        url: "/Home/GetAllRoles",
        content: "application/json; charset=utf-8",
        dataType: "json",
        success: function (d) {
            var i;
            for (i = 0; i < d.length; i++) {
                var obj = {
                    Id: d[i].Id,
                    RoleName: d[i].RoleName
                }
                strtoappend += "<tr>" +
                                    "<td>" + d[i].RoleName + "</td>" +
                                    "<td>" + "<button type='button' class='btn btn-primary' onclick='DeleteRole(" + obj +")'>Delete</button>" + "</td>" +
                               "</tr>";
            }
            wheretoappent.html(strtoappend);
        },
        error: function (xhr, textStatus, errorThrown) {
            // TODO: Show error
        }
    });
}

function DeleteRole(modelToDelete) {
    $.ajax({
        type: "POST",
        url: '/Home/DeleteRole',
        dataType: "json", 
        contentType: 'application/json; charset=utf-8',
        data: modelToDelete,
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            //alert(data);
            $(function () {
                $("#dialog-confirm").dialog({
                    resizable: false,
                    height: 140,
                    modal: true,
                    buttons: {
                        "Yes delete this item": function () {
                            $(this).dialog("close");
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    }
                });
            });
        },
        error: function (xhr) {
            alert('error');
        }
    });
}