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
  `hba1c_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `hba1c_phanloai` varchar(40) DEFAULT NULL,
  `bmi_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `bmi_phanloai` varchar(40) DEFAULT NULL,
  `kt_bl_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kt_tdcs_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kt_dd_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kt_vd_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kt_th_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kt_tlhv_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kt_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kt_phanloai` varchar(40) DEFAULT NULL,
  `kt_nxtq` text,
  `kntcs_ht_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kntcs_csbc_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kntcs_tddh_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kntcs_cdvd_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kntcs_cdau_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kntcs_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kntcs_phanloai` varchar(40) DEFAULT NULL,
  `kntcs_nxtq` text,
  `mdrc_dt_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `mdrc_tddh_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `mdrc_cdvd_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `mdrc_cdau_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `mdrc_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `mdrc_phanloai` varchar(40) DEFAULT NULL,
  `mdrc_nxtq` text,
  `kndctl_ctlqdbs_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kndctl_cttcmqh_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kndctl_gnvttdt_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kndctl_gncx_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kndctl_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `kndctl_phanloai` varchar(40) DEFAULT NULL,
  `kndctl_nxtq` text,
  `dltd_dltdbt_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `dltd_dltdbn_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `dltd_val` decimal(6,1) NOT NULL DEFAULT '0.0',
  `dltd_phanloai` varchar(40) DEFAULT NULL,
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

-- Dump completed on 2022-06-07 19:09:16
