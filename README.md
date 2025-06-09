# CLRCommon

CLRCommon is a collection of helper utilities and classes for .NET development.

## NuGet Package
The NuGet package can be found [here](https://www.nuget.org/packages/Marqdouj.CLRCommon/)

## Demo
- A demo of this and some of my other NuGet packages can be found [here](https://github.com/marqdouj/BlazorSandbox)

## Features 
- **ExceptionExtensions**
  - ***ToMessage()***. Resolves all messages recursively. Returns a joined string (optional separator).
  - ***ToList()***. Resolves all messages recursively. Returns a list of messages.
- **ListExtensions**
  - ToDataTable(). Converts a list of objects to a System.Data.DataTable.
- **MinMaxN**
  - INumber that is constrained between a minimum and maximum value.
- **Paging**
	- PagedData - a class to hold the results for paged data
	- PagedRange - a class to calculate a range of pages
	- PageInfo - a class to hold paging information
- **PathExtensions**
  - Helper method to resolve a folder locations not supported by Environment.GetFolderPath 
    - Currently only the `Downloads` folder is supported
- **StateContainer**
  - Notifcations when a value changes (StateChanged).
  - Supports INotifyPropertyChanged and Action (Blazor)
-  **StringExtensions**
	- **IsNumeric** - determines if a string is numeric
	- **IsPositiveInteger** - determines if a string is a positive integer
	- **Left** - returns the leftmost characters of a string (Mimics VB's Left function))
	- **Right** - returns the rightmost characters of a string (Mimics VB's Right function))
	- **ToBoolOrNull** - converts a string to a Boolean or null (supports Y/N, YES/NO, 1/-1))
	- **ToCrLf** - Takes a string and converts its line endings to CrLf
	- **ToDecimal** - converts a string to a decimal
	- **ToDecimalOrNull** - converts a string to a decimal or null
	- **ToDecimalOrValue** - converts a string to a decimal or a specified default value
	- **ToDouble** - converts a string to a double
	- **ToDoubleOrNull** - converts a string to a double or null
	- **ToDoubleOrValue** - converts a string to a double or a specified default value
	- **ToInt32** - converts a string to an integer
	- **ToInt32OrNull** - converts a string to an integer or null
	- **ToInt32OrValue** - converts a string to an integer or a specified default value
	- **ToInt32List** - converts a delimited string to a list of integers
	- **ToInt64** - converts a string to a long
	- **ToInt64OrNull** - converts a string to a long or null
	- **ToInt64OrValue** - converts a string to a long or a specified default value
	- **ToInt64List** - converts a delimited string to a list of longs
	- **ToNewLine** - Converts line endings to Environment.NewLine
	- **ToTitleCase** - converts a string to title case using a specified culture (wrapper for TextInfo.ToTitleCase))
	- **Truncate** - truncates a string to a specified length
- **StringExtensions (Lists)**
    - **ToInt32List** - Converts delimited string of integer to Int32 List
	- **ToInt64List** - Converts delimited string of long to Int64 List

## Release Notes
v8.8.3
- added optional `separator` to `Exception.ToMessage()` extension.

v8.8.2
- override MinMaxN ToString to return the Value

v8.8.1
- added 'SuppressNotifications' flag to StateContainer

v8.8.0
- Added [JsonConstructor] to MinMaxN

v8.7.1
- Added NuGet pkg icon

v8.7.0
- Fixed bug in MinMaxN calculations for Center/Width properties

v8.6.0 (Depreciated)
- added Center/Width properties to MinMaxN

v8.5.0
 - MinMaxN
	- added MinMaxN tests to project
	- added constructor without Value parameter
 - added StringExtensions.IsNumeric tests to project
	- added support for null strings in StringExtensions.IsNumeric
 - added StringExtensions.IsPositiveInteger tests to project
	- added support for null strings in StringExtensions.IsPositiveInteger
	- Zero is now considered a positive integer in StringExtensions.IsPositiveInteger

v8.4.0
 - added StringExtensions tests to project
 - found and fixed bug in StringExtensions.ToNewLine

v8.3.0
 - refactored StringExtensions.Truncate.

v8.2.1
 - removed 'AllowUnsafeBlocks' from project file (not needed)
 - added StringExtension Method
	- String.ToNewLine - Converts line endings to Environment.NewLine

v8.2.0
 - Updated Comments
 - added ListExtensions / IEnumerableExtensions
	- ToDataTable - converts a list of objects to a DataTable
 - added PathExtensions
	- GetPath - returns the path of a known folder not supported by Environment.SpecialFolder
	  - currently only supports Downloads folder
 - added StringExtensions
 - added Paging helper class
	
v8.1.1
 - added MinMaxN<T> / INumber<T>: ensures a value is within a min/max range
 - added ExceptionExtensions
	- ToMessage - returns the message of an exception and all inner exceptions
	- ToMessages - returns the message of an exception and all inner exceptions as a list

v8.1.0
 - BREAKING CHANGES.
 - StateContainer: Changed OnChange to StateChanged; added INotifyPropertyChanged support/PropertyChanged
