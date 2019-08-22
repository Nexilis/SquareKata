Based on:
"F# property based testing introduction" by Mark Seemann on Pluralsight

The only valid inputs are A-Z

Examples:
input:
A
output:
A

input:
B
output:
ABA
B B
ABA

input:
C
output:
ABCBA
B   B
C   C
B   B
ABCBA

It's hard to implement using Example-Driven Development, used Property Based Testing instead.

Run using:
$ dotnet test
