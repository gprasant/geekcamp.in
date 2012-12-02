namespace geekcamp.core.Models

module ContactRepository =

    open Raven.Client.Document
    open geekcamp.core.Models
    open Raven.Client.Linq

    let newSession =
        let store = new DocumentStore()
        store.Url <- "http://localhost:8080/"
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

