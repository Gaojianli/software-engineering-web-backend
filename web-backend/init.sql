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

-- 导出  表 acctrl.controllrequest 结构
CREATE TABLE IF NOT EXISTS `controllrequest` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roomID` int(11) NOT NULL,
  `status` tinyint(1) NOT NULL DEFAULT 0,
  `mode` tinyint(1) DEFAULT 1,
  `targetTemp` float DEFAULT 27,
  `fanSpeed` int(11) DEFAULT NULL,
  `nowTemp` int(11) DEFAULT NULL,
  `time` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `roomID` (`roomID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- 正在导出表  acctrl.controllrequest 的数据：~8 rows (大约)
DELETE FROM `controllrequest`;
/*!40000 ALTER TABLE `controllrequest` DISABLE KEYS */;
INSERT INTO `controllrequest` (`id`, `roomID`, `status`, `mode`, `targetTemp`, `fanSpeed`, `nowTemp`, `time`) VALUES
	(3, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:19:07'),
	(4, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:23:35'),
	(5, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:24:20'),
	(6, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:26:36'),
	(7, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:28:14'),
	(8, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:28:43'),
	(9, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:31:43'),
	(10, 5, 1, 1, 27, 2000, 25, '2020-06-13 11:35:28');
/*!40000 ALTER TABLE `controllrequest` ENABLE KEYS */;

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

-- 正在导出表  acctrl.order 的数据：~4 rows (大约)
DELETE FROM `order`;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` (`id`, `roomID`, `checkInTime`, `checkOutTime`, `fee`, `finished`) VALUES
	(2, 5, '2020-06-12 20:20:06', '2020-06-12 21:10:45', 0000000000000000000000, 1),
	(3, 5, '2020-06-12 21:15:44', '2020-06-12 21:15:55', 0000000000000000000000, 1),
	(4, 5, '2020-06-12 21:16:09', '2020-06-12 21:16:12', 0000000000000000000000, 1),
	(5, 5, '2020-06-12 21:16:18', '0001-01-01 00:00:00', 0000000000000000000000, 0);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;

-- 导出  表 acctrl.room 结构
CREATE TABLE IF NOT EXISTS `room` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderID` int(11) DEFAULT 0,
  `latestRequest` int(11) DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `FK__controllrequest` (`latestRequest`),
  CONSTRAINT `FK__controllrequest` FOREIGN KEY (`latestRequest`) REFERENCES `controllrequest` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- 正在导出表  acctrl.room 的数据：~10 rows (大约)
DELETE FROM `room`;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
INSERT INTO `room` (`id`, `orderID`, `latestRequest`) VALUES
	(1, 0, NULL),
	(2, 0, NULL),
	(3, 0, NULL),
	(4, 0, NULL),
	(5, 0, 10),
	(6, 0, NULL),
	(7, 0, NULL),
	(8, 0, NULL),
	(9, 0, NULL),
	(10, 0, NULL);
/*!40000 ALTER TABLE `room` ENABLE KEYS */;

-- 导出  表 acctrl.user 结构
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `password` varchar(100) NOT NULL,
  `role` varchar(10) NOT NULL DEFAULT 'manager',
  PRIMARY KEY (`id`),
  KEY `username` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- 正在导出表  acctrl.user 的数据：~0 rows (大约)
DELETE FROM `user`;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`id`, `name`, `password`, `role`) VALUES
	(3, '114514', '114514', 'manager');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
