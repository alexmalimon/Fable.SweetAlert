namespace SweetAlert

[<RequireQualifiedAccess>]
module Swal =

    open SweetAlert.Types

    open Fable.Core
    open Fable.Core.JS
    open Fable.Core.JsInterop

    let private mapButtonOption (option: ButtonItem) =
        match option.Option with
        | BooleanOption boolVal -> option.Text ==> boolVal
        | StringOption strVal -> option.Text ==> strVal
        | ComplexOption complexVal -> option.Text ==> toPlainJsObj complexVal

    let private mapComplexButtons (complexButtonOptions: ButtonItem list): obj =
        complexButtonOptions
        |> List.map mapButtonOption
        |> createObj

    let private mapButtons (buttons: ButtonTypes) =
        match buttons with
        | Boolean boolean -> boolean |> U3.Case1
        | StringOrBoolList stringOrBoolList ->
            stringOrBoolList
            |> List.map (fun value ->
                match value with
                | StringType stringVal -> stringVal |> U2.Case1
                | BooleanType boolVal -> boolVal |> U2.Case2)
            |> List.toArray
            |> U3.Case2
        | ButtonsList complexOptions ->
            !!(complexOptions |> mapComplexButtons)
            |> U3.Case3

    let private mapToBaseOptions (options: SwalOptions) =
        {| title = options.Title
           text = options.Text
           icon = options.Icon
           className = options.ClassName
           closeOnClickOutside = options.CloseOnClickOutside
           closeOnEsc = options.CloseOnEsc
           dangerMode = options.DangerMode
           timer = options.Timer
           buttons = options.Buttons |> Option.map mapButtons |}

    [<Import("default", "sweetalert")>]
    let private swal'<'resp> (_: obj): Promise<'resp option> = jsNative

    let swal<'resp> (options: SwalOptions): Promise<'resp option> =
        options
        |> mapToBaseOptions
        |> toPlainJsObj
        |> swal'
