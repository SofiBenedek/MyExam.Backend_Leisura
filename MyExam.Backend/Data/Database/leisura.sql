-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Már 03. 11:12
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `leisura`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `leisura_card`
--

CREATE TABLE `leisura_card` (
  `id` int(2) NOT NULL,
  `employee_name` varchar(12) DEFAULT NULL,
  `is_male` varchar(5) DEFAULT NULL,
  `transaction_date` date(10) DEFAULT NULL,
  `amount_huf` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `leisura_card`
--

INSERT INTO `leisura_card` (`id`, `employee_name`, `is_male`, `transaction_date`, `amount_huf`) VALUES
(1, 'Kiss Gábor', 'True', '2025-09-01', 25000),
(2, 'Nagy Anna', 'False', '2025-09-01', 18000),
(3, 'Szabó László', 'True', '2025-09-02', -6500),
(4, 'Tóth Eszter', 'False', '2025-09-02', 22000),
(5, 'Varga Péter', 'True', '2025-09-03', 30000),
(6, 'Kovács Dóra', 'False', '2025-09-03', -8200),
(7, 'Kiss Gábor', 'True', '2025-09-04', -4200),
(8, 'Nagy Anna', 'False', '2025-09-04', 18000),
(9, 'Szabó László', 'True', '2025-09-05', 25000),
(10, 'Tóth Eszter', 'False', '2025-09-05', -11000),
(11, 'Varga Péter', 'True', '2025-09-06', -5600),
(12, 'Kovács Dóra', 'False', '2025-09-06', 20000),
(13, 'Kiss Gábor', 'True', '2025-09-07', 25000),
(14, 'Nagy Anna', 'False', '2025-09-08', -7400),
(15, 'Szabó László', 'True', '2025-09-08', 18000),
(16, 'Tóth Eszter', 'False', '2025-09-09', 22000),
(17, 'Varga Péter', 'True', '2025-09-10', -12000),
(18, 'Kovács Dóra', 'False', '2025-09-10', 20000),
(19, 'Kiss Gábor', 'True', '2025-09-11', -3500),
(20, 'Nagy Anna', 'False', '2025-09-12', 18000),
(21, 'Szabó László', 'True', '2025-09-12', -9100),
(22, 'Tóth Eszter', 'False', '2025-09-13', 22000),
(23, 'Varga Péter', 'True', '2025-09-14', 30000),
(24, 'Kovács Dóra', 'False', '2025-09-14', -6000),
(25, 'Kiss Gábor', 'True', '2025-09-15', 25000),
(26, 'Nagy Anna', 'False', '2025-09-16', -9800),
(27, 'Szabó László', 'True', '2025-09-16', 18000),
(28, 'Tóth Eszter', 'False', '2025-09-17', -4300),
(29, 'Varga Péter', 'True', '2025-09-18', 30000),
(30, 'Kovács Dóra', 'False', '2025-09-18', 20000),
(31, 'Kiss Gábor', 'True', '2025-09-19', -15000),
(32, 'Nagy Anna', 'False', '2025-09-20', 18000),
(33, 'Szabó László', 'True', '2025-09-20', -5200),
(34, 'Tóth Eszter', 'False', '2025-09-21', 22000),
(35, 'Varga Péter', 'True', '2025-09-22', -7600),
(36, 'Kovács Dóra', 'False', '2025-09-22', 20000),
(37, 'Kiss Gábor', 'True', '2025-09-23', 25000),
(38, 'Nagy Anna', 'False', '2025-09-24', -3300),
(39, 'Szabó László', 'True', '2025-09-24', 18000),
(40, 'Tóth Eszter', 'False', '2025-09-25', -8900),
(41, 'Varga Péter', 'True', '2025-09-26', 30000),
(42, 'Kovács Dóra', 'False', '2025-09-27', -4700),
(43, 'Kiss Gábor', 'True', '2025-09-28', -6200),
(44, 'Nagy Anna', 'False', '2025-09-30', 18000);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `leisura_card`
--
ALTER TABLE `leisura_card`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
