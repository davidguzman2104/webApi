-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: data
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `items` (
  `id_item` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `foto` varchar(100) NOT NULL,
  `status` enum('disponible','prestado','ocupado') NOT NULL,
  `ubicacion` varchar(100) NOT NULL,
  `disponibilidad_entrega` varchar(200) NOT NULL,
  `num_control` int DEFAULT NULL,
  `nombre_alumno` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_item`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (2,'Cámara Canon','imagenes/camara.jpg','prestado','Laboratorio A','',20230002,NULL),(3,'Proyector Epson','images/cal.jpg','ocupado','Sala de juntas','10-12',20230003,NULL),(4,'Tablet Samsung','imagenes/tablet.jpg','disponible','Centro de cómputo','',20230004,NULL),(5,'Microscopio','microscopio.jpg','prestado','Laboratorio B','',20230005,NULL),(6,'Laptop HP','laptop.jpg','disponible','Biblioteca','',20230001,NULL),(7,'Cámara Canon','camara.jpg','prestado','Laboratorio A','',20230002,NULL),(8,'Proyector Epson','proyector.jpg','ocupado','Sala de juntas','',20230003,NULL),(9,'Tablet Samsung','tablet.jpg','disponible','Centro de cómputo','',20230004,NULL),(10,'Microscopio','microscopio.jpg','prestado','Laboratorio B','',20230005,NULL),(11,'Laptop HP','imagenes/laptop.jpg','disponible','Biblioteca','',20230001,NULL),(12,'Cámara Canon','camara.jpg','prestado','Laboratorio A','',20230002,NULL),(13,'Proyector Epson','proyector.jpg','ocupado','Sala de juntas','',20230003,NULL),(14,'Tablet Samsung','tablet.jpg','disponible','Centro de cómputo','',20230004,NULL),(15,'Jumpers','jump.jpg','prestado','Edifico X','Prestado',21200654,'Edgar Hernandez Mendoza'),(17,'Laptop Asus','images/laptop.jpg','disponible','Edificio B','Disponib',21200255,'DAVID FI'),(18,'impresora','imp.jpeg','disponible','Edificio Y','Disponib',22200788,'juan'),(19,'Cámara Canon','','prestado','Laboratorio A','9-10',21200255,'David'),(20,'libro','imagenes/libro.jpg','prestado','Edificio G','9-13',21200255,'David');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-26 19:10:58
