var student = {
    valForm: (selector) => {
        $(selector).validate({
            rules: {
                name: {
                    required: true,
                    maxlength: 50,
                    minlength: 3
                },
                birthDate: {
                    required: true
                },
                sexFk: {
                    required: true
                },
                schoolFk: {
                    required: true
                },
                groupFk: {
                    required: true
                }
            },
            messages: {
                name: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Enter Name!`,
                    maxlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El máximo de caracteres es {0}!`),
                    minlength: jQuery.validator.format(`<i class="fa-solid fa-circle-xmark me-1"></i>¡El mínimo de caracteres son {0}!`)
                },
                birthDate: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Select Date!`
                },
                sexFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Select Gender!`
                },
                schoolFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Select School!`
                },
                groupFk: {
                    required: `<i class="fa-solid fa-circle-xmark me-1"></i>¡Select Group!`
                }
            }
        })
    },
    getStudents: () => {
        $.ajax({
            method: "GET",
            url: "../Student/GetAllDetails/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    var rows = "";

                    for (i = 0; i < data.detail.entities.length; i++) {
                        rows = rows.concat(`
                        <tr>
                            <td>
                                ${data.detail.entities[i].name}
                            </td>
                            <td>
                                ${data.detail.entities[i].birthDate.slice(0, 10)}
                            </td>
                            <td>
                                ${data.detail.entities[i].sexName}
                            </td> 
                            <td>
                                ${data.detail.entities[i].groupName}
                            </td>  
                            <td>
					                <a href="javascript:void(0)" onclick="student.editModal(${data.detail.entities[i].id});"><i class="fa-solid icon fa-pen-to-square"></i></a> |
                                    <a href="javascript:void(0)" onclick="student.deleteModal(${data.detail.entities[i].id});"><i class="fa-regular icon fa-trash-can"></i></a>
				            </td>
                        </tr>
                        `)
                        $("#students").html(rows);
                    }
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getSex: () => {
        $.ajax({
            method: "GET",
            url: "../Sex/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#createSex").append(`<option value="">--Select--</option>`);
                    for (var i = 0; i < data.detail.entities.length; i++) {
                        $("#createSex").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getSchool: () => {
        $.ajax({
            method: "GET",
            url: "../School/GetAll/",
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    $("#createSchoolFk").append(`<option value="">--Select--</option>`);
                    for (var i = 0; i < data.detail.entities.length; i++) {
                        $("#createSchoolFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                    }
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    getGroupBySchoolId: () => {
        $("#createGroupFk").empty();

        if ($("#createSchoolFk").val() !== "") {
            $("#createGroupFk").prop("disabled", false);
            $("#createGroupFk").append(`<option value="">--Select--</option>`);
        } else {
            $("#createGroupFk").prop("disabled", true);
        }

        var schoolFk = $("#createSchoolFk").val();
        $.ajax({
            method: "GET",
            url: `../Group/GetBySchoolId?schoolId=${schoolFk}`,
            type: "JSON",
            data: {}
        })
            .done((data) => {
                if (data.success == 1) {
                    console.log(data);
                    for (var i = 0; i < data.detail.entities.length; i++) {
                        $("#createGroupFk").append(`<option value="${data.detail.entities[i].id}">${data.detail.entities[i].name}</option>`);
                    }
                } else {
                    alert(data.detail.error);
                }
            })
            .fail((jqHR, textStatus, errorThrow) => {
                alert(errorThrow);
            })
    },
    maxBirthDate: () => {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }

        today = yyyy + '-' + mm + '-' + dd;
        document.getElementById("createBirthDate").setAttribute("max", today);
    },
    createModal: () => {
        $("#createModal").modal("show");
        $("#createGroupFk").prop("disabled", true);
    },
    closeCreateModal: () => {
        $("#createModal").modal("hide");
        $("#createName, #createBirthDate, #createSex, #createSchoolFk").val("");
        $("#createGroupFk").empty();
        $("#createName-error, #createBirthDate-error, #createSex-error, #createSchoolFk-error,#createSchoolFk-error, #createGroupFk-error").remove();
    },
    save: () => {
        if ($("#createForm").valid()) {
            var name = $("#createName").val();
            var birthDate = $("#createBirthDate").val();
            var sexFk = $("#createSex").val();
            var groupFk = $("#createGroupFk").val();

            $.ajax({
                method: "POST",
                url: "../Student/Add/",
                type: "POST",
                data: {
                    name: name,
                    birthDate: birthDate,
                    sexFk: sexFk,
                    groupFk: groupFk
                }
            })
                .done((data) => {
                    if (data.success == 1) {
                        alert(data.detail.message);
                        student.closeCreateModal();
                        student.getStudents();
                    }
                })
                .fail((jqHR, textStatus, errorThrow) => {
                    alert(errorThrow);
                })
        }
    }
}