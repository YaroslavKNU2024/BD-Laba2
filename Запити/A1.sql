SELECT DISTINCT Variants.VariantName FROM Variants
JOIN Virus ON
Variants.VirusId = Virus.Id
JOIN CountriesVariants ON CountriesVariants.CountryId IN
(
	SELECT DISTINCT CountriesVariants.CountryId FROM CountriesVariants
	JOIN Variants ON  Variants.Id = CountriesVariants.VariantId
	WHERE Variants.VariantName = 