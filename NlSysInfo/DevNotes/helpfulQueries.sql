-- select the max created - 1 (so you can compare to max created)
select created, count(*) from snapshot where created = (select max(created) from snapshot where created <  (select max(created) from snapshot));

-- select max created
select created, count(*) from snapshot where created = (select max(created)from snapshot);

WITH CompareProcs(name,file) AS 
(
    SELECT name, filehash from snapshot where 
    created = (select max(created) from snapshot)
    ) select name, filehash from snapshot where created = '11/27/2024 10:22:05 AM' 
    and name not in (select name from CompareProcs);

    WITH CompareProcs(name,file) AS 
(
    SELECT name, filehash from snapshot where 
    created = (select max(created) from snapshot)
    ) select name, filehash from snapshot where created = '11/26/2024 9:59:51 PM' 
    and name not in (select name from CompareProcs);

    select name, count(name) from snapshot 
    where created = (select max(created) from snapshot)
     group by name having count(name) > 1;

     