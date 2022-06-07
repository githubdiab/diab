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
-- Table structure for table `survey_import_change_numbers`
--

DROP TABLE IF EXISTS `survey_import_change_numbers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `survey_import_change_numbers` (
  `category_code` varchar(50) NOT NULL,
  `convert_number_range` varchar(50) NOT NULL,
  `description_answer` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `survey_import_change_numbers`
--

LOCK TABLES `survey_import_change_numbers` WRITE;
/*!40000 ALTER TABLE `survey_import_change_numbers` DISABLE KEYS */;
INSERT INTO `survey_import_change_numbers` VALUES ('TL','1','Không phải vấn đề'),('TL','2','Chỉ có chút vấn đề'),('TL','3','Bình thường'),('TL','4','Vấn đề hơi nghiêm trọng'),('TL','5','Vấn đề nghiêm trọng'),('TL','6','Vấn đề rất nghiêm trọng'),('RS','1','Luôn luôn'),('RS','2','Thường xuyên'),('RS','3','Đôi khi'),('RS','4','Hiếm khi'),('RS','5','Không bao giờ'),('DL','1','Hoàn toàn không đúng'),('DL','2','Không đúng'),('DL','3','Không đúng lắm'),('DL','4','Không biết'),('DL','5','Hơi đúng'),('DL','6','Rất Đúng'),('DL','7','Hoàn toàn đúng');
/*!40000 ALTER TABLE `survey_import_change_numbers` ENABLE KEYS */;
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
