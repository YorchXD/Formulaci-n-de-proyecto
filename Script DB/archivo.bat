SETLOCAL
SET directory=.
SET mysqldir="D:\xampp\mysql\bin
SET user=root
SET pwd=
SET dbname=simrend
SET server=localhost

for %%f in (.\*.sql) do %mysqldir%\mysql" --user=%user% --password=%pwd% --host=%server% %dbname%   --default-character-set=utf8 < %%f
ENDLOCAL
PAUSE