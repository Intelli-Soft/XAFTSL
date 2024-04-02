
# XAFTSL
Welcome to XAFTSL => XAF Type Safe Localization

This software can help to create a type safe way for using custom string localization in DevExpress XAF.

When you have to work with "CaptionHelper.GetLocalizedText" method, this is for you!

The DevExpress documentation for this: https://docs.devexpress.com/eXpressAppFramework/112655/localization/how-to-localize-custom-string-constants

This software is based on my other repository:
https://github.com/Intelli-Soft/XAFCodeGenCustomLocalization

The big difference is, that with the other repository you have a WinForms UI to easy generate the code.
This software comes without UI and is fully .NET 8.0 supported.


## Usage

```cmd
XAFSTL.exe [options]

 /?               - Show the help screen.
 /n:namespace     - Namespace of the generated code.
 /d:destination    - Filename of the generated code.
 /x:xafml file     - Filename of the xafml file.
 /l:language       - Language of the generated code.     Possible values: 'C', 'VB'
 /t:textoptions    - Text options of the generated code. Possible values: 'None', 'FirstToUpper', 'ToLower', 'ToUpper'
 /f:framework      - Framework of the generated code.    Possible values: 'DotNetFive', 'DotNetSixPlus'

All of the above arguments are needed to execute the application correctly.
Optional arguments:

 /pre:prefix       - Prefix of the generated code.
 /post:suffix      - Suffix of the generated code.
```


## Authors

- [@Intell!Soft](https://www.github.com/Intelli-Soft)


## License

[MIT](https://choosealicense.com/licenses/mit/)






