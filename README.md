# wan24-I8NGUI

**NOTE**: This repository contains only a prototype at present. There was 
nothing released or officially published yet!

This repository contains an app with a GUI for translating i8n files.

Supported platforms are:

- Browser (PWA)
- Microsoft Windows 10+
- MAC Catalyst

Supported input file formats are:

- gettext PO (*.po)
- gettext MO (*.mo)
- wan24-I8NTool (*.i8n)
- wan24-I8NKws (*.kws)

Supported output file formats are:

- gettext PO (*.po)
- wan24-I8NTool (*.i8n)
- wan24-I8NKws (*.kws)

**NOTE**: gettext MO output isn't supported. Please use gettext for compiling 
a PO file to the MO format.

## Usage

### How to get it

#### Browser (PWA)

Please [click here]() to run the latest version in your browser.

#### Microsoft Windows 10+

TODO

#### MAC Catalyst

TODO

### CLI usage

For working with gettext PO/MO, wan24-I8NTool i8n and wan24-I8NKws files 
please use the 
[`wan24-I8NTool` dotnet tool](https://www.nuget.org/packages/wan24-I8NTool/) 
and follow the instructions from the 
[`wan24-I8NTool` GitHub repository](https://github.com/nd1012/wan24-I8NTool).

You can also use the `wan24-I8NTool` for extracting strings for translations 
from your projects source code into gettext PO, i8n or `wan24-I8NKws` file 
formats, which you can open and translate using the `wn24-I8NGUI`, no matter 
what operating system you (or your translator) use.

## Limitations

### gettext PO/MO

- The MO file format can be parsed for input, but not compiled from a PO file 
for output
- Obsolete keyword comments won't be interpreted
