-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Wersja serwera:               5.5.21-log - MySQL Community Server (GPL)
-- Serwer OS:                    Win32
-- HeidiSQL Wersja:              11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Zrzut struktury bazy danych pumox
CREATE DATABASE IF NOT EXISTS `pumox` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `pumox`;

-- Zrzut struktury tabela pumox.companies
CREATE TABLE IF NOT EXISTS `companies` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4,
  `EstablishmentYear` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Eksport danych został odznaczony.

-- Zrzut struktury tabela pumox.employees
CREATE TABLE IF NOT EXISTS `employees` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `CompanyId` bigint(20) NOT NULL,
  `FirstName` longtext CHARACTER SET utf8mb4,
  `LastName` longtext CHARACTER SET utf8mb4,
  `DateOfBirth` datetime NOT NULL,
  `JobTitle` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Employees_Companies_CompanyId` (`CompanyId`),
  CONSTRAINT `FK_Employees_Companies_CompanyId` FOREIGN KEY (`CompanyId`) REFERENCES `companies` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Eksport danych został odznaczony.

-- Zrzut struktury tabela pumox.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Eksport danych został odznaczony.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
