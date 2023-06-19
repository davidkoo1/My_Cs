CREATE DATABASE Ninja


USE Ninja

CREATE TABLE Clan
(
ClanID INT PRIMARY KEY,
ClanName VARCHAR(30),
ClanDiscription VARCHAR(MAX)
)

CREATE TABLE Village
(
VillageID INT PRIMARY KEY,
VillageName VARCHAR(100)
)

CREATE TABLE Rank
(
RankID INT PRIMARY KEY,
RankName VARCHAR(30),
RankLetter VARCHAR(5)
)

CREATE TABLE Ninja
(
NinjaID INT PRIMARY KEY,
NinjaName VARCHAR(30),
IDClan INT FOREIGN KEY REFERENCES Clan(ClanID),
IDVillage INT FOREIGN KEY REFERENCES Village(VillageID),
IDRank INT FOREIGN KEY REFERENCES Rank(RankID),
Traitor BIT
)


CREATE TABLE SkillCategory
(
CategoryID INT PRIMARY KEY,
CategoryName VARCHAR(50)
)

CREATE TABLE Skill
(
SkillID INT PRIMARY KEY,
SkillName VARCHAR(30),
SkillDiscription VARCHAR(500),
IDCategory INT FOREIGN KEY REFERENCES SkillCategory(CategoryID),
IDRank INT FOREIGN KEY REFERENCES Rank(RankID)
)

CREATE TABLE NinjaSkills
(
IDNinja INT FOREIGN KEY REFERENCES Ninja(NinjaID),
IDSkill INT FOREIGN KEY REFERENCES Skill(SkillID)
)

CREATE TABLE Battle
(
BattleID INT PRIMARY KEY,
BattleName VARCHAR(100),
BattleDiscription VARCHAR(MAX),
IDVillage INT FOREIGN KEY REFERENCES Village(VillageID)
)

CREATE TABLE NinjaBattles
(
IDNinja INT FOREIGN KEY REFERENCES Ninja(NinjaID),
IDBattle INT FOREIGN KEY REFERENCES Battle(BattleID)
)

DELETE FROM NinjaBattles WHERE IDNinja = 5 AND IDBattle = 1
INSERT INTO NinjaBattles(IDNinja, IDBattle) VALUES (5, 1) 
Select * from NinjaBattles

--Деревня и ранги с количеством ниндзя
SELECT VillageName, RankLetter, Count(*) AS Ninjas -- NinjaName, VillageName, RankLetter, RankName
FROM Village INNER JOIN 
( 
Ninja INNER JOIN Rank
ON Ninja.IDRank = Rank.RankID
)
ON Ninja.IDVillage = Village.VillageID
GROUP BY VillageName, RankLetter


--Техники и сколько раз использовали
SELECT SkillName, COUNT(*) AS UsedCount
FROM Skill INNER JOIN 
(
NinjaSkills INNER JOIN Ninja
ON NinjaSkills.IDNinja = Ninja.NinjaID
)
ON NinjaSkills.IDSkill = Skill.SkillID
GROUP BY SkillName 
ORDER BY UsedCount ASC


--Групировка колво ниндзя в кланах
SELECT ClanName, COUNT(*) as NinjasINClan 
FROM 
Clan FULL JOIN Ninja
ON Clan.ClanID = Ninja.IDClan
GROUP BY ClanName

--Вывод ниндзя по рангам
SELECT NinjaName, RankLetter
FROM Ninja INNER JOIN Rank
ON Ninja.IDRank = Rank.RankID
ORDER BY RankID DESC


--Кол-во ниндзя каждого ранга
SELECT RankLetter, COUNT(*)
FROM Rank INNER JOIN Ninja
ON Rank.RankID = Ninja.IDRank
GROUP BY RankLetter


SELECT * FROM Ninja
FOR JSON PATH, ROOT('Ninjas')


