
SELECT DISTINCT Variants.VariantName
FROM Variants
WHERE Variants.Id IN
	(SELECT DISTINCT CountriesVariants.VariantId FROM CountriesVariants
	WHERE CountriesVariants.CountryId IN
		(
		SELECT Countries.Id FROM Countries
		WHERE
			Countries.CountryName = 
			