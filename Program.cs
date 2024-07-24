// See https://aka.ms/new-console-template for more information

using HubspotDemoProject.Test;

#region Contact

// Get all contacts
await ContactServiceTests.TestGetAllContacts();

////Get contact by ID
//var contactid = 23074803442;
//await ContactServiceTests.TestGetContactById(contactid);

////Create a contact
//var newContact = new Contact
//{
//    Properties = new ContactProperties
//    {
//        FirstName = "*****",
//        LastName = "******",

//    }
//};
//await ContactServiceTests.TestCreateContact(newContact);

////Update contact
//var updatedcontactID = 23603652806;
//var updatedContact = new Contact
//{
//    Properties = new ContactProperties
//    {
//        FirstName = "*****",
//        LastName = "******",

//    }
//};
//await ContactServiceTests.TestUpdateContact(updatedcontactID, updatedContact);

////Delete a contact
//var contactID = 23074803442;
//await ContactServiceTests.TestDeleteContact(contactID);
#endregion
