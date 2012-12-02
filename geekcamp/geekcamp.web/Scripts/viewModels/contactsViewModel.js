// This is largely based on the example from http://knockoutjs.com/examples/contactsEditor.html
(function ( viewModel, $ ) {
    viewModel.ContactsViewModel = function ( contacts ) {
        var self = this;
        self.contacts = ko.observableArray( ko.utils.arrayMap( contacts, function ( contact ) {
            return { name: contact.name, email: contact.email, phone: contact.phone, organization: contact.organization };
        }));

        self.addContact = function () {
            var data = geekcamp.utility.serializeObject( $("#contactForm") );
            $.ajax({
                url: "/api/Contacts",
                data: JSON.stringify( data ),
                type: "POST",
                dataType: "json",
                contentType: "application/json"
            })
            .done(function () {
                toastr.success( "You have successfully created a new contact!", "Success!" );
                self.contacts.push( data );
                window.location.href = "#/";
            })
            .fail(function () {
                toastr.error( "There was an error creating your new contact", "<sad face>" );
            });
        };
    };
})( geekcamp.ViewModels = geekcamp.ViewModels || {}, jQuery );