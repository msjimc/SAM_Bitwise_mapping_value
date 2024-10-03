# SAM Bitwise mapping value
When aligning NGS data to a reference sequence, the aligner records an array of data on each reads alignment and when present it's mate pair. This data is stored as single 32 bit integer, with each bit linked to a statement as listed in the table.

|Decimal value of bit|Summary|Description|
|-|-|-|

|1|PAIRED	|paired-end (or multiple-segment) sequencing technology|
|2|PROPER_|PAIR	each segment properly aligned according to the aligner|
|4	|UNMAP|	segment unmapped|
|8	|MUNMAP|	next segment in the template unmapped|
|16	|REVERSE|	SEQ is reverse complemented|
|32|	MREVERSE|	SEQ of the next segment in the template is reverse complemented|
|64	|READ1| the first segment in the template|
|128	|READ2|	the last segment in the template|
|256	|SECONDARY|	secondary alignment|
|512	|QCFAIL|	not passing quality controls|
|1024	|DUP|	PCR or optical duplicate|
|2048	|SUPPLEMENTARY|	supplementary alignment|
