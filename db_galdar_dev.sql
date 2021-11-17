-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-11-2021 a las 18:47:29
-- Versión del servidor: 10.4.19-MariaDB
-- Versión de PHP: 8.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `db_galdar_dev`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `images`
--

CREATE TABLE `images` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `fileName` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `images`
--

INSERT INTO `images` (`id`, `name`, `fileName`, `description`, `createdAt`, `updatedAt`) VALUES
(1, 'Solar Panel', 'Solar Panel.jpg', 'Sun energy', '2021-10-31 16:14:15', '2021-10-31 16:14:15'),
(2, 'Wind Turbine', 'Wind Turbine.jpg', 'Wind power', '0001-01-01 01:01:36', '2021-11-03 15:23:26'),
(3, 'The big opening', 'The big opening.jpg', 'Where all started', '2021-10-31 16:30:15', '2021-10-31 16:30:15'),
(4, 'Our Builds', 'Our_Builds.jpg', 'Clean and smooth', '0001-01-01 01:01:36', '2021-11-03 16:02:51'),
(14, 'Example1', 'Example.jpg', 'It\'s an example, what if I write a lot', '0001-01-01 01:01:36', '2021-11-05 15:34:13'),
(18, '3', '3', '3', '0001-01-01 01:01:36', '2021-11-15 15:34:05');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reviews`
--

CREATE TABLE `reviews` (
  `id` int(11) NOT NULL,
  `content` varchar(255) DEFAULT NULL,
  `mail` varchar(255) DEFAULT NULL,
  `target` varchar(255) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `texts`
--

CREATE TABLE `texts` (
  `id` int(11) NOT NULL,
  `content` varchar(255) DEFAULT NULL,
  `mail` varchar(255) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `texts`
--

INSERT INTO `texts` (`id`, `content`, `mail`, `userId`, `createdAt`, `updatedAt`) VALUES
(3, 'aaa', 'aaa', NULL, '2021-11-10 17:29:58', '2021-11-10 17:29:58'),
(5, 'Ejemplo de mensaje largo, editar para ver completo porque no entra en la tabla', 'ibraime@gmail.com', NULL, '0001-01-01 01:01:36', '2021-11-10 19:09:56');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `mail` varchar(255) DEFAULT NULL,
  `darkmode` tinyint(1) DEFAULT NULL,
  `isAdmin` tinyint(1) DEFAULT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `mail`, `darkmode`, `isAdmin`, `createdAt`, `updatedAt`) VALUES
(4, 'asoret', '$2a$10$OO2gCH221AqaGEaW/8Bk/u0czFBa9zyLyUABUje2O.APCTcdcTicS', 'asoret@email.com', 0, 1, '2021-10-21 15:21:03', '2021-10-21 15:21:03'),
(7, 'example', '$2a$10$YPrFQmW3JFyf8cXFW4pveO.L0H16jp.829S1zV/bYnluS1dp6HEnu', 'example@gmail.com', 0, 0, '2021-11-17 17:30:21', '2021-11-17 17:30:21');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `images`
--
ALTER TABLE `images`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `reviews`
--
ALTER TABLE `reviews`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_userIdRev` (`userId`);

--
-- Indices de la tabla `texts`
--
ALTER TABLE `texts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_userId` (`userId`);

--
-- Indices de la tabla `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `images`
--
ALTER TABLE `images`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `reviews`
--
ALTER TABLE `reviews`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `texts`
--
ALTER TABLE `texts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `reviews`
--
ALTER TABLE `reviews`
  ADD CONSTRAINT `fk_userIdRev` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `texts`
--
ALTER TABLE `texts`
  ADD CONSTRAINT `FK_CONSTRAINTuserId` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_IdUser` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_userId` FOREIGN KEY (`userId`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `texts_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
