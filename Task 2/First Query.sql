use world;
SELECT
  country.Name,city.Population
FROM country
  INNER JOIN city
    ON city.id = country.Capital
WHERE country.Capital ORDER BY city.Population DESC LIMIT 5