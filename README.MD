AWS 사용에 대한 리포트 요청이 잦아짐에 따라 AWS 에서 csv 의 RAW 데이터를 토대로
날짜 변경 및 api 호출을 통해 데이터를 가지고 와서, 
사용자가 요청한 리포트 형태로의 csv 파일을 만드는 프로그램 입니다.

기본적으로 athena 에서 돌린 쿼리를 csv 로 떨구고 시작하며, 
해당 툴은 개인적인 목적으로 만들어져, 다른사람들에게는 사용된 코드 정도 보는 것 외엔 별 필요 없는 프로그램이다.

This application reads a csv file containing raw data
and reproduces a monthly required report.

- it is built for my personal usage so it will not work for the others..
- but, what it does might matter.

- what it does.. (아래 1번부터 6번까지 파일을 열어 따로 excel/csv 작업을 해야 해서 그냥 프로그램으로 진행함)

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

