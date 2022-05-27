SELECT Count(DISTINCT Countries.CountryName)
FROM Countries
WHERE Countries.Id IN (
	SELECT DISTINCT CountriesVariants.CountryId FROM CountriesVariants
	WHERE CountriesVariants.VariantId IN (
		SELECT Variants.Id FROM Variants
		WHERE Variants.VariantName = 