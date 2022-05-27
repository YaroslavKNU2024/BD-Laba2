SELECT DISTINCT Variants.VariantName FROM Variants
JOIN Virus ON
Variants.VirusId = Virus.Id
JOIN CountriesVariants ON CountriesVariants.CountryId IN
(
	SELECT DISTINCT Countries.Id FROM Countries
	JOIN Variants ON  Variants.Id = CountriesVariants.VariantId AND
		Virus.VirusName=
		