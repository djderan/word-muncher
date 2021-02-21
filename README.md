# word-muncher

## Building Instructions
This project should be built using VS19.

## Running Instructions
This console application is setup to run from command line with two arguments, the first
argument including the file to be processed, the second is an output file that will contain
the results of the run.  The results file will be overwritten during the run.  

Ex. word-muncher.exe "C:\word-muncher\Text1.txt" "C:\word-muncher\Results.txt"

If running through visual studio the project properties have already been configured to run 
Test2 and output to Results.txt in the root folder.

## Data Assumptions
This program assumes that all the stop words are not provided at run time and are instead
accessed as a resource.  This program assumes that the input will be skipping any non alpha
or white space characer and then defining a word as letters between to white space characters.

## Sample Output
Output will be in the format of the word : number of occurances.

Output of Test1.txt
us:11
govern:10
peopl:10
right:10
law:9
state:9
power:8
time:6
among:5
declar:5
establish:5
refus:5
abolish:4
assent:4
coloni:4
form:4
free:4
independ:4
larg:4
legisl:4

Output for Test2.txt
said:462
alic:401
littl:128
look:104
like:97
know:90
went:83
go:77
thing:77
queen:76
thought:76
time:74
sai:70
get:68
see:68
king:64
think:64
dont:60
turtl:60
well:60
