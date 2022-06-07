-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: diab_stg
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `images`
--

DROP TABLE IF EXISTS `images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `images` (
  `id` varchar(36) NOT NULL,
  `code` varchar(32) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `physical_path` text NOT NULL,
  `title` varchar(250) NOT NULL,
  `type` int NOT NULL,
  `checksum` text NOT NULL,
  `size` bigint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_images_code` (`code`),
  KEY `ix_images_create_datetime` (`create_datetime`),
  KEY `ix_images_creator_id` (`creator_id`),
  KEY `ix_images_is_deleted` (`is_deleted`),
  KEY `ix_images_update_datetime` (`update_datetime`),
  KEY `ix_images_updater_id` (`updater_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `images`
--

LOCK TABLES `images` WRITE;
/*!40000 ALTER TABLE `images` DISABLE KEYS */;
INSERT INTO `images` VALUES ('5464fbab-6b0f-427c-5408-08d9fa0494ed',NULL,0,'2022-02-27 22:19:43','2022-02-27 22:19:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Files\\20220227\\TinyTake23-02-2022-02-51-25-20220227151943403.png','TinyTake23-02-2022-02-51-25.png',13,'3363c82eba7977379f13115500dce17e',81810),('5f39456f-5d2d-4f7a-e235-08da1159c835',NULL,1,'2022-03-29 07:57:33','2022-03-29 08:00:05','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,'Files/20220329/Admin icon-20220329075733489.png','Admin icon.png',13,'1c46b54f0e61fcbb8c03274cd59085a8',2954),('76e49046-375f-410e-3bea-08d9f9e072c7',NULL,0,'2022-02-27 18:01:04','2022-02-27 18:01:04','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Files\\20220227\\ソースマージ-20220227110104293.png','ソースマージ.png',13,'735fbb353c89003362b9a73d852e0cb5',18224),('7fe4ccb5-f634-4910-e236-08da1159c835',NULL,0,'2022-03-29 08:00:05','2022-03-29 08:00:05','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Files/20220329/Admin icon-20220329080005059.png','Admin icon.png',13,'1c46b54f0e61fcbb8c03274cd59085a8',2954);
/*!40000 ALTER TABLE `images` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-07 19:09:16
