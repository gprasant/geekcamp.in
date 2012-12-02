namespace geekcamp.core.Models

type Contact() =
    let mutable id = 0
    let mutable name = ""
    let mutable phone = ""
    let mutable email = ""
    let mutable organization = ""
    let mutable contactType = 0
    member x.Name with get() = name and set v = name <- v
    member x.Phone with get() = phone and set v = phone <- v
    member x.Email with get() = email and set v = email <- v
    member x.Organization with get() = organization and set v = organization <- v
    member x.ContactType with get() = contactType and set v = contactType <- v
    member x.Id with get() = id and set v = id <- v