

SELECT Variants.VariantName FROM Variants
WHERE Variants.VirusId IN
	(SELECT Virus.Id
	 FROM Virus
	 WHERE
		(Virus.VirusName = 
