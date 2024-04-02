
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

 _/?_               - Show the help screen.
 _/n:namespace_     - Namespace of the generated code.

_/d:destination_   - Filename of the generated code.

_/x:xafml file_    - Filename of the xafml file.

_/l:language_      - Language of the generated code.     Possible values: 'C', 'VB'

_/t:textoptions_   - Text options of the generated code. Possible values: 'None', 'FirstToUpper', 'ToLower', 'ToUpper'

_/f:framework_     - Framework of the generated code.    Possible values: 'DotNetFive', 'DotNetSixPlus'

All of the above arguments are needed to execute the application correctly.

Optional arguments:

_/pre:prefix_      - Prefix of the generated code.

_/post:suffix_     - Suffix of the generated code.
```


## Authors

- [@Intell!Soft](https://www.github.com/Intelli-Soft)


## License

[MIT](https://choosealicense.com/licenses/mit/)






