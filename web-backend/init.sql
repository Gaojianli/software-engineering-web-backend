-- MySQL dump 10.17  Distrib 10.3.22-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: acctrl
-- ------------------------------------------------------
-- Server version	10.3.22-MariaDB-0+deb10u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `acctrl`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `acctrl` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `acctrl`;

--
-- Table structure for table `ControllRequest`
--

DROP TABLE IF EXISTS `ControllRequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ControllRequest` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roomID` int(11) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT 0,
  `mode` tinyint(2) DEFAULT 1,
  `targetTemp` float DEFAULT 27,
  `fanSpeed` int(11) DEFAULT NULL,
  `nowTemp` int(11) DEFAULT NULL,
  `time` datetime NOT NULL DEFAULT current_timestamp(),
  `orderId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `roomID` (`roomID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ControllRequest`
--

LOCK TABLES `ControllRequest` WRITE;
/*!40000 ALTER TABLE `ControllRequest` DISABLE KEYS */;
INSERT INTO `ControllRequest` VALUES (13,5,1,1,27,2000,25,'2020-06-13 13:30:26',6),(15,5,1,2,23,200,24,'2020-06-13 17:00:41',7),(16,5,1,2,23,200,24,'2020-06-13 17:02:11',7);
/*!40000 ALTER TABLE `ControllRequest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Order`
--

DROP TABLE IF EXISTS `Order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Order` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `roomID` int(10) unsigned NOT NULL,
  `checkInTime` datetime DEFAULT current_timestamp(),
  `checkOutTime` datetime DEFAULT NULL,
  `fee` double unsigned zerofill NOT NULL DEFAULT 0000000000000000000000,
  `finished` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Order`
--

LOCK TABLES `Order` WRITE;
/*!40000 ALTER TABLE `Order` DISABLE KEYS */;
INSERT INTO `Order` VALUES (2,5,'2020-06-12 20:20:06','2020-06-12 21:10:45',0000000000000000000000,1),(3,5,'2020-06-12 21:15:44','2020-06-12 21:15:55',0000000000000000000000,1),(4,5,'2020-06-12 21:16:09','2020-06-12 21:16:12',0000000000000000000000,1),(5,5,'2020-06-12 21:16:18','2020-06-13 13:30:05',0000000000000000000000,1),(6,5,'2020-06-13 13:30:08','2020-06-13 16:57:42',0000000000000000000000,1),(7,5,'2020-06-13 16:58:26','0001-01-01 00:00:00',0000000000000000000000,0);
/*!40000 ALTER TABLE `Order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Room`
--

DROP TABLE IF EXISTS `Room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Room` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderID` int(11) DEFAULT 0,
  `latestRequest` int(11) DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Room`
--

LOCK TABLES `Room` WRITE;
/*!40000 ALTER TABLE `Room` DISABLE KEYS */;
INSERT INTO `Room` VALUES (1,0,0),(2,0,0),(3,0,0),(4,0,0),(5,7,16),(6,0,0),(7,0,0),(8,0,0),(9,0,0),(10,0,0);
/*!40000 ALTER TABLE `Room` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `User`
--

DROP TABLE IF EXISTS `User`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `User` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `password` varchar(100) NOT NULL,
  `role` varchar(10) NOT NULL DEFAULT 'manager',
  PRIMARY KEY (`id`),
  KEY `username` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `User`
--

LOCK TABLES `User` WRITE;
/*!40000 ALTER TABLE `User` DISABLE KEYS */;
INSERT INTO `User` VALUES (3,'114514','114514','manager');
/*!40000 ALTER TABLE `User` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-13 17:24:25
