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
-- Table structure for table `alumnos`
--

DROP TABLE IF EXISTS `alumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumnos` (
  `num_control` int NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellido_paterno` varchar(100) DEFAULT NULL,
  `apellido_materno` varchar(100) DEFAULT NULL,
  `usuario` varchar(10) NOT NULL,
  `contraseña` varchar(50) NOT NULL,
  `carrera` varchar(100) NOT NULL,
  `ubicacion_alumno` varchar(100) NOT NULL,
  `mail` varchar(100) NOT NULL,
  `foto` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumnos`
--

LOCK TABLES `alumnos` WRITE;
/*!40000 ALTER TABLE `alumnos` DISABLE KEYS */;
INSERT INTO `alumnos` VALUES (20230001,'Luis','Martínez','Sánchez','lmartinez','pass123','Ingeniería en Sistemas','','luis@example.com','luis.jpg'),(20230002,'Ana','Gómez','Pérez','agomez','pass456','Ingeniería Industrial','','ana@example.com','ana.jpg'),(20230003,'Carlos','Ramírez','López','cramirez','pass789','Arquitectura','','carlos@example.com','carlos.jpg'),(20230004,'María','Fernández','Díaz','mfernandez','pass101','Contaduría','','maria@example.com','maria.jpg'),(20230005,'José','Hernández','Morales','jhernandez','pass202','Derecho','','jose@example.com','jose.jpg'),(21200654,'Edgar','Hernandez','Mendoza','HM','123','Edificio Y','ITCS','edgarhdzm@gmail.com','imagenes/16.png'),(21200255,'DAVID FIDEL','Guzman','Sanchez','Sman','123','IELEC','Edificio X','Danno3028@gmail.com','imagenes/16.jpeg'),(12345,'Juan','Pérez','López','juanp','miClave123','Ciudad XYZ','Ingeniería','juan@example.com','foto.jpg'),(22200788,'Juan Felipe','Ortega','Olvera','Juanito','1234','Edificio Y','ITIC','hola@gmail.com','imagenes/2.jpg'),(21200667,'carmen','covadonga','trejo','Carmen','1234','ITIC','Edificio Y','holis@gmail.com','imagenes/3.jpg'),(21200258,'alberto','Castillo','Olvera','cast','1234','Edificio Y','IMEC','holis@gmail.com','');
/*!40000 ALTER TABLE `alumnos` ENABLE KEYS */;
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
