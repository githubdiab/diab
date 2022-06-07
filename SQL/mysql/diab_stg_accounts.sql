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
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accounts` (
  `id` varchar(36) NOT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `username` varchar(30) NOT NULL,
  `first_name` varchar(250) DEFAULT NULL,
  `middle_name` varchar(250) DEFAULT NULL,
  `last_name` varchar(250) DEFAULT NULL,
  `date_of_birth` datetime DEFAULT NULL,
  `gender` int DEFAULT NULL,
  `code` varchar(100) NOT NULL,
  `facebook_user_id` text,
  `google_user_id` text,
  `phone_number` varchar(13) DEFAULT NULL,
  `phone_number_verified` tinyint(1) NOT NULL,
  `force_change_password` tinyint(1) NOT NULL,
  `hashed_password` varchar(500) NOT NULL,
  `password_salt` varchar(100) NOT NULL,
  `nation_id` varchar(36) DEFAULT NULL,
  `province_id` varchar(36) DEFAULT NULL,
  `district_id` varchar(36) DEFAULT NULL,
  `ward_id` varchar(36) DEFAULT NULL,
  `address` text,
  `cover_id` varchar(36) DEFAULT NULL,
  `email` text,
  `active` tinyint(1) NOT NULL DEFAULT '0',
  `account_type` int NOT NULL DEFAULT '0',
  `second_phone_number` varchar(13) DEFAULT NULL,
  `full_name_search` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_accounts_code` (`code`),
  UNIQUE KEY `ix_accounts_username` (`username`),
  KEY `ix_accounts_create_datetime` (`create_datetime`),
  KEY `ix_accounts_creator_id` (`creator_id`),
  KEY `ix_accounts_district_id` (`district_id`),
  KEY `ix_accounts_is_deleted` (`is_deleted`),
  KEY `ix_accounts_nation_id` (`nation_id`),
  KEY `ix_accounts_province_id` (`province_id`),
  KEY `ix_accounts_update_datetime` (`update_datetime`),
  KEY `ix_accounts_updater_id` (`updater_id`),
  KEY `ix_accounts_ward_id` (`ward_id`),
  CONSTRAINT `fk_accounts_districts_district_id` FOREIGN KEY (`district_id`) REFERENCES `districts` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `fk_accounts_nations_nation_id` FOREIGN KEY (`nation_id`) REFERENCES `nations` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `fk_accounts_provinces_province_id` FOREIGN KEY (`province_id`) REFERENCES `provinces` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `fk_accounts_wards_ward_id` FOREIGN KEY (`ward_id`) REFERENCES `wards` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` VALUES ('715201ca-af1e-4962-8f06-d719de7531af',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','superhero1','leopard','','','2019-12-28 17:00:00',1,'Coach superhero1',NULL,NULL,'+84703343412',0,0,'dummy','dummy','2857c61e-d5d2-4a7c-810c-1e7ab9e25d86',NULL,NULL,NULL,NULL,NULL,'hero@gmail.com',1,1,NULL,'leopard'),('86b8a36b-15e4-40e9-87d3-15ad42a6210a',0,'2022-01-10 00:25:12','2022-01-10 00:25:12','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','phuthao19','phuthao','','','2022-01-01 17:00:00',1,'Coach phuthao19',NULL,NULL,'+84702112615',0,0,'dummy','dummy','2857c61e-d5d2-4a7c-810c-1e7ab9e25d86','0437e75e-6ab2-4334-a463-088da8a2776a','f1f5a89d-d332-41d7-8416-75dc0c3a3607','af884fa3-e9f7-433f-8604-71fdb5206791',NULL,NULL,'robinle1902@gmail.com',1,1,NULL,'phuthao'),('a8b898c7-0dfd-438f-96e9-b9b9e3e18f37',0,'2021-12-27 21:33:42','2021-12-27 22:24:24','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','user01','User',' ','01','1991-10-19 17:00:00',1,'B1',NULL,NULL,NULL,0,0,'0','0','2857c61e-d5d2-4a7c-810c-1e7ab9e25d86','f5cb671d-0392-414c-af9c-bcb64cea806d','7280b5ad-e765-47c0-b810-b18c965f7846','c77c5200-8f00-4ecf-ad5d-80c0c62635e3',NULL,NULL,NULL,1,1,NULL,NULL),('cb356d0b-b62b-4418-a295-b2b71393fba6',0,'2021-12-27 21:33:42','2021-12-27 22:24:27','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','admin01','Admin',' ','01','1991-10-19 17:00:00',1,'A1',NULL,NULL,NULL,0,0,'0','0','2857c61e-d5d2-4a7c-810c-1e7ab9e25d86','f5cb671d-0392-414c-af9c-bcb64cea806d','7280b5ad-e765-47c0-b810-b18c965f7846','c77c5200-8f00-4ecf-ad5d-80c0c62635e3',NULL,NULL,'quochuy91.np@gmail.com',1,0,NULL,NULL),('ef1562a1-07ec-40de-a654-3db6300ae631',0,'2021-12-27 21:44:39','2021-12-27 21:44:39','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','quochuy91','quochuy','','','1991-10-19 17:00:00',1,'Coach quochuy91',NULL,NULL,'+84123568795',0,0,'dummy','dummy','2857c61e-d5d2-4a7c-810c-1e7ab9e25d86','510b3d22-c77b-404b-acaa-c0c927336e58','be99a86b-d566-41bc-b62c-91a0a8c021a7','1e2a2016-2800-4452-8c04-bc4d397bea91','a',NULL,'quochuy91.np@gmail.com',1,1,NULL,'quochuy');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-07 19:09:15
