-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-12-2021 a las 13:28:25
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
  `place` varchar(50) NOT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `images`
--

INSERT INTO `images` (`id`, `name`, `fileName`, `place`, `createdAt`, `updatedAt`) VALUES
(22, 'LaGraciosa1', 'graciosa1', 'La Graciosa', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(23, 'LaGraciosa2', 'graciosa2', 'La Graciosa', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(24, 'LaGraciosa3', 'graciosa3', 'La Graciosa', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(25, 'PlayaBlanca1', 'playablanca1', 'Playa Blanca', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(26, 'PlayaBlanca2', 'playablanca2', 'Playa Blanca', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(27, 'PlayaBlanca3', 'playablanca3', 'Playa Blanca', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(28, 'Timanfaya1', 'timanfaya1', 'National Park Timanfaya', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(29, 'Timanfaya2', 'timanfaya2', 'National Park Timanfaya', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(30, 'Timanfaya3', 'timanfaya3', 'National Park Timanfaya', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(31, 'Arrecife1', 'arrecife1', 'Arrecife', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(32, 'Arrecife2', 'arrecife2', 'Arrecife', '2021-12-10 18:54:19', '2021-12-10 18:54:19'),
(33, 'Arrecife3', 'arrecife3', 'Arrecife', '2021-12-10 18:54:19', '2021-12-10 18:54:19');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reviews`
--

CREATE TABLE `reviews` (
  `id` int(11) NOT NULL,
  `content` varchar(255) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `target` varchar(255) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `createdAt` datetime NOT NULL,
  `updatedAt` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `reviews`
--

INSERT INTO `reviews` (`id`, `content`, `username`, `target`, `userId`, `createdAt`, `updatedAt`) VALUES
(16, 'I really like this beach, it\'s the best one!', 'another1', 'Playa Blanca', NULL, '0001-01-01 01:01:36', '2021-12-10 16:57:32'),
(17, 'I went there with my parents the last week', 'another1', 'Playa Blanca', 13, '2021-12-10 16:57:00', '2021-12-10 16:57:00'),
(18, 'I would like to come there one day', 'another1', 'Arrecife', 13, '2021-12-10 16:58:10', '2021-12-10 16:58:10'),
(19, 'The water looks so shiny', 'another1', 'Arrecife', 13, '2021-12-10 16:58:20', '2021-12-10 16:58:20'),
(20, 'It looks so natural', 'another1', 'La Graciosa', 13, '2021-12-10 16:58:48', '2021-12-10 16:58:48'),
(21, 'Hope they don\'t build a big city there', 'another1', 'La Graciosa', 13, '2021-12-10 16:59:14', '2021-12-10 16:59:14'),
(22, 'If you travel to lanzarote, you should take that tour', 'another1', 'National Park Timanfaya', 13, '2021-12-10 17:00:11', '2021-12-10 17:00:11'),
(23, 'The volcanoes are amazing', 'another1', 'National Park Timanfaya', 13, '2021-12-10 17:00:34', '2021-12-10 17:00:34'),
(25, 'Not a bad place I guess', 'TheGamer', 'Arrecife', 21, '2021-12-10 19:16:56', '2021-12-10 19:16:56'),
(26, 'The restaurants are decent', 'TheGamer', 'Arrecife', 21, '2021-12-10 19:17:38', '2021-12-10 19:17:38'),
(27, 'Sadly there is a name on the floor', 'TheGamer', 'Playa Blanca', 21, '2021-12-10 19:18:20', '2021-12-10 19:18:20'),
(28, 'Those trees look nice', 'TheGamer', 'Playa Blanca', 21, '2021-12-10 19:19:18', '2021-12-10 19:19:18'),
(29, 'Hope the volcanoes don\'t wake up', 'TheGamer', 'National Park Timanfaya', 21, '2021-12-10 19:19:53', '2021-12-10 19:19:53'),
(30, 'Interesting place', 'TheGamer', 'National Park Timanfaya', 21, '2021-12-10 19:20:17', '2021-12-10 19:20:17'),
(31, 'Called \"La Graciosa\" but I don\'t see the funny part', 'TheGamer', 'La Graciosa', 21, '2021-12-10 19:20:58', '2021-12-10 19:20:58'),
(32, 'Praise the sun', 'TheGamer', 'La Graciosa', 21, '2021-12-10 19:21:31', '2021-12-10 19:21:31');

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
(3, 'example', 'example@gmail.com', NULL, '0001-01-01 01:01:36', '2021-11-23 16:12:26'),
(5, 'Ejemplo de mensaje largo, editar para ver completo porque no entra en la tabla', 'ibraime@gmail.com', NULL, '0001-01-01 01:01:36', '2021-11-10 19:09:56'),
(6, 'I have to write this again for a simple but punisher mistake, hope it works this time to send a message please.', 'admin@admin.com', 8, '2021-11-24 17:56:29', '2021-11-24 17:56:29'),
(10, 'Interesting project, not myself sure', 'asoret@email.com', 4, '2021-11-24 18:05:22', '2021-11-24 18:05:22'),
(11, 'Prueba2 mod', 'asoret@email.com', NULL, '0001-01-01 01:01:36', '2021-12-08 20:22:29'),
(14, 'Mensaje de prueba web', 'admin@admin.com', 8, '2021-11-26 01:48:46', '2021-11-26 01:48:46'),
(18, 'trial itch2', 'admin@admin.com', NULL, '0001-01-01 01:01:36', '2021-12-09 19:02:00'),
(20, 'New message 10/12', 'admin@admin.com', 8, '2021-12-10 16:44:36', '2021-12-10 16:44:36');

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
(8, 'admin', '$2a$10$t4l2emWW5YZHLGrDkc.jV.pvXbRqCgxUALadNtp.G037y4XU6ONjm', 'admin@admin.com', 1, 1, '0001-01-01 01:01:36', '2021-12-10 16:54:00'),
(13, 'another1', '$2a$10$VqVZkFWPUFvX6JMxyHAhmOIQ6fUlKwr30pCvdplOhyy/65dbkcgNi', 'another@gmail.com', 0, 0, '0001-01-01 01:01:36', '2021-12-09 17:24:12'),
(21, 'TheGamer', '$2a$10$gQm.v7Z4iOx9LHSQDLUnZOieSen/5WruPJAbgUHtuWOSpzGuxEURu', 'theGamer@hotmail.com', 1, 0, '0001-01-01 01:01:36', '2021-12-10 19:16:39');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT de la tabla `reviews`
--
ALTER TABLE `reviews`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT de la tabla `texts`
--
ALTER TABLE `texts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

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
