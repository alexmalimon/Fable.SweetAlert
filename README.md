# Fable.SweetAlert 

[SweetAlert](https://sweetalert.js.org/) integration with Fable, made with :heart:

## Installation (manual)
- Install this library from nuget
```
paket add Fable.SweetAlert --project /path/to/Project.fsproj
```
- Install sweetalert from npm (version 2.x)
```
npm install sweetalert 2.1.2 --save
yarn add sweetalert@2.1.2
```
### Code Sample
This is an example of simple `Swal` alert.

```fs
let options =
    { SwalOptions.Default with
        Title = Some "Good job!"
        Text = Some "You clicked the button!"
        Icon = Some SwalIcon.Success }

Swal.swal options
```