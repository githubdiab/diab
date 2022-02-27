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
-- Table structure for table `account_imports`
--

DROP TABLE IF EXISTS `account_imports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `account_imports` (
  `id` varchar(36) NOT NULL,
  `code` varchar(32) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `user_code` int NOT NULL,
  `user_name` varchar(50) NOT NULL,
  `user_gender` varchar(10) DEFAULT NULL,
  `user_yearofbirth` int NOT NULL,
  `user_career` varchar(50) NOT NULL,
  `user_phone` varchar(13) DEFAULT NULL,
  `user_hoobit` varchar(100) DEFAULT NULL,
  `user_address` varchar(100) NOT NULL,
  `user_province` varchar(50) NOT NULL,
  `story_success` varchar(1000) NOT NULL,
  `user_typeofsick` varchar(50) DEFAULT NULL,
  `year_foundout` int NOT NULL,
  `cover_id` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_account_imports_user_code` (`user_code`),
  UNIQUE KEY `ix_account_imports_code` (`code`),
  KEY `ix_account_imports_create_datetime` (`create_datetime`),
  KEY `ix_account_imports_update_datetime` (`update_datetime`),
  KEY `ix_account_imports_creator_id` (`creator_id`),
  KEY `ix_account_imports_updater_id` (`updater_id`),
  KEY `ix_account_imports_is_deleted` (`is_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account_imports`
--

LOCK TABLES `account_imports` WRITE;
/*!40000 ALTER TABLE `account_imports` DISABLE KEYS */;
INSERT INTO `account_imports` VALUES ('09503849-51e9-489d-8595-9b4f061c460f','0950384951e9489d85959b4f061c460f',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1132,'Lê Đình Thành Công 4','Nam',1950,'Hưu trí','0985678126','Du lịch','126 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('0f95d2f4-2f51-473a-7f6c-c1c792354545','0f95d2f42f51473a7f6cc1c792354545',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1149,'Lê Trần Công danh 21','Nam',1971,'Công nhân','0343842833','Xem phim','14 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip 2',2016,NULL),('1810c078-3175-982e-224e-25b9b6e203b4','1810c0783175982e224e25b9b6e203b4',0,'2022-01-14 17:23:37','2022-02-27 18:01:04','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1129,'Tran quoc huy','Nam',1991,'Hưu trí','0985678123','Du lịch','123 Phan Văn Trị, P10, quận Gò Vấp','Bà Rịa Vũng Tàu','Thay đổi lối sống','Tip1',1991,'76e49046-375f-410e-3bea-08d9f9e072c7'),('2575d6d1-3171-a2d7-a4ac-5eae64569084','2575d6d13171a2d7a4ac5eae64569084',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1151,'Lê Trần Công danh 23','Nam',1971,'Hưu trí','0343842833','Xem phim','14 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip 2',2016,NULL),('2b689bfd-3fd5-445b-46d3-79d4a69b64fe','2b689bfd3fd5445b46d379d4a69b64fe',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1152,'Lê Trần Công danh 24','Nam',1971,'Công nhân','0985678123','Du lịch','14 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip 2',2016,NULL),('2df8ccde-971f-3d10-1fc3-4dd2e74d180e','2df8ccde971f3d101fc34dd2e74d180e',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1130,'Lê Đình Thành Công 2','Nam',1950,'Hưu trí','0985678124','Du lịch','124 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('3ac3d065-0c9e-686f-1183-546aab6b8b66','3ac3d0650c9e686f1183546aab6b8b66',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1133,'Lê Đình Thành Công 5','Nam',1950,'Hưu trí','0985678127','Du lịch','127 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('50ed8372-1b9d-2129-0dda-a9eaa6cb5eb7','50ed83721b9d21290ddaa9eaa6cb5eb7',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1146,'Lê Trần Công danh 18','Nam',1950,'Hưu trí','0985678129','Du lịch','129 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi tư duy','Tip1',2018,NULL),('54c513e0-14aa-1953-5c32-a4cf3c7b7f8d','54c513e014aa19535c32a4cf3c7b7f8d',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1131,'Lê Đình Thành Công 3','Nam',1950,'Hưu trí','0985678125','Du lịch','125 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('5a8c075b-05e6-a503-91e9-e41e61516431','5a8c075b05e6a50391e9e41e61516431',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1134,'Lê Đình Thành Công 6','Nam',1950,'Hưu trí','0985678128','Du lịch','128 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('668c716c-1b31-239b-1bbb-23042d9c54d0','668c716c1b31239b1bbb23042d9c54d0',0,'2022-01-14 17:23:37','2022-02-27 22:19:43','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1140,'Lê Trần Công danh 12','Nam',1950,'Hưu trí','0985678123','Du lịch','123 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,'5464fbab-6b0f-427c-5408-08d9fa0494ed'),('6a989dbd-a10d-87db-214a-6171bddd56f6','6a989dbda10d87db214a6171bddd56f6',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1139,'Lê Trần Công danh 11','Nam',1971,'Công nhân','0343842833','Xem phim','14 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi lối sống','Tip 2',2016,NULL),('6fb32347-90a4-a1c4-401a-17339aaf15d4','6fb3234790a4a1c4401a17339aaf15d4',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1136,'Lê Trần Công danh 8','Nam',1971,'Công nhân','0343842832','Xem phim','12 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip 2',2016,NULL),('7f2c572c-6a3a-207b-a3b5-e0181ef50a92','7f2c572c6a3a207ba3b5e0181ef50a92',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1150,'Lê Trần Công danh 22','Nam',1971,'Công nhân','0343842833','Xem phim','14 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip 2',2016,NULL),('8cea4b79-31cd-8a9d-9311-736ebb5b50d2','8cea4b7931cd8a9d9311736ebb5b50d2',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1147,'Lê Trần Công danh 19','Nam',1971,'Công nhân','0343842832','Xem phim','12 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip 2',2016,NULL),('97bbc8f3-4404-4c62-76ea-3207386d61c2','97bbc8f344044c6276ea3207386d61c2',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1143,'Lê Trần Công danh 15','Nam',1950,'Hưu trí','0985678126','Du lịch','126 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('9a7e079c-9d14-a5d2-7ea1-3a2d8134884a','9a7e079c9d14a5d27ea13a2d8134884a',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1141,'Lê Trần Công danh 13','Nam',1950,'Hưu trí','0985678124','Du lịch','124 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('a1617443-4dce-1937-0568-bbea41db13df','a16174434dce19370568bbea41db13df',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1148,'Lê Trần Công danh 20','Nam',1971,'Công nhân','0343842833','Xem phim','13 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip2',2016,NULL),('a2a2c526-1991-1554-20d9-867ca05c204a','a2a2c5261991155420d9867ca05c204a',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1135,'Lê Đình Thành Công 7','Nam',1950,'Hưu trí','0985678129','Du lịch','129 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi tư duy','Tip1',2018,NULL),('b80c5057-44b3-834d-89ae-acba62c87fa6','b80c505744b3834d89aeacba62c87fa6',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1145,'Lê Trần Công danh 17','Nam',1950,'Hưu trí','0985678128','Du lịch','128 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi tư duy','Tip1',2018,NULL),('bd121a9a-442b-69e6-8bc3-d19ab6005d1f','bd121a9a442b69e68bc3d19ab6005d1f',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1138,'Lê Trần Công danh 10','Nam',1971,'Công nhân','0343842833','Xem phim','14 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip 2',2016,NULL),('c7c9b64f-0d0b-4a1f-a312-c36655577d7e','c7c9b64f0d0b4a1fa312c36655577d7e',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1142,'Lê Trần Công danh 14','Nam',1950,'Hưu trí','0985678125','Du lịch','125 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('cc05cb6c-9189-a03d-9b59-9492384264fd','cc05cb6c9189a03d9b599492384264fd',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1144,'Lê Trần Công danh 16','Nam',1950,'Hưu trí','0985678127','Du lịch','127 Phan Văn Trị, P10, quận Gò Vấp','Tp.HCM','Thay đổi lối sống','Tip1',2018,NULL),('d03e65b2-19d0-6273-50a7-4d30af782c35','d03e65b219d0627350a74d30af782c35',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6',1137,'Lê Trần Công danh 9','Nam',1971,'Công nhân','0343842833','Xem phim','13 Hai Bà Trưng, phường 6, quận 1','Tp.HCM','Thay đổi tư duy','Tip2',2016,NULL);
/*!40000 ALTER TABLE `account_imports` ENABLE KEYS */;
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
