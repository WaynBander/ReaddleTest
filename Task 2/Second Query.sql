use world;
SELECT
 SUM((country.Population/100)*countrylanguage.Percentage)AS People
 FROM country
 INNER JOIN countrylanguage ON country.Code=countrylanguage.CountryCode
 WHERE  country.Continent='Europe' AND countrylanguage.Language="English"
 
 