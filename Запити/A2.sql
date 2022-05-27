SELECT DISTINCT Variants.VariantName FROM Variants
JOIN Virus ON
Variants.VirusId = Virus.Id
JOIN SymptomsVariants ON SymptomsVariants.SymptomId IN
(
	SELECT DISTINCT SymptomsVariants.SymptomId FROM SymptomsVariants
	JOIN Variants ON  Variants.Id = SymptomsVariants.VariantId
	WHERE Variants.VariantName = 