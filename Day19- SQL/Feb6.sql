select * into #temp1 from [Person].[Address]

select * from #temp1
DELETE #temp1 --dlt table data
DROP table #temp1

SELECT top 5 * into #temp1 from [Person].[Address]
select * from #temp1


SELECT top 5 * into ##temp1 from [Person].[Address]   --global table shared to all in the server
select * from ##temp1
