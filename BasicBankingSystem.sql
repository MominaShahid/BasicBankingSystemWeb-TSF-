/*
SQLyog Community v13.1.6 (64 bit)
MySQL - 10.4.13-MariaDB : Database - basicbankingsystem
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`basicbankingsystem` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `basicbankingsystem`;

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `Cus_id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Current_Balance` int(11) DEFAULT NULL,
  PRIMARY KEY (`Cus_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

/*Data for the table `customer` */

insert  into `customer`(`Cus_id`,`Name`,`Email`,`Current_Balance`) values 
(1,'Momina','momina@gmail.com',555600),
(2,'Maha','maha@gmail.com',88),
(3,'Rimsha','rimsha@gmail.com',443320),
(4,'Kainat','kainat@gmail.com',109872),
(5,'Faiz','faiz@gmail.com',809099),
(6,'Ayesha','ayesha@gmail.com',205010),
(7,'Laiba','laiba@gmail.com',5000000),
(8,'Khizer','khizer@gmial.com',345500),
(9,'Faizan','faizan@gmail.com',991000),
(10,'Kamran','kamran@gmail.com',458090);

/*Table structure for table `transfer` */

DROP TABLE IF EXISTS `transfer`;

CREATE TABLE `transfer` (
  `Transfer_id` int(10) NOT NULL AUTO_INCREMENT,
  `Sender_id` int(20) DEFAULT NULL,
  `Receiver_id` int(20) DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL,
  `DateTime` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Transfer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

/*Data for the table `transfer` */

insert  into `transfer`(`Transfer_id`,`Sender_id`,`Receiver_id`,`Amount`,`DateTime`) values 
(1,1,2,100,'2021-08-21 01:35:20'),
(3,2,3,200,'2021-08-21 15:48:34'),
(4,1,3,250,'2021-08-21 15:55:44'),
(5,1,4,10,'2021-08-21 15:56:42'),
(6,2,1,100,'2021-08-21 16:15:49'),
(7,3,5,50,'2021-08-21 16:17:37'),
(8,1,2,100,'2021-08-21 16:18:29'),
(9,2,1,89,'2021-08-21 16:27:33'),
(10,6,7,205011,'2021-08-21 16:44:15');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
