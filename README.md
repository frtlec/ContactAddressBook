What is ContactAdrressBook?

It is a web service for keeping your contacts and contact information in a database and you can report your data
########################
########################
########################
########################
What technologies are required to use Contact Address Book services?
Microsoft Sql Server for database
Redis Server for caching
#######################################################################
for all /api
   Creating a contact in the address book:
       [POST] /persons/add
         Request body 
                   personFirstName:string[50],
                   personLastName:string[50],
                   personCompany:string[50],
                   ContactInfos:array<ContactInfos{
                                                    phoneNumber:string[12],
                                                    email:string[50],
                                                    city:string[99]
                                                   }>
          Response 
              Success Message/Error Message/Validation Message                
  Removing a contact in the address book
      [POST] /persons/remove
         Request body 
                   personId:int,
                   personLastName?:string,
                   personCompany?:string,

         Response 
          Success Message/Error Message
  Updating contacts in the address book
       [POST] /persons/update
         Request body 
                   personId:int,
                   personFirstName?:string[50],
                   personLastName?:string[50],
                   personCompany?:string[50]
         Response
           Success Message/Error Message
       
 Listing the contacts in the address book  
      [GET] /persons/getall
         Request  Params 
             does not take parameter
         Reponse Params
                personId:int,
                personFirstName:string,
                personLastName:string,
                personCompany:string,
                personCreatedDate:datetime,
                personLastUpdateDate:datetime
                ContactInfos:array<ContactInfos>
 
 Bringing the contact and detailed information about a person in the address book      
          [GET] /persons/getbyid/{personId}
         Request Params 
             personId:int
         Reponse body
                personId:int,
                personFirstName:string,
                personLastName:string,
                personCompany:string,
                personCreatedDate:datetime,
                personLastUpdateDate:datetime
                ContactInfos:array<ContactInfos>
       
  Adding contact information in the address book
   
        [POST] /contactinfos/add
         Request body 
                   personId:int,
                   phoneNumber:string[12],
                   email:string[50],
                   city?:string[99]
         Response
           Success Message/Error Message
        
 Removing the contact information from a contact  
          [GET] /contactinfos/removeall/{personId}
         Request Params 
             personId:int
        Response
            Success Message/Error Message
       
       
       
       
       
       
       
       
       
       
       
