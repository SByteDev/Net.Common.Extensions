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


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update the tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)