This application reads a csv file containing raw data
and reproduces a monthly required report.

- it is a personal usage so it is useless for others..

- what it does..

1. it gets the csv file from the disk
2. it sends over to api and receives text formatted result.
3. it stores the text result to tempResult.csv file
4. it reads the neccessary data from the original file and the tempResult file 
and bind them into 2 collections (lists) and join them together into a 1 collection.
5. before joining 2 collections, there are data alternations take place
5-1. the UTC datetime info a local dateTime info
5-2. it merges certain columns(array members) into 1
6. it writes the joined collection into a result csv file.


I built this application.. 'coz 
I didn't want to do copying, pasting etc on csv files..
for monthly reports..

