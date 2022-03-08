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
-- Table structure for table `survey_imports`
--

DROP TABLE IF EXISTS `survey_imports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `survey_imports` (
  `id` varchar(36) NOT NULL,
  `code` varchar(32) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `user_id` varchar(36) NOT NULL,
  `course_goal` varchar(1000) NOT NULL,
  `course_action` varchar(1000) NOT NULL,
  `course_final_rate` varchar(1000) NOT NULL,
  `participation_package` varchar(50) NOT NULL,
  `survey_type_code` varchar(20) NOT NULL,
  `survey_type` varchar(50) NOT NULL,
  `survey_day` date NOT NULL,
  `import_day` date NOT NULL,
  `survey_code` varchar(20) NOT NULL,
  `survey_name` varchar(100) NOT NULL,
  `survey_result_id` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_survey_imports_code` (`code`),
  KEY `ix_survey_imports_user_id` (`user_id`),
  KEY `ix_survey_imports_survey_result_id` (`survey_result_id`),
  KEY `ix_survey_imports_create_datetime` (`create_datetime`),
  KEY `ix_survey_imports_update_datetime` (`update_datetime`),
  KEY `ix_survey_imports_creator_id` (`creator_id`),
  KEY `ix_survey_imports_updater_id` (`updater_id`),
  KEY `ix_survey_imports_is_deleted` (`is_deleted`),
  CONSTRAINT `fk_survey_imports_account_imports_account_imports_id` FOREIGN KEY (`user_id`) REFERENCES `account_imports` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `fk_survey_imports_import_results_import_results_id` FOREIGN KEY (`survey_result_id`) REFERENCES `survey_import_results` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `survey_imports`
--

LOCK TABLES `survey_imports` WRITE;
/*!40000 ALTER TABLE `survey_imports` DISABLE KEYS */;
INSERT INTO `survey_imports` VALUES ('00e7531f-6d43-8651-17ba-6e3f004c39c4','00e7531f6d43865117ba6e3f004c39c4',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','668c716c-1b31-239b-1bbb-23042d9c54d0','Học hỏi à chính','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','#NAME?','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('0b6d3bfe-3785-85b8-61a3-5541b1bf591d','0b6d3bfe378585b861a35541b1bf591d',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','97bbc8f3-4404-4c62-76ea-3207386d61c2','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('12937d9f-4878-8895-898c-efa7d42672c2','12937d9f48788895898cefa7d42672c2',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','2575d6d1-3171-a2d7-a4ac-5eae64569084','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('166ac15b-02d0-27a1-0cac-8333e6a729ef','166ac15b02d027a10cac8333e6a729ef',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','a1617443-4dce-1937-0568-bbea41db13df','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('1b73cff7-514e-60c8-6436-322364848aa5','1b73cff7514e60c86436322364848aa5',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','bd121a9a-442b-69e6-8bc3-d19ab6005d1f','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('214557ad-4962-a656-3ed8-184576c0739c','214557ad4962a6563ed8184576c0739c',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','09503849-51e9-489d-8595-9b4f061c460f','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('2f27f5b5-241b-92d3-1e2f-fc8b5f7b3013','2f27f5b5241b92d31e2ffc8b5f7b3013',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','8cea4b79-31cd-8a9d-9311-736ebb5b50d2','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('313d05e1-1535-934a-5697-9b71b4659244','313d05e11535934a56979b71b4659244',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','2df8ccde-971f-3d10-1fc3-4dd2e74d180e','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('32ebe520-08ee-83a0-1721-9747a3be3b6d','32ebe52008ee83a017219747a3be3b6d',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','54c513e0-14aa-1953-5c32-a4cf3c7b7f8d','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('40217ef1-6e86-44b6-8239-7310b93d0f90','40217ef16e8644b682397310b93d0f90',0,'2022-01-14 17:23:37','2022-03-08 08:02:52','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','a2a2c526-1991-1554-20d9-867ca05c204a','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('482a281b-2c0f-1308-a1b9-3d7b428e7bf5','482a281b2c0f1308a1b93d7b428e7bf5',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','6a989dbd-a10d-87db-214a-6171bddd56f6','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('4e371517-413e-9a8f-0212-089b8d633fb1','4e371517413e9a8f0212089b8d633fb1',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','2b689bfd-3fd5-445b-46d3-79d4a69b64fe','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('584436e6-4049-1e04-513d-bd85749d106a','584436e640491e04513dbd85749d106a',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','5a8c075b-05e6-a503-91e9-e41e61516431','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('59fc7565-687c-0a89-368a-9b3f44da1f89','59fc7565687c0a89368a9b3f44da1f89',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','7f2c572c-6a3a-207b-a3b5-e0181ef50a92','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('60dd2c5d-4f0e-1fb1-a51f-8fce3ace9e25','60dd2c5d4f0e1fb1a51f8fce3ace9e25',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','c7c9b64f-0d0b-4a1f-a312-c36655577d7e','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('62f1df8b-140d-4621-0049-a2f3ce795af4','62f1df8b140d46210049a2f3ce795af4',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','6fb32347-90a4-a1c4-401a-17339aaf15d4','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('67e75c2c-1955-41bf-79fc-14b8c328733e','67e75c2c195541bf79fc14b8c328733e',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','1810c078-3175-982e-224e-25b9b6e203b4','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('6d0ef669-a55a-37b9-541b-5ee891dd6da3','6d0ef669a55a37b9541b5ee891dd6da3',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','b80c5057-44b3-834d-89ae-acba62c87fa6','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('91fc4f0d-3bd8-135d-5642-3ddf7211663f','91fc4f0d3bd8135d56423ddf7211663f',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','3ac3d065-0c9e-686f-1183-546aab6b8b66','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('9be0d3e2-5e8b-380a-5b8e-e80cffd0882f','9be0d3e25e8b380a5b8ee80cffd0882f',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','9a7e079c-9d14-a5d2-7ea1-3a2d8134884a','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('dfbbb7a2-2b17-a48a-0b1f-277dbe5345af','dfbbb7a22b17a48a0b1f277dbe5345af',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','d03e65b2-19d0-6273-50a7-4d30af782c35','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('e3625aba-6a16-8649-6e8d-0735f2ca2842','e3625aba6a1686496e8d0735f2ca2842',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','50ed8372-1b9d-2129-0dda-a9eaa6cb5eb7','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL),('e725d337-95d4-9cef-9cf0-fa9047a39b90','e725d33795d49cef9cf0fa9047a39b90',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','0f95d2f4-2f51-473a-7f6c-c1c792354545','Chữa bệnh tốt hơn','Dùng nhiều chất xơ','Thành viên năng động','Gói thấu cảm','ĐV.002','Khảo sát đầu vào','2021-12-12','2022-02-20','KS.002','Bộ câu hỏi KSĐV 2',NULL),('efa9ec4e-87c7-7d25-7dd5-647727715944','efa9ec4e87c77d257dd5647727715944',0,'2022-01-14 17:23:37','2022-03-08 07:40:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','cc05cb6c-9189-a03d-9b59-9492384264fd','Học hỏi','Duy trì thể dục sáng','Thành viên rất tích cực tương tác','Gói đồng hành','ĐV.001','Khảo sát đầu vào','2021-11-28','2022-02-20','KS.001','Bộ câu hỏi KSĐV 1',NULL);
/*!40000 ALTER TABLE `survey_imports` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-08  8:06:33
