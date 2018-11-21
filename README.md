# Krita Brush Info

Krita Brush Info is a C# Windows application that reads Krita brush configurations and displays them in a readable form. It can also compare two brushes and show the differences. This can be useful for seeing the structure of the brush parameters and to easily compare the differences between two brushes. It is easier to compare brushes this way than by hunting through the brush properties dialog in Krita, and it may give you some insight into how Krita brushes are configured.

It can read .kpp brush preset files or get them from a .bundle resource bundle.

See http://kenevans.net/opensource/KritaBrushInfo/Help/Overview.html

**Installation**

If you are installing from a download, just unzip the files into a directory somewhere convenient. Then run it from there. If you are installing from a build, copy these files and directories from the bin/Release directory to a convenient directory.

* KritaBrushInfo.exe
* Help

To uninstall, just delete these files.

You will also need to install ExifTool by Paul Harvey to read the EXIF information in the .kpp preset file. This is free software.  You can redistribute it and/or modify it under the same terms as Perl, which it uses.  The ExifTool site is:

https://www.sno.phy.queensu.ca/~phil/exiftool

**More Information**

More information and FAQ are at https://kennethevans.github.io as well as more projects from the same author.

Licensed under the MIT license. (See: https://en.wikipedia.org/wiki/MIT_License)