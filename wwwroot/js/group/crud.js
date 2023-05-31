var group = {
    getSchools: () => {
        $.ajax({
            method: "GET",
            url: "../School/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#createSchoolFk").append(`<option value="">--Seleccione--</option>`);
                    for (var i = 0; i < data.detail.entities.length; i++) {
                        $("#createSchoolFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getSchoolsForUpdate: () => {
        $.ajax({
            method: "GET",
            url: "../School/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    //$("#editSchoolFk").append(`<option value="">--Seleccione--</option>`);
                    for (var i = 0; i < data.detail.entities.length; i++) {
                        $("#editSchoolFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                    }
                } else {

                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getGroups: () => {
        $.ajax({
            method: "GET",
            url: "../Group/GetAllDetails/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    console.log
                    var rows = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        rows = rows.concat(`
                        <tr>
                            <td>
                                ${data.detail.entities[i].name}
                            </td>
                            <td>
                                ${data.detail.entities[i].maxStudents}
                            </td>
                            <td>
                                ${data.detail.entities[i].schoolName}
                            </td>             
                            <td>
					                <a href="javascript:void(0)" onclick="group.editModal(${data.detail.entities[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                    <a href="javascript:void(0)" onclick="group.deleteModal(${data.detail.entities[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
				            </td>
                        </tr>
                        `)
                        $("#groups").html(rows);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    createModal: () => {
        $("#createModal").modal("show");
    },
    closeCreateModal: () => {
        $("#createModal").modal("hide");
        $("#createName, #createMaxStudents, #createSchoolFk").val("");
    },
    save: () => {
        $.ajax({
            method: "POST",
            url: "../Group/Add/",
            type: "JSON",
            data: {
                name: $("#createName").val(),
                maxStudents: $("#createMaxStudents").val(),
                schoolFk: $("#createSchoolFk").val()
            }
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#createModal").modal("hide");
                    $("#createName, #createMaxStudents, #createSchoolFk").val("");
                    alert(data.detail.message);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    editModal: (id) => {
        $.ajax({
            method: "GET",
            url: `../Group/GetById?id=${id}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#editModal").modal("show");
                    $("#editId").val(data.detail.entity.id);
                    $("#editName").val(data.detail.entity.name);
                    $("#editMaxStudents").val(data.detail.entity.maxStudents);
                    $("#editSchoolFk").val(data.detail.entity.schoolFk);
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    closeEditModal: () => {
        $("#editModal").modal("hide");
    },
    update: () => {
        var id = $("#editId").val();
        var name = $("#editName").val();
        var maxStudents = $("#editMaxStudents").val();
        var schoolFk = $("#editSchoolFk").val();

        $.ajax({
            method: "PATCH",
            url: "../Group/Update/",
            type: "JSON",
            data: {
                id: id,
                name: name,
                maxStudents: maxStudents,
                schoolFk: schoolFk
            }
        })
            .done((data) => {
                if (data.success == 1) {
                    alert(data.detail.message);
                    $("#editModal").modal("hide");
                    group.getGroups();
                }
                else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    }
}