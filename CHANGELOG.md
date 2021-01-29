# Changelog

All significant changes to the program will be documented in this file.  
We're not using [semantic versioning](http://semver.org/).

This is how we're determining the versions:

Position | Meaning
-|-
1 | Features added
0 | Improved features
0 | Patches

1. [Released](#Released)
1. [Previous Repository](#Previous-repository)

## Released

### Version [3.0.3](https://github.com/nico-castell/Password-Magician/releases/tag/3.0.3) - *2021-01-28*

### Fixed
Fixed a bug in *encrypt* mode where the program would have an unhandled
exception if the user inserted an empty key.

### Version 3.0.2 - *2021-01-22*
*Developers update*

#### Changed
Namespaces, project file names, and sub-directories.

### Version [3.0.1](https://github.com/nico-castell/Password-Magician/releases/tag/3.0.1) - *2021-01-22*
*Developers update*

#### Added
The main feature of this update is the addition of Unit testing. Specifically
on the *Modifier* class.

#### Changed
Access modifier in the *_allowLetters* field in the *Modifier* class.

### Version [3.0.0](https://github.com/nico-castell/Password-Magician/releases/tag/3.0.0) - *2021-01-19*

#### Added
An encryption mode that uses XOR boolean logic and a password.

### Version [2.1.0](https://github.com/nico-castell/Password-Magician/releases/tag/2.1.0) - *2021-01-16*

#### Added
When in 'obfuscate' mode, the user can now choose to allow or forbid Letters,
Numbers, and/or symbols.

### Version [2.0.0](https://github.com/nico-castell/Password-Magician/releases/tag/2.0.0) - *2021-01-16*

#### Added
Now, the program has te functionality to obfuscate a given password in a
**one** **way** **only** process.

### Version [1.2.1](https://github.com/nico-castell/Password-Magician/releases/tag/1.2.1) - *2021-01-15*

#### Fixed
Now the text box is white instead of grey.

---
<!-- These releases come from the projects previous repository, so the dates,
unfortunately, have been lost. -->

## Previous repository

### Version 1.2.0

#### Added
1. An installer for the program.
2. An icon.

### Version 1.1.0

#### Changed
Now, when the user has unchecked two checkboxes, the third one, still
unchecked, will be disabled.

### Version 1.0.0

First release

#### Added
* Password generator
* Length selecter
* Checkboxes to allow or not allow letters, numbers, and/or symbols.
* Hide or show the generated password.
* A button to copy the password to the clipboard.
