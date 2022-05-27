SELECT Virus.VirusName FROM Virus
WHERE Virus.GroupId IN
	(SELECT VirusGroup.Id
	 FROM VirusGroup
	 WHERE
		(VirusGroup.GroupName = 