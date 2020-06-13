-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        10.4.13-MariaDB - mariadb.org binary distribution
-- 服务器操作系统:                      Win64
-- HeidiSQL 版本:                  11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- 导出 acctrl 的数据库结构
CREATE DATABASE IF NOT EXISTS `acctrl` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `acctrl`;


-- 导出  表 acctrl.order 结构
CREATE TABLE IF NOT EXISTS `order` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `roomID` int(10) unsigned NOT NULL,
  `checkInTime` datetime DEFAULT current_timestamp(),
  `checkOutTime` datetime DEFAULT NULL,
  `fee` double unsigned zerofill NOT NULL DEFAULT 0000000000000000000000,
  `finished` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;


-- 导出  表 acctrl.user 结构
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `password` varchar(100) NOT NULL,
  `role` varchar(10) NOT NULL DEFAULT 'manager',
  PRIMARY KEY (`id`),
  KEY `username` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;


-- 导出  表 acctrl.controllrequest 结构
CREATE TABLE IF NOT EXISTS `controllrequest` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roomID` int(11) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT 0,
  `mode` tinyint(1) NOT NULL DEFAULT 1,
  `targetTemp` float DEFAULT 27,
  `fanSpeed` int(11) DEFAULT NULL,
  `nowTemp` int(11) DEFAULT NULL,
  `time` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `roomID` (`roomID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 导出  表 acctrl.room 结构
CREATE TABLE IF NOT EXISTS `room` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderID` int(11) DEFAULT 0,
  `latestRequest` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `FK__controllrequest` (`latestRequest`),
  CONSTRAINT `FK__controllrequest` FOREIGN KEY (`latestRequest`) REFERENCES `controllrequest` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- 正在导出表  acctrl.room 的数据：~0 rows (大约)
DELETE FROM `room`;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` (`id`, `orderID`, `latestRequest`) VALUES
	(1, 0, NULL),
	(2, 0, NULL),
	(3, 0, NULL),
	(4, 0, NULL),
	(5, 0, NULL),
	(6, 0, NULL),
	(7, 0, NULL),
	(8, 0, NULL),
	(9, 0, NULL),
	(10, 0, NULL);



