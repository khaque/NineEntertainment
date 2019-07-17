$(document).ready(function () {
    GenerateTable();
});

function GenerateTable() {
    // empty thead & tbody, just in case, to avoid data duplication
    $('#raceTable thead, #raceTable tbody').html('');

    // show loading animation
    showLoadingAnimation();

    var opt = GetSelectedRace();
    GetTableHeader();
    GetTableBody(opt);
}

function GetSelectedRace() {
    var opt = $('#raceSelect').val();
    return opt;
}

function GetTableHeader() {
    var html = `<tr>
        <th>Name</th>
        <th>Age</th>
        <th>Height</th>
    </tr>`;
    $('#raceTable thead').append(html);
}

function GetTableBody(race) {
    var url = `/api/GetPersonListByRace/${race}`;
    $.get(url, function (data) {
        var tblBody = $("#raceTable tbody");

        $.each(data, function (index, item) {
            var html = `<tr>
                <td> ${item.Name} </td>
                <td> ${item.Age} </td>
                <td> ${item.Height} </td>
            </tr>`;

            tblBody.append(html);
        });
        removeLoadingAnimation();
        $('#raceTable').DataTable().order([2, 'asc']);
        $('#raceTable').DataTable().page.len(10).draw();
    });
}

function SelectRace(race) {
    $('#raceSelect').val(race);
    GenerateTable();
}

function showLoadingAnimation() {
    var html = `<tr class="loader">
        <td colspan="3"> Loading ... </td>
    </tr>`;
    $('#raceTable tbody').append(html);
}

function removeLoadingAnimation() {
    $('.loader').remove();
}