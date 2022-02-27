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
-- Table structure for table `survey_import_results`
--

DROP TABLE IF EXISTS `survey_import_results`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `survey_import_results` (
  `id` varchar(36) NOT NULL,
  `code` varchar(32) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `hba1c_val` int NOT NULL DEFAULT '0',
  `bmi_val` int NOT NULL DEFAULT '0',
  `kt_bl_val` int NOT NULL DEFAULT '0',
  `kt_tdcs_val` int NOT NULL DEFAULT '0',
  `kt_dd_val` int NOT NULL DEFAULT '0',
  `kt_vd_val` int NOT NULL DEFAULT '0',
  `kt_th_val` int NOT NULL DEFAULT '0',
  `kt_tlhv_val` int NOT NULL DEFAULT '0',
  `kt_val` int NOT NULL DEFAULT '0',
  `kt_nxtq` text,
  `kntcs_ht_val` int NOT NULL DEFAULT '0',
  `kntcs_csbc_val` int NOT NULL DEFAULT '0',
  `kntcs_tddh_val` int NOT NULL DEFAULT '0',
  `kntcs_cdvd_val` int NOT NULL DEFAULT '0',
  `kntcs_cdau_val` int NOT NULL DEFAULT '0',
  `kntcs_val` int NOT NULL DEFAULT '0',
  `kntcs_nxtq` text,
  `mdrc_dt_val` int NOT NULL DEFAULT '0',
  `mdrc_dh_val` int NOT NULL DEFAULT '0',
  `mdrc_cdvd_val` int NOT NULL DEFAULT '0',
  `mdrc_cdau_val` int NOT NULL DEFAULT '0',
  `mdrc_val` int NOT NULL DEFAULT '0',
  `mdrc_nxtq` text,
  `kndctl_ctlqdbs_val` int NOT NULL DEFAULT '0',
  `kndctl_cttcmqh_val` int NOT NULL DEFAULT '0',
  `kndctl_gnvttdt_val` int NOT NULL DEFAULT '0',
  `kndctl_gncx_val` int NOT NULL DEFAULT '0',
  `kndctl_val` int NOT NULL DEFAULT '0',
  `kndctl_nxtq` text,
  `dltd_dltdbt_val` int NOT NULL DEFAULT '0',
  `dltd_dltdbn_val` int NOT NULL DEFAULT '0',
  `dltd_val` int NOT NULL DEFAULT '0',
  `dltd_nxtq` text,
  `nxtq` text,
  `dxvmt_nxtq` text,
  `khvhd_nxtq` text,
  `is_close` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_survey_import_results_code` (`code`),
  KEY `ix_survey_import_results_create_datetime` (`create_datetime`),
  KEY `ix_survey_import_results_update_datetime` (`update_datetime`),
  KEY `ix_survey_import_results_creator_id` (`creator_id`),
  KEY `ix_survey_import_results_updater_id` (`updater_id`),
  KEY `ix_survey_import_results_is_deleted` (`is_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `survey_import_results`
--

LOCK TABLES `survey_import_results` WRITE;
/*!40000 ALTER TABLE `survey_import_results` DISABLE KEYS */;
INSERT INTO `survey_import_results` VALUES ('02736a98-1a97-4878-a4d4-08d9f9f9a7a4',NULL,1,'2022-02-27 21:05:51','2022-02-27 21:30:53','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('1540400d-76c2-4e5c-3137-08d9f9fe7447',NULL,0,'2022-02-27 21:39:49','2022-02-27 21:39:49','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('15e3001d-11a1-44c9-f835-08d9f9f8ef49',NULL,0,'2022-02-27 20:58:05','2022-02-27 20:58:05','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('1b804d6e-393e-4d98-3e08-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('2cf0763e-4d5b-42f5-3dfc-08d9f9fd6613',NULL,1,'2022-02-27 21:28:18','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('2e2c06d1-031d-4cb9-f834-08d9f9f8ef49',NULL,0,'2022-02-27 20:58:00','2022-02-27 20:58:00','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('3f2f1502-c646-482f-a4d8-08d9f9f9a7a4',NULL,1,'2022-02-27 21:07:46','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('42f11756-3f5b-43e3-a4d0-08d9f9f9a7a4',NULL,0,'2022-02-27 21:03:03','2022-02-27 21:03:03','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('443195ff-2eaf-49a4-3e01-08d9f9fd6613',NULL,1,'2022-02-27 21:30:53','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('45966c57-3ad8-4ef6-f833-08d9f9f8ef49',NULL,0,'2022-02-27 20:56:51','2022-02-27 20:56:51','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('48f71b07-8cde-43de-3e09-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('56e57538-cab4-45b5-a4ce-08d9f9f9a7a4',NULL,1,'2022-02-27 21:01:30','2022-02-27 21:28:18','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('6465cc39-7e40-4e2a-3e05-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('646cd4c0-ae7b-4953-a4d3-08d9f9f9a7a4',NULL,1,'2022-02-27 21:05:15','2022-02-27 21:30:47','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('65423175-467f-4a35-a4cf-08d9f9f9a7a4',NULL,1,'2022-02-27 21:02:46','2022-02-27 21:28:18','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('7964e506-ae7f-4432-3dfe-08d9f9fd6613',NULL,1,'2022-02-27 21:30:47','2022-02-27 21:30:53','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('8bf29ea7-e64f-4fed-3e04-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('9a5b85a4-9220-4f8f-a4d2-08d9f9f9a7a4',NULL,1,'2022-02-27 21:04:34','2022-02-27 21:30:47','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('a36ac583-c937-48f3-3e0c-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('aa018009-f371-48ad-3e0b-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('b16bb5fa-d46e-46be-a63f-2f7f5db9858d','',0,'2022-01-14 17:23:37','2022-02-27 18:02:31','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1,2,3,4,5,6,7,9,9,'nxtq12222222',11,12,13,14,14,16,'ntx233333333333',20,21,22,23,34,'ntx344444444444eee',31,32,33,34,35,'nxt45555555555',41,42,43,'aaaaaaaaaaaaaaarrrrrr','nxtq12222222','dddddddd','nxtq12222222',0),('bb327945-35cd-41c4-3dfd-08d9f9fd6613',NULL,1,'2022-02-27 21:28:18','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('bb3edeb0-0c63-4c0c-a4d1-08d9f9f9a7a4',NULL,0,'2022-02-27 21:03:24','2022-02-27 21:03:24','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('c09d01c8-5a9f-4f24-f832-08d9f9f8ef49',NULL,0,'2022-02-27 20:56:21','2022-02-27 20:56:21','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('c2b5f2f4-fe0b-4720-3e02-08d9f9fd6613',NULL,1,'2022-02-27 21:30:53','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('ce151f69-db68-4f5b-a4d5-08d9f9f9a7a4',NULL,1,'2022-02-27 21:07:30','2022-02-27 21:07:46','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('d3c3cc3c-f033-44cf-3138-08d9f9fe7447',NULL,0,'2022-02-27 21:43:45','2022-02-27 21:43:59','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',1),('d577958f-b347-4ed8-3139-08d9f9fe7447',NULL,0,'2022-02-27 21:43:48','2022-02-27 21:43:48','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('d9a3fbd7-14c1-42a8-3e00-08d9f9fd6613',NULL,1,'2022-02-27 21:30:53','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('e54843a6-120f-4778-a4d6-08d9f9f9a7a4',NULL,1,'2022-02-27 21:07:36','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('e70a83cd-8958-42dc-a4d7-08d9f9f9a7a4',NULL,1,'2022-02-27 21:07:40','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'aaaaaaa',5,5,5,5,5,5,'aaaaaaaaaaa',5,5,5,5,5,'aaaaaaaaaaaa',5,5,5,5,5,'aaaaaaaaa',5,5,5,'aaaaaaaaaaaaaaaaa','aaaaaaa',NULL,'aaaaaaa',0),('f09fdf49-3588-43d0-3e03-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 22:19:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,NULL,5,5,5,5,5,5,NULL,5,5,5,5,5,NULL,5,5,5,5,5,NULL,5,5,5,NULL,NULL,NULL,NULL,0),('f0f4224d-33cd-4ea9-3dff-08d9f9fd6613',NULL,1,'2022-02-27 21:30:47','2022-02-27 21:30:53','cb356d0b-b62b-4418-a295-b2b71393fba6',NULL,5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('f416dc40-281c-4281-3e0a-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('f6303e01-0223-475d-3e06-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('f7f71871-20c2-439d-3e07-08d9f9fd6613',NULL,0,'2022-02-27 21:31:02','2022-02-27 21:31:02','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0),('fd7d3b8e-9489-4485-3136-08d9f9fe7447',NULL,0,'2022-02-27 21:35:51','2022-02-27 21:35:51','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',5,5,5,5,5,5,5,5,5,'',5,5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,5,5,'',5,5,5,'','','','',0);
/*!40000 ALTER TABLE `survey_import_results` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-27 23:01:03
