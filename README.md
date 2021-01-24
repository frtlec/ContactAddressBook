<h2>What is ContactAdrressBook?</h2>

<p>It is a web service for keeping your contacts and contact information in a database and you can report your data</p>

<h4>What technologies are required to use ContactAddressBook services?</h4>
<ul><li>Microsoft Sql Server for database</li>
<li>Redis Server for caching</li></ul>

<h4>Usage</h4>
<pre style='background:#ff77'>for all /api</pre>
<span>Creating a contact in the address book:</span>
       <pre>[POST] /persons/add</pre>
       <pre>
         Request body 
                   personFirstName:string[50],
                   personLastName:string[50],
                   personCompany:string[50],
                   ContactInfos:[ContactInfos{
                                        phoneNumber:string[12],
                                        email:string[50],
                                        city:string[99]
                                      }]
       </pre>
       <pre>
              Response 
              Success Message/Error Message/Validation Message
       </pre>
       <span>  Removing a contact in the address book</span>
      <pre>
         [POST] /persons/remove
           Request body 
                     personId:int,
                     personLastName?:string,
                     personCompany?:string,
           Response 
           Success Message/Error Message
        </pre>
      <span>Updating contacts in the address book</span>
<pre>
       [POST] /persons/update
         Request body 
                   personId:int,
                   personFirstName?:string[50],
                   personLastName?:string[50],
                   personCompany?:string[50]
         Response
           Success Message/Error Message
           </pre>
 Listing the contacts in the address book  
 <pre>   [GET] /persons/getall
         Request  Params 
             does not take parameter
         Reponse Params
                personId:int,
                personFirstName:string,
                personLastName:string,
                personCompany:string,
                personCreatedDate:datetime,
                personLastUpdateDate:datetime
                ContactInfos:array<ContactInfos></pre>
 
 Bringing the contact and detailed information about a person in the address book      
 <pre>    [GET] /persons/getbyid/{personId}
         Request Params 
             personId:int
         Reponse body
                personId:int,
                personFirstName:string,
                personLastName:string,
                personCompany:string,
                personCreatedDate:datetime,
                personLastUpdateDate:datetime
                ContactInfos:array<ContactInfos></pre>
       
  Adding contact information in the address book
   
   <pre>   [POST] /contactinfos/add
         Request body 
                   personId:int,
                   phoneNumber:string[12],
                   email:string[50],
                   city?:string[99]
         Response
           Success Message/Error Message</pre>
       
  Removing the contact information from a contact
  <pre>  [GET] /contactinfos/removeall/{personId}
         Request Params 
             personId:int
        Response
        Success Message/Error Message</pre>
            
   Requesting a report which shows the statistics according to the location of people in the address book.      
       
       
       
      
       [GET] /reports/getstatisticreportbylocation
         Request  Params 
             does not take parameter
         Reponse Params
                counterPersonByCityDto:[{numberOfPerson:int,cityName:string}]
                counterPhoneNumberByCityDto:[{counterPhoneNumber:int,cityName:string}]
