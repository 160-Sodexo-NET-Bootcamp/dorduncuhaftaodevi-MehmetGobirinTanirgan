# Sodexo .NET Bootcamp - Fourth Homework

### Details

- Deadline: 26 Jan 2022
- [Details of homework](https://github.com/Semra4141/UcuncuHaftaOdevi/files/7918753/Odev.4.0.pdf)


#### Observation of Hangfire Jobs

I started the app at 02:00 PM and waited until daily update.
<br>

1. At the beginning, I sent the requests for adding recurring jobs.

![](images/recurring-jobs.PNG)
<br><br>


2. First job that I added to Hangfire, was inserting a record in every 15 minutes. 

The situation of table until daily update, you can see that the job is inserting a record in every 15 minutes correctly.

![](images/table-before-update.PNG)
<br><br>

Successed jobs until daily update.

![](images/jobs-before-update.PNG)
<br><br>


3. When it comes to the daily update (06:00 PM), status of the records on table should be updated.

Table situation during daily update.

![](images/table-on-update.PNG)
<br><br>

Successed jobs during daily update.

![](images/jobs-on-update.PNG)
<br><br>

4. After the daily update, first job kept inserting records.

![](images/table-after-update.PNG)
<br><br>

