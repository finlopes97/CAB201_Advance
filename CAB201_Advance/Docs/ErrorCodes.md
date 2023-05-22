# Error Codes for Advance

#### Error 1: 
```csharp
$"Invalid argument 1 {value}. Argument 1 only accepts values 'black', 'white' or 'name.'"
```
This error is thrown when a user inputs an argument in the first position that does not match the accepted string 
values described previously. Steps to rectify are to provide a valid value from the three specified. 

#### Error 2:
```csharp
$"Invalid argument 2 {value}. The provided filepath does not exist. Please try again with a valid filepath."
```
This error is thrown when the argument in the second position is a filepath that does not exist. Steps to rectify are to 
provide a valid filepath to a file that exists.

#### Error 3:
```csharp
$"Invalid argument 3 {value}. The provided filepath does not exist. Please try again with a valid filepath."
```
As above, but for the argument in the third position. Steps to rectify are as above, adjusted for the write path.

#### Error 4:
```csharp
$"The file at path {PathToReadIn} could not be opened. This file may be the wrong type or corrupted, please try a new file."
```
This error is thrown when the filepath to be read in by th streamreader in Game_Manager.cs cannot be opened for some
reason. Steps to rectify are to ensure the file you are providing the program is a readable file with appropriate 
permissions set, a valid extension such as .txt and that the file is not corrupted.

#### Error 5: 
```csharp
$"Line {row + 1} of the file at filepath {PathToReadIn} is either null or contains the incorrect number of columns. Please try a new file or edit the existing one."
```
This error is thrown when a line is found in the read in file that is null or does not match the specified number
of columns (default 9 + the new-line column). Steps to rectify are to open the specified file and edit it to ensure that there are 9 columns
in each row and that there are no empty rows before the end of the file.

#### Error 6
```csharp
$"The character {line[col]} was found in line {row + 1} and is an invalid character. Please try a new file or edit the existing one."
```
This error is thrown when the program receives an invalid character as an input. Valid characters are Z, B, M, J, S, D, 
C, G, z, b, m, j, s, d, c, g, . (period) and # (hash). If a character other than those listed then it will halt. Steps 
to rectify are to open the file specified in the error and remove any invalid characters, replacing them with valid ones.

#### Error 7
```csharp
$
```