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
-- Table structure for table `survey_range_values`
--

DROP TABLE IF EXISTS `survey_range_values`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `survey_range_values` (
  `id` varchar(36) NOT NULL,
  `code` varchar(32) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `create_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `creator_id` varchar(36) DEFAULT NULL,
  `updater_id` varchar(36) DEFAULT NULL,
  `category` varchar(40) NOT NULL,
  `sub_category` varchar(40) NOT NULL,
  `from_value` int NOT NULL,
  `to_value` int NOT NULL,
  `description` varchar(40) DEFAULT NULL,
  `message_to_customer` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_survey_range_value_category_sub_category` (`category`,`sub_category`,`from_value`,`to_value`),
  KEY `ix_survey_range_value_create_datetime` (`create_datetime`),
  KEY `ix_survey_range_value_update_datetime` (`update_datetime`),
  KEY `ix_survey_range_value_creator_id` (`creator_id`),
  KEY `ix_survey_range_value_updater_id` (`updater_id`),
  KEY `ix_survey_range_value_is_deleted` (`is_deleted`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `survey_range_values`
--

LOCK TABLES `survey_range_values` WRITE;
/*!40000 ALTER TABLE `survey_range_values` DISABLE KEYS */;
INSERT INTO `survey_range_values` VALUES ('020e3f3d-5275-4177-922e-152d5b5126ef','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','BMI','BMI',30,99999,'Béo phì độ 2','Bạn đang BMI_BMI_Béo phì độ 2'),('03267189-4d3d-72e2-3961-67c53c30720c','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Căng thẳng trong các mối quan hệ',0,3,'Ít stress hoặc không có','Bạn đang Khả năng điều chỉnh tâm lý_Căng thẳng trong các mối quan hệ_Ít stress hoặc không có'),('0ae4a96c-2974-5563-827b-005d721c5fa1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Mức độ rào cản',0,2,'Không bao giờ','Bạn đang Mức độ rào cản_Mức độ rào cản_Không bao giờ'),('0f38a46e-179a-152e-84a8-70ab74ec8f84','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','HbA1C','HbA1C',9,99999,'Rất cao','Bạn đang HbA1C_HbA1C_Rất cao'),('0fcd2063-7050-1312-443f-37bc0ed38a4b','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Gánh nặng cảm xúc',5,11,'Stress mức độ cao/nặng','Bạn đang Khả năng điều chỉnh tâm lý_Gánh nặng cảm xúc_Stress mức độ cao/nặng'),('13b513b5-8118-93aa-5426-62eb1dd44c2c','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Hút thuốc',1,2,'Có hút thuốc','Bạn đang Khả năng tự chăm sóc_Hút thuốc_Có hút thuốc'),('154e42d8-4f44-5672-6c1f-db7e0b0b71dc','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Dùng thuốc',7,9,'Thường xuyên','Bạn đang Mức độ rào cản_Dùng thuốc_Thường xuyên'),('18f0f3f7-530a-3a1d-98e2-7198f5e37ee1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Bệnh lý',9,11,'Kiến thức rất tốt','Bạn đang Kiến thức_Bệnh lý_Kiến thức rất tốt'),('19117391-17ba-8425-9346-84ee78fc8dbd','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Khả năng tự chăm sóc',0,5,'Tốt','Bạn đang Khả năng tự chăm sóc_Khả năng tự chăm sóc_Tốt'),('19c7cc62-53f3-4588-2e8d-a87d208d6c4a','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Động lực thay đổi','Động lực thay đổi bên ngoài',7,11,'Rất đúng','Bạn đang Động lực thay đổi_Động lực thay đổi bên ngoài_Rất đúng'),('1a68452b-6843-014a-2363-3ce736e8398a','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Gánh nặng cảm xúc',0,3,'Ít stress hoặc không có','Bạn đang Khả năng điều chỉnh tâm lý_Gánh nặng cảm xúc_Ít stress hoặc không có'),('218a24bf-7875-2be1-40e9-623155e67e3f','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ ăn uống',4,7,'Đôi khi','Bạn đang Mức độ rào cản_Chế độ ăn uống_Đôi khi'),('227a7275-1017-73a2-22e1-933249a05326','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ ăn uống',2,4,'Hiếm khi','Bạn đang Mức độ rào cản_Chế độ ăn uống_Hiếm khi'),('22d38be4-1cad-a2ee-2769-40443481444b','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Gánh nặng về tuân thủ điều trị',3,5,'Stress mức độ trung bình','Bạn đang Khả năng điều chỉnh tâm lý_Gánh nặng về tuân thủ điều trị_Stress mức độ trung bình'),('29d40b05-7891-9b67-8d76-8d87807d12eb','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chế độ ăn uống',0,1,'Cần cải tiến','Bạn đang Khả năng tự chăm sóc_Chế độ ăn uống_Cần cải tiến'),('2aac647e-7f6c-9d72-410e-6343933d1570','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chăm sóc bàn chân',5,11,'Rất tốt','Bạn đang Khả năng tự chăm sóc_Chăm sóc bàn chân_Rất tốt'),('2ac79b4d-7531-4ce2-255f-4871f13b9068','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Khả năng tự chăm sóc',5,11,'Rất tốt','Bạn đang Khả năng tự chăm sóc_Khả năng tự chăm sóc_Rất tốt'),('2f0c9451-0238-9da8-2753-9912da451ab2','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Gánh nặng về tuân thủ điều trị',5,11,'Stress mức độ cao/nặng','Bạn đang Khả năng điều chỉnh tâm lý_Gánh nặng về tuân thủ điều trị_Stress mức độ cao/nặng'),('32b9c1cf-3bce-62d1-2232-1cca45207b92','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Căng thẳng liên quan đến bác sĩ',3,5,'Stress mức độ trung bình','Bạn đang Khả năng điều chỉnh tâm lý_Căng thẳng liên quan đến bác sĩ_Stress mức độ trung bình'),('33b3bd20-8279-454d-0461-ca193c6286ed','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chế độ vận động',0,5,'Tốt','Bạn đang Khả năng tự chăm sóc_Chế độ vận động_Tốt'),('34688d30-141a-847a-389c-a4926a8f94ed','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chế độ ăn uống',5,11,'Rất tốt','Bạn đang Khả năng tự chăm sóc_Chế độ ăn uống_Rất tốt'),('352a28eb-5e41-1898-542b-21701c626f7f','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Gánh nặng về tuân thủ điều trị',0,3,'Ít stress hoặc không có','Bạn đang Khả năng điều chỉnh tâm lý_Gánh nặng về tuân thủ điều trị_Ít stress hoặc không có'),('3b3727b5-1d4c-1deb-7db0-047055aa0b9f','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Vận động',0,5,'Cần cũng cố kiến thức','Bạn đang Kiến thức_Vận động_Cần cũng cố kiến thức'),('3fc1e1f2-708b-a13b-a3a3-c55302208b7a','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Theo dõi chỉ số',8,11,'Kiến thức rất tốt','Bạn đang Kiến thức_Theo dõi chỉ số_Kiến thức rất tốt'),('41cf46f6-9a7b-4c69-01a2-9c7af52094f2','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tinh thần',8,11,'Kiến thức rất tốt','Bạn đang Kiến thức_Tinh thần_Kiến thức rất tốt'),('481e7855-897c-925d-3d4a-585d4fdb013d','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Động lực thay đổi','Động lực thay đổi bên ngoài',3,7,'Hơi đúng','Bạn đang Động lực thay đổi_Động lực thay đổi bên ngoài_Hơi đúng'),('49b8cc8a-80b9-222e-9490-09aa66930442','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','BMI','BMI',0,18,'Thiếu cân','Bạn đang BMI_BMI_Thiếu cân'),('4da54d8e-7eb8-3795-20b9-b54762e1177c','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chế độ ăn uống',0,5,'Tốt','Bạn đang Khả năng tự chăm sóc_Chế độ ăn uống_Tốt'),('5596253f-3399-4a06-2ad7-2847b790800a','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Động lực thay đổi','Động lực thay đổi bên trong',7,11,'Rất đúng','Bạn đang Động lực thay đổi_Động lực thay đổi bên trong_Rất đúng'),('55d81968-3b63-042e-97ff-049efdee2a08','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','BMI','BMI',25,30,'Béo phì độ 1','Bạn đang BMI_BMI_Béo phì độ 1'),('5c199979-6154-452a-78cf-2531b3446329','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chăm sóc bàn chân',0,5,'Tốt','Bạn đang Khả năng tự chăm sóc_Chăm sóc bàn chân_Tốt'),('5c6ea5e3-62c9-59eb-7464-365995e82d8f','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Mức độ rào cản',2,4,'Hiếm khi','Bạn đang Mức độ rào cản_Mức độ rào cản_Hiếm khi'),('627603f6-04ec-8155-7016-e71662a46eab','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','BMI','BMI',23,25,'Dự cân','Bạn đang BMI_BMI_Dự cân'),('65243121-1f01-a55f-0c18-3daa1e7333a7','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Khả năng tự chăm sóc',0,1,'Cần cải tiến','Bạn đang Khả năng tự chăm sóc_Khả năng tự chăm sóc_Cần cải tiến'),('6afd977e-47de-714b-8f02-fb54ecc15937','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','HbA1C','HbA1C',0,7,'Bình thường','Bạn đang HbA1C_HbA1C_Bình thường'),('6e13c759-48d2-8218-316b-71157f0b677e','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tâm lý hành vi',7,8,'Kiến thức khá tốt','Bạn đang Kiến thức_Tâm lý hành vi_Kiến thức khá tốt'),('6e184db0-89c6-4f29-1ec8-b491db9454f3','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Dùng thuốc',4,7,'Đôi khi','Bạn đang Mức độ rào cản_Dùng thuốc_Đôi khi'),('74690a0e-3147-5a8d-6f3d-f14e3c561bd5','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chế độ vận động',0,1,'Cần cải tiến','Bạn đang Khả năng tự chăm sóc_Chế độ vận động_Cần cải tiến'),('79621cd6-5fc2-21d1-2143-1399cf4d4d83','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Dinh dưỡng',0,5,'Cần cũng cố kiến thức','Bạn đang Kiến thức_Dinh dưỡng_Cần cũng cố kiến thức'),('83d9dcc7-427b-4dd1-8d71-333c35c431de','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chăm sóc bàn chân',0,1,'Cần cải tiến','Bạn đang Khả năng tự chăm sóc_Chăm sóc bàn chân_Cần cải tiến'),('8431c677-1208-9284-6442-dc7e667d8ef3','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Căng thẳng liên quan đến bác sĩ',5,11,'Stress mức độ cao/nặng','Bạn đang Khả năng điều chỉnh tâm lý_Căng thẳng liên quan đến bác sĩ_Stress mức độ cao/nặng'),('851600c7-5c35-8027-a7b3-b14a393a7e00','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tinh thần',5,7,'Kiến thức trung bình','Bạn đang Kiến thức_Tinh thần_Kiến thức trung bình'),('8745480f-3be9-9773-2b81-45a6d06d6122','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ vận động',2,4,'Hiếm khi','Bạn đang Mức độ rào cản_Chế độ vận động_Hiếm khi'),('879ac62b-4743-5292-a719-2cd18b3e94d1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Theo dõi chỉ số',7,8,'Kiến thức khá tốt','Bạn đang Kiến thức_Theo dõi chỉ số_Kiến thức khá tốt'),('8d133e7b-9a68-05d2-487b-cc2ea39a4298','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Kiến thức',0,5,'Cần cũng cố kiến thức','Bạn đang Kiến thức_Kiến thức_Cần cũng cố kiến thức'),('8f652c8f-88e8-1847-2fc6-be41547e4e32','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Dinh dưỡng',5,7,'Kiến thức trung bình','Bạn đang Kiến thức_Dinh dưỡng_Kiến thức trung bình'),('915d11b9-4fd2-0589-08cb-21ffbe504d0e','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Chế độ vận động',5,11,'Rất tốt','Bạn đang Khả năng tự chăm sóc_Chế độ vận động_Rất tốt'),('93d19a76-3901-0b41-3779-b6ae4e640f91','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Theo dõi đường huyết',0,5,'Tốt','Bạn đang Khả năng tự chăm sóc_Theo dõi đường huyết_Tốt'),('96fb4343-4cdc-16b4-9f08-0af4648625f5','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Dùng thuốc',9,11,'Luôn luôn','Bạn đang Mức độ rào cản_Dùng thuốc_Luôn luôn'),('9aa7b278-81b1-69e7-2fdc-c86ffc7523e3','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ vận động',9,11,'Luôn luôn','Bạn đang Mức độ rào cản_Chế độ vận động_Luôn luôn'),('9d43f512-5fce-6b09-7058-2b3a82cf1625','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Căng thẳng trong các mối quan hệ',5,11,'Stress mức độ cao/nặng','Bạn đang Khả năng điều chỉnh tâm lý_Căng thẳng trong các mối quan hệ_Stress mức độ cao/nặng'),('9f99c04f-22b3-51a7-4e7e-881b971118c2','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Động lực thay đổi','Động lực thay đổi bên ngoài',0,3,'Hoàn toàn không đúng','Bạn đang Động lực thay đổi_Động lực thay đổi bên ngoài_Hoàn toàn không đúng'),('a203ba6d-8783-385b-22f7-747fdad80604','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Mức độ rào cản',9,11,'Luôn luôn','Bạn đang Mức độ rào cản_Mức độ rào cản_Luôn luôn'),('a31fd4e8-7d6a-0e10-8dbc-cb3a1e5e85b7','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Đường huyết',9,11,'Luôn luôn','Bạn đang Mức độ rào cản_Đường huyết_Luôn luôn'),('a4572c3a-394a-2978-1ee4-cb0d3c3c14aa','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tâm lý hành vi',5,7,'Kiến thức trung bình','Bạn đang Kiến thức_Tâm lý hành vi_Kiến thức trung bình'),('a488a112-054d-317b-86a5-b5442a3043bb','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Dùng thuốc',2,4,'Hiếm khi','Bạn đang Mức độ rào cản_Dùng thuốc_Hiếm khi'),('a68a59ee-4597-2130-403b-b13947c07e1f','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Kiến thức',5,7,'Kiến thức trung bình','Bạn đang Kiến thức_Kiến thức_Kiến thức trung bình'),('a841b123-440d-1851-8da6-e6d1acf17175','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Mức độ rào cản',7,9,'Thường xuyên','Bạn đang Mức độ rào cản_Mức độ rào cản_Thường xuyên'),('aa85239a-514b-72b7-30bf-fbece6028bf0','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tâm lý hành vi',0,5,'Cần cũng cố kiến thức','Bạn đang Kiến thức_Tâm lý hành vi_Cần cũng cố kiến thức'),('ae459d30-4153-76b9-21b9-b3c0094d1d49','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Dinh dưỡng',8,11,'Kiến thức rất tốt','Bạn đang Kiến thức_Dinh dưỡng_Kiến thức rất tốt'),('b0e56383-41b7-762f-007c-d33a7f8a2551','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tinh thần',7,8,'Kiến thức khá tốt','Bạn đang Kiến thức_Tinh thần_Kiến thức khá tốt'),('b1b0a48f-2f58-538c-183c-87e181f52d36','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Vận động',8,11,'Kiến thức rất tốt','Bạn đang Kiến thức_Vận động_Kiến thức rất tốt'),('b1b36ca5-07dc-2c05-43b9-ee69f43f680d','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ vận động',7,9,'Thường xuyên','Bạn đang Mức độ rào cản_Chế độ vận động_Thường xuyên'),('b3341bbe-63d0-4954-09ec-31585306a1a4','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Căng thẳng liên quan đến bác sĩ',0,3,'Ít stress hoặc không có','Bạn đang Khả năng điều chỉnh tâm lý_Căng thẳng liên quan đến bác sĩ_Ít stress hoặc không có'),('b48f4d5f-00b1-a6cc-8f12-1f033cc0422b','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Vận động',7,8,'Kiến thức khá tốt','Bạn đang Kiến thức_Vận động_Kiến thức khá tốt'),('b592359d-480d-a2e8-15b8-49ae1dfb3d50','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Kiến thức',7,8,'Kiến thức khá tốt','Bạn đang Kiến thức_Kiến thức_Kiến thức khá tốt'),('b7e5f9e8-180d-7501-91ef-4d78d18a9ca1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Khả năng điều chỉnh tâm lý',5,11,'Stress mức độ cao/nặng','Bạn đang Khả năng điều chỉnh tâm lý_Khả năng điều chỉnh tâm lý_Stress mức độ cao/nặng'),('b80ad30f-a6e4-7b3d-a1d2-b5b377a97b85','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Đường huyết',7,9,'Thường xuyên','Bạn đang Mức độ rào cản_Đường huyết_Thường xuyên'),('b9725ed2-40d0-8ff5-13ae-edd5cfcc1bb1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Vận động',5,7,'Kiến thức trung bình','Bạn đang Kiến thức_Vận động_Kiến thức trung bình'),('bade1168-2425-a411-107a-90a38c4406e1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tinh thần',0,5,'Cần cũng cố kiến thức','Bạn đang Kiến thức_Tinh thần_Cần cũng cố kiến thức'),('bc5de2b0-8e80-1b84-8dcc-85e39c28a719','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Dinh dưỡng',7,8,'Kiến thức khá tốt','Bạn đang Kiến thức_Dinh dưỡng_Kiến thức khá tốt'),('bcbc780f-2d5e-5586-1a94-898744cc4729','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Đường huyết',2,4,'Hiếm khi','Bạn đang Mức độ rào cản_Đường huyết_Hiếm khi'),('bd32ff47-a5a7-75b4-1bdc-bfe85cd4289f','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Đường huyết',0,2,'Không bao giờ','Bạn đang Mức độ rào cản_Đường huyết_Không bao giờ'),('c690a388-1dd9-7dbc-3750-d4e110485701','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Hút thuốc',0,1,'Không hút thuốc','Bạn đang Khả năng tự chăm sóc_Hút thuốc_Không hút thuốc'),('c791bebb-8d33-3190-2405-68b535f63a0c','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Bệnh lý',7,8,'Kiến thức khá tốt','Bạn đang Kiến thức_Bệnh lý_Kiến thức khá tốt'),('cfbc3930-7979-693b-3537-b755b68d50c6','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ ăn uống',9,11,'Luôn luôn','Bạn đang Mức độ rào cản_Chế độ ăn uống_Luôn luôn'),('d1cbf8d5-90a7-0317-409b-fd5d88e1864e','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Đường huyết',4,7,'Đôi khi','Bạn đang Mức độ rào cản_Đường huyết_Đôi khi'),('d34414ea-5bc0-3d06-5374-915032116ebc','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','HbA1C','HbA1C',8,9,'Cao','Bạn đang HbA1C_HbA1C_Cao'),('d427ca0d-8953-9a3e-1261-11f3512a4d45','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Dùng thuốc',0,2,'Không bao giờ','Bạn đang Mức độ rào cản_Dùng thuốc_Không bao giờ'),('d5c2400d-1f55-6e84-13bd-752165868a28','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ vận động',4,7,'Đôi khi','Bạn đang Mức độ rào cản_Chế độ vận động_Đôi khi'),('dafaa02b-7eb0-a3ba-7f37-9ecad49a41c1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Mức độ rào cản',4,7,'Đôi khi','Bạn đang Mức độ rào cản_Mức độ rào cản_Đôi khi'),('dd517392-62dc-284e-6c69-d2856e8f6d44','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ ăn uống',7,9,'Thường xuyên','Bạn đang Mức độ rào cản_Chế độ ăn uống_Thường xuyên'),('ddd94182-02dc-1d16-a4ba-7dcd20ad8116','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Tâm lý hành vi',8,11,'Kiến thức rất tốt','Bạn đang Kiến thức_Tâm lý hành vi_Kiến thức rất tốt'),('de3a135a-1277-0080-7255-096ebbf608a7','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Theo dõi đường huyết',5,11,'Rất tốt','Bạn đang Khả năng tự chăm sóc_Theo dõi đường huyết_Rất tốt'),('df0486c5-9982-77a5-819d-62c3ffcfa167','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ ăn uống',0,2,'Không bao giờ','Bạn đang Mức độ rào cản_Chế độ ăn uống_Không bao giờ'),('e214764d-3cdd-10bc-2b17-7a6d0e440e89','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Mức độ rào cản','Chế độ vận động',0,2,'Không bao giờ','Bạn đang Mức độ rào cản_Chế độ vận động_Không bao giờ'),('e4978185-6345-213f-a01f-ee1c82f79069','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Kiến thức',8,11,'Kiến thức rất tốt','Bạn đang Kiến thức_Kiến thức_Kiến thức rất tốt'),('e52bc7bb-65bd-41ba-7dff-584d69b97eba','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Căng thẳng trong các mối quan hệ',3,5,'Stress mức độ trung bình','Bạn đang Khả năng điều chỉnh tâm lý_Căng thẳng trong các mối quan hệ_Stress mức độ trung bình'),('e95870bc-45a7-1408-47ec-88b2bd9ca57c','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng tự chăm sóc','Theo dõi đường huyết',0,1,'Cần cải tiến','Bạn đang Khả năng tự chăm sóc_Theo dõi đường huyết_Cần cải tiến'),('efa65b82-a314-5ba4-080e-2a2516967df8','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Gánh nặng cảm xúc',3,5,'Stress mức độ trung bình','Bạn đang Khả năng điều chỉnh tâm lý_Gánh nặng cảm xúc_Stress mức độ trung bình'),('f08ab1c1-5b59-799f-a106-35f2b6a2198e','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Bệnh lý',5,7,'Kiến thức trung bình','Bạn đang Kiến thức_Bệnh lý_Kiến thức trung bình'),('f135f84c-3561-6c4e-63fe-6538cd9838ee','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Khả năng điều chỉnh tâm lý',3,5,'Stress mức độ trung bình','Bạn đang Khả năng điều chỉnh tâm lý_Khả năng điều chỉnh tâm lý_Stress mức độ trung bình'),('f3ae146b-1fa9-5b2a-0532-34df54dba1bd','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Động lực thay đổi','Động lực thay đổi bên trong',0,3,'Hoàn toàn không đúng','Bạn đang Động lực thay đổi_Động lực thay đổi bên trong_Hoàn toàn không đúng'),('f49bd974-237b-9c98-7764-c79ef0c688c1','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Bệnh lý',0,5,'Cần cũng cố kiến thức','Bạn đang Kiến thức_Bệnh lý_Cần cũng cố kiến thức'),('f4d8dff2-47bb-876a-0b9c-4372f57281f5','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','BMI','BMI',18,23,'Bình thường','Bạn đang BMI_BMI_Bình thường'),('f8a50064-58b9-8974-0fe8-6e4549a7801a','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Theo dõi chỉ số',0,5,'Cần cũng cố kiến thức','Bạn đang Kiến thức_Theo dõi chỉ số_Cần cũng cố kiến thức'),('f918daff-7750-29fd-0437-36744f997a32','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Động lực thay đổi','Động lực thay đổi bên trong',3,7,'Hơi đúng','Bạn đang Động lực thay đổi_Động lực thay đổi bên trong_Hơi đúng'),('f931e18e-a581-6bc9-955f-e39749e0261c','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','HbA1C','HbA1C',7,8,'Khá cao','Bạn đang HbA1C_HbA1C_Khá cao'),('fcdd0c03-86a7-8205-151f-79e9bcdda086','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Kiến thức','Theo dõi chỉ số',5,7,'Kiến thức trung bình','Bạn đang Kiến thức_Theo dõi chỉ số_Kiến thức trung bình'),('fda6459d-0107-4b0b-8f96-d55293f862f6','',0,'2022-01-14 17:23:37','2022-01-14 17:23:37','cb356d0b-b62b-4418-a295-b2b71393fba6','cb356d0b-b62b-4418-a295-b2b71393fba6','Khả năng điều chỉnh tâm lý','Khả năng điều chỉnh tâm lý',0,3,'Ít stress hoặc không có','Bạn đang Khả năng điều chỉnh tâm lý_Khả năng điều chỉnh tâm lý_Ít stress hoặc không có');
/*!40000 ALTER TABLE `survey_range_values` ENABLE KEYS */;
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