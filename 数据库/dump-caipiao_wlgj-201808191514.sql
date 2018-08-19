-- MySQL dump 10.13  Distrib 5.7.19, for Win64 (x86_64)
--
-- Host: localhost    Database: caipiao_wlgj
-- ------------------------------------------------------
-- Server version	5.7.19-log

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
-- Table structure for table `admin_quanxian`
--

DROP TABLE IF EXISTS `admin_quanxian`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admin_quanxian` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `adminid` int(11) NOT NULL,
  `adminname` varchar(64) DEFAULT NULL,
  `qxid` int(11) NOT NULL,
  `qxname` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin_quanxian`
--

LOCK TABLES `admin_quanxian` WRITE;
/*!40000 ALTER TABLE `admin_quanxian` DISABLE KEYS */;
/*!40000 ALTER TABLE `admin_quanxian` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `caizhong`
--

DROP TABLE IF EXISTS `caizhong`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `caizhong` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `czname` varchar(32) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caizhong`
--

LOCK TABLES `caizhong` WRITE;
/*!40000 ALTER TABLE `caizhong` DISABLE KEYS */;
INSERT INTO `caizhong` VALUES (1,'2018-08-19 06:17:19','重庆彩',NULL),(2,'2018-08-19 06:17:19','龙江彩',NULL),(3,'2018-08-19 06:17:28','新疆彩',NULL),(4,'2018-08-19 06:17:28','时时乐',NULL),(5,'2018-08-19 06:17:28','福彩3D',NULL),(6,'2018-08-19 06:17:28','江西彩',NULL),(7,'2018-08-19 06:17:28','11运夺金',NULL),(8,'2018-08-19 06:17:28','49选一',NULL),(9,'2018-08-19 06:17:28','快乐十分',NULL),(10,'2018-08-19 06:17:28','江西11x5',NULL),(11,'2018-08-19 06:17:28','广东11x5',NULL),(12,'2018-08-19 06:17:28','重庆11x5',NULL),(13,'2018-08-19 06:17:28','天津彩',NULL),(14,'2018-08-19 06:17:28','六合彩',NULL),(15,'2018-08-19 06:17:28','安徽快3',NULL),(16,'2018-08-19 06:17:28','福建快3',NULL),(17,'2018-08-19 06:17:28','排列三',NULL),(18,'2018-08-19 06:17:28','排列五',NULL),(19,'2018-08-19 06:17:28','江苏快3',NULL),(20,'2018-08-19 06:17:28','广西快3',NULL),(21,'2018-08-19 06:17:28','分分彩',NULL),(22,'2018-08-19 06:17:28','两分彩',NULL),(23,'2018-08-19 06:17:28','北京PK拾',NULL);
/*!40000 ALTER TABLE `caizhong` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chongzhi`
--

DROP TABLE IF EXISTS `chongzhi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chongzhi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `userid` int(11) NOT NULL,
  `username` varchar(64) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `money` decimal(9,2) NOT NULL,
  `bankname` varchar(128) DEFAULT NULL,
  `realname` varchar(128) DEFAULT NULL,
  `bankno` varchar(128) DEFAULT NULL,
  `paytype` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chongzhi`
--

LOCK TABLES `chongzhi` WRITE;
/*!40000 ALTER TABLE `chongzhi` DISABLE KEYS */;
/*!40000 ALTER TABLE `chongzhi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emailset`
--

DROP TABLE IF EXISTS `emailset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `emailset` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `email` varchar(128) NOT NULL,
  `password` varchar(128) NOT NULL,
  `smtp` varchar(128) NOT NULL,
  `cur` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emailset`
--

LOCK TABLES `emailset` WRITE;
/*!40000 ALTER TABLE `emailset` DISABLE KEYS */;
/*!40000 ALTER TABLE `emailset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gudong`
--

DROP TABLE IF EXISTS `gudong`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gudong` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `username` varchar(64) DEFAULT NULL,
  `email` varchar(128) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gudong`
--

LOCK TABLES `gudong` WRITE;
/*!40000 ALTER TABLE `gudong` DISABLE KEYS */;
/*!40000 ALTER TABLE `gudong` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `liushui`
--

DROP TABLE IF EXISTS `liushui`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `liushui` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `userid` int(11) NOT NULL,
  `username` varchar(64) DEFAULT NULL,
  `beforemoney` decimal(9,3) NOT NULL,
  `changemoney` decimal(9,3) NOT NULL,
  `aftermoney` decimal(9,3) NOT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `type` int(11) NOT NULL,
  `xzid` int(11) NOT NULL,
  `txid` int(11) NOT NULL,
  `czid` int(11) NOT NULL,
  `fhdate` varchar(16) DEFAULT NULL,
  `czr` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `liushui`
--

LOCK TABLES `liushui` WRITE;
/*!40000 ALTER TABLE `liushui` DISABLE KEYS */;
/*!40000 ALTER TABLE `liushui` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `news` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `title` varchar(256) DEFAULT NULL,
  `body` text,
  `cabh` varchar(64) DEFAULT NULL,
  `caname` varchar(64) DEFAULT NULL,
  `visitnum` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qihaoinfo`
--

DROP TABLE IF EXISTS `qihaoinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `qihaoinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `qihao` varchar(32) DEFAULT NULL,
  `starttime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `endtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `kjtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `remark` varchar(1024) DEFAULT NULL,
  `czid` int(11) NOT NULL,
  `czname` varchar(32) DEFAULT NULL,
  `kjcode` varchar(512) DEFAULT NULL,
  `kjcode2` varchar(512) DEFAULT NULL,
  `code1` int(11) NOT NULL,
  `code2` int(11) NOT NULL,
  `code3` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qihaoinfo`
--

LOCK TABLES `qihaoinfo` WRITE;
/*!40000 ALTER TABLE `qihaoinfo` DISABLE KEYS */;
INSERT INTO `qihaoinfo` VALUES (1,'2018-08-19 07:13:25','699165','2018-08-19 03:07:00','2018-08-19 03:11:00','2018-08-19 03:12:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(2,'2018-08-19 07:13:25','699166','2018-08-19 03:12:00','2018-08-19 03:16:00','2018-08-19 03:17:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(3,'2018-08-19 07:13:25','699167','2018-08-19 03:17:00','2018-08-19 03:21:00','2018-08-19 03:22:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(4,'2018-08-19 07:13:25','699168','2018-08-19 03:22:00','2018-08-19 03:26:00','2018-08-19 03:27:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(5,'2018-08-19 07:13:25','699169','2018-08-19 03:27:00','2018-08-19 03:31:00','2018-08-19 03:32:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(6,'2018-08-19 07:13:25','699170','2018-08-19 03:32:00','2018-08-19 03:36:00','2018-08-19 03:37:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(7,'2018-08-19 07:13:25','699171','2018-08-19 03:37:00','2018-08-19 03:41:00','2018-08-19 03:42:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(8,'2018-08-19 07:13:25','699172','2018-08-19 03:42:00','2018-08-19 03:46:00','2018-08-19 03:47:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(9,'2018-08-19 07:13:25','699173','2018-08-19 03:47:00','2018-08-19 03:51:00','2018-08-19 03:52:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(10,'2018-08-19 07:13:25','699174','2018-08-19 03:52:00','2018-08-19 03:56:00','2018-08-19 03:57:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(11,'2018-08-19 07:13:25','699175','2018-08-19 03:57:00','2018-08-19 04:01:00','2018-08-19 04:02:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(12,'2018-08-19 07:13:25','699176','2018-08-19 04:02:00','2018-08-19 04:06:00','2018-08-19 04:07:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(13,'2018-08-19 07:13:25','699177','2018-08-19 04:07:00','2018-08-19 04:11:00','2018-08-19 04:12:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(14,'2018-08-19 07:13:25','699178','2018-08-19 04:12:00','2018-08-19 04:16:00','2018-08-19 04:17:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(15,'2018-08-19 07:13:25','699179','2018-08-19 04:17:00','2018-08-19 04:21:00','2018-08-19 04:22:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(16,'2018-08-19 07:13:25','699180','2018-08-19 04:22:00','2018-08-19 04:26:00','2018-08-19 04:27:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(17,'2018-08-19 07:13:25','699181','2018-08-19 04:27:00','2018-08-19 04:31:00','2018-08-19 04:32:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(18,'2018-08-19 07:13:25','699182','2018-08-19 04:32:00','2018-08-19 04:36:00','2018-08-19 04:37:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(19,'2018-08-19 07:13:26','699183','2018-08-19 04:37:00','2018-08-19 04:41:00','2018-08-19 04:42:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0),(20,'2018-08-19 07:13:26','699184','2018-08-19 04:42:00','2018-08-19 04:46:00','2018-08-19 04:47:00',NULL,23,'北京PK拾',NULL,NULL,0,0,0);
/*!40000 ALTER TABLE `qihaoinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quanxian`
--

DROP TABLE IF EXISTS `quanxian`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `quanxian` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `qxname` varchar(64) DEFAULT NULL,
  `url` varchar(1024) DEFAULT NULL,
  `bh` varchar(64) DEFAULT NULL,
  `pbh` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quanxian`
--

LOCK TABLES `quanxian` WRITE;
/*!40000 ALTER TABLE `quanxian` DISABLE KEYS */;
/*!40000 ALTER TABLE `quanxian` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shuxing`
--

DROP TABLE IF EXISTS `shuxing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shuxing` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `sxname` varchar(128) DEFAULT NULL,
  `sxvalue` varchar(128) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shuxing`
--

LOCK TABLES `shuxing` WRITE;
/*!40000 ALTER TABLE `shuxing` DISABLE KEYS */;
/*!40000 ALTER TABLE `shuxing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tixian`
--

DROP TABLE IF EXISTS `tixian`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tixian` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `userid` int(11) NOT NULL,
  `username` varchar(64) DEFAULT NULL,
  `money` decimal(9,2) NOT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `replay` varchar(1024) DEFAULT NULL,
  `bankno` varchar(128) DEFAULT NULL,
  `bankname` varchar(128) DEFAULT NULL,
  `realname` varchar(64) DEFAULT NULL,
  `userbankid` int(11) NOT NULL,
  `khh` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tixian`
--

LOCK TABLES `tixian` WRITE;
/*!40000 ALTER TABLE `tixian` DISABLE KEYS */;
/*!40000 ALTER TABLE `tixian` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userbank`
--

DROP TABLE IF EXISTS `userbank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userbank` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `userid` int(11) NOT NULL,
  `username` varchar(64) DEFAULT NULL,
  `bankname` varchar(64) DEFAULT NULL,
  `bankno` varchar(64) DEFAULT NULL,
  `realname` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  `khh` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userbank`
--

LOCK TABLES `userbank` WRITE;
/*!40000 ALTER TABLE `userbank` DISABLE KEYS */;
/*!40000 ALTER TABLE `userbank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userinfo`
--

DROP TABLE IF EXISTS `userinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `username` varchar(32) DEFAULT NULL,
  `email` varchar(32) DEFAULT NULL,
  `password` varchar(32) DEFAULT NULL,
  `txpassword` varchar(32) DEFAULT NULL,
  `mobile` varchar(32) DEFAULT NULL,
  `address` varchar(512) DEFAULT NULL,
  `bankno` varchar(64) DEFAULT NULL,
  `bankname` varchar(32) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT '0',
  `realname` varchar(32) DEFAULT NULL,
  `idcard` varchar(32) DEFAULT NULL,
  `balance` decimal(9,3) NOT NULL DEFAULT '0.000',
  `password3` varchar(64) DEFAULT NULL,
  `erweima` varchar(1024) DEFAULT NULL,
  `parentid` int(11) NOT NULL DEFAULT '0',
  `parentname` varchar(64) DEFAULT NULL,
  `parentpath` varchar(2048) DEFAULT NULL,
  `question` varchar(128) DEFAULT NULL,
  `answer` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userinfo`
--

LOCK TABLES `userinfo` WRITE;
/*!40000 ALTER TABLE `userinfo` DISABLE KEYS */;
INSERT INTO `userinfo` VALUES (1,'2018-08-19 06:01:39','admin',NULL,'33F3929AB3234E35D759ED70580EA815','33F3929AB3234E35D759ED70580EA815',NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,0.000,NULL,NULL,0,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `userinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wanfa`
--

DROP TABLE IF EXISTS `wanfa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wanfa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `wfname` varchar(64) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `czid` int(11) NOT NULL DEFAULT '0',
  `basemoney` decimal(9,2) NOT NULL DEFAULT '0.00',
  `groupname` varchar(64) DEFAULT NULL,
  `peilv` decimal(9,2) NOT NULL DEFAULT '0.00',
  `isshow` int(11) NOT NULL DEFAULT '0',
  `shortname` varchar(64) DEFAULT NULL,
  `sort` int(11) NOT NULL DEFAULT '0',
  `bigname` varchar(64) DEFAULT NULL,
  `tesu` int(11) NOT NULL DEFAULT '0',
  `tesu_peilv` decimal(9,2) NOT NULL DEFAULT '0.00',
  `tesu_je` decimal(9,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20001006 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wanfa`
--

LOCK TABLES `wanfa` WRITE;
/*!40000 ALTER TABLE `wanfa` DISABLE KEYS */;
INSERT INTO `wanfa` VALUES (20000000,'2018-08-19 06:24:00','pk拾普通下注复式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000101,'2018-08-19 06:24:00','pk拾猜冠军',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000201,'2018-08-19 06:24:00','pk拾猜前二单式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000202,'2018-08-19 06:24:00','pk拾猜前二复式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000301,'2018-08-19 06:24:00','pk拾猜前三单式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000302,'2018-08-19 06:24:00','pk拾猜前三复式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000401,'2018-08-19 06:24:00','pk拾猜前四单式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000402,'2018-08-19 06:24:00','pk拾猜前四复式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000501,'2018-08-19 06:24:00','pk拾猜前五单式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000502,'2018-08-19 06:24:00','pk拾猜前五复式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000601,'2018-08-19 06:24:00','pk拾猜前六单式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000602,'2018-08-19 06:24:00','pk拾猜前六复式',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000701,'2018-08-19 06:24:00','pk拾定位胆1-5',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000702,'2018-08-19 06:24:00','pk拾定位胆6-10',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000801,'2018-08-19 06:24:00','pk拾大小单双冠军',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000802,'2018-08-19 06:24:00','pk拾大小单双亚军',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000803,'2018-08-19 06:24:00','pk拾大小单双季军',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000901,'2018-08-19 06:24:00','pk拾龙虎冠军',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000902,'2018-08-19 06:24:00','pk拾龙虎亚军',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000903,'2018-08-19 06:24:00','pk拾龙虎季军',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000904,'2018-08-19 06:24:00','pk拾龙虎第四名',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20000905,'2018-08-19 06:24:00','pk拾龙虎第五名',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20001001,'2018-08-19 06:24:00','pk拾和值冠亚',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20001002,'2018-08-19 06:24:00','pk拾和值中二',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20001003,'2018-08-19 06:24:00','pk拾和值后二',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20001004,'2018-08-19 06:24:00','pk拾和值前三',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00),(20001005,'2018-08-19 06:24:00','pk拾和值后三',NULL,23,0.00,'北京PK拾',1.00,0,NULL,0,NULL,0,0.00,0.00);
/*!40000 ALTER TABLE `wanfa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `xiazhuinfo`
--

DROP TABLE IF EXISTS `xiazhuinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `xiazhuinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `userid` int(11) NOT NULL,
  `username` varchar(32) DEFAULT NULL,
  `czid` int(11) NOT NULL,
  `czname` varchar(32) DEFAULT NULL,
  `wfid` int(11) NOT NULL,
  `wfname` varchar(64) DEFAULT NULL,
  `buycode` varchar(128) DEFAULT NULL,
  `beishu` decimal(9,2) NOT NULL,
  `buymoney` decimal(9,3) NOT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `qihao` varchar(32) DEFAULT NULL,
  `iszj` int(11) NOT NULL,
  `zjmoney` decimal(9,3) NOT NULL,
  `kjcode` varchar(64) DEFAULT NULL,
  `shouxufee` decimal(9,3) NOT NULL,
  `czr` varchar(64) DEFAULT NULL,
  `kjtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `xiazhuinfo`
--

LOCK TABLES `xiazhuinfo` WRITE;
/*!40000 ALTER TABLE `xiazhuinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `xiazhuinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yugengdan`
--

DROP TABLE IF EXISTS `yugengdan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `yugengdan` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `adminid` int(11) NOT NULL,
  `adminname` varchar(64) DEFAULT NULL,
  `userid` int(11) NOT NULL,
  `username` varchar(64) DEFAULT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yugengdan`
--

LOCK TABLES `yugengdan` WRITE;
/*!40000 ALTER TABLE `yugengdan` DISABLE KEYS */;
/*!40000 ALTER TABLE `yugengdan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'caipiao_wlgj'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-19 15:14:24
