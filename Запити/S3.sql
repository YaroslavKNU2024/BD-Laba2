
SELECT DISTINCT Variants.VariantName
FROM Variants
WHERE Variants.Id IN
	(SELECT DISTINCT SymptomsVariants.VariantId FROM SymptomsVariants
	WHERE SymptomsVariants.SymptomId IN
		(
		SELECT Symptoms.Id FROM Symptoms
		WHERE
			Symptoms.SymptomName = 
		
