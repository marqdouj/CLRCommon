# CLRCommon

CLRCommon is a collection of helper utilities and classes for .NET development.

## NuGet Package

https://www.nuget.org/packages/Marqdouj.CLRCommon/

## Release Notes
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
 - removed <AllowUnsafeBlocks>true</AllowUnsafeBlocks> from project file (not needed)
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
	- IsNumeric - determines if a string is numeric
	- IsPositiveInteger - determines if a string is a positive integer
	- Left - returns the leftmost characters of a string (Mimics VB's Left function))
	- Right - returns the rightmost characters of a string (Mimics VB's Right function))
	- ToBoolOrNull - converts a string to a Boolean or null (supports Y/N, YES/NO, 1/-1))
	- ToDecimal - converts a string to a decimal
	- ToDecimalOrNull - converts a string to a decimal or null
	- ToDecimalOrValue - converts a string to a decimal or a specified default value
	- ToDouble - converts a string to a double
	- ToDoubleOrNull - converts a string to a double or null
	- ToDoubleOrValue - converts a string to a double or a specified default value
	- ToInt32 - converts a string to an integer
	- ToInt32OrNull - converts a string to an integer or null
	- ToInt32OrValue - converts a string to an integer or a specified default value
	- ToInt32List - converts a delimited string to a list of integers
	- ToInt64 - converts a string to a long
	- ToInt64OrNull - converts a string to a long or null
	- ToInt64OrValue - converts a string to a long or a specified default value
	- ToInt64List - converts a delimited string to a list of longs
	- ToTitleCase - converts a string to title case using a specified culture (wrapper for TextInfo.ToTitleCase))
	- Truncate - truncates a string to a specified length
 - added Paging helper class
	- PagedData<T> - a class to hold the results for paged data
	- PagedRange - a class to calculate a range of pages
	- PageInfo - a class to hold paging information
	
v8.1.1
 - added MinMaxN<T> / INumber<T>: ensures a value is within a min/max range
 - added ExceptionExtensions
	- ToMessage - returns the message of an exception and all inner exceptions
	- ToMessages - returns the message of an exception and all inner exceptions as a list

v8.1.0
 - BREAKING CHANGES.
 - StateContainer: Changed OnChange to StateChanged; added INotifyPropertyChanged support/PropertyChanged
