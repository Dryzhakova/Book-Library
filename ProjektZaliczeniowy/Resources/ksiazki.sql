-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: ksiazki
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `autorzy`
--

DROP TABLE IF EXISTS `autorzy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autorzy` (
  `id_autorzy` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `imie` char(20) NOT NULL,
  `nazwisko` char(25) NOT NULL,
  `biografia` varchar(700) NOT NULL,
  PRIMARY KEY (`id_autorzy`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autorzy`
--

LOCK TABLES `autorzy` WRITE;
/*!40000 ALTER TABLE `autorzy` DISABLE KEYS */;
INSERT INTO `autorzy` VALUES (1,'Cassandra','Clare','Pisarka urodzona w amerykańskiej rodzinie w Teheranie. Przez większość dzieciństwa podróżowała po świecie, odbyła nawet jedną wędrówkę przez Himalaje. Mieszkała we Francji, Anglii i Szwajcarii. Licealne lata spędziła w Los Angeles, tam napisała m.in. opowieść Piękna Cassandra, opartą na opowiadaniu Jane Austen. Po ukończeniu college\'u mieszkała w Los Angeles i Nowym Jorku, gdzie pracowała w redakcjach czasopism rozrywkowych, a nawet w tabloidach. Równolegle zaczęła pracę nad swoją powieścią Miasto Kości, inspirowaną miejskim krajobrazem Manhattanu. Mieszkając w Los Angeles, zaczęła pisać utwory fan fiction pod pseudonimem Cassandra Clare.'),(2,'Holly','Black','Urodziła się w West Long Branch w New Jersey w 1971 roku. Przez pierwsze lata życia Black jej rodzina mieszkała w zgrzybiałym wiktoriańskim domu. Ukończyła studia na College of New Jersey w 1994 roku. Pracowała jako redaktor w czasopismach medycznych, w tym w The Journal of Pain, jednocześnie kontynuując studia na Rutgers University. Jeśli nie powiodłoby się jej pisanie, chciała zostać bibliotekarką. Była redaktorem w miesięczniku 8d, traktującym o grach fabularnych.'),(3,'Stephen','King','Amerykański powieściopisarz, głównie literatury grozy. W przeszłości publikował pod pseudonimem Richard Bachman, raz jako John Swithen.');
/*!40000 ALTER TABLE `autorzy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ksiazki`
--

DROP TABLE IF EXISTS `ksiazki`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ksiazki` (
  `id_ksiazki` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `tytul` char(50) NOT NULL,
  `id_autor` tinyint unsigned NOT NULL,
  `id_wydawnictwo` tinyint unsigned NOT NULL,
  `id_rodzaj` tinyint unsigned NOT NULL,
  `okladka` mediumblob,
  `opis` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id_ksiazki`),
  UNIQUE KEY `tytul` (`tytul`),
  KEY `id_autor` (`id_autor`),
  KEY `id_wydawnictwo` (`id_wydawnictwo`),
  KEY `id_rodzaj` (`id_rodzaj`),
  CONSTRAINT `ksiazki_ibfk_1` FOREIGN KEY (`id_autor`) REFERENCES `autorzy` (`id_autorzy`),
  CONSTRAINT `ksiazki_ibfk_2` FOREIGN KEY (`id_wydawnictwo`) REFERENCES `wydawnictwo` (`id_wydawnictwo`),
  CONSTRAINT `ksiazki_ibfk_3` FOREIGN KEY (`id_rodzaj`) REFERENCES `rodzaje` (`id_rodzaje`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ksiazki`
--

LOCK TABLES `ksiazki` WRITE;
/*!40000 ALTER TABLE `ksiazki` DISABLE KEYS */;
INSERT INTO `ksiazki` VALUES (1,'Miasto kości',1,5,1,_binary 'ksiazka1.jpg','Być świadkiem morderstwa - to przeżycie, które pozostawia w psychice ślad na całe życie. Clary Fray wiedze życie normalnej, nieco zbuntowanej nastolatki. Gdy jednak pewnego razu w klubie staje się świadkiem bezwzględnego morderstwa popełnionego przez trzech nastolatków na ich rówieśniku, jej dotychczasowa rzeczywistość kompletnie się rozpada.\n\n'),(2,'Okrutny książę',2,9,1,_binary 'ksiazka2.jpg','Krwawa zbrodnia na zawsze odmienia los trzech sióstr. Zostają porwane do świata elfów, bajecznego Elysium. Upływa dziesięć lat; Jude pragnie za wszelką cenę odnaleźć swoje miejsce w krainie elfów - lecz dumni elfowie gardzą śmiertelniczką, a wzgardliwszy od innych jest książę Cardan, najmłodszy i najokrutniejszy z potomków Najwyższego Króla.'),(4,'Zielona Mila',3,11,5,_binary 'ksiazka3.jpg','Akcja powieści, zbliżonej klimatem do głośnej noweli tego samego autora, Skazani na Shawshank, toczy się w Ameryce lat 30. Jej bohaterowie to więźniowie oczekujący na wykonanie kary śmierci i pilnujący ich strażnicy. Wśród przebywających w więzieniu Cold Mountain skazańców znajduje się nieobliczalny, niezwykle agresywny młodociany zabójca William Wharton; jest Eduard Delacroix, niepozorny Francuz z Luizjany, który zgwałcił, zabił młodą dziewczynę i dla zatarcia śladów spalił kolejnych sześć osób. Jest wreszcie skazany za brutalny mord na dwóch małych dziewczynkach John Coffey, zagadkowy olbrzym o wiecznie załzawionych oczach, obdarzony niezwykłą mocą.');
/*!40000 ALTER TABLE `ksiazki` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recenzje`
--

DROP TABLE IF EXISTS `recenzje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recenzje` (
  `id_recenzja` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `id_ksiazki` tinyint unsigned NOT NULL,
  `ocena` int NOT NULL,
  PRIMARY KEY (`id_recenzja`),
  KEY `id_ksiazki` (`id_ksiazki`),
  CONSTRAINT `recenzje_ibfk_1` FOREIGN KEY (`id_ksiazki`) REFERENCES `ksiazki` (`id_ksiazki`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recenzje`
--

LOCK TABLES `recenzje` WRITE;
/*!40000 ALTER TABLE `recenzje` DISABLE KEYS */;
/*!40000 ALTER TABLE `recenzje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rodzaje`
--

DROP TABLE IF EXISTS `rodzaje`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rodzaje` (
  `id_rodzaje` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `rodzaj` char(25) NOT NULL,
  PRIMARY KEY (`id_rodzaje`),
  UNIQUE KEY `rodzaj` (`rodzaj`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rodzaje`
--

LOCK TABLES `rodzaje` WRITE;
/*!40000 ALTER TABLE `rodzaje` DISABLE KEYS */;
INSERT INTO `rodzaje` VALUES (7,'Biografia'),(9,'Dla dzieci'),(1,'Fantastyka'),(5,'Horror'),(11,'Komiksy'),(6,'Kryminał'),(10,'Kulinarna'),(8,'Młodzieżowa'),(12,'Popularnonaukowa'),(4,'Powieść historyczna'),(3,'Romans'),(2,'Sci-Fi');
/*!40000 ALTER TABLE `rodzaje` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wydawnictwo`
--

DROP TABLE IF EXISTS `wydawnictwo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wydawnictwo` (
  `id_wydawnictwo` tinyint unsigned NOT NULL AUTO_INCREMENT,
  `nazwa` char(25) NOT NULL,
  PRIMARY KEY (`id_wydawnictwo`),
  UNIQUE KEY `nazwa` (`nazwa`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wydawnictwo`
--

LOCK TABLES `wydawnictwo` WRITE;
/*!40000 ALTER TABLE `wydawnictwo` DISABLE KEYS */;
INSERT INTO `wydawnictwo` VALUES (11,'Albatros'),(6,'BeYa'),(2,'Egmont'),(9,'Jaguar'),(5,'Mag'),(1,'Nasza Księgarnia'),(7,'Otwarte'),(3,'Świat Książki'),(8,'Uroboros'),(4,'Wolne Lektury'),(10,'You & YA');
/*!40000 ALTER TABLE `wydawnictwo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-24 16:08:28
