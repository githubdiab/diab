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
-- Table structure for table `user_forgot_password_tokens`
--

DROP TABLE IF EXISTS `user_forgot_password_tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_forgot_password_tokens` (
  `id` varchar(36) NOT NULL,
  `code` varchar(32) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `token` varchar(250) NOT NULL,
  `expiration_date` datetime NOT NULL,
  `status` int NOT NULL,
  `dia_baccount_id` varchar(36) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_user_forgot_password_tokens_code` (`code`),
  KEY `ix_user_forgot_password_tokens_create_datetime` (`create_datetime`),
  KEY `ix_user_forgot_password_tokens_creator_id` (`creator_id`),
  KEY `ix_user_forgot_password_tokens_dia_baccount_id` (`dia_baccount_id`),
  KEY `ix_user_forgot_password_tokens_is_deleted` (`is_deleted`),
  KEY `ix_user_forgot_password_tokens_update_datetime` (`update_datetime`),
  KEY `ix_user_forgot_password_tokens_updater_id` (`updater_id`),
  CONSTRAINT `fk_user_forgot_password_tokens_accounts_dia_baccount_id` FOREIGN KEY (`dia_baccount_id`) REFERENCES `accounts` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_forgot_password_tokens`
--

LOCK TABLES `user_forgot_password_tokens` WRITE;
/*!40000 ALTER TABLE `user_forgot_password_tokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_forgot_password_tokens` ENABLE KEYS */;
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
