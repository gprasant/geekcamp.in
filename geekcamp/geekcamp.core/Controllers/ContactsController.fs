namespace geekcamp.core.Controllers

open System.Collections.Generic
open System.Web
open System.Web.Mvc
open System.Net.Http
open System.Web.Http
open geekcamp.core.Models

type ContactsController() =
    inherit ApiController()

    // GET /api/contacts
    member x.Get() = 
        ContactRepository.readAll()
    // POST /api/contacts
    member x.Post ([<FromBody>] contact:Contact) = 
        ContactRepository.create(contact)