-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: autoparking
-- ------------------------------------------------------
-- Server version	5.5.49

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admins` (
  `Id` int(11) NOT NULL,
  `Name` varchar(80) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admins`
--

LOCK TABLES `admins` WRITE;
/*!40000 ALTER TABLE `admins` DISABLE KEYS */;
INSERT INTO `admins` VALUES (1,'Leonid','grg853m'),(2,'Misha','lt4k4m2k'),(3,'Vitalik','1112');
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cars`
--

DROP TABLE IF EXISTS `cars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cars` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `SerialNum` varchar(45) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `ClientsId` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`ClientsId`),
  KEY `fk_cars_clients1_idx` (`ClientsId`),
  CONSTRAINT `fk_cars_clients1` FOREIGN KEY (`ClientsId`) REFERENCES `clients` (`Id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cars`
--

LOCK TABLES `cars` WRITE;
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` VALUES (1,'car1','fdf3432','2016-12-15',1),(2,'car2','ffg5335','2016-12-15',1),(3,'car3','fhj1456','2016-12-15',2),(4,'car4','fh43335','2016-12-15',1),(5,'car5','dvy3343','2016-12-15',2),(6,'gfdsg','re435','2016-12-26',1),(7,'DBJ','fddfef','2016-12-30',1),(8,'ergweg1','ew1','2016-12-30',1);
/*!40000 ALTER TABLE `cars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clients` (
  `Id` int(11) NOT NULL,
  `Name` varchar(80) NOT NULL,
  `PassportId` varchar(45) DEFAULT NULL,
  `RegistrationDate` date DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `IsBlock` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'Client1','TT544912','2016-10-11','1111',0),(2,'Client2','TT538975','2016-10-12','1111',0),(3,'Client3','TT398989','2016-11-09','1111',0);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `placedcars`
--

DROP TABLE IF EXISTS `placedcars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `placedcars` (
  `IdCar` int(11) NOT NULL,
  `IdPlace` int(11) NOT NULL,
  PRIMARY KEY (`IdCar`,`IdPlace`),
  KEY `fk_placedCars_places1_idx` (`IdPlace`),
  CONSTRAINT `fk_placedCars_cars1` FOREIGN KEY (`IdCar`) REFERENCES `cars` (`Id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_placedCars_places1` FOREIGN KEY (`IdPlace`) REFERENCES `places` (`Id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `placedcars`
--

LOCK TABLES `placedcars` WRITE;
/*!40000 ALTER TABLE `placedcars` DISABLE KEYS */;
INSERT INTO `placedcars` VALUES (1,1),(2,2),(3,3),(4,4),(5,5);
/*!40000 ALTER TABLE `placedcars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `places`
--

DROP TABLE IF EXISTS `places`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `places` (
  `Id` int(11) NOT NULL,
  `IsAvailable` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `places`
--

LOCK TABLES `places` WRITE;
/*!40000 ALTER TABLE `places` DISABLE KEYS */;
INSERT INTO `places` VALUES (1,0),(2,0),(3,0),(4,0),(5,0),(6,1),(7,1),(8,1),(9,1),(10,1);
/*!40000 ALTER TABLE `places` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'autoparking'
--

--
-- Dumping routines for database 'autoparking'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-01-05 23:01:10
