-- select the max created - 1 (so you can compare to max created)
select created, count(*) from snapshot where created = (select max(created) from snapshot where created <  (select max(created) from snapshot));

-- select max created
select created, count(*) from snapshot where created = (select max(created)from snapshot);