//------------------------------------------------- Intervention -----------------------------------------------------------\\
function GetDataCustomer(customer) {

    $(document).ready(function () {        

        var id = "";
        // Calls the function to hide the fields
        hideAll();

        // When there is a change in the customer field, execute the function  
        let buildings = customer.buildings;
        let select = [new Option("--- Select ---", "")]; // Instantiates a new Option type object, first line shown in the dropdown
        buildings.forEach((element) => {  // A forEach to add the new Options object, with the data returned in ajax.
            select.push(new Option(`Building #${element.id}`, element.id));
        });
        $("#building-select").html(select);

        

        $("#building-select").on('change', function () {

            id = $(this).val();

            if (id === "") {

                hideAll(); // Ensures that other fields are hidden if you change the customer field back to the initial position.

            } else {
                $("#battery").show();

                let batteries = customer.buildings.find(building => building.id == (this.value)).batteries;
                console.log(batteries);

                let select = [new Option("--- Select ---", "")]; // Instantiates a new Option type object, first line shown in the dropdown
                batteries.forEach((element) => {  // A forEach to add the new Options object, with the data returned in ajax.
                    select.push(new Option(`Battery #${element.id}`, element.id));
                });
                $("#battery-select").html(select);
            }
        });


        $("#battery-select").on('change', function () {

            id = $(this).val();

            if (id === "") {

                hideAll(); // Ensures that other fields are hidden if you change the customer field back to the initial position.

            } else {
                $("#column").show();

                let building_id = $('#building-select option:selected').val();

                var battery = customer
                    .buildings.find(building => building.id == building_id)
                    .batteries.find(battery => battery.id == this.value);

                let columns = battery.columns;

                let select = [new Option("--- Select ---", "")]; // Instantiates a new Option type object, first line shown in the dropdown
                columns.forEach((element) => {  // A forEach to add the new Options object, with the data returned in ajax.
                    select.push(new Option(`Column #${element.id}`, element.id));
                });
                $("#column-select").html(select);
            }
        });

        $("#column-select").on('change', function () {

            id = $(this).val();

            if (id === "") {

                hideAll(); // Ensures that other fields are hidden if you change the customer field back to the initial position.

            } else {
                $("#elevator").show();

                let building_id = $('#building-select option:selected').val();
                let battery_id = $('#battery-select option:selected').val();

                column = customer
                    .buildings.find(building => building.id == building_id)
                    .batteries.find(battery => battery.id == battery_id)
                    .columns.find(column => column.id == this.value);

                let elevators = column.elevators;

                let select = [new Option("--- Select ---", "")]; // Instantiates a new Option type object, first line shown in the dropdown
                elevators.forEach((element) => {  // A forEach to add the new Options object, with the data returned in ajax.
                    select.push(new Option(`Elevator #${element.id}`, element.id));
                });
                $("#elevator-select").html(select);
            }
        });

        // functions hiding    
        function hideAll() {
            $("#battery").hide();
            hideColumn();
        }

        function hideColumn() {
            $("#column").hide();
            hideElevator();
        }

        function hideElevator() {
            $("#elevator").hide();
        }
    });
}

//------------------------------------------------ Create Intervention ----------------------------------------------------\\

function createIntervention() {

    var data = {
        customer_id: $('#customer_id').val() == "" ? null : $('#customer_id').val(),
        author: $('#customer_id').val() == "" ? null : $('#customer_id').val(),
        building_id: $('#building-select').val() == "" ? null : $('#building-select').val(),
        battery_id: $('#battery-select').val() == "" ? null : $('#battery-select').val(),
        column_id: $('#column-select').val() == "" ? null : $('#column-select').val(),
        elevator_id: $('#elevator-select').val() == "" ? null : $('#elevator-select').val(),
        report: $('#description').val() == "" ? null : $('#description').val()
    };

    $.ajax({
        url: 'https://rocket-elevators.azurewebsites.net/api/Interventions',
        type: 'POST',
        data: JSON.stringify(data),
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "HEAD, GET, POST, PUT, PATCH, DELETE",
            "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With",
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (result) {
            alert('Intervention created successfully!');
            $('.pointer').prop('selected', function () {
                this.value = "";
                $("#battery").hide();
                $("#column").hide();
                $("#elevator").hide();
            });
            $('#description').val("");
            return false;
        }
    });
    return false;
}

//---------------------------------------------- InterventionViaProduct ------------------------------------------------------\\

function Intervention_Product(buildingId, batteryId, columnId, elevatorId, customer) {

    $(document).ready(function () {

        if (buildingId) {
            let select = [new Option(`Building #${buildingId}`, buildingId)];
            $("#building-select").html(select);
            hideAll();
        }

        // ------------ Fill the form with data after choose a battery ---------------- //
        if (batteryId) {

            for (b of customer.buildings) {
                for (bat of b.batteries) {
                    if (bat.id == batteryId) {
                        building = b;
                        battery = bat;
                        break;
                    }                    
                }
            }

            let select = [new Option(`Building #${building.id}`, building.id)];
            $("#building-select").html(select);

            let selectBat = [new Option(`Battery #${battery.id}`, battery.id)];
            $("#battery-select").html(selectBat);
            hideColumn();
        }

        // ------------ Fill the form with data after choose a column ---------------- //
        if (columnId) {
            let building;
            let battery;
            let column;

            for (b of customer.buildings) {
                for (bat of b.batteries) {
                    for (c of bat.columns) {
                        if (c.id == columnId) {
                            building = b;
                            battery = bat;
                            column = c;
                            break;
                        }
                    }
                }
            }

            let select = [new Option(`Building #${building.id}`, building.id)];
            $("#building-select").html(select);

            let selectBat = [new Option(`Battery #${battery.id}`, battery.id)];
            $("#battery-select").html(selectBat);

            let selectCol = [new Option(`Column #${column.id}`, column.id)];
            $("#column-select").html(selectCol);

            hideElevator();

        }

        // ------------ Fill the form with data after choose an elevator ---------------- //
        if (elevatorId) {
            let building;
            let battery;
            let column;
            let elevator;

            for (bld of customer.buildings) {
                for (batt of bld.batteries) {
                    for (col of batt.columns) {
                        for (elv of col.elevators) {
                            if (elv.id == elevatorId) {
                                building = bld;
                                battery = batt;
                                column = col;
                                elevator = elv;
                                break;
                            }
                        }
                    }
                }
            }

            let select = [new Option(`Building #${building.id}`, building.id)];
            $("#building-select").html(select);

            let selectBat = [new Option(`Battery #${battery.id}`, battery.id)];
            $("#battery-select").html(selectBat);

            let selectCol = [new Option(`Column #${column.id}`, column.id)];
            $("#column-select").html(selectCol);

            let selectElev = [new Option(`Elevator #${elevator.id}`, elevator.id)];
            $("#elevator-select").html(selectElev);
        }
    });

    // functions hiding    
    function hideAll() {
        $("#battery").hide();
        hideColumn();
    }

    function hideColumn() {
        $("#column").hide();
        hideElevator();
    }

    function hideElevator() {
        $("#elevator").hide();
    }
}