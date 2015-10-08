
$(document).on('click', '.btn_deleterole', function () {
    var id = $(this).attr('id');
    var name = $(this).closest('tr').children().first().text();
    var rowtodelete = $(this).closest('tr');
    fnDeleteDialog(id, name, rowtodelete);
});

$(document).on('click', '#btn_menagerols', function () {
    $("#roleadministration_part").show();
});

$(document).on('click', '#btn_closeadminrolepart', function () {
    $("#roleadministration_part").hide();
});

$(document).ready(function () {
    var path = window.location.host;
    getallroles($("#tbl_listofroles > tbody"));

    $("#btn_createNewRole").click(function () {
        $("#addrole_part").show();
        $("#addroleforuser_part").hide();
        $("#listofroles_part").hide();
    });

    //show part for adding rol for user
    $("#btn_addroleforuser").click(function () {
        $("#addrole_part").hide();
        $("#addroleforuser_part").show();
        $("#listofroles_part").hide();
    });

    //cancel adding role
    $("#btn_canceladding").click(function () {
        $("#addrole_part").hide();
        $("#addroleforuser_part").hide();
        $("#listofroles_part").show();
    });

    //adding new role
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

    //search user email for which you like to add new role (using autocomlete)
    $("#txt_usersemailautocompl").autocomplete({
        source: '/Home/GetAllUsers',
        select: function(event, ui) {
            alert(ui.item.label);
        },
        minLength: 1,
        delay: 500
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
                strtoappend += "<tr>" +
                                    "<td>" + d[i].RoleName + "</td>" +
                                    "<td>" + "<button type='button' class='btn btn-primary btn_deleterole' id='"+ d[i].Id+"'>Delete</button>" + "</td>" +
                               "</tr>";
            }
            wheretoappent.html(strtoappend);
        },
        error: function (xhr, textStatus, errorThrown) {
            // TODO: Show error
        }
    });
}

function fnDeleteDialog(id, rolename, rowtodelete) {
    $("#dialog-confirm > p").empty()
                            .append("<span class='ui-icon ui-icon-alert' style='float: left; margin: 0 7px 20px 0;'></span>" +
                                    "<p>Are you sure that you want to delete this item? </p>" +
                                    "<span class='ui-icon ui-icon-minus' style='float: left; margin: 0 7px 20px 0;'></span>" +
                                    "Role Name: " +
                                    rolename);

    $("#dialog-confirm").dialog({
        resizable: false,
        modal: true,
        //title: "Modal",
        height: 200,
        width: 300,
        buttons: {
            "Yes": function () {
                $(this).dialog('close');
                callback(true, id, rowtodelete);
            },
            "No": function () {
                $(this).dialog('close');
                callback(false);
            }
        }
    });
}

function callback(value, modelToDelete, rowtodelete) {
    if (value) {
        //var baseurl = window.location.href;
        $.ajax({
            url: "/Home/DeleteRole/?modelToDelete=" + modelToDelete,
            type: "Post",
            success: function (data) {
                alert('Deleted Successfully');
                rowtodelete.remove();
                //window.location.href = "Index";
            },
            error: function (msg) { alert(msg); }
        });
    } else {
        alert("Rejected!");
    }
}