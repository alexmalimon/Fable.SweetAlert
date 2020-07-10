namespace SweetAlert.Types

open Fable.Core

type ButtonClasses =
    | Class of string
    | Classes of string list

type ButtonSettings =
    { Visible: bool option
      Text: string option
      Value: obj option
      ClassName: ButtonClasses option
      CloseModal: bool option }
    static member Default =
        { Visible = Some true
          Text = None
          Value = None
          ClassName = None
          CloseModal = Some true }

type ComplexButtonOptions =
    | BooleanOption of bool
    | StringOption of string
    | ComplexOption of ButtonSettings

type ButtonItem =
    { Text: string
      Option: ComplexButtonOptions }

type StringOrBool =
    | StringType of string
    | BooleanType of bool

type ButtonTypes =
    | Boolean of bool
    | StringOrBoolList of StringOrBool list
    | ButtonsList of ButtonItem list

[<StringEnum>]
[<RequireQualifiedAccess>]
type SwalIcon =
    | [<CompiledName("error")>] Error
    | [<CompiledName("success")>] Success
    | [<CompiledName("warning")>] Warning
    | [<CompiledName("info")>] Information

type SwalOptions =
    { Title: string option
      Text: string option
      Icon: SwalIcon option
      ClassName: string option
      CloseOnClickOutside: bool option
      CloseOnEsc: bool option
      DangerMode: bool option
      Timer: int32 option
      Buttons: ButtonTypes option }
    static member Default =
        { Title = None
          Text = None
          Icon = None
          ClassName = None
          CloseOnClickOutside = None
          CloseOnEsc = None
          DangerMode = None
          Timer = None
          Buttons = Some(Boolean true) }
