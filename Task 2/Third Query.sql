SELECT country.Name  FROM (
select countrylanguage.CountryCode, COUNT(CountryCode) as sumT from countrylanguage
where countrylanguage.IsOfficial='T' 
group by countrylanguage.CountryCode 
)AS sum,
(select countrylanguage.CountryCode, COUNT(CountryCode) as sumF from countrylanguage
where countrylanguage.IsOfficial='F'
group by countrylanguage.CountryCode ) as summ, country 
INNER JOIN countrylanguage ON countrylanguage.CountryCode=country.Code
WHERE  summ.sumF>(sum.sumT*2) AND sum.sumT>=2  AND countrylanguage.CountryCode=summ.CountryCode AND countrylanguage.CountryCode=sum.CountryCode
group by sum.CountryCode