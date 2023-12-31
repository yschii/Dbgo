CREATE DATABASE  IF NOT EXISTS `asdf` 
USE `asdf`;

DROP TABLE IF EXISTS `member`;

CREATE TABLE `member` (
  `id` int NOT NULL,
  `nuid` varchar(50) NOT NULL,
  `name` varchar(20) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` mediumtext,
  `enroll` datetime DEFAULT NULL,
  `fix` datetime DEFAULT NULL,
  `psw` varchar(255) NOT NULL DEFAULT '0000',
  `point` int NOT NULL DEFAULT '0',
  `reset` varchar(255) DEFAULT '0000',
  `adminName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nuid` (`nuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3 COMMENT='card';

INSERT INTO `member` VALUES (1,'60de15be',NULL,NULL,NULL,'2023-07-04 16:23:55',NULL,'0000',0,'0',NULL),(2,'b0042abe',NULL,NULL,NULL,'2023-07-04 16:24:32',NULL,'0000',1000,'0',NULL),(3,'800419be',NULL,NULL,NULL,'2023-07-04 16:25:20',NULL,'0000',1000,'0',NULL),(4,'30dc0ebe',NULL,NULL,NULL,'2023-07-04 16:25:25',NULL,'0000',0,'0',NULL),(5,'f0870fbe',NULL,NULL,NULL,'2023-07-04 16:25:38',NULL,'0000',0,'0',NULL),(6,'703a24be',NULL,NULL,NULL,'2023-07-04 16:26:19',NULL,'0000',0,'0',NULL),(7,'809c18be',NULL,NULL,NULL,'2023-07-04 16:26:53',NULL,'0000',0,'0',NULL),(8,'50b411be',NULL,NULL,NULL,'2023-07-04 16:27:29',NULL,'0000',0,'0',NULL),(9,'f0d613be',NULL,NULL,NULL,'2023-07-04 16:28:28',NULL,'0000',1000,'0',NULL),(10,'20621bbe',NULL,NULL,NULL,'2023-07-04 16:29:12',NULL,'0000',2000,'0',NULL),(11,'a04815be',NULL,NULL,NULL,'2023-07-04 16:29:29',NULL,'0000',1000,'0',NULL),(12,'c05b11be',NULL,NULL,NULL,'2023-07-04 16:30:03',NULL,'0000',0,'0',NULL),(13,'a3e73efc','CYS','010********','Hangul NO','2023-07-04 16:30:32','2023-08-23 13:40:51','$2y$10$9v9yI4RiF27yOAYtgVCFi.MxVIPV8CY/G5FzwCUFmRNVe0l1992f6',33002,'$2y$10$9v9yI4RiF27yOAYtgVCFi.MxVIPV8CY/G5FzwCUFmRNVe0l1992f6','CYS'),(14,'c0ee5f10','Polytech','01000000000','Polytech','2023-07-04 16:31:45','2023-07-31 14:50:22','$2y$10$AV6NL2BjXjI418GtPFCmSu39cjsB70V03jzxiRDdYfpN.a4nSx4mW',3000,'$2y$10$AV6NL2BjXjI418GtPFCmSu39cjsB70V03jzxiRDdYfpN.a4nSx4mW','Polytech');
