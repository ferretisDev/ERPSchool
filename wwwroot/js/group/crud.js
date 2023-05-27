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
    editModal: () => {

    }
}