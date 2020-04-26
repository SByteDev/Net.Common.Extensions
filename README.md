# Extensions for .Net
![GitHub](https://img.shields.io/github/license/SByteDev/Net.MvvmCross.Extensions.svg)
![Nuget](https://img.shields.io/nuget/v/SByteDev.MvvmCross.Extensions.svg)

[![Build Status](https://travis-ci.org/SByteDev/Net.Common.Extensions.svg?branch=develop)](https://travis-ci.org/SByteDev/Net.Common.Extensions)
[![codecov](https://codecov.io/gh/SByteDev/Net.Common.Extensions/branch/develop/graph/badge.svg)](https://codecov.io/gh/SByteDev/Net.Common.Extensions)
[![CodeFactor](https://www.codefactor.io/repository/github/sbytedev/net.common.extensions/badge)](https://www.codefactor.io/repository/github/sbytedev/net.common.extensions)

## Installation

Use [NuGet](https://www.nuget.org) package manager to install this library.

```bash
Install-Package SByteDev.Common.Extensions
```

## Usage
```cs
using SByteDev.Common.Extensions;
```

### ICommand Extensions
To safely check whether the `ICommand` can be executed in its current state:

```cs
var canExecute = Command.SafeCanExecute(parameter);
```

To safely invoke the `ICommand` if this command can be executed in its current state:

```cs
var isExecuted = Command.SafeExecute(parameter);
```

### IEnumerable Extensions
To search for the specified object and get the index of its first occurrence in a collection:

```cs
var index = default(IEnumerable).IndexOf(item);
var index = default(IEnumerable).IndexOf(item, comparer);
var index = default(IEnumerable<TItem>).IndexOf(item);
var index = default(IEnumerable<<TItem>>).IndexOf(item, comparer);
```

To get a specified number of contiguous elements from the specified index:

```cs
var items = default(IEnumerable<TItem>).Take(startIndex, length);
```

To check if the specified enumerable is `null` or has a length of zero:

```cs
var isNullOrEmpty = default(IEnumerable).IsNullOrEmpty();
```

To get the number of elements in a sequence:

```cs
var count = default(IEnumerable).Count();
```

### String Extensions
To check is the specified string is null or an empty string:

```cs
var isNullOrEmpty = "string".IsNullOrEmpty();
```

To check is the specified string is null, empty, or consists only of white-space characters:

```cs
var isNullOrEmpty = "string".IsNullOrWhiteSpace();
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update the tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)