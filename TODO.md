# TODO

Things that need to be done and improved before a final release


- *stability* - Add XML comments to all public classes and members
- *stability* - Improve code coverage
- *code quality* - consider generating TernaryInt-members that are common to different TernaryInt-types.


- *feature* - Implement conversions between all trit types. 
Possibly with the introduction of an ITerneryComparable

- *feature* - Big Ternaries: (operations on) ternary numbers with more than 32 trits.
  - Convert to end from long
  - Tritshifts
  - Convert from and to binary
  - Convert from and to decimal

- *feature* - Streams: reading from and writing to (binary) data streams.
  - TernaryStream
  - StreamAdapters (with different encoding schemes and autodetection)
  - Shortcuts for writing directly to output and files

- *feature* - Ternary character set / string
   - (UTF8 and ASCII are inherently binary-based. Move around characters.)
   - TernaryChar and TernaryString
   - Conversion from en to char/string
