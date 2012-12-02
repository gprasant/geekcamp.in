namespace geekcamp.core.Models

module ContactRepository =

    open Raven.Client.Document
    open geekcamp.core.Models
    open Raven.Client.Linq
    open System.Configuration

    let newSession =
        let store = new DocumentStore() 
        store.Url <- "https://ec2-eu1.cloudbird.net/Databases/6ecd2066-08c9-4600-9c2b-90593977d91e.geekcamp.in"
        store.ApiKey <- "ce150dde-6a06-4496-904d-5113d68ef8aa" 
        store.Initialize() |> ignore
        store.OpenSession()

    let create(contact: Contact) = 
        use session = newSession
        session.Store(contact)
        session.SaveChanges()

    let read(contactId: int) = 
        use session = newSession
        session.Load<Contact>(contactId)

    let readAll() = 
        use session = newSession
        let aRead = session.Query<Contact>()
        List.ofSeq aRead

