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
-- Table structure for table `common_configures`
--

DROP TABLE IF EXISTS `common_configures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `common_configures` (
  `id` varchar(36) NOT NULL,
  `code` varchar(32) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `key` text NOT NULL,
  `value` text NOT NULL,
  `configure_setup_type` int DEFAULT NULL,
  `description` text,
  `name` text,
  `short_description` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_common_configures_code` (`code`),
  KEY `ix_common_configures_create_datetime` (`create_datetime`),
  KEY `ix_common_configures_creator_id` (`creator_id`),
  KEY `ix_common_configures_is_deleted` (`is_deleted`),
  KEY `ix_common_configures_update_datetime` (`update_datetime`),
  KEY `ix_common_configures_updater_id` (`updater_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `common_configures`
--

LOCK TABLES `common_configures` WRITE;
/*!40000 ALTER TABLE `common_configures` DISABLE KEYS */;
INSERT INTO `common_configures` VALUES ('1b168b70-8f5c-4ff5-be5f-cef166c01c2b','1b168b708f5c4ff5be5fcef166c01c2b',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Orange3','#FCB276',2,'','param','param'),('1bff30c4-27d9-4625-9905-93192652fdc3','1bff30c427d94625990593192652fdc3',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Green4','#9CD9B8',2,'','param','param'),('2443197b-2470-4bc5-aca8-bc83e57c7f6d','2443197b24704bc5aca8bc83e57c7f6d',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Main2','#008479',2,'','param','param'),('45b40e37-db47-4f77-b048-ec86bfeebad7','45b40e37db474f77b048ec86bfeebad7',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Red4','#FF8E8E',2,'','param','param'),('4e09259c-3e0e-4737-928d-a15c775fd61d','4e09259c3e0e4737928da15c775fd61d',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Gray2','#787A7D',2,'','param','param'),('752020f3-ae62-4954-8d34-51d584821bdd','752020f3ae6249548d3451d584821bdd',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Yellow1','#FDB913',2,'','param','param'),('9e3aaeb2-5ecc-4852-9b67-ae316db681bf','9e3aaeb25ecc48529b67ae316db681bf',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Green6','#E6F6ED',2,'','param','param'),('a04622c6-0cbe-47c2-b187-97d39ec00484','a04622c60cbe47c2b18797d39ec00484',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Main1','#01645A',2,'','param','param'),('a8e1d48e-121d-4ebe-a7ac-ec4757c23ce6','a8e1d48e121d4ebea7acec4757c23ce6',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Red1','#E53935',2,'','param','param'),('cdc02c28-8ed8-4717-bdfc-838bd8bd956f','cdc02c288ed84717bdfc838bd8bd956f',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Red5','#FFCDD2',2,'','param','param'),('db257890-46ba-4294-8b29-4f33081074c6','db25789046ba42948b294f33081074c6',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Orange1','#F58220',2,'','param','param'),('e750ff85-252f-43d0-ad80-a04edff099f2','e750ff85252f43d0ad80a04edff099f2',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Green1','#21A567',2,'','param','param'),('e8f9885c-8a5d-405f-b011-30614006e790','e8f9885c8a5d405fb01130614006e790',0,'2021-12-27 15:28:45','2021-12-27 17:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Color.Red6','#FFE3E3',2,'','param','param');
/*!40000 ALTER TABLE `common_configures` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-07 19:09:17
