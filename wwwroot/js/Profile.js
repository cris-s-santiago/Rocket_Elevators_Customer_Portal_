function UpdateCustomer() {

    var data = {
        company_name: $('#company_name').val(),
        full_name_of_company_contact: $('#full_name_of_company_contact').val(),
        company_contact_phone: $('#company_contact_phone').val(),
        email_of_company_contact: $('#email_of_company_contact').val(),
        company_description: $('#company_description').val(),
        full_name_of_service_technical_authority: $('#full_name_of_service_technical_authority').val(),
        technical_authority_phone_for_service_: $('#technical_authority_phone_for_service_').val(),
        technical_manager_email_for_service: $('#technical_manager_email_for_service').val()
    };

    $.ajax({
        url: 'https://rocket-elevators.azurewebsites.net/api/Customers',
        type: 'PUT',
        data: JSON.stringify(data),
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "HEAD, GET, POST, PUT, PATCH, DELETE",
            "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With",
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (result) {
            alert('Customer updated successfully!');
            return false;
        }
    });

    return false;

}